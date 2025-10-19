//using SmileSoft.API.Clients;
//using SmileSoft.Dominio;
//using SmileSoft.UI.Desktop;
//using DTO;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;


//namespace SmileSoft.WindowsForms
//{
//    public partial class FormInicioAdmin : Form
//    {
//        public FormInicioAdmin()
//        {
//            InitializeComponent();
//            // colocar boton de cerrar sesion a la derecha
//            tsbCerrarSesion.Alignment = ToolStripItemAlignment.Right;
//        }
//        public void FormInicioAlternativo_Load(object sender, EventArgs e)
//        {
//            btnEditar.Enabled = false;
//            btnBorrar.Enabled = false;
//        }

//        private string EntidadSeleccionada = string.Empty;
//        private List<Usuario> usuarios = new();
//        private List<ObraSocial> obrasSociales = new();
//        private List<TipoPlan> planes = new();
//        private List<Odontologo> odontologos = new();
//        private List<Paciente> pacientes = new();
//        private List<TipoAtencion> tiposAtencion = new();


//        // Reusable generic loader for any entity T
//        private async Task CargarEntidad<T>(
//            Func<Task<IEnumerable<T>>> getAllAsync,
//            string nombreEntidadPlural
//            )
//        {
//            try
//            {
//                var response = await getAllAsync();
//                var list = response?.ToList() ?? new List<T>();

//                if (list.Count > 0)
//                {
//                    dgvPrincipal.AutoGenerateColumns = true;

//                    // Reset then bind to support proper refresh/sorting
//                    dgvPrincipal.DataSource = null;
//                    dgvPrincipal.DataSource = new BindingSource { DataSource = list };

//                    //onLoaded?.Invoke(list);

//                    // Example: hide Id column if present
//                    if (dgvPrincipal.Columns.Contains("Id"))
//                        dgvPrincipal.Columns["Id"].Visible = false;
//                }
//                else
//                {
//                    dgvPrincipal.DataSource = null;
//                    MessageBox.Show($"No se encontraron {nombreEntidadPlural}.", "Información",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//            catch (HttpRequestException ex)
//            {
//                MessageBox.Show($"Error de conexión al cargar {nombreEntidadPlural}: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            catch (TaskCanceledException ex)
//            {
//                MessageBox.Show($"Timeout al cargar {nombreEntidadPlural}: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error al cargar {nombreEntidadPlural}: {ex.Message}", "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        // Current users loader reuses the generic method
//        //private async Task ObtenerDatos()
//        //{
//        //    await CargarEntidad<Usuario>(
//        //        UsuarioApiClient.GetAllAsync,
//        //        "usuarios",
//        //        list => usuarios = list
//        //    );
//        //}
//        private async void tsbUsuarios_Click(object sender, EventArgs e)
//        {
//            EntidadSeleccionada = "Usuarios";
//            await CargarEntidad<UsuarioDTO>(
//                UsuarioApiClient.GetAllAsync,
//                "usuarios"
//            );
//        }

//        private async void tsbOS_Click(object sender, EventArgs e)
//        {
//            EntidadSeleccionada = "Obras Sociales";
//            await CargarEntidad<ObraSocial>(
//                ObraSocialApiClient.GetAllAsync,
//                "obras sociales"
//            //list => obrasSociales = list
//            );
//        }

//        private async void tsbPlanes_Click(object sender, EventArgs e)
//        {
//            EntidadSeleccionada = "Tipo Plan";
//            await CargarEntidad<TipoPlan>(
//                TipoPlanApiClient.GetAllAsync,
//                "tipos plan"
//            //list => obrasSociales = list
//            );

//        }

//        private async void tsbPacientes_Click(object sender, EventArgs e)
//        {
//            EntidadSeleccionada = "Pacientes";
//            await CargarEntidad<Paciente>(
//                PacienteApiClient.GetAllAsync,
//                "pacientes"
//            //list => obrasSociales = list
//            );
//        }

//        private async void tsbTiposAtencion_Click(object sender, EventArgs e)
//        {
//            EntidadSeleccionada = "Tipo Atencion";
//            await CargarEntidad<TipoAtencion>(
//                TipoAtencionApiClient.GetAllAsync,
//                "tipos de atención"
//            //list => obrasSociales = list
//            );

