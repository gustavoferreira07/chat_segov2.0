using chat_segov.Controlador;
using chat_segov.Repositorio;
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
    public partial class tela_chat_grupo : MetroForm
    {
        public tela_chat_grupo()
        {
            InitializeComponent();
            timer1.Start();
        }
        tela_grupo tela = new tela_grupo();
        Image vimagem1;
        string msg;
        int segundo;
       
        public void AbrirGrupo()
        {
            Conexao con = new Conexao();
            MySqlCommand cmdo = new MySqlCommand("select * from tb_grupo where nm_grupo = @nome ", con.ConectarBD());
            cmdo.Parameters.Add("@nome", MySqlDbType.VarChar).Value = lblNomeGrupo.Text;
            MySqlDataReader dr2 = cmdo.ExecuteReader();
            while (dr2.Read())
            {
                tela.richTextBox1.Text=dr2[4].ToString();
                tela.txtNomeGrupo.Text = dr2[1].ToString();
                Variaveis_globais.id_grupo = dr2[0].ToString();
                tela.btnAlterar.Visible = true;
                tela.btnSalvar.Visible = false;
                RetornarImagem();
            }
        }

        public void RetornarImagem()
        {
            Conexao con = new Conexao();
           tela. pictureBox1.Image = null;

            try
            {
                MySqlCommand cmdSelect = new MySqlCommand("select foto_grupo from tb_grupo where nm_grupo= @nome", con.ConectarBD());
                cmdSelect.Parameters.Add("@nome", MySqlDbType.VarChar).Value = lblNomeGrupo.Text;
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

        private void label1_Click(object sender, EventArgs e)
        {           
            tela.Show();
            AbrirGrupo();
        }

        private void tela_chat_grupo_Load(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
            ArredondaFoto();
        }

        public void ArredondaFoto()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 2, pictureBox1.Height - 2);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
        }

        public void Carrega_chat()
        {
            richTextBox1.Clear();

            MySqlDataReader dr;
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select * from tb_grupo where nm_grupo = @grupo", con.ConectarBD());
            cmd.Parameters.Add("@grupo", MySqlDbType.VarChar).Value = lblNomeGrupo.Text;
           
            dr = cmd.ExecuteReader();
            if (dr.HasRows == false)
            {
            }
            else
                while (dr.Read())
                {                    
                    richTextBox1.Text = dr[3].ToString();
                    richTextBox1.SelectionStart = richTextBox1.Text.Length;

                    richTextBox1.ScrollToCaret();
                }

            con.DesconectarBD();

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            
            msg = Variaveis_globais.usuario + ": " + txtMensagem.Text;
            string texto=richTextBox1.Text = richTextBox1.Text + "\n" + msg;

            Armazena_msg_grupo salva = new Armazena_msg_grupo();
            salva.Continua_chat(lblNomeGrupo.Text, texto);

            /*richTextBox1.SelectionLength = 0;
            richTextBox1.SelectionStart = 0;*/
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
           
            richTextBox1.ScrollToCaret();
            txtMensagem.Clear();
            txtMensagem.Focus();
            

        }

        private void txtMensagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnEnviar.PerformClick();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            segundo++;
            if (segundo == 10)
            {
                Carrega_chat();
                timer1.Dispose();
                timer1.Stop();
                segundo = 0;
                timer1.Start();
            }
        }

  
    }
}
