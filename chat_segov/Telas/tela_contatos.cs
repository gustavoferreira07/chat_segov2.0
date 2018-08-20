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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov.Telas
{
    public partial class tela_contatos : MetroForm
    {
        public tela_contatos()
        {
            InitializeComponent();
        }
        Salva_usuario salva = new Salva_usuario();
        string msg;
        private void tela_contatos_Load(object sender, EventArgs e)
        {
              Listar_contatos listar_tabelas = new Listar_contatos();
              DataSet ds = new DataSet();
              ds = listar_tabelas.listarContato(msg);
              metroGrid1.DataSource = ds.Tables[0];
              metroGrid1.Columns[0].HeaderText = "Nome";
              metroGrid1.Columns[1].HeaderText = "Username";
              metroGrid1.Columns[2].HeaderText = "Departamento";


              metroGrid1.Refresh();
            
        }
            private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
            msg = (metroGrid1.Rows[e.RowIndex].Cells["username"].Value).ToString();
            }

        private void chamarChatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tela_conversa tela = new tela_conversa();
            MySqlDataReader dr;
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select * from tb_conversa where destinatario = @destinatario  and remetente =@remetente or destinatario =@remetente and remetente=@destinatario", con.ConectarBD());
            cmd.Parameters.Add("@destinatario", MySqlDbType.VarChar).Value = msg;
            cmd.Parameters.Add("@remetente", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
            dr = cmd.ExecuteReader();
            if (dr.HasRows == false)
            {
                tela.Show();
                tela.cbbDesti.Text = msg;

            }
            else
               tela.Show();
               while (dr.Read())
               {

                  tela.cbbDesti.Text = dr[2].ToString();
                  tela.richTextBox1.Text = dr[3].ToString();
               }
               con.DesconectarBD();
               con.ConectarBD();
               con.DesconectarBD();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
          
                       
           
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listar_contatos listar_tabelas = new Listar_contatos();
            DataSet ds = new DataSet();
            ds = listar_tabelas.listarTexto(txtContato.Text);
            metroGrid1.DataSource = ds.Tables[0];
            metroGrid1.Columns[0].HeaderText = "Nome";
            metroGrid1.Columns[1].HeaderText = "Username";
            metroGrid1.Columns[1].HeaderText = "Departamento";
         
            metroGrid1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Listar_contatos listar_tabelas = new Listar_contatos();
            DataSet ds = new DataSet();
            ds = listar_tabelas.listarContato(msg);
            metroGrid1.DataSource = ds.Tables[0];
            metroGrid1.Columns[0].HeaderText = "Nome";
            metroGrid1.Columns[1].HeaderText = "Username";
            metroGrid1.Columns[1].HeaderText = "Departamento";
           
            metroGrid1.Refresh();
            txtContato.Clear();
            txtContato.Focus();
        }

        private void apagarConversaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MetroMessageBox.Show(this,"Deseja apagar permanentemente esta convrsa?", "Aviso!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.Yes)
            {
                Conversa conversa = new Conversa();
                Limpa_conversa limpa = new Limpa_conversa();

                conversa.Remetente = Variaveis_globais.usuario;
                conversa.Destinatario = msg;

                limpa.Limpa(conversa);
              
            }
            else
            {

            }
        }
    }
}
