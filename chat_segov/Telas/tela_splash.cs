using MetroFramework.Forms;
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
    public partial class tela_splash : MetroForm
    {
        public tela_splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {

                progressBar1.Value = progressBar1.Value + 2;

            }
            else
            {
                timer1.Enabled = false;
                this.Visible = false;

                tela_login chama = new tela_login();
                chama.Show();
            }
        }
        double por;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (por < 100)
            {
                por = por + 2;
                lblPor.Text = por.ToString() + " %";

            }
            else
            {
                timer2.Enabled = false;

            }
        }
    }
}
