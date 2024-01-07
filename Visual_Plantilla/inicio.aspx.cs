using System;
using System.Data.SqlTypes;
using System.Linq;
using System.Web.UI.WebControls;
using Visual_Data;
using Visual_Logica;

namespace Visual_Plantilla
{
    public partial class inicio : System.Web.UI.Page
    {
        private static DC_ClinicaDataContext dc = new DC_ClinicaDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            loadUser();
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


    }
}
