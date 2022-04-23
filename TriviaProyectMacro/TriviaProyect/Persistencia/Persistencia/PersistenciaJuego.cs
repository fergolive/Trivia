using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia.Persistencia
{
    internal class PersistenciaJuego:MarshalByRefObject,IPersistenciaJuego
    {
        //singleton
        private static PersistenciaJuego _miPersistencia=null;
        private PersistenciaJuego() { }
        public static PersistenciaJuego GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaJuego();
            return _miPersistencia;
        }

        public void Alta_Juego(Juego j)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Alta_Juego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter fechaHoraInicio = new SqlParameter("@fechaHoraInicio", j.fechaHoraInicio);
            SqlParameter fechaHoraFinal = new SqlParameter("@fechaHoraFinal", j.fechaHoraFinal);
            SqlParameter cantMovimientos = new SqlParameter("@cantMovimientos", j.cantMovimientos);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(fechaHoraInicio);
            oComando.Parameters.Add(fechaHoraFinal);
            oComando.Parameters.Add(cantMovimientos);

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


       public void Modificacion_Juego(Juego j)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Modificacion_Juego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter numero = new SqlParameter("@numero", j.numero);
            SqlParameter fechaHoraInicio = new SqlParameter("@fechaHoraInicio", j.fechaHoraInicio);
            SqlParameter fechaHoraFinal = new SqlParameter("@fechaHoraFinal", j.fechaHoraFinal);
            SqlParameter cantMovimientos = new SqlParameter("@cantMovimientos", j.cantMovimientos);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(numero);
            oComando.Parameters.Add(fechaHoraInicio);
            oComando.Parameters.Add(fechaHoraFinal);
            oComando.Parameters.Add(cantMovimientos);

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

        public void Baja_Juego(Juego j) 
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Baja_Juego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter numero = new SqlParameter("@numero", j.numero);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(numero);
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

        public List<Juego> Listar_Juego() 
        {
            int documento;
            String numero;
            String fechaHoraInicio;
            String fechaHoraFinal;
            String cantMovimientos;
            List<Juego> juegos = new List<Juego>();
            List<Pregunta> preguntas;
            Jugador jugador; 

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Listar_Juego" ,oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    documento = Convert.ToInt32(oReader["numero"]);
                    user = (String)oReader["fechaHoraInicio"];
                    pass = (String)oReader["fechaHoraFinal"];
                    nombre = (String)oReader["cantMovimientos"];
                    numJugador = convert.ToInt32(oReader["numJugador"]);
                        
                    Jugador _jugadorParam = new jugador(); //creo un jugador solamente 
                    _jugadorParam.Documento=numJugador;    //para pasarlo por parametro
                    Jugador _jugador = Persistencia.FabricaPersistencia.GetPersistenciaJugador().Buscar_Jugador(numJugador);
                    List<Preguntas> _preguntas = Persistencia.FabricaPersistencia.GetPersistenciaPregunta().Listar_Juego();
                    Juego j=new Juego(numero,fechaHoraInicio,fechaHoraFinal,cantMovimientos,_jugador,_preguntas);
                    Juegos.Add(j);
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
            return Juegos;
        } 

        public Juego Buscar_Juego(Juego j) 
        {
            int numero;
            String fechaHoraInicio;
            String fechaHoraFinal;
            String cantMovimientos;
            Juego j;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Juego " + j.numero ,oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    fechaHoraInicio = (String)oReader["fechaHoraInicio"];
                    fechaHoraFinal = (String)oReader["fechaHoraFinal"];
                    cantMovimientos = Convert.ToInt32(oReader["cantMovimientos"]);
                    numJugador = convert.ToInt32(oReader["numJugador"]);
                        
                    Jugador _jugadorParam = new jugador(); //creo un jugador solamente 
                    _jugadorParam.Documento=numJugador;    //para pasarlo por parametro
                    Jugador _jugador = Persistencia.FabricaPersistencia.GetPersistenciaJugador().Buscar_Jugador(numJugador);
                    List<Preguntas> _preguntas = Persistencia.FabricaPersistencia.GetPersistenciaPregunta().Listar_Juego();
                    Juego j=new Juego(numero,fechaHoraInicio,fechaHoraFinal,cantMovimientos,_jugador,_preguntas);

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
            return Juego;
        } 


      
    }
}
