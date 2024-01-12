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
    public partial class Crear : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si hay información en la sesión
            if (Session["RedirectMessage"] != null && Session["RedirectUrl"] != null)
            {
                // Obtener el mensaje de éxito de la sesión
                string successMessage = Session["RedirectMessage"].ToString();

                // Mostrar el mensaje de éxito
                lblMensaje.Text = successMessage;
                lblMensaje.ForeColor = System.Drawing.Color.Green;

                // Limpiar la información de la sesión para que no se muestre en futuras recargas de la página
                Session.Remove("RedirectMessage");
                Session.Remove("RedirectUrl");
            }
            // para mostra la descirpcion de los roles
            if (!IsPostBack)
            {
                try
                {
                    // Llenar el DropDownList solo si no es una devolución de postback
                    foreach (var rol in LogicaUsuario.mostrarRoles())
                    {
                        ddlRoles.Items.Add(new ListItem(rol.Item2, rol.Item1.ToString()));
                    }
                }
                catch (Exception ex)
                {
                    // Manejar el error de manera adecuada, por ejemplo, mostrar un mensaje al usuario
                    lblMensaje.Text = $"Error al cargar roles: {ex.Message}";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string usuario = txtUsuario.Text;
                string clave = txtClave.Text;
                string correo = txtCorreo.Text;
                int idRol = int.Parse(ddlRoles.SelectedValue);

                // Lógica para insertar el nuevo usuario en la base de datos
                LogicaUsuario.insertarUsuario(nombre, apellido, usuario, clave, correo, "A", idRol);

                // Mostrar mensaje de éxito
                Session["RedirectMessage"] = "Usuario creado correctamente.";
                Session["RedirectUrl"] = "~/PagesAspx/Home.aspx";

                // Redirigir a la página de inicio
                Response.Redirect("~/PagesAspx/Home.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al insertar usuario: {ex.Message}";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}