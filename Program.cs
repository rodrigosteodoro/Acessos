using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acessos
{
    internal static class Program
    {
        // Program.cs
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var loginForm = new Loginfrm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Geral()); // Só inicia o loop da aplicação se o login for OK
                }
                else
                {
                    // Se o login for cancelado ou falhar, encerra o app
                    Application.Exit();
                }
            }
        }


    }
}
