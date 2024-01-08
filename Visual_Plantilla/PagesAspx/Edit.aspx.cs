using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Visual_Data;
using Visual_Logica;

namespace Visual_Plantilla.PagesAspx
{
    public partial class Edit : System.Web.UI.Page
    {
        // Asegúrate de tener esta variable en tu clase, así podrás acceder a tu DataContext
        private static DC_ClinicaDataContext dc = new DC_ClinicaDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosUsuario();
            }
        }

        private void CargarDatosUsuario()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["userId"]))
            {
                int userId = Convert.ToInt32(Request.QueryString["userId"]);
                Usuario usuario = LogicaUsuario.getUserById(userId);

                if (usuario != null)
                {
                    txtNombreEdit.Text = usuario.nombre;
                    txtApellidoEdit.Text = usuario.apellido;
                    txtUsuarioEdit.Text = usuario.usuario1;
                    txtClaveEdit.Text = usuario.clave;
                    txtCorreoEdit.Text = usuario.email;
                    txtEstadoEdit.Text = usuario.estado;
                    txtRolEdit.Text = usuario.id_rol.ToString();
                }
            }
            else if (Session["UserIdToEdit"] != null)
            {
                int userId = Convert.ToInt32(Session["UserIdToEdit"]);
                Usuario usuario = LogicaUsuario.getUserById(userId);

                if (usuario != null)
                {
                    txtNombreEdit.Text = usuario.nombre;
                    txtApellidoEdit.Text = usuario.apellido;
                    txtUsuarioEdit.Text = usuario.usuario1;
                    txtClaveEdit.Text = usuario.clave;
                    txtCorreoEdit.Text = usuario.email;
                    txtEstadoEdit.Text = usuario.estado;
                    txtRolEdit.Text = usuario.id_rol.ToString();
                }
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            try
            {
                int userId;

                if (int.TryParse(Request.QueryString["userId"], out userId) || Session["UserIdToEdit"] != null)
                {
                    // Se intenta obtener userId de la URL, si no, se usa la sesión
                    userId = userId == 0 ? Convert.ToInt32(Session["UserIdToEdit"]) : userId;

                    string nuevoNombre = txtNombreEdit.Text;
                    string nuevoApellido = txtApellidoEdit.Text;
                    string nuevoUsuario = txtUsuarioEdit.Text;
                    string nuevoClave = txtClaveEdit.Text;
                    string nuevoCorreo = txtCorreoEdit.Text;
                    string nuevoEstado = txtEstadoEdit.Text;
                    int nuevoRol = int.Parse(txtRolEdit.Text);

                    // Lógica para actualizar el usuario
                    LogicaUsuario.ActualizarUsuarioFP(userId, nuevoNombre, nuevoApellido, nuevoUsuario, nuevoClave, nuevoCorreo, nuevoEstado, nuevoRol);

                    // Redirecciona a la página de inicio después de la actualización
                    Response.Redirect("../inicio.aspx");
                }
            }
            catch (Exception ex)
            {
                // Maneja errores según sea necesario
            }
        }
    }
}