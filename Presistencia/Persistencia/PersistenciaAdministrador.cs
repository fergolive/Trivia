using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia
{
    internal class PersistenciaAdministrador : MarshalByRefObject, IPersistenciaAdministrador
    {
        //singleton
        private static PersistenciaAdministrador _miPersistencia=null;
        private PersistenciaAdministrador() { }
        public static PersistenciaAdministrador GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaAdministrador();
            return _miPersistencia;
        }

        public void Alta_Administrador(Administrador a)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Alta_Administrador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter documento = new SqlParameter("@documento", a.Documento);
            SqlParameter user = new SqlParameter("@user", a.User);
            SqlParameter pass = new SqlParameter("@pass", a.Pass);
            SqlParameter nombre = new SqlParameter("@nombre", a.Nombre);
            SqlParameter genestadisticas = new SqlParameter("@genEstadisticas", a.GenEstadisticas);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(documento);
            oComando.Parameters.Add(user);
            oComando.Parameters.Add(pass);
            oComando.Parameters.Add(nombre);
            oComando.Parameters.Add(genestadisticas);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

            
                if (resultado == 2)
                    throw new Exception("Ya existe el nombre de usuario");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }


        public void Modificacion_Administrador(Administrador a)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Modificacion_Administrador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter documento = new SqlParameter("@documento", a.Documento);
            SqlParameter user = new SqlParameter("@user", a.User);
            SqlParameter pass = new SqlParameter("@pass", a.Pass);
            SqlParameter nombre = new SqlParameter("@nombre", a.Nombre);
            SqlParameter genestadisticas = new SqlParameter("@genEstadisticas", a.GenEstadisticas);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(documento);
            oComando.Parameters.Add(user);
            oComando.Parameters.Add(pass);
            oComando.Parameters.Add(nombre);
            oComando.Parameters.Add(genestadisticas);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 2)
                    throw new Exception("Ya existe un administrador con ese documento");
              

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public void Baja_Administrador(Administrador a) 
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Baja_Administrador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter documento = new SqlParameter("@documento", a.Documento);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(documento);
            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == 2)
                    throw new Exception("No existe ese documento");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public List<Administrador> Listar_Administrador() //Listar todos los Administradores
        {
            int documento;
            String user;
            String pass;
            String nombre;
            bool genEstadisticas;
            List<Administrador> administradores = new List<Administrador>();

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Listar_Administrador" ,oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    documento = Convert.ToInt32(oReader["documento"]);
                    user = (String)oReader["user"];
                    pass = (String)oReader["pass"];
                    nombre = (String)oReader["nombre"];
                    genEstadisticas = Convert.ToBoolean(oReader["genEstadisticas"]);
                    
                    Administrador a=new Administrador(documento,user,pass,nombre,genEstadisticas);

                    administradores.Add(a);
                }


                oReader.Close();
            }
            catch (Exception oEx)
            {
                throw new Exception(oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return administradores;
        } 

        public Administrador Buscar_Administrador(int documento) //Buscar un Administrador por documento
        {
            int doc;
            String user;
            String pass;
            String nombre;
            bool genEstadisticas;
            Administrador admin=null;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Administrador " + documento ,oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    doc = Convert.ToInt32(oReader["documento"]);
                    user = (String)oReader["usuario"];
                    pass = (String)oReader["pass"];
                    nombre = (String)oReader["nombre"];
                    genEstadisticas = Convert.ToBoolean(oReader["genEstadisticas"]);
                    
                    admin=new Administrador(documento,user,pass,nombre,genEstadisticas);

                }


                oReader.Close();
            }
            catch (Exception oEx)
            {
                throw new Exception(oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return admin;
        } 

        public Administrador Logueo_Administrador(String user,String pass) //Buscar un jugador por documento
        {
            int documento;
            String user1;
            String pass1;
            String nombre;
            Administrador usuarioLogueado=null;
            bool genEstadisticas=false;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Logueo_Administrador " + user+","+pass, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    documento = Convert.ToInt32(oReader["documento"]);
                    user1 = (String)oReader["usuario"];
                    pass1 = (String)oReader["pass"];
                    nombre = (String)oReader["nombre"];
                    genEstadisticas=Convert.ToBoolean(oReader["genEstadisticas"]);

                    usuarioLogueado = new Administrador(documento, user1, pass1, nombre,genEstadisticas);

                }


                oReader.Close();
            }
            catch (Exception oEx)
            {
                throw new Exception(oEx.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return usuarioLogueado;
        }

        public void CrearUsuarioLogueoBD(String usuario, String pass, String rol, String Permiso)
        {
        

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("CrearUsuarioLogueoBD", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _usuario = new SqlParameter("@usuario", usuario);
            SqlParameter _pass = new SqlParameter("@pass", pass);
            SqlParameter _rol = new SqlParameter("@rol", rol);
            SqlParameter _permiso = new SqlParameter("@permiso", Permiso);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(_usuario);
            oComando.Parameters.Add(_pass);
            oComando.Parameters.Add(_rol);
            oComando.Parameters.Add(_permiso);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;


                if (resultado == -1)
                    throw new Exception("No se ha podido crear el usuario, intentelo mas tarde");
                if (resultado == 2)
                    throw new Exception("Ya existe el usuario");


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
          
        }
      
    }
}
