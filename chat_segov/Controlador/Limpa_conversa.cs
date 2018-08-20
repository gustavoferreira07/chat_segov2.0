using chat_segov.Repositorio;
using MetroFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov.Controlador
{
    class Limpa_conversa
    {
        Conexao conexao = new Conexao();
        MySqlCommand comando = new MySqlCommand();


        public void Limpa(Conversa usuario)
        {
            comando.CommandText = "insert into tb_backup_conversa(id_chat, remetente, destinatario,mensagem, lido)  select * from tb_conversa where remetente=@rem and destinatario=@dest or remetente=@dest and destinatario=@rem; delete from tb_conversa where remetente=@rem and destinatario=@dest or remetente=@dest and destinatario=@rem";
            comando.Parameters.Add("@rem", MySqlDbType.VarChar).Value = usuario.Remetente;
            comando.Parameters.Add("@dest", MySqlDbType.VarChar).Value = usuario.Destinatario;
            comando.Connection = conexao.ConectarBD();
            try
            {
                comando.ExecuteNonQuery();
                MessageBox.Show("Conversa apagada com sucesso !", "Concluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao apagar conversa. \n Detalhes do erro: " + e.Message);
            }
            conexao.DesconectarBD();
        }
    }
}
