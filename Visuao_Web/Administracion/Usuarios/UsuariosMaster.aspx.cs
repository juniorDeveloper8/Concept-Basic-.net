using System;
using Visual_Logica;

namespace Visuao_Web.Administracion.Usuarios
{

    public partial class UsuariosMaster : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                mostrarUsuarios();
            }
        }

        private void mostrarUsuarios()
        {
            gdvUsuarios.DataSource = LogicaUsuario.mostrarUsuariosActivos();
            gdvUsuarios.DataBind();
        }

        protected void gdvUsuarios_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e) // evento rowcommand
        {
            string codigo = e.CommandName.ToLower();
            if (e.CommandName.Equals("Modificar"))
            {
                Response.Redirect("UsuariosNuevos.aspx?=cod" + codigo);
            }
            else if (e.CommandName.Equals("Eliminar"))
            {
                var user = LogicaUsuario.getUserById(int.Parse(codigo));
                if (user != null)
                {   
                    LogicaUsuario.deleteUser(user);
                    mostrarUsuarios();
                    Response.Write("<scirpt>alert('Eliminado correctamente')</script>");
                }
            }
        }
    }
}