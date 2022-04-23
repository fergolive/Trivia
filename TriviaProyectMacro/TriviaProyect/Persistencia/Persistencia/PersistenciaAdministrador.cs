using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia.Persistencia
{
    internal class PersistenciaAdministrador:MarshalByRefObject,IPersistenciaAdministrador
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

        public void Alta_Administrador(Juego j)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Alta_Administrador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter user = new SqlParameter("@user", j.user);
            SqlParameter pass = new SqlParameter("@pass", j.pass);
            SqlParameter nombre = new SqlParameter("@nombre", j.nombre);
            SqlParameter genestadisticas = new SqlParameter("@genEstadisticas", j.genEstadisticas);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

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

            /*
                if (resultado == 1)
                    throw new Exception("Evento creado");
                if (resultado == -2)
                    throw new Exception("No se puedo crear el evento");
                if (resultado == -3)
                    throw new Exception("No se puedo crear el evento");

            */

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


        public void Modificacion_Administrador(Juego j)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Modificacion_Administrador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter documento = new SqlParameter("@documento", j.documento);
            SqlParameter user = new SqlParameter("@user", j.user);
            SqlParameter pass = new SqlParameter("@pass", j.pass);
            SqlParameter nombre = new SqlParameter("@nombre", j.nombre);
            SqlParameter genestadisticas = new SqlParameter("@genEstadisticas", j.genEstadisticas);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

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

            /*
                if (resultado == 1)
                    throw new Exception("Evento creado");
                if (resultado == -2)
                    throw new Exception("No se puedo crear el evento");
                if (resultado == -3)
                    throw new Exception("No se puedo crear el evento");

            */

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

        public void Baja_Administrador(Administrador j) 
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Baja_Administrador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter documento = new SqlParameter("@documento", j.documento);

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

            /*
                if (resultado == 1)
                    throw new Exception("Evento eliminado");
                if (resultado == -2)
                    throw new Exception("No existe el evento, ha sido eliminado");
            */


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
            String nomPublico;
            List<Administrador> Administradores = new List<Administradores>();

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
                    nomPublico = (String)oReader["nomPublico"];
                    
                    Administrador a=new Administrador(documento,user,pass,nombre,nomPublico);

                    Administrador.Add(a);
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
            return Administradores;
        } 

        public Administrador Buscar_Administrador(Administrador a) //Buscar un Administrador por documento
        {
            int documento;
            String user;
            String pass;
            String nombre;
            String nomPublico;
            Administrador a;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Administrador " + a.documento ,oConexion);
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
                    nomPublico = (String)oReader["nomPublico"];
                    
                    Administrador a=new Administrador(documento,user,pass,nombre,nomPublico);

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
            return Administrador;
        } 


      
    }
}
