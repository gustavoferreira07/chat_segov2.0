using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov.Telas
{
    public partial class tela_email : MetroForm
    {
        public tela_email()
        {
            InitializeComponent();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = new System.Net.NetworkCredential("guga.etecbg@gmail.com", "40591044");
            MailMessage mail = new MailMessage();
            mail.Sender = new System.Net.Mail.MailAddress("guga.etecbg@gmail.com");
            mail.From = new MailAddress("guga.etecbg@gmail.com");
            mail.To.Add("guga.etecbg@gmail.com");
            mail.Subject = txtTitulo.Text;
            mail.Body = txtMensagem.Text;
          
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            try
            {
                MetroMessageBox.Show(this, "Erro relatado com sucesso !", "Sucesso !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                client.Send(mail);
                txtMensagem.Clear();
                txtTitulo.Clear();
            }
            catch (System.Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
            finally
            {
                mail = null;
            }
        }
    }
}
