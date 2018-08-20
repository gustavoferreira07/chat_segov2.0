using chat_segov.Controlador;
using chat_segov.Repositorio;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov.Telas
{
    public partial class tela_perfil : MetroForm
    {
        public tela_perfil()
        {
            InitializeComponent();
        }
        public long tamanhoArquivoImagem = 0;
        public byte[] vetorImagens;
        Image vimagem1;
        private void tela_perfil_Load(object sender, EventArgs e)
        {

            

            MySqlDataReader dr;

            Conexao conexao = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select * from tb_usuario where username=@login", conexao.ConectarBD());
                cmd.Parameters.Add("@login", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
                dr = cmd.ExecuteReader();

                if (dr.HasRows == false)
                {
                    MessageBox.Show("CPF não cadastrado, faça seu cadastro");

                }
                else
                {
                   while (dr.Read())
                   {
                    lblNomes.Text = dr[1].ToString();
                    lblusuario.Text = dr[2].ToString();
                    lblStatus.Text = dr[5].ToString();
                    lblDepartamento.Text = dr[4].ToString();
                    RetornarImagem();

                   }
                }
                 conexao.DesconectarBD();
        }

       
        public void CarregaImagem()
        {

            try
            {

                opdFunc.ShowDialog(this);

                string strFn = opdFunc.FileName;
                
                if (string.IsNullOrEmpty(strFn))
                    return;
                opdFunc.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
                pictureBox1.Image = Image.FromFile(strFn);
                FileInfo arqImagem = new FileInfo(strFn);
                tamanhoArquivoImagem = arqImagem.Length;
                FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                vetorImagens = new byte[Convert.ToInt32(this.tamanhoArquivoImagem)];
                int iBytesRead = fs.Read(vetorImagens, 0, Convert.ToInt32(this.tamanhoArquivoImagem));

                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        public void RetornarImagem()
        {
            Conexao con = new Conexao();
            pictureBox1.Image = null;
            
            try
            {
                MySqlCommand cmdSelect = new MySqlCommand("select foto from tb_usuario where username=@LOGIN", con.ConectarBD());
                cmdSelect.Parameters.Add("@LOGIN", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
                DataSet ds = new DataSet();
                MySqlDataAdapter sqlda = new MySqlDataAdapter(cmdSelect);
                sqlda.Fill(ds, "tb_usuario");

                con.DesconectarBD();
                using (var stream = new System.IO.MemoryStream((byte[])ds.Tables["tb_usuario"].Rows[0]["foto"]))
                {
                    pictureBox1.Image = Bitmap.FromStream(stream);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if ((pictureBox1.Image == null)||(pictureBox1==null))
            {
                MetroMessageBox.Show(this, "É necessário alterar a foto para salvar", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Salva_usuario salva = new Salva_usuario();
                Usuario usu = new Usuario();
                usu.Foto = vetorImagens;

                salva.SalvarEdit(usu, Variaveis_globais.usuario);
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaImagem();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tela_alterar_senha tela = new tela_alterar_senha();
            tela.Show();
        }
    }
    }

