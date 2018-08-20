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
    public partial class tela_grupo : MetroForm
    {
        public tela_grupo()
        {
            InitializeComponent();
        }
        Conexao conexao = new Conexao();
        string usuario;
        string usuario2;
        public long tamanhoArquivoImagem = 0;
        public byte[] vetorImagens;
        Grupo grupo = new Grupo();
        Salva_grupo salva = new Salva_grupo();


        private void tela_grupo_Load(object sender, EventArgs e)
        {
            ListarUsuario();
            
        }
        public void ListarUsuario()
        {
            MySqlCommand cm = new MySqlCommand("select * from tb_usuario ", conexao.ConectarBD());         
            MySqlDataReader dr = cm.ExecuteReader();
            while (dr.Read())
            {             
                    listBox1.Items.Add(dr[2].ToString());              
            }
        }
        public void ArredondaFoto()
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 2, pictureBox1.Height - 2);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
        }

        public void CarregaImagem()
        {

            try
            {

                openFileDialog1.ShowDialog(this);

                string strFn = openFileDialog1.FileName;

                if (string.IsNullOrEmpty(strFn))
                    return;
                openFileDialog1.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF|" + "All files (*.*)|*.*";
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

       
        private void listBox1_Click(object sender, EventArgs e)
        {
            usuario = listBox1.SelectedItems[0].ToString();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                richTextBox1.Text = richTextBox1.Text + "\n" + usuario;
            }
            catch
            {
                MetroMessageBox.Show(this, "É preciso selecionar um contato para adicioná-lo","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void listBox2_Click(object sender, EventArgs e)
        {
            usuario2 = listBox1.SelectedItems[0].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CarregaImagem();
            ArredondaFoto();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Grupo grupo = new Grupo();
            Salva_grupo salva = new Salva_grupo();

            grupo.Nm_grupo = txtNomeGrupo.Text;
            grupo.Foto_grupo = vetorImagens;
            grupo.Mensagem = " ";
            grupo.Participantes = richTextBox1.Text;

            salva.salvarGrupo(grupo);
        }
       
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                grupo.Nm_grupo = txtNomeGrupo.Text;              
                grupo.Participantes = richTextBox1.Text;
                salva.AlterarGrupoSemFoto(grupo, Variaveis_globais.id_grupo);
            }
            else
            {
                grupo.Nm_grupo = txtNomeGrupo.Text;
                grupo.Foto_grupo = vetorImagens;
                grupo.Participantes = richTextBox1.Text;
                salva.AlterarGrupo(grupo, Variaveis_globais.id_grupo);
            }          
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }
    }
}
