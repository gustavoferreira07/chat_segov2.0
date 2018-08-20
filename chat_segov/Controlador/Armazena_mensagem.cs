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
    class Armazena_mensagem
    {
        Conexao conexao = new Conexao();
        MySqlCommand comando = new MySqlCommand();
        MySqlCommand comand= new MySqlCommand();

        public void salvarMensagem(Conversa conversa)
        {
            comando.CommandText = "insert into tb_conversa(remetente, destinatario, mensagem, lido)  values('" + conversa.Remetente + "','" + conversa.Destinatario + "','" + conversa.Mensagem + "','" + conversa.Lido+ "')";
            comando.Connection = conexao.ConectarBD();

            try
            {

                comando.ExecuteNonQuery();
             /*   MessageBox.Show("insert com sucesso!", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Information);*/

            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao enviar msg. \n Detalhesdo Erro: " + e.Message);

            }
            //Desconectar pela ultima vez
            conexao.DesconectarBD();
        }

        public void salvarnotificacao(Conversa conversa, string msg)
        {
            comando.CommandText = "insert into tb_notificacao(remetente, destinatario, mensagem,lido)  values('" + conversa.Remetente + "','" + conversa.Destinatario + "','" + msg + "','" + conversa.Lido + "')";
            comando.Connection = conexao.ConectarBD();

            try
            {

                comando.ExecuteNonQuery();
                /*   MessageBox.Show("insert com sucesso!", "Informação",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);*/

            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao enviar msg. \n Detalhesdo Erro: " + e.Message);

            }
            //Desconectar pela ultima vez
            conexao.DesconectarBD();
        }

        public void Continua_chat(Conversa cv)
        {
           
            comand.CommandText = "update tb_conversa set mensagem ='"+cv.Mensagem+"', lido='"+ cv.Lido+"' where remetente ='"+cv.Remetente+"' and  destinatario='"+cv.Destinatario+"'";


            comand.Connection = conexao.ConectarBD();

            try
            {

                comand.ExecuteNonQuery();
               /* MessageBox.Show("update com sucesso!", "Informação",
                MessageBoxButtons.OK, MessageBoxIcon.Information);*/

            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao enviar msg. \n Detalhesdo Erro: " + e.Message);

            }
            //Desconectar pela ultima vez
            conexao.DesconectarBD();
        }
    }
}

