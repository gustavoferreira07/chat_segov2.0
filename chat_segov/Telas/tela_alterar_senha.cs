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
    public partial class tela_alterar_senha : Form
    {
        public tela_alterar_senha()
        {
            InitializeComponent();
        }
        Conexao conexao = new Conexao();
        MySqlCommand comando = new MySqlCommand();

        public static string AcertaSenha(string _senha)
        {
            StringBuilder senha = new StringBuilder();

            MD5 md5 = MD5.Create();
            byte[] entrada = Encoding.ASCII.GetBytes(_senha);
            byte[] hash = md5.ComputeHash(entrada);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                senha.Append(hash[i].ToString("X2"));
            }
            return senha.ToString();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            comando.CommandType = CommandType.Text;

            MySqlDataReader dr2;
            MySqlCommand cmdo = new MySqlCommand("select * from tb_usuario where username=@usu ", conexao.ConectarBD());
            cmdo.Parameters.Add("@usu", MySqlDbType.VarChar).Value = txtUsu.Text;
            dr2 = cmdo.ExecuteReader();
            try
            {
                if (dr2.HasRows == true)
                {
                    conexao.DesconectarBD();
                    MySqlCommand cmdSelect = new MySqlCommand("select * from tb_usuario where username=@usu1", conexao.ConectarBD());
                    cmdSelect.Parameters.Add("@usu1", MySqlDbType.VarChar).Value = txtUsu.Text;
                    DataSet ds = new DataSet();
                    MySqlDataAdapter sqlda = new MySqlDataAdapter(cmdSelect);
                    sqlda.Fill(ds, "tb_usuario");
                    string senhaconf = ds.Tables["tb_usuario"].Rows[0]["senha"].ToString();
                    if (AcertaSenha(txtSenhaAtual.Text) != senhaconf)
                    {
                        MessageBox.Show("A senha antigo não esta correta");
                        txtSenhaAtual.Clear();
                        conexao.DesconectarBD();
                    }

                    else
                    {


                        conexao.DesconectarBD();


                        comando.CommandText = "update tb_usuario set senha=@senha where username= '" + txtUsu.Text+"'";                     
                        comando.Parameters.Add("@senha", MySqlDbType.VarChar).Value = AcertaSenha(txtNovaSenha.Text);


                        comando.Connection = conexao.ConectarBD();
                        comando.ExecuteNonQuery();
                       MessageBox.Show(this,"Senha Alterada com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conexao.DesconectarBD();
                        this.Close();

                    }
                }

                else
                {
                    MessageBox.Show("usuario nao encontrado");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSenhaAtual_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAlterar.PerformClick();
            }
        }

        private void txtNovaSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnAlterar.PerformClick();
            }
        }
    }
    
}
