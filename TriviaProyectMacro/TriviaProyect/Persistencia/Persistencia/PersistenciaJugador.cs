using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia.Persistencia
{
    internal class PersistenciaJugador:MarshalByRefObject,IPersistenciaJugador
    {
        //singleton
        private static PersistenciaJugador _miPersistencia=null;
        private PersistenciaJugador() { }
        public static PersistenciaJugador GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaJugador();
            return _miPersistencia;
        }

        public void Alta_Jugador(Juego j)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Alta_Jugador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter user = new SqlParameter("@user", j.user);
            SqlParameter pass = new SqlParameter("@pass", j.pass);
            SqlParameter nombre = new SqlParameter("@nombre", j.nombre);
            SqlParameter genestadisticas = new SqlParameter("@nomPublico", j.genEstadisticas);

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


        public void Modificacion_Jugador(Juego j)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Modificacion_Jugador", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter documento = new SqlParameter("@documento", j.user);
            SqlParameter user = new SqlParameter("@user", j.user);
            SqlParameter pass = new SqlParameter("@pass", j.pass);
            SqlParameter nombre = new SqlParameter("@nombre", j.nombre);
            SqlParameter genestadisticas = new SqlParameter("@nomPublico", j.genEstadisticas);

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

        public void Baja_Jugador(Jugador j) 
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Baja_Jugador", oConexion);
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

        public List<Jugador> Listar_Jugador() //Listar todos los jugadores
        {
            int documento;
            String user;
            String pass;
            String nombre;
            String nomPublico;
            List<Jugador> Jugadores = new List<Jugador>();

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Listar_Jugador" ,oConexion);
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
                    
                    Jugador j=new jugador(documento,user,pass,nombre,nomPublico);

                    Jugadores.Add(j);
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
            return Jugadores;
        } 

        public Jugador Buscar_Jugador(Jugador j) //Buscar un jugador por documento
        {
            int documento;
            String user;
            String pass;
            String nombre;
            String nomPublico;
            Jugador j;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Jugador " + j.documento ,oConexion);
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
                    
                    Jugador j=new jugador(documento,user,pass,nombre,nomPublico);

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
            return Jugador;
        } 


      
    }
}
