using chat_segov.Controlador;
using MetroFramework;
using MetroFramework.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov.Telas
{
    public partial class tela_login : MetroForm
    {
        public tela_login()
        {
            InitializeComponent();
        }

        string id_usuario;
        string username;
        string ip;

        private void button1_Click(object sender, EventArgs e)
        {
            Conexao con = new Conexao();
            con.ConectarBD();
        }

        private void txt_senha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_logar.PerformClick();
            }
        }

        private void txt_usuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btn_logar.PerformClick();
            }
        }

        public static string AcertaSenha(string _senha)
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

        private void btn_logar_Click(object sender, EventArgs e)
        {
            if ((txt_usuario.Text == "admin") || (txt_senha.Text == "admin"))
            {
               MetroMessageBox.Show(this,"Login efetuado com sucesso", "Bem vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tela_principal tela = new tela_principal();
                tela.Show();
                txt_senha.Clear();
                txt_usuario.Clear();

            }
            else
            {
                MySqlDataReader dr;
                Conexao con = new Conexao();
                MySqlCommand cmd = new MySqlCommand("select * from tb_usuario where username=@usuario and senha=@senha", con.ConectarBD());
                cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = txt_usuario.Text;
                cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = AcertaSenha( txt_senha.Text);

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                  { 
                    MetroMessageBox.Show(this,"Login efetuado com sucesso !", "Bem vindo " + txt_usuario.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tela_principal tela = new tela_principal();
                    while (dr.Read())
                    {
                        id_usuario = dr[0].ToString();
                        username = dr[2].ToString();
                        ip = dr[5].ToString();
                           

                    }
                    Variaveis_globais.id_usuario = id_usuario;
                    Variaveis_globais.ip = ip;
                    Variaveis_globais.usuario = username;
                    tela.lblUsuario.Text = username;
                    tela.Show();
                    this.Close();
                    txt_senha.Clear();
                    txt_usuario.Clear();
                    
                        con.DesconectarBD();
                  }
                    Conexao co = new Conexao();
                    MySqlCommand cm = new MySqlCommand("update tb_usuario set status='online' where username=@usuario", co.ConectarBD());                 
                    cm.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = username;
                    try
                    {
                        cm.ExecuteNonQuery();
                        Variaveis_globais.status ="online";
                    }
                    catch(Exception ex)
                    {
                        MetroMessageBox.Show(this,"Erro ao ficar online !\n"+ ex.Message);
                    }
                }
                else
                {
                    MetroMessageBox.Show(this,"Senha ou usuário inválido !", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_senha.Clear();
               
                }
                
            }
        }
            private void lkl_cadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
                tela_cadastro tela = new tela_cadastro();
                tela.Show();
            }

        private void tela_login_Load(object sender, EventArgs e)
        {
            txt_usuario.Focus();
        }
    }

}