//        }

//        private void btnVolver_Click(object sender, EventArgs e)
//        {
//            this.Close();

//        }
//        private void dgvPrincipal_SelectionChanged(object sender, EventArgs e)
//        {
//            if (dgvPrincipal.SelectedRows.Count > 0)
//            {
//                btnEditar.Enabled = true;
//                btnBorrar.Enabled = true;
//            }
//            else
//            {
//                btnEditar.Enabled = false;
//                btnBorrar.Enabled = false;

//            }
//        }
//        private async void btnEditar_Click(object sender, EventArgs e)
//        {
//            if (dgvPrincipal.CurrentRow != null)
//            {
//                var selectedEntity = dgvPrincipal.CurrentRow.DataBoundItem;
//                switch (EntidadSeleccionada)
//                {
//                    case "Usuarios":
//                        {
//                            if (selectedEntity is Usuario usuario)
//                            {
//                                var formUsuario = new FormUsuario(usuario.Id);
//                                formUsuario.ShowDialog();
//                                await CargarEntidad<UsuarioDTO>(
//                                    UsuarioApiClient.GetAllAsync,
//                                    "usuarios"
//                                );
//                            }
//                            break;
//                        }
//                    case "Obras Sociales":
//                        {
//                            if (selectedEntity is ObraSocial obraSocial)
//                            {
//                                var formOS = new FormOS(obraSocial.Id);
//                                formOS.ShowDialog();
//                                await CargarEntidad<ObraSocial>(
//                                    ObraSocialApiClient.GetAllAsync,
//                                    "obras sociales"
//                                );
//                            }
//                            break;
//                        }
//                    case "Tipo Plan":
//                        {
//                            if (selectedEntity is TipoPlan tipoPlan)
//                            {
//                                var formPlan = new FormTipoPlan(tipoPlan.Id);
//                                formPlan.ShowDialog();
//                                await CargarEntidad<TipoPlan>(
//                                    TipoPlanApiClient.GetAllAsync,
//                                    "tipos plan"
//                                );
//                            }
//                            break;
//                        }
//                    case "Pacientes":
//                        {
//                            if (selectedEntity is Paciente paciente)
//                            {
//                                var formPaciente = new FormPaciente(paciente.Id);
//                                formPaciente.ShowDialog();
//                                await CargarEntidad<Paciente>(
//                                    PacienteApiClient.GetAllAsync,
//                                    "pacientes"
//                                );
//                            }
//                            break;
//                        }
//                    case "Tipo Atencion":
//                        {
//                            if (selectedEntity is TipoAtencion tipoAtencion)
//                            {
//                                var formTA = new FormTipoAtencion(tipoAtencion.Id);
//                                formTA.ShowDialog();
//                                await CargarEntidad<TipoAtencion>(
//                                    TipoAtencionApiClient.GetAllAsync,
//                                    "tipos atencion"
//                                );
//                            }
//                            break;
//                        }
//                    default:
//                        MessageBox.Show("Seleccione una entidad para editar un registro.", "Información",
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        break;
//                }
//            }
//            else
//            {
//                MessageBox.Show("Seleccione un registro para editar");

//            }
//        }

