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
    class Salva_usuario
    {
        Conexao conexao = new Conexao();
        MySqlCommand comando = new MySqlCommand();


        public void salvarUsuario(Usuario usuario)
        {
            comando.CommandText = "insert into tb_usuario (nm_usuario, username, senha,departamento, foto)  values('" + usuario.Nome + "','" + usuario.Username + "','" + usuario.Senha + "','" + usuario.Departamento + "',@foto)";
            comando.Parameters.Add("@foto", MySqlDbType.LongBlob).Value = usuario.Foto;
            comando.Connection = conexao.ConectarBD();
            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao cadastrar usuario. \n Detalhes do erro: " + e.Message);
            }
            conexao.DesconectarBD();
        }

        public void SalvarEdit( Usuario users,string user)
        {
           
            comando.CommandText = "update tb_usuario set foto=@foto where username =@user";
            comando.Parameters.Add("@user", MySqlDbType.VarChar).Value = user;
            comando.Parameters.Add("@foto", MySqlDbType.LongBlob).Value = users.Foto;
            comando.Connection = conexao.ConectarBD();
            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("foto alterada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao trocar foto. \n Detalhes do erro: " + e.Message);
            }
            conexao.DesconectarBD();
        }
        public void salvarUsuarioSemFoto(Usuario usuario)
        {
            comando.CommandText = "insert into tb_usuario (nm_usuario, username, senha,departamento)  values('" + usuario.Nome + "','" + usuario.Username + "','" + usuario.Senha + "','" + usuario.Departamento + "')";
            comando.Parameters.Add("@foto", MySqlDbType.LongBlob).Value = usuario.Foto;
            comando.Connection = conexao.ConectarBD();
            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Usuario cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao cadastrar usuario. \n Detalhes do erro: " + e.Message);
            }
            conexao.DesconectarBD();
        }
    }
}
