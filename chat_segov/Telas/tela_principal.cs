using chat_segov.Controlador;
using chat_segov.Telas;
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

namespace chat_segov
{
    public partial class tela_principal : MetroForm
    {
        public tela_principal()
        {
            InitializeComponent();
              timer1.Start();
        }
        Conexao conexao = new Conexao();
        string list;
        public string nomeUsu;
        string msg;
        private void conversasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void novoChatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void novaConversaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tela_conversa tela = new tela_conversa();
            tela.Show();
        }

        public void NovaMensagem_Click(object sender, EventArgs e)
        {
            new tela_conversa().Show();
        }

        public void Abrir_Click(object sender, EventArgs e)
        {
           
            tela_principal tela = new tela_principal();
            tela.Show();
           
        }
        public void Fechar_Click(object sender, EventArgs e)
        {
            DialogResult dialogo = MessageBox.Show("Deseja sair do chat?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.Yes)
            {
                Conexao co = new Conexao();
                MySqlCommand cm = new MySqlCommand("update tb_usuario set status='offline' where username=@usuario", co.ConectarBD());
                cm.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
                cm.ExecuteNonQuery();

                Application.Exit();
            }
        }

        private void tela_principal_Load(object sender, EventArgs e)
        {
            MySqlCommand cm = new MySqlCommand("select username, status from tb_usuario where status = 'online'", conexao.ConectarBD());
            MySqlDataReader dr = cm.ExecuteReader();

            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["username"].ToString());
                item.SubItems.Add(dr["status"].ToString());
                listView1.Items.Add(item);
            }
            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Abrir", Abrir_Click));
            contextMenu.MenuItems.Add(new MenuItem("Enviar mensagem", NovaMensagem_Click));
            contextMenu.MenuItems.Add(new MenuItem("Fechar", Fechar_Click));
            notifyIcon1.ContextMenu = contextMenu;

        }

        public void LeConversa()
        {
            tela_conversa tela = new tela_conversa();
            MySqlDataReader dr;
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("select * from tb_conversa where destinatario = @destinatario and lido ='n' and remetente =@remetente or destinatario=@remetente and remetente=@destinatario and lido='n'", con.ConectarBD());
            cmd.Parameters.Add("@destinatario", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
            cmd.Parameters.Add("@remetente", MySqlDbType.VarChar).Value = msg;
            dr = cmd.ExecuteReader();
            string remet;
            if (dr.HasRows == false)
            {
                MessageBox.Show("Erro ao buscar !");
            }
            else
            {
                tela.Show();
                while (dr.Read())
                {
                    remet = dr[1].ToString();
                    if (Variaveis_globais.usuario == remet)
                    {
                        tela.cbbDesti.Text = dr[1].ToString();
                        tela.richTextBox1.Text = dr[3].ToString();
                    }
                    else if (Variaveis_globais.usuario != remet)
                    {
                        tela.cbbDesti.Text = dr[2].ToString();
                        tela.richTextBox1.Text = dr[3].ToString();
                    }
                }
                con.DesconectarBD();
                con.ConectarBD();
                con.DesconectarBD();
            }

            Conexao co = new Conexao();
            MySqlCommand cm = new MySqlCommand("update tb_conversa set lido='s' where destinatario = @destinatario and lido ='n' and remetente =@remetente or destinatario=@remetente and remetente=@destinatario; update tb_notificacao set lido='s' where destinatario = @destinatario and lido ='n' and remetente =@remetente or destinatario=@remetente and remetente=@destinatario", co.ConectarBD());
            cm.Parameters.Add("@destinatario", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
            cm.Parameters.Add("@remetente", MySqlDbType.VarChar).Value = msg;
           
            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("LIDO COM SUCESSO !");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    

        private void chamarPrivadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tela_conversa tela = new tela_conversa();
            LeConversa();
            tela.Show();
            tela.cbbDesti.Text = msg;

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            list = listView1.SelectedItems[0].SubItems[0].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarregaOnline();
        }

        private void minhasMensagensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tela_mensagens tela = new tela_mensagens();
            tela.Show();
        }

        private void mudarTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tela_tema tela = new tela_tema();
            tela.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            msg = listView1.SelectedItems[0].SubItems[0].Text;
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void contatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tela_contatos tela = new tela_contatos();
            tela.Show();
        }
        string id_notificacao;
        public void Notificacao()
        {
            tela_conversa tela = new tela_conversa();
            MySqlDataReader dr;
            Conexao con = new Conexao();
            MySqlCommand cmd = new MySqlCommand("SELECt * FROM tb_notificacao where destinatario=@usuario or remetente =@usuario and lido = 'n' ORDER BY id_notificacao DESC LIMIT 1 ", con.ConectarBD());
            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
            dr = cmd.ExecuteReader();
           
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {

                    id_notificacao = dr[0].ToString();
                    if (id_notificacao != Variaveis_globais.mensagem)
                    {
                        notifyIcon1.ShowBalloonTip(10, "Nova mensagem", dr[3].ToString(), ToolTipIcon.None);
                        Variaveis_globais.mensagem = id_notificacao;
                    }
                    else
                    {

                        
                    }                  
                }
            }
            conexao.DesconectarBD();
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tela_sobre tela = new tela_sobre();
            tela.Show();
        }
        int segundo = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            segundo++;
            

            if (segundo == 15)
            {
                CarregaOnline();
                Notificacao();
                timer1.Dispose();
                timer1.Stop();
                segundo = 0;
                timer1.Start();
               
            }
        }

        public void VerificaNovaMensagem()
        {

        }

        private void tela_principal_FormClosed(object sender, FormClosedEventArgs e)
        {

            
            DialogResult dialogo = MetroMessageBox.Show(this, "Deseja sair do chat?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogo == DialogResult.Yes)
            {
                Conexao co = new Conexao();
                MySqlCommand cm = new MySqlCommand("update tb_usuario set status='offline' where username=@usuario", co.ConectarBD());
                cm.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = Variaveis_globais.usuario;
                cm.ExecuteNonQuery();

                Application.Exit();
            }
    
        }

        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tela_perfil tela = new tela_perfil();
            tela.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

        }
        public void CarregaOnline()
        {

            listView1.Items.Clear();

            Conexao conec = new Conexao();
            MySqlCommand cm = new MySqlCommand("select username, status from tb_usuario where status = 'online'", conec.ConectarBD());
            MySqlDataReader dr = cm.ExecuteReader();


            while (dr.Read())
            {
              
                ListViewItem item = new ListViewItem(dr["username"].ToString());
                item.SubItems.Add(dr["status"].ToString());
              
                listView1.Items.Add(item);
               
            }
            conexao.DesconectarBD();
        }

        private void novoGrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tela_grupo tela = new tela_grupo();
            tela.Show();
            tela.btnSalvar.Visible = true;
        }

        private void relatarProblemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tela_email tela = new tela_email();
            tela.Show();
        }

        
    }
}
