using chat_segov.Controlador;
using chat_segov.Repositorio;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov.Telas
{
    public partial class tela_conversa : MetroForm
    {
        public tela_conversa()
        {
            InitializeComponent();
            timer1.Start();
        }
        int segundo;
        string update;
        Image vimagem1;
        string msg;
        Conexao conexao = new Conexao();

        public void Carrega_chat()
        {
            richTextBox1.Clear();
           
           MySqlDataReader dr;
           Conexao con = new Conexao();
           MySqlCommand cmd = new MySqlCommand("select * from tb_conversa where destinatario = @destinatario  and remetente =@remetente or destinatario =@remetente and remetente=@destinatario order by id_chat asc", con.ConectarBD());
           cmd.Parameters.Add("@destinatario", MySqlDbType.VarChar).Value = cbbDesti.Text;
           cmd.Parameters.Add("@remetente", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
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

      
        string remetente;
        public void VerificaMensagem()
        {     
            string mensagem;
            Conversa conversa = new Conversa();
            Armazena_mensagem salva = new Armazena_mensagem();
            tela_conversa tela = new tela_conversa();
            MySqlDataReader dr;
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select * from tb_conversa where destinatario = @destinatario  and remetente =@remetente or destinatario=@remetente and remetente = @destinatario", con.ConectarBD());
            cmd.Parameters.Add("@destinatario", MySqlDbType.VarChar).Value = cbbDesti.Text;
            cmd.Parameters.Add("@remetente", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
            dr = cmd.ExecuteReader();
            if (dr.HasRows == false)
            {
                conversa.Remetente = Variaveis_globais.usuario;
                conversa.Destinatario = cbbDesti.Text;
                conversa.Mensagem = msg;
                conversa.Lido = "n";
                salva.salvarMensagem(conversa);

                salva.salvarnotificacao(conversa, msg);
            }
            else if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    remetente = dr[1].ToString();
                    mensagem = dr[3].ToString();
                    update = mensagem + "\n" + msg;
                }            
                if (remetente != Variaveis_globais.usuario)
                {
                        conversa.Remetente = cbbDesti.Text;
                        conversa.Destinatario = Variaveis_globais.usuario;
                        conversa.Mensagem = update;
                        conversa.Lido = "n";
                        salva.Continua_chat(conversa);
                    salva.salvarnotificacao(conversa, msg);
                }
                    if (Variaveis_globais.usuario == remetente)
                    {

                        conversa.Remetente = Variaveis_globais.usuario;
                        conversa.Destinatario = cbbDesti.Text;
                        conversa.Mensagem = update;
                        conversa.Lido = "n";
                        salva.Continua_chat(conversa);
                    salva.salvarnotificacao(conversa,msg);
                    }
                
            }           
        }
        public void ArredondaFoto()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox3.Width - 0, pictureBox3.Height - 0);
            Region rg = new Region(gp);
            pictureBox3.Region = rg;
        }

        private void tela_conversa_Load(object sender, EventArgs e)
        {
            ArredondaFoto();
            richTextBox1.SelectionStart = richTextBox1.Text.Length;

            richTextBox1.ScrollToCaret();
            preencherCBB();
            
            string status;
            MySqlDataReader dr;
            Conexao co = new Conexao();
            MySqlCommand cm = new MySqlCommand("select * from tb_usuario where username='" + cbbDesti.Text + "'", co.ConectarBD());
            dr = cm.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    status = dr["status"].ToString();

                    if (status == "online")
                    {
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = false;
                        lbl_status.Visible = true;
                        lbl_status.Text = cbbDesti.Text + " está " + status;
                    }
                    else if (status == "offline")
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = true;
                        lbl_status.Visible = true;
                        lbl_status.Text = cbbDesti.Text + " está " + status;
                    }
                }
             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void preencherCBB()
        {
            Conexao con = new Conexao();
            try
            {
                con.ConectarBD();
                con.DesconectarBD();
            }

            catch (MySqlException sqle)
            {
                con.ConectarBD();
                MessageBox.Show("Falha ao efetuar a conexão. Erro: " + sqle);
            }
            String scom = "select * from tb_usuario order by username";
            MySqlDataAdapter da = new MySqlDataAdapter(scom, con.ConectarBD());
            DataTable dtResultado = new DataTable();
            dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
            cbbDesti.DataSource = null;
            da.Fill(dtResultado);
            cbbDesti.DataSource = dtResultado;
            cbbDesti.ValueMember= "id_usuario";
            cbbDesti.DisplayMember = "username";
           // cbbDesti.SelectedItem = "";
            cbbDesti.Refresh(); //faz uma nova busca no BD para preencher os valores da cb de departamentos.
            con.DesconectarBD();
        }

        private void cbbDesti_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            string status;
            MySqlDataReader dr;
            Conexao co = new Conexao();
            MySqlCommand cm = new MySqlCommand("select * from tb_usuario where username='"+ cbbDesti.Text+"'", co.ConectarBD());
            dr= cm.ExecuteReader();

            try  
            {
                while (dr.Read())
                {
                    status = dr["status"].ToString();

                    if (status == "online")
                    {
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = false;
                        lbl_status.Visible = true;
                        lbl_status.Text = cbbDesti.Text + " está online";
                        RetornarImagem();
                    }
                    else if (status == "offline")
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = true;
                        lbl_status.Visible = true;
                        lbl_status.Text = cbbDesti.Text + " está offline";
                        RetornarImagem();
                    }
                   
                }
                RetornarImagem();
                Carrega_chat();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }                         
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if(cbbDesti.Text == Variaveis_globais.usuario)
            {
                MessageBox.Show("Selecione o destinatario !", "atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (txtMensagem.Text== "")
            {
                MessageBox.Show("Texto vazio","atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                msg = Variaveis_globais.usuario + ": " + txtMensagem.Text ;
               
                richTextBox1.Text = richTextBox1.Text + "\n" + msg;
                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
                txtMensagem.Clear();
                txtMensagem.Focus();
                VerificaMensagem();

            } 
        }

        private void txtMensagem_MouseDown(object sender, MouseEventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text + "\n" + msg;
        }

        private void metroListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
         //   msg = metroListView1.Text.ToString();
        }

        private void txtMensagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_enviar.PerformClick();
            }
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            string status;
            MySqlDataReader dr;
            Conexao co = new Conexao();
            MySqlCommand cm = new MySqlCommand("select * from tb_usuario where username='" + cbbDesti.Text + "'", co.ConectarBD());
            dr = cm.ExecuteReader();

            try
            {
                while (dr.Read())
                {
                    status = dr["status"].ToString();

                    if (status == "online")
                    {
                        pictureBox2.Visible = true;
                        pictureBox1.Visible = false;
                        lbl_status.Visible = true;
                        lbl_status.Text = cbbDesti.Text + " está " + status;
                    }
                    else if (status == "offline")
                    {
                        pictureBox2.Visible = false;
                        pictureBox1.Visible = true;
                        lbl_status.Visible = true;
                        lbl_status.Text = cbbDesti.Text + " está " + status;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {           
            timer1.Interval = 500;
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

        public void RetornarImagem()
        {
            pictureBox3.Image = null;
            string cbb = cbbDesti.Text;
            try
            {
                MySqlCommand cmdSelect = new MySqlCommand("select foto from tb_usuario where username=@LOGIN", conexao.ConectarBD());
                cmdSelect.Parameters.Add("@LOGIN", MySqlDbType.VarChar).Value = cbb;
                DataSet ds = new DataSet();
                MySqlDataAdapter sqlda = new MySqlDataAdapter(cmdSelect);
                sqlda.Fill(ds, "tb_usuario");

                conexao.DesconectarBD();
                using (var stream = new System.IO.MemoryStream((byte[])ds.Tables["tb_usuario"].Rows[0]["foto"]))
                {
                    pictureBox3.Image = Bitmap.FromStream(stream);
                    vimagem1 = Bitmap.FromStream(stream);
                }
              
            }
           
            catch
            {
             //   MessageBox.Show(" Imagem Invalida \n" + ex.Message);

            }
            finally
            {

                conexao.DesconectarBD();

            }
        }

        private void tela_conversa_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Carrega_chat();
        }
    }
}




