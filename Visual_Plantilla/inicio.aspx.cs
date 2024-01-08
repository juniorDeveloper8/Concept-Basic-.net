using System;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Claims;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Visual_Data;
using Visual_Logica;

namespace Visual_Plantilla
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica si el usuario está autenticado
                if (!User.Identity.IsAuthenticated)
                {
                    // Resto del código para la autenticación cuando el usuario no está autenticado
                }
                else
                {
                    // El usuario está autenticado, puedes agregar lógica adicional si es necesario
                    // ...

                    // Accede al control en la página maestra
                    Label lblWelcomeMessage = Master?.FindControl("lblWelcomeMessage") as Label;

                    // Verifica si el control se encontró antes de usarlo
                    if (lblWelcomeMessage != null)
                    {
                        // Modifica el texto del control
                        lblWelcomeMessage.Text = $"Bienvenido, {User.Identity.Name}!";
                    }
                }
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PagesAspx/Home.aspx");
            
        }
      
    }
}
