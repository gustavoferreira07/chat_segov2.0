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
    class Salva_grupo
    {
        Conexao conexao = new Conexao();
        MySqlCommand comando = new MySqlCommand();


        public void salvarGrupo(Grupo grupo)
        {
            comando.CommandText = "insert into tb_grupo (nm_grupo, foto_grupo, mensagem, participantes)  values('" + grupo.Nm_grupo + "', @foto, '" + grupo.Mensagem + "','" + grupo.Participantes+"')";
            comando.Parameters.Add("@foto", MySqlDbType.LongBlob).Value = grupo.Foto_grupo;
            comando.Connection = conexao.ConectarBD();
            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Grupo criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao criar grupo. \n Detalhes do erro: " + e.Message);
            }
            conexao.DesconectarBD();
        }

        public void AlterarGrupo(Grupo grupo, string id)
        {
            comando.CommandText = "update tb_grupo set nm_grupo=@nome, foto_grupo=@foto, participantes=@participantes where id_chat ="+id;
            comando.Parameters.Add("@foto", MySqlDbType.LongBlob).Value = grupo.Foto_grupo;
            comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = grupo.Nm_grupo;
            comando.Parameters.Add("@participantes", MySqlDbType.LongText).Value = grupo.Participantes;
  
            comando.Connection = conexao.ConectarBD();
            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Grupo atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao alterar grupo. \n Detalhes do erro: " + e.Message);
            }
            conexao.DesconectarBD();
        }

        public void AlterarGrupoSemFoto(Grupo grupo, string id)
        {
            comando.CommandText = "update tb_grupo set nm_grupo=@nome,participantes=@participantes where id_chat =" + id;            
            comando.Parameters.Add("@nome", MySqlDbType.VarChar).Value = grupo.Nm_grupo;
            comando.Parameters.Add("@participantes", MySqlDbType.LongText).Value = grupo.Participantes;

            comando.Connection = conexao.ConectarBD();
            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Grupo atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao alterar grupo. \n Detalhes do erro: " + e.Message);
            }
            conexao.DesconectarBD();
        }
    }
}