//        private async void btnBorrar_Click(object sender, EventArgs e)
//        {
//            if (dgvPrincipal.CurrentRow != null)
//            {
//                var selectedEntity = dgvPrincipal.CurrentRow.DataBoundItem;
//                switch (EntidadSeleccionada)
//                {
//                    case "Usuarios":
//                        {
//                            if (selectedEntity is Usuario usuario)
//                            {
//                                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                                if (confirmResult == DialogResult.Yes)
//                                {
//                                    await UsuarioApiClient.DeleteAsync(usuario.Id);
//                                    MessageBox.Show("Usuario eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                                    await CargarEntidad<UsuarioDTO>(
//                                        UsuarioApiClient.GetAllAsync,
//                                        "usuarios"
//                                    );
//                                }
//                            }
//                            break;
//                        }
//                    case "Obras Sociales":
//                        {
//                            if (selectedEntity is ObraSocial obraSocial)
//                            {
//                                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar esta obra social?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                                if (confirmResult == DialogResult.Yes)
//                                {
//                                    await ObraSocialApiClient.DeleteAsync(obraSocial.Id);
//                                    MessageBox.Show("Obra Social eliminada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                                    await CargarEntidad<ObraSocial>(
//                                        ObraSocialApiClient.GetAllAsync,
//                                        "obras sociales"
//                                    );
//                                }
//                            }
//                            break;
//                        }
//                    case "Tipo Plan":
//                        {
//                            if (selectedEntity is TipoPlan tipoPlan)
//                            {
//                                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este tipo de plan?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                                if (confirmResult == DialogResult.Yes)
//                                {
//                                    await TipoPlanApiClient.DeleteAsync(tipoPlan.Id);
//                                    MessageBox.Show("Tipo de Plan eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                                    await CargarEntidad<TipoPlan>(
//                                        TipoPlanApiClient.GetAllAsync,
//                                        "tipos plan"
//                                    );
//                                }
//                            }
//                            break;
//                        }
//                    case "Pacientes":
//                        {
//                            if (selectedEntity is Paciente paciente)
//                            {
//                                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este paciente?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                                if (confirmResult == DialogResult.Yes)
//                                {
//                                    await PacienteApiClient.DeleteAsync(paciente.Id);
//                                    MessageBox.Show("Paciente eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                                    await CargarEntidad<Paciente>(
//                                        PacienteApiClient.GetAllAsync,
//                                        "pacientes"
//                                    );
//                                }
//                            }
//                            break;
//                        }
//                    case "Tipo Atencion":
//                        {
//                            if (selectedEntity is TipoAtencion tipoAtencion)
//                            {
//                                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este tipo de atención?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
//                                if (confirmResult == DialogResult.Yes)
//                                {
//                                    await TipoAtencionApiClient.DeleteAsync(tipoAtencion.Id);
//                                    MessageBox.Show("Tipo de Atención eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                                    await CargarEntidad<TipoAtencion>(
//                                        TipoAtencionApiClient.GetAllAsync,
//                                        "tipos atencion"
//                                    );
//                                }
//                            }
//                            break;
//                        }
//                    default:
//                        MessageBox.Show("Seleccione una entidad para eliminar un registro.", "Información",
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        break;
//                }
//            }
//        }

//        private async void btnCrear_Click(object sender, EventArgs e)
//        {
//            switch (EntidadSeleccionada)
//            {
//                case "Usuarios":
//                    {
//                        var formUsuario = new FormUsuario();
//                        formUsuario.ShowDialog();
//                        await CargarEntidad<UsuarioDTO>(
//                            UsuarioApiClient.GetAllAsync,
//                            "usuarios"
//                        );
//                        break;
//                    }
//                case "Obras Sociales":
//                    {
//                        var formOS = new FormOS();
//                        formOS.ShowDialog();
//                        await CargarEntidad<ObraSocial>(
//                            ObraSocialApiClient.GetAllAsync,
//                            "obras sociales"
//                        );
//                        break;
//                    }
//                case "Tipo Plan":
//                    {
//                        var formPlan = new FormTipoPlan();
//                        formPlan.ShowDialog();
//                        await CargarEntidad<TipoPlan>(
//                            TipoPlanApiClient.GetAllAsync,
//                            "tipos plan"
//                        );
//                        break;
//                    }
//                case "Pacientes":
//                    {
//                        var formPaciente = new FormPaciente();
//                        formPaciente.ShowDialog();
//                        await CargarEntidad<Paciente>(
//                            PacienteApiClient.GetAllAsync,
//                            "pacientes"
//                        );
//                        break;
//                    }
//                case "Tipo Atencion":
//                    {
//                        var formTA = new FormTipoAtencion();
//                        formTA.ShowDialog();
//                        await CargarEntidad<TipoAtencion>(
//                            TipoAtencionApiClient.GetAllAsync,
//                            "tipos atencion"
//                        );
//                        break;
//                    }
//                default:
//                    MessageBox.Show("Seleccione una entidad para crear un nuevo registro.", "Información",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    break;
//            }

//        }

//        private void tsbCerrarSesion_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }
//    }
//}
