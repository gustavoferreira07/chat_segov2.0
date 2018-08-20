using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chat_segov.Controlador
{
    class Listar_contatos
    {
        Conexao conexao = new Conexao();
        public DataSet listarContato(string msg)
        {
            DataSet ds = new DataSet();
            MySqlDataAdapter da;
            da = new MySqlDataAdapter("select nm_usuario, username, departamento from tb_usuario", conexao.ConectarBD());         
            da.Fill(ds);
            conexao.DesconectarBD();
            return ds;
        }
         public DataSet listarTexto(string texto)
        {
            DataSet ds2 = new DataSet();
            MySqlDataAdapter da2;
            da2 = new MySqlDataAdapter("select nm_usuario, username, departamento from tb_usuario where username like '%" + texto+"%'", conexao.ConectarBD());
            da2.Fill(ds2);
            conexao.DesconectarBD();
            return ds2;
        }
    }
}
