using chat_segov.Telas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chat_segov
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new tela_splash());
        }
        /// <summary>
        /// Invokes an action on the UI thread
        /// </summary>
        public static void Invoke(this Control control, Action action)
        {
            control.Invoke(action);
        }
    }
}
