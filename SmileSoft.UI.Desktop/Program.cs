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

            // Registrar AuthService como singleton
            var authService = new WindowsFormsAuthService();
            AuthServiceProvider.Register(authService);

            // Bucle principal de la aplicación
            while (true)
            {
                Form mainForm = null;
                using (var loginForm = new FormLogin())
                {
                    if (loginForm.ShowDialog() != DialogResult.OK)
                    {
                        break; // Sale del bucle y termina la aplicación
                    }

                    // Determinar el formulario a mostrar según el rol del usuario
                    switch (loginForm.UserRole?.ToUpper())
                    {
                        case "ADMIN":
                            mainForm = new FormHomeSuperUsuario();
                            break;
                        case "SECRETARIO":
                            mainForm = new FormHomeSecretario();
                            break;
                        case "ODONTOLOGO":
                            MessageBox.Show("El portal de Odontólogo está disponible en la aplicación web.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            continue; // Vuelve al login
                        default:
                            MessageBox.Show($"Rol '{loginForm.UserRole}' no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue; // Vuelve al login
                    }
                    mainForm.Text = $"SmileSoft - {loginForm.UserRole} ({loginForm.Username})";
                }

                // Si se determinó un formulario principal, ejecútalo.
                if (mainForm != null)
                {
                    Application.Run(mainForm);
                }

                // Cuando Application.Run() termina (porque el mainForm se cerró),
                // el bucle while(true) vuelve a empezar, mostrando el login de nuevo.
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            // Manejo de excepciones no controladas
            MessageBox.Show($"Error inesperado: {e.Exception.Message}", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}