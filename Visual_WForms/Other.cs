using System;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using Visual_Data;
using Visual_Logica;

namespace Visual_WForms
{
    public partial class Other : Form
    {
        string usu_conectado;
        public Other()
        {
            InitializeComponent();
            usu_conectado = Login.usuarioConectado;
        }

        private void Other_Load(object sender, EventArgs e)
        {
            mostrarDatosTabla();
            //mostrarRoles();
            update();
        }


        public void cargarUsuarioConectado(string conectado)
        {
            txt_conectado.Text = $"{conectado}";
        }
        //comentado momentaneamente

        //public void mostrarRoles()
        //{
        //    var roles = LogicaUsuario.mostrarRoles();
        //    roles.Insert( new role
        //    {
        //        id = 
        //        descripcion = "Selecciona Uno..."
        //    });
        //    cmb_rol.Items.Clear();
        //    cmb_rol.Items.AddRange(roles.ToArray());
        //    cmb_rol.DisplayMember = "descripcion";
        //    cmb_rol.ValueMember = "id";
        //    cmb_rol.SelectedIndex = 0;
        //}

        public void mostrarDatosTabla()
        {
            gv_table.DataSource = LogicaUsuario.mostrarUsuariosActivos();// usando logica acortada para listar
            gv_table.Refresh();
        }
        public void limpiarCampos()
        {
            txt_nombre.Text = "";
            txt_apellido.Text = "";
            txt_usuario.Text = "";
            txt_clave.Text = "";
            txt_correo.Text = "";
            txt_estado.Text = "";
            cmb_rol.SelectedIndex = 0;
        }

