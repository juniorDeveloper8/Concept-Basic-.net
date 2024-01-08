using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Visual_Data;
using Visual_Logica;

namespace Visual_Plantilla.PagesAspx
{
    public partial class Home : System.Web.UI.Page
    {
        private static DC_ClinicaDataContext dc = new DC_ClinicaDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadUser();
            }
        }
        private void loadUser()
        {
            var usuarios = LogicaUsuario.mostrarUsuariosActivos();

            if (usuarios != null)/*evaluo q los paramtros no sean nulos*/
            {
                ListUser.DataSource = usuarios;
                ListUser.DataBind();
            }
            else
            {
                var usuariosA = dc.Usuarios
                    /*redusco el tamaño de la tabla creo usando linq*/
                    .Where(data => data.estado.Equals('A') &&
                                   (data.ingreso != null && data.ingreso > SqlDateTime.MinValue.Value) &&
                                   (data.modificacion != null && data.modificacion > SqlDateTime.MinValue.Value) &&
                                   (data.eliminacion != null && data.eliminacion > SqlDateTime.MinValue.Value))
                    .ToList()
                    .Select(data => new Usuario
                    {
                        id = data.id,
                        nombre = data.nombre,
                        apellido = data.apellido,
                        usuario1 = data.usuario1,
                        clave = data.clave,
                        email = data.email,
                        sueldo = data.sueldo,
                        estado = data.estado,
                        id_rol = data.id_rol,
                    })
                    .ToList();

                ListUser.DataSource = usuariosA;
                ListUser.DataBind();
            }
        }

        protected void lnkEdit_Click(object sender, ImageClickEventArgs e)
        {
            // Obtén el ID del usuario desde el comando
            ImageButton btn = (ImageButton)sender;
            string userId = btn.CommandArgument;

            // Almacena el ID del usuario en la sesión
            Session["UserIdToEdit"] = userId;

            // Redirecciona a Edit.aspx con el ID del usuario como parámetro
            Response.Redirect("~/PagesAspx/Edit.aspx");
        }

        protected void lnkEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                // Obtén el ID del usuario desde el comando
                ImageButton btn = (ImageButton)sender;
                int userId = Convert.ToInt32(btn.CommandArgument);

                // Obtiene el usuario a eliminar
                Usuario usuario = LogicaUsuario.getUserById(userId);

                if (usuario != null)
                {
                    // Llama a la función para eliminar el usuario
                    bool eliminado = LogicaUsuario.deleteUser(usuario);

                    if (eliminado)
                    {
                        // Muestra un mensaje de éxito
                        ScriptManager.RegisterStartupScript(this, GetType(), "EliminarExitoso", "alert('Usuario eliminado correctamente.');", true);
                    }
                    else
                    {
                        // Muestra un mensaje de error
                        ScriptManager.RegisterStartupScript(this, GetType(), "EliminarError", "alert('Error al intentar eliminar el usuario.');", true);
                    }

                    // Recarga la lista de usuarios después de la eliminación
                    loadUser();
                }
            }
            catch (Exception ex)
            {
                // Maneja errores según sea necesario
            }
        }
    }
}