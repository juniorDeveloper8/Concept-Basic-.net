using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual_Data;
using Visual_Logica;

namespace Visual_WForms
{
    public partial class Login : Form
    {
        public static string usuarioConectado { get;private set; }
        public Login()
        {
            InitializeComponent();
        }

        public void inicioUsuario()
        {
            var usuario = txt_usuario.Text;
            var clave = txt_clave.Text;

            var existe = LogicaUsuario.verificarExistenciUsuario(usuario);
            if (existe)
            {
                //MessageBox.Show("Existe", "SYSTEMA XYZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var estado = LogicaUsuario.verificarEstadoUsuario(usuario);
                if (estado == false)
                {
                    //MessageBox.Show("Activo", "SYSTEMA XYZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var login = LogicaUsuario.LoginUsuario(usuario, clave);
                    if (login != null)
                    {
                        int rol = login.id_rol;
                        string rolDes = "";
                        if (rol == 1)
                        {
                            rolDes = "Admin";
                        }
                        else if (rol == 2)
                        {
                            rolDes = "vendedor";
                        }
                        MessageBox.Show("Bienvenido " + usuario + " " + rolDes + " ", "SYSTEMA XYZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        usuarioConectado = usuario;
                        this.Hide();
                        Other otro = new Other();
                        otro.Show();

                        
                    }
                    else
                    {

                        LogicaUsuario.aumentarIntetnos(usuario);
                        int nn  = LogicaUsuario.intentos(usuario);
                        if (nn < 3)
                        {
                            MessageBox.Show("Tiene como máximo 3 intentos, este es su intento #" + nn, "SYSTEMA XYZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            LogicaUsuario.BloquearUsuario(usuario);
                            MessageBox.Show("Su Usuario " + usuario + " ha sido bloqueado por exceder los intentos ", "SYSTEMA XYZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        MessageBox.Show("Contraseña incorrecta " + usuario, "SYSTEMA XYZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("SU USUARIO ESTA BLOQUEADO, COMUNIQUESE CON UN ADMINISTRADOR", "SYSTEMA XYZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("No Existe este Usuario", "SYSTEMA XYZ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void bnt_aceptar_Click(object sender, EventArgs e)
        {
            inicioUsuario();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
