using chat_segov.Repositorio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov.Controlador
{
    class Armazena_msg_grupo
    {
        Conexao conexao = new Conexao();
        MySqlCommand comando = new MySqlCommand();
        MySqlCommand comand = new MySqlCommand();


        public void Continua_chat(string nm_grupo, string mensagem)
        {
            comand.CommandText = "update tb_grupo set mensagem ='" + mensagem + "' where nm_grupo ='" + nm_grupo +"'";
            comand.Connection = conexao.ConectarBD();

            try
            {
                comand.ExecuteNonQuery();
              /*  MessageBox.Show("update com sucesso!", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            */}
            catch (Exception e)
            {
                MessageBox.Show("Falha ao enviar msg. \n Detalhesdo Erro: " + e.Message);
            }
            //Desconectar pela ultima vez
            conexao.DesconectarBD();
        }
    }
}

