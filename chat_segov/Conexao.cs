using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov
{
    class Conexao
    {
        MySqlConnection con = new MySqlConnection("host= 127.0.0.1; userid= root; password=; database=db_chat;Convert Zero Datetime=True;Allow Zero Datetime=True");

        public MySqlConnection ConectarBD()
        {
            try
            {
                con.Open();
               
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao conectar banco de dados. \nDetalhes do erro: " + e);
            }
            return con;
        }

        public MySqlConnection DesconectarBD()
        {
            try
            {
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao desconectar banco de dados. \nDetalhes do erro: " + e);
            }
            return con;
        }

        public void ChecarSetiveAberFecha()
        {
            try
            {
                if (con != null && con.State != System.Data.ConnectionState.Closed)
                {
                    DesconectarBD();
                }
            }
            catch
            {

            }
        }
    }
}