        private void gv_table_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gv_table.Rows.Count)
            {
                DataGridViewRow filaSeleccionada = gv_table.Rows[e.RowIndex];

                txt_id.Text = filaSeleccionada.Cells["id"].Value.ToString();
                txt_nombre.Text = filaSeleccionada.Cells["nombre"].Value.ToString();
                txt_apellido.Text = filaSeleccionada.Cells["apellido"].Value.ToString();
                txt_usuario.Text = filaSeleccionada.Cells["usuario1"].Value.ToString();
                txt_clave.Text = filaSeleccionada.Cells["clave"].Value.ToString();
                txt_correo.Text = filaSeleccionada.Cells["email"].Value.ToString();
                txt_estado.Text = filaSeleccionada.Cells["estado"].Value.ToString();
                cmb_rol.SelectedIndex = int.Parse(filaSeleccionada.Cells["id_rol"].Value.ToString());
            }
        }

        private void btn_insertar_Click(object sender, EventArgs e)
        {
            string nombre = txt_nombre.Text;
            string apellido = txt_apellido.Text;
            string usuario = txt_usuario.Text;
            string clave = txt_clave.Text;
            string correo = txt_correo.Text;
            string estado = txt_estado.Text;
            int rol = cmb_rol.SelectedIndex;

            string conectado = usu_conectado;

            if (nombre == "" || apellido == "" || usuario == "" || clave == "" || correo == "" || estado == "" || rol == 0)
            {
                MessageBox.Show("Debe llenar todos los campos", "Sistema XYZ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string patternNombreApellido = "^[a-zA-Z]*$";
                Regex regexNA = new Regex(patternNombreApellido);

                string patternEstado = "^[AI]*$";
                Regex regexE = new Regex(patternEstado);

                string patternCorreoElectronico = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                Regex regexC = new Regex(patternCorreoElectronico);


                if (!regexNA.IsMatch(nombre) || !regexNA.IsMatch(apellido) || !regexNA.IsMatch(usuario))
                {
                    MessageBox.Show("El campo Apellido solo debe contener letras y espacios.", "Error");
                    return; // Salir del método sin realizar la inserción
                }
                if (!regexE.IsMatch(estado))
                {
                    MessageBox.Show("El campo Estado solo debe contener A (Activo) o I (incativo).", "Error");
                    return; // Salir del método sin realizar la inserción
                }
                if (!regexC.IsMatch(correo))
                {
                    MessageBox.Show("El correo no es Correcto.", "Error");
                    return; // Salir del método sin realizar la inserción
                }
                LogicaUsuario.insertarUsuario(nombre, apellido, usuario, clave, correo, estado, rol); ;
                limpiarCampos();
                MessageBox.Show("Usuario Insertado", "Sistema Tabla", MessageBoxButtons.OK, MessageBoxIcon.Information);
                mostrarDatosTabla();

                int lastUser = LogicaUsuario.lastReg();

            }
        }

        private void btn_modificar_Click(object sender, EventArgs e)
        {
            if (gv_table.SelectedRows.Count > 0)
            {
                int id = int.Parse(txt_id.Text);

                // Obtener usuario antes de la actualización
                Usuario usuarioAntiguo;
                using (DC_ClinicaDataContext dc = new DC_ClinicaDataContext())
                {
                    usuarioAntiguo = dc.Usuarios.SingleOrDefault(data => data.id == id);
                }

                // Actualizar el usuario
                using (DC_ClinicaDataContext dc = new DC_ClinicaDataContext())
                {
                    var usuarioActualizar = dc.Usuarios.SingleOrDefault(data => data.id == id);

                    if (usuarioActualizar != null)
                    {
                        // Actualizar propiedades según tus necesidades
                        usuarioActualizar.nombre = txt_nombre.Text;
                        usuarioActualizar.apellido = txt_apellido.Text;
                        usuarioActualizar.usuario1 = txt_usuario.Text;
                        usuarioActualizar.clave = txt_clave.Text;
                        usuarioActualizar.email = txt_correo.Text;
                        usuarioActualizar.estado = txt_estado.Text;

                        dc.SubmitChanges();
                        gv_table.Refresh();
                    }
                }

                string conectado = usu_conectado;

                // Obtener el usuario después de la actualización
                Usuario usuarioNuevo = LogicaUsuario.ObtenerUsuarioAntesDeActualizacion(id);

                // Obtener los valores antiguos y nuevos
                if (usuarioNuevo != null)
                {
                    string cambios = ObtenerValoresAntiguosYActuales(usuarioAntiguo, usuarioNuevo);
                    LogicaUsuario.auditoria(conectado, "U", id, "A", cambios, usuarioAntiguo.estado);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el usuario después de la actualización.");
                }

                mostrarDatosTabla();
            }
            else
            {
                MessageBox.Show("No se pudo obtener el usuario antes de la actualización.");
            }

            mostrarDatosTabla();

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {

            int id = int.Parse(txt_id.Text.ToString());
            LogicaUsuario.eliminarUsuario(id);
            mostrarDatosTabla();

            //LogicaUsuario.auditoria("test", "D", id, "A");

        }

        private void btn_limpiarCampos_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        public static string ObtenerUsuarioAntesDeActualizacion(int id, Usuario usuarioAntiguo, Usuario usuarioNuevo)
        {
            using (DC_ClinicaDataContext dc = new DC_ClinicaDataContext())
            {
                Usuario usuarioExistente = dc.Usuarios.SingleOrDefault(data => data.id == id);

                if (usuarioExistente != null && usuarioAntiguo != null && usuarioNuevo != null)
                {

                    // Obtener los valores nuevos
                    string newValue = ObtenerValoresNuevos(usuarioNuevo);

                    // Comparar y devolver los valores antiguos y nuevos
                    string cambios = $"NewValue: {newValue}";

                    return cambios;
                }
            }
            return string.Empty;
        }

        private static string ObtenerValoresNuevos(Usuario usuario)
        {
            return $"Nombre: {usuario.nombre}, Apellido: {usuario.apellido}, " +
                   $"Usuario: {usuario.usuario1}, Clave: {usuario.clave}, " +
                   $"Correo: {usuario.email}, Estado: {usuario.estado}";
        }

        private string ObtenerValoresAntiguos(Usuario usuarioAntiguo, int id)
        {
            if (usuarioAntiguo != null)
            {
                // Comparar y devolver los valores antiguos y nuevos según tus necesidades
                string cambios = $"Nombre: {usuarioAntiguo.nombre} -> {txt_nombre.Text}, " +
                                 $"Apellido: {usuarioAntiguo.apellido} -> {txt_apellido.Text}, " +
                                 $"Usuario: {usuarioAntiguo.usuario1} -> {txt_usuario.Text}, " +
                                 $"Clave: {usuarioAntiguo.clave} -> {txt_clave.Text}, " +
                                 $"Correo: {usuarioAntiguo.email} -> {txt_correo.Text}, " +
                                 $"Estado: {usuarioAntiguo.estado} -> {txt_estado.Text}";

                return cambios;
            }
            return string.Empty;
        }
        private string ObtenerValoresAntiguosYActuales(Usuario usuarioAntiguo, Usuario usuarioNuevo)
        {
            if (usuarioAntiguo != null && usuarioNuevo != null)
            {
                // Obtener los valores antiguos
                string oldValue = $"Nombre: {usuarioAntiguo.nombre}, Apellido: {usuarioAntiguo.apellido}, " +
                                  $"Usuario: {usuarioAntiguo.usuario1}, Clave: {usuarioAntiguo.clave}, " +
                                  $"Correo: {usuarioAntiguo.email}, Estado: {usuarioAntiguo.estado}";

                // Obtener los valores nuevos
                string newValue = $"Nombre: {usuarioNuevo.nombre}, Apellido: {usuarioNuevo.apellido}, " +
                                  $"Usuario: {usuarioNuevo.usuario1}, Clave: {usuarioNuevo.clave}, " +
                                  $"Correo: {usuarioNuevo.email}, Estado: {usuarioNuevo.estado}";

                // Comparar y devolver los valores antiguos y nuevos
                string cambios = $"OldValue: {oldValue}, NewValue: {newValue}";

                return cambios;
            }
            return string.Empty;
        }

        //funcion actulizar principal 

        private void update()
        {
            try
            {
                if (int.TryParse(txt_id.ToString(), out var codigoUsu))

                {
                    var user = LogicaUsuario.getUserById(codigoUsu);

                    if (user != null)
                    {
                        user.nombre = txt_nombre.Text;
                        user.apellido = txt_apellido.Text;
                        user.usuario1 = txt_usuario.Text;
                        user.clave = txt_clave.Text;
                        user.email = txt_correo.Text;
                        user.estado = txt_estado.Text;
                        user.modificacion = DateTime.Now;

                        if (LogicaUsuario.updateUser(user))
                        {
                            MessageBox.Show("Registro Modificado de manera EXITOSA", "Sistema Medico XYZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            mostrarDatosTabla();
                            return;
                        }
                    }
                    MessageBox.Show("Error al actualizar el usuario", "Sistema Medico XYZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Ingrese un valor válido para el ID de usuario", "Sistema Medico XYZ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registro NO Modificado - Error: " + ex.Message, "Sistema Medico XYZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
