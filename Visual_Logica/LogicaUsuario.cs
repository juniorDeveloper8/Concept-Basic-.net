using System;
using System.Collections.Generic;
using System.Linq;
using Visual_Data;

namespace Visual_Logica
{
    public class LogicaUsuario
    {
        private static DC_ClinicaDataContext dc = new DC_ClinicaDataContext();


        /*esto para ver la descripcion de los roles al momento de hacer la insercion */
        


        public static Usuario LoginUsuario(string usuario, string clave)
        {
            try
            {
                var user = dc.Usuarios.FirstOrDefault(data => data.usuario1.Equals(usuario)
                    && data.clave.Equals(clave) && data.estado.Equals('A'));
                return user;
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                throw;
            }
        }

        public static bool verificarExistenciUsuario(string usuario)
        {

            try
            {
                var info = dc.Usuarios.FirstOrDefault(data => data.usuario1.Equals(usuario));
                if (info == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                throw;
            }
        }

        public static void aumentarIntetnos(String usuario)
        {
            dc.aumentarIntentos(usuario);
        }

        public static void BloquearUsuario(string usuario)
        {
            dc.bloquearUsuario(usuario);
        }

        public static Usuario verificarIntentos(string usuario)
        {
            try
            {
                var intentos = dc.Usuarios.Where(data => data.usuario1.Equals(usuario)).FirstOrDefault();
                return intentos;
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                throw;
            }
        }

        public static bool verificarEstadoUsuario(string usuario)
        {
            try
            {
                var existeUsuarioInactivo = dc.Usuarios.Any(data => data.estado.Equals('I') && data.usuario1.Equals(usuario));
                return existeUsuarioInactivo;
            }
            catch (Exception e)
            {
                string mensaje = e.Message;
                throw;
            }
        }

        public static void reiniciarIntentos(string usuario)
        {
            dc.reiniciarIntentos(usuario);
        }


        public static int intentos(string usuario)
        {
            int intento = dc.Usuarios.Where(data => data.usuario1.Equals(usuario))
                .Select(data => data.intentos ?? 0)
                .FirstOrDefault();
            return intento;
        }

        // funcion listar por id

        public static Usuario getUserById(int idUser)
        {
            try
            {
                var user = dc.Usuarios.Where(data => data.estado.Equals("A")
                && data.id.Equals(idUser));

                return user.FirstOrDefault();
            }
            catch (Exception)
            {
                throw new ArgumentException("Error en getUserById - Consulta por Id");
            }
        }
        // funcion listar
        public static List<Usuario> mostrarUsuariosActivos()
        {
            var usuarios = dc.Usuarios.Where(data => data.estado.Equals('A')).ToList().Select(data => new Usuario
            {
                id = data.id,
                nombre = data.nombre,
                apellido = data.apellido,
                usuario1 = data.usuario1,
                clave = data.clave,
                email = data.email,
                sueldo = data.sueldo,
                ingreso = data.ingreso,
                estado = data.estado,
                id_rol = data.id_rol,

            }).ToList();
            return usuarios;
        }
        // funcion de insertar
        public static Usuario insertarUsuario(string nombre, string apellido, string usuario, string clave, string correo, string estado, int rol)
        {
            var nuwevoUsuario = new Usuario
            {
                nombre = nombre,
                apellido = apellido,
                usuario1 = usuario,
                clave = clave,
                email = correo,
                estado = estado,
                id_rol = rol,
                sueldo = 500,
            };
            dc.Usuarios.InsertOnSubmit(nuwevoUsuario);
            dc.SubmitChanges();
            return nuwevoUsuario;
        }
        // funcion actualizar principal
        public static void ActualizarUsuarioFP(int id, string nombre, string apellido, string usuario, string clave, string correo, string estado, int rol)
        {
            var usuarioActualizar = dc.Usuarios.SingleOrDefault(data => data.id == id);

            if (usuarioActualizar != null)
            {
                usuarioActualizar.id_rol = rol;
                usuarioActualizar.nombre = nombre;
                usuarioActualizar.apellido = apellido;
                usuarioActualizar.usuario1 = usuario;
                usuarioActualizar.clave = clave;
                usuarioActualizar.email = correo;
                usuarioActualizar.estado = estado;

                dc.SubmitChanges();
            }
        }
        // funcion actualizar 
        public static void ActualizarUsuario(int id, string nombre, string apellido, string usuario, string clave, string correo, string estado, int rol)
        {
            using (DC_ClinicaDataContext dc = new DC_ClinicaDataContext())
            {
                // Obtener usuario antes de la actualización
                var usuarioAntesDeActualizacion = dc.Usuarios.SingleOrDefault(data => data.id == id);

                if (usuarioAntesDeActualizacion != null)
                {
                    // Crear una copia del usuario antes de la actualización
                    Usuario copiaUsuarioAntesDeActualizacion = new Usuario
                    {
                        id_rol = usuarioAntesDeActualizacion.id_rol,
                        nombre = usuarioAntesDeActualizacion.nombre,
                        apellido = usuarioAntesDeActualizacion.apellido,
                        usuario1 = usuarioAntesDeActualizacion.usuario1,
                        clave = usuarioAntesDeActualizacion.clave,
                        email = usuarioAntesDeActualizacion.email,
                        estado = usuarioAntesDeActualizacion.estado
                        // Añadir otras propiedades según sea necesario
                    };

                    // Actualizar el usuario
                    var usuarioActualizar = dc.Usuarios.SingleOrDefault(data => data.id == id);
                    usuarioActualizar.id_rol = rol;
                    usuarioActualizar.nombre = nombre;
                    usuarioActualizar.apellido = apellido;
                    usuarioActualizar.usuario1 = usuario;
                    usuarioActualizar.clave = clave;
                    usuarioActualizar.email = correo;
                    usuarioActualizar.estado = estado;

                    dc.SubmitChanges();

                }
            }
        }
        // funcion eliminar
        public static void eliminarUsuario(int id)
        {
            var eliminarUser = dc.Usuarios.SingleOrDefault(data => data.id == id);

            if (eliminarUser != null)
            {
                dc.Usuarios.DeleteOnSubmit(eliminarUser);
                dc.SubmitChanges();
            }
        }
        // lisatar por roles
        public static List<Tuple<int, string>> mostrarRoles()
        {
            try
            {
                var listaRol = dc.roles.Where(data => data.estado.Equals('A')).ToList();

                // Mapear a lista de tuplas con id y descripción
                var roles = listaRol.Select(r => new Tuple<int, string>(r.id, r.descripcion)).ToList();

                return roles;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener roles: {ex.Message}");
                throw;
            }
        }

        // funciones de la auditoria
        public static void auditoria(string usuario, string tipo, int codigo, string newValue, string oldValue, string estado)
        {
            DC_ClinicaDataContext dc = new DC_ClinicaDataContext();
            dc.save_auditoria(usuario, tipo, codigo, newValue, oldValue, estado);
        }

        public static int lastReg()
        {
            var last = dc.Usuarios.OrderByDescending(data => data.id).Select(data => data.id).FirstOrDefault();
            return last;
        }

        public static Usuario ObtenerUsuarioAntesDeActualizacion(int id)
        {
            using (DC_ClinicaDataContext dc = new DC_ClinicaDataContext())
            {
                try
                {
                    Usuario usuarioAntiguo = dc.Usuarios.SingleOrDefault(data => data.id == id);
                    return usuarioAntiguo;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al obtener usuario antes de la actualización: {ex.Message}");
                    return null;
                }
            }
        }
        // funciones actualizar del presi
        public static bool updateUser(Usuario user)
        {
            try
            {
                user.modificacion = DateTime.Now;
                dc.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool deleteUser(Usuario user)
        {
            try
            {
                user.eliminacion = DateTime.Now;
                user.estado = "I";
                dc.SubmitChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
