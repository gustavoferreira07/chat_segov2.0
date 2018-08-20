using chat_segov.Controlador;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov.Telas
{
    public partial class tela_mensagens : MetroForm
    {
        public tela_mensagens()
        {
            InitializeComponent();
            timer1.Start();
        }
        string msg;
        string msg2;
        Conexao conexao = new Conexao();
        string remet;
        tela_chat_grupo tela = new tela_chat_grupo();
        Image vimagem1;

        private void tela_mensagens_Load(object sender, EventArgs e)
        {
            ListarUsuario();
            ListarGrupo();       
        }

        public void ListarUsuario()
        {
            listView1.Items.Clear();
            MySqlCommand cm = new MySqlCommand("select * from tb_conversa where  destinatario=@destinatario  or remetente = @destinatario and lido = 'n'", conexao.ConectarBD());          
            cm.Parameters.Add("@destinatario", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
            MySqlDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
                remet = dr[1].ToString();
                if (remet == Variaveis_globais.usuario)
                {
                    ListViewItem item = new ListViewItem(dr["destinatario"].ToString());
                    listView1.Items.Add(item);
                }
                else if (remet != Variaveis_globais.usuario)
                {
                    listView1.Items.Add(dr[1].ToString());
                }
                
            }
            conexao.DesconectarBD();
        }

        public void ListarGrupo()
        {
            listView2.Items.Clear();
            Conexao con = new Conexao();  
            MySqlCommand cmdo = new MySqlCommand("select * from tb_grupo where participantes like '%"+Variaveis_globais.usuario+"%' ", con.ConectarBD());
            MySqlDataReader dr2 = cmdo.ExecuteReader();
            while (dr2.Read())
            {
                listView2.Items.Add(dr2[1].ToString());
            }
            conexao.DesconectarBD();
        }

        private void responderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            msg=listView1.SelectedItems[0].SubItems[0].Text;
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void AbrirGrupo()
        {
            Conexao con = new Conexao();
            MySqlCommand cmdo = new MySqlCommand("select * from tb_grupo where nm_grupo = @nome ", con.ConectarBD());
            cmdo.Parameters.Add("@nome", MySqlDbType.VarChar).Value = msg2;
            MySqlDataReader dr2 = cmdo.ExecuteReader();
            while (dr2.Read())
            {
                tela.Show();
                tela.richTextBox1.Text= dr2[3].ToString();
                tela.lblNomeGrupo.Text = dr2[1].ToString();
                RetornarImagem();
            }
        }

        public void RetornarImagem()
        {
            Conexao con = new Conexao();
            tela.pictureBox1.Image = null;

            try
            {
                MySqlCommand cmdSelect = new MySqlCommand("select foto_grupo from tb_grupo where nm_grupo= @nome", con.ConectarBD());
                cmdSelect.Parameters.Add("@nome", MySqlDbType.VarChar).Value = msg2;
                DataSet ds = new DataSet();
                MySqlDataAdapter sqlda = new MySqlDataAdapter(cmdSelect);
                sqlda.Fill(ds, "tb_grupo");

                con.DesconectarBD();
                using (var stream = new System.IO.MemoryStream((byte[])ds.Tables["tb_grupo"].Rows[0]["foto_grupo"]))
                {
                    tela.pictureBox1.Image = Bitmap.FromStream(stream);
                    vimagem1 = Bitmap.FromStream(stream);
                }

            }

            catch
            {
                //   MessageBox.Show(" Imagem Invalida \n" + ex.Message);
            }
            finally
            {

                con.DesconectarBD();

            }
        }


        private void listView2_DoubleClick(object sender, EventArgs e)
        {          
           
            AbrirGrupo();
            this.Close();
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            msg2 = listView2.SelectedItems[0].SubItems[0].Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ListarUsuario();
            ListarGrupo();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            tela_conversa tela = new tela_conversa();
            MySqlDataReader dr;
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select * from tb_conversa where destinatario = @destinatario and lido ='n' and remetente =@remetente or destinatario=@remetente and remetente=@destinatario and lido='n'", con.ConectarBD());
            cmd.Parameters.Add("@destinatario", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
            cmd.Parameters.Add("@remetente", MySqlDbType.VarChar).Value = msg;
            dr = cmd.ExecuteReader();
            string remet;
            if (dr.HasRows == false)
            {
                MessageBox.Show("Erro ao buscar !");
            }
            else
            {
                tela.Show();
                while (dr.Read())
                {
                    remet = dr[1].ToString();
                    if (Variaveis_globais.usuario == remet)
                    {
                        tela.cbbDesti.Text = dr[1].ToString();
                        tela.richTextBox1.Text = dr[3].ToString();
                    }
                    else if (Variaveis_globais.usuario != remet)
                    {
                        tela.cbbDesti.Text = dr[2].ToString();
                        tela.richTextBox1.Text = dr[3].ToString();
                    }
                    this.Close();
                }
                con.DesconectarBD();
                con.ConectarBD();
                con.DesconectarBD();
            }

            Conexao co = new Conexao();
            MySqlCommand cm = new MySqlCommand("update tb_conversa set lido='s' where destinatario = @destinatario and lido ='n' and remetente =@remetente or destinatario=@remetente and remetente=@destinatario", co.ConectarBD());
            cm.Parameters.Add("@destinatario", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
            cm.Parameters.Add("@remetente", MySqlDbType.VarChar).Value = msg;
            cm.ExecuteNonQuery();
            try
            {
                MessageBox.Show("LIDO COM SUCESSO !");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
    

