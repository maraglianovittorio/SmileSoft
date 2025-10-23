using DTO;
using SmileSoft.API.Clients;
using SmileSoft.Dominio;
using SmileSoft.API.Auth.WindowsForms;
using SmileSoft.UI.Desktop;

namespace SmileSoft.WindowsForms
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();

            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            Task.Run(async () => await MainAsync()).GetAwaiter().GetResult();
        }
        static async Task MainAsync()
        {
            // Registrar AuthService en singleton
            var authService = new WindowsFormsAuthService();
            AuthServiceProvider.Register(authService);

            // Loop principal de autenticaci�n
            while (true)
            {

                if (!await authService.IsAuthenticatedAsync())
                {
                    var loginForm = new FormLogin();
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        // Usuario cancel� login, cerrar aplicaci�n
                        return;
                    }
                }

                try
                {
                    //Application.Run(new FormHomeAtencion());
                    break; // La aplicaci�n se cerr� normalmente
                }
                catch (UnauthorizedAccessException ex)
                {
                    // Sesi�n expirada, mostrar mensaje y volver al login
                    MessageBox.Show(ex.Message, "Sesi�n Expirada",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    // El loop continuar� y volver� a mostrar login
                }
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if (e.Exception is UnauthorizedAccessException)
            {
                // Sesi�n expirada
                MessageBox.Show("Su sesi�n ha expirado. Debe volver a autenticarse.", "Sesi�n Expirada",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Reiniciar la aplicaci�n para volver al login
                Application.Restart();
            }
            else
            {
                // Otras excepciones, mostrar error gen�rico
                MessageBox.Show($"Error inesperado: {e.Exception.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}