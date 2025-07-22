using DTO;
using SmileSoft.Dominio;
namespace SmileSoft.UI.Desktop
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form1 = new FormPostPaciente();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            form1.Show();
            Application.Run(new FormGetPacientes());
        }
    }
}