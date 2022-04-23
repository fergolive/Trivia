using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;

namespace Persistencia
{
    internal class PersistenciaUsuario : MarshalByRefObject, IPersistenciaUsuario
    {
        //singleton
        private static PersistenciaUsuario _miPersistencia=null;
        private PersistenciaUsuario() { }
        public static PersistenciaUsuario GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaUsuario();
            return _miPersistencia;
        }

        public Usuario Logueo_Usuario(String user,String pass) //Buscar un jugador por documento
        {
            int documento;
            String user1;
            String pass1;
            String nombre;
            Usuario usuarioLogueado=null;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Logueo_Usuario " + user+","+pass, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    documento = Convert.ToInt32(oReader["documento"]);
                    user1 = (String)oReader["user"];
                    pass1 = (String)oReader["pass"];
                    nombre = (String)oReader["nombre"];
                    

                    usuarioLogueado = new Usuario(documento, user, pass, nombre);

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
            return (new Jugador());
        }
        
        public int Chequeo_Usuario(String user,String pass)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Chequeo_Usuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter usuario = new SqlParameter("@user", user);
            SqlParameter contrasena = new SqlParameter("@pass", pass);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(usuario);
            oComando.Parameters.Add(contrasena);
            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;
            
                if (resultado == 1)
                    throw new Exception("usuario o contraseña mal ingresado");


                return resultado;

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
