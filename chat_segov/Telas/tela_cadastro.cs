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
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov.Telas
{
    public partial class tela_cadastro : MetroForm
    {
       

        public tela_cadastro()
        {
            InitializeComponent();

           

        }
        public long tamanhoArquivoImagem = 0;
        public byte[] vetorImagens1;


        public void CarregaImagem1(PictureBox picture)
        {
            try
            {
                opdcad.ShowDialog(this);

                string strFn = opdcad.FileName;

                if (string.IsNullOrEmpty(strFn))
                    return;

                picture.Image = Image.FromFile(strFn);
                FileInfo arqImagem = new FileInfo(strFn);
                tamanhoArquivoImagem = arqImagem.Length;
                FileStream fs = new FileStream(strFn, FileMode.Open, FileAccess.Read, FileShare.Read);
                vetorImagens1 = new byte[Convert.ToInt32(this.tamanhoArquivoImagem)];
                int iBytesRead = fs.Read(vetorImagens1, 0, Convert.ToInt32(this.tamanhoArquivoImagem));

                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static string AcertaSenha( string _senha)
        {
            StringBuilder senha = new StringBuilder();

            MD5 md5 = MD5.Create();
            byte[] entrada = Encoding.ASCII.GetBytes( _senha);
            byte[] hash = md5.ComputeHash(entrada);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                senha.Append(hash[i].ToString("X2"));
            }
            return senha.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((txt_nome.Text == "") || (txt_username.Text == "") || (txt_senha.Text == "") || (txt_confirmaSenha.Text == "") && (txt_senha.Text != txt_confirmaSenha.Text))
            {
                MetroMessageBox.Show(this, "Preencha todos os campos corretamente!", "Campos Vazios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if((pictureBox1==null)||(pictureBox1.Image==null))
            { 
                Usuario usuario = new Usuario();
                Salva_usuario salvar = new Salva_usuario();

                usuario.Nome = txt_nome.Text;
                usuario.Username = txt_username.Text;
                usuario.Senha = AcertaSenha( txt_senha.Text);
                usuario.Departamento = cbb_departamento.Text;
            

                salvar.salvarUsuarioSemFoto(usuario);
                txt_nome.Clear();
                txt_username.Clear();
                txt_senha.Clear();
                txt_confirmaSenha.Clear();
                cbb_departamento.Text = "";
                txt_nome.Focus();
                pictureBox1.Image = null;
            }
            else
            {
                Usuario usuario = new Usuario();
                Salva_usuario salvar = new Salva_usuario();

                usuario.Nome = txt_nome.Text;
                usuario.Username = txt_username.Text;
                usuario.Senha = AcertaSenha(txt_senha.Text);
                usuario.Departamento = cbb_departamento.Text;
                usuario.Foto = vetorImagens1;

                salvar.salvarUsuario(usuario);
                txt_nome.Clear();
                txt_username.Clear();
                txt_senha.Clear();
                txt_confirmaSenha.Clear();
                cbb_departamento.Text = "";
                txt_nome.Focus();
                pictureBox1.Image = null;
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
            String scom = "select * from tb_departamento order by id_departamento";
            MySqlDataAdapter da = new MySqlDataAdapter(scom, con.ConectarBD());
            DataTable dtResultado = new DataTable();
            dtResultado.Clear();//o ponto mais importante (limpa a table antes de preenche-la)
            cbb_departamento.DataSource = null;
            da.Fill(dtResultado);
            cbb_departamento.DataSource = dtResultado;
            cbb_departamento.ValueMember = "id_departamento";
            cbb_departamento.DisplayMember = "ds_departamento";
            // cbbDesti.SelectedItem = "";
            cbb_departamento.Refresh(); //faz uma nova busca no BD para preencher os valores da cb de departamentos.
            con.DesconectarBD();
        }
        private void tela_cadastro_Load(object sender, EventArgs e)
        {
            preencherCBB();
            pictureBox1.Image = null;
        }

        private string GetLocalIp()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "127.0.0.1";

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
       


        private void button2_Click(object sender, EventArgs e)
        {
            CarregaImagem1(pictureBox1);
        }
    }
}


