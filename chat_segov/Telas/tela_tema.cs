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
    public partial class tela_tema : MetroForm
    {
        public tela_tema()
        {
            InitializeComponent();
            this.StyleManager = msmMain; 
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            msmMain.Theme = MetroFramework.MetroThemeStyle.Dark;

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            msmMain.Theme = MetroFramework.MetroThemeStyle.Light;
        }

        private void tela_tema_Load(object sender, EventArgs e)
        {

        }
    }
}
