using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia
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

        public Juego Alta_Juego(Juego j)
        {

            int numero;
            DateTime fechaInicio;
            
            int cantMovimientos;
            int numJugador;
            int contestacionesok;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Alta_Juego " +"'"+ j.FechaHoraInicio+"'"+","+j.Player.Documento, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    fechaInicio = Convert.ToDateTime(oReader["fechaHoraInicio"]);
                    //fechaFinal = Convert.ToDateTime(oReader["fechaHoraFin"]);
                    cantMovimientos = Convert.ToInt32(oReader["cantMovimientos"]);
                    contestacionesok = Convert.ToInt32(oReader["contestacionesOK"]);
                    numJugador = Convert.ToInt32(oReader["numeroJugador"]);

                    //busco el jugador de la pregunta

                    Jugador jugador = Persistencia.PersistenciaJugador.GetPersistencia().Buscar_Jugador(numJugador);

                    //busco las preguntas del juego
                    List<Pregunta> preguntas = Persistencia.PersistenciaPregunta.GetPersistencia().Buscar_Preguntas(numero); //busca 9 pregunta


                    j = new Juego(numero, fechaInicio,DateTime.Now, cantMovimientos,contestacionesok, jugador, preguntas,null);
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
            return j;
        }


       public void Modificacion_Juego(Juego j)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Modificacion_Juego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter numero = new SqlParameter("@numero", j.Numero);
            SqlParameter fechaHoraInicio = new SqlParameter("@fechaHoraInicio", j.FechaHoraInicio);
            SqlParameter fechaHoraFinal = new SqlParameter("@fechaHoraFinal", j.FechaHoraFinal);
            SqlParameter cantMovimientos = new SqlParameter("@cantMovimientos", j.CantMovimientos);
            SqlParameter contestacionesOk = new SqlParameter("@contestaciones", j.ContestacionesOK);
            SqlParameter estado1 = new SqlParameter("@estado1", j.EstadosPreguntas[0]);
            SqlParameter estado2 = new SqlParameter("@estado2", j.EstadosPreguntas[1]);
            SqlParameter estado3 = new SqlParameter("@estado3", j.EstadosPreguntas[2]);
            SqlParameter estado4 = new SqlParameter("@estado4", j.EstadosPreguntas[3]);
            SqlParameter estado5 = new SqlParameter("@estado5", j.EstadosPreguntas[4]);
            SqlParameter estado6 = new SqlParameter("@estado6", j.EstadosPreguntas[5]);
            SqlParameter estado7 = new SqlParameter("@estado7", j.EstadosPreguntas[6]);
            SqlParameter estado8 = new SqlParameter("@estado8", j.EstadosPreguntas[7]);
            SqlParameter estado9 = new SqlParameter("@estado9", j.EstadosPreguntas[8]);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(numero);
            oComando.Parameters.Add(fechaHoraInicio);
            oComando.Parameters.Add(fechaHoraFinal);
            oComando.Parameters.Add(cantMovimientos);
            oComando.Parameters.Add(contestacionesOk);
            oComando.Parameters.Add(estado1);
            oComando.Parameters.Add(estado2);
            oComando.Parameters.Add(estado3);
            oComando.Parameters.Add(estado4);
            oComando.Parameters.Add(estado5);
            oComando.Parameters.Add(estado6);
            oComando.Parameters.Add(estado7);
            oComando.Parameters.Add(estado8);
            oComando.Parameters.Add(estado9);

            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("Error al guarda el juego");


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

            SqlParameter numero = new SqlParameter("@numero", j.Numero);

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

     

        public List<Juego> Buscar_Juegos_xJugador(int documento)
        {

            int numero;
            DateTime fechaInicio;
            DateTime fechaFinal;
            int cantMovimientos;
            int numJugador;
            List<Juego> juegos = new List<Juego>();
            int contestacionesok;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Buscar_Juegos_xJugador "+documento , oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    fechaInicio = Convert.ToDateTime(oReader["fechaHoraInicio"]);
                    fechaFinal = Convert.ToDateTime(oReader["fechaHoraFin"]);
                    cantMovimientos = Convert.ToInt32(oReader["cantMovimientos"]);
                    contestacionesok = Convert.ToInt32(oReader["contestacionesOK"]);
                    numJugador = Convert.ToInt32(oReader["numeroJugador"]);

                    //busco el jugador de la pregunta
                    Jugador jugador = Persistencia.PersistenciaJugador.GetPersistencia().Buscar_Jugador(numJugador);

                    //busco las preguntas del juego
                    List<Pregunta> preguntas = Persistencia.PersistenciaPregunta.GetPersistencia().Buscar_Preguntas(numero); //busca 9 preguntas

                    //creo el juego
                    Juego j = new Juego(numero, fechaInicio, fechaFinal, cantMovimientos,contestacionesok, jugador, preguntas,null);

                    juegos.Add(j);
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
            return juegos;

        } 

        public Juego Buscar_Juego(int numJuego) 
        {
            int numero;
            DateTime fechaInicio;
            DateTime fechaFinal;
            int cantMovimientos;
            int numJugador;
            List<Juego> juegos = new List<Juego>();
            Juego j=null;
            int contestacionesok;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Juego " + numJuego, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    fechaInicio = Convert.ToDateTime(oReader["fechaHoraInicio"]);
                    fechaFinal = Convert.ToDateTime(oReader["fechaHoraFinal"]);
                    cantMovimientos = Convert.ToInt32(oReader["cantMovimientos"]);
                    contestacionesok = Convert.ToInt32(oReader["contestacionesOK"]);
                    numJugador = Convert.ToInt32(oReader["numJugador"]);

                    //busco el jugador de la pregunta
                   
                    Jugador jugador = Persistencia.PersistenciaJugador.GetPersistencia().Buscar_Jugador(numJugador);

                    //busco las preguntas del juego
                    List<Pregunta> preguntas = Persistencia.PersistenciaPregunta.GetPersistencia().Buscar_Preguntas(numero); //busca 9 pregunta


                    j = new Juego(numero, fechaInicio, fechaFinal, cantMovimientos, contestacionesok,jugador, preguntas,null);
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
            return j;
        }

        public List<Juego> ListarJuegosFinalizados()
        {
            int numero;
            int cantMovimientos;
            DateTime fechaHInicio;
            DateTime fechaHFinal;
            int numJugador;
            int contestacionesok;
            List<Juego> juegosFinzalizados = new List<Juego>();

            
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec ListarJuegosFinalizados", oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    cantMovimientos = Convert.ToInt32(oReader["cantMovimientos"]);
                    contestacionesok = Convert.ToInt32(oReader["contestacionesOK"]);
                    fechaHInicio = Convert.ToDateTime(oReader["fechaHoraInicio"]);
                    fechaHFinal = Convert.ToDateTime(oReader["fechaHoraFin"]);
                    numJugador = Convert.ToInt32(oReader["numeroJugador"]);

                    Jugador jugador = Persistencia.FabricaPersistencia.getPersistenciaJugador().Buscar_Jugador_xnumJuego(numJugador);
                    List<Pregunta> preguntas = Persistencia.FabricaPersistencia.getPersistenciaPregunta().Buscar_Preguntas(numero); 
                    Juego nuevoJuego = new Juego(numero,fechaHInicio,fechaHFinal,cantMovimientos,contestacionesok,jugador,preguntas,null);

                    juegosFinzalizados.Add(nuevoJuego);
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
            return juegosFinzalizados;
        }

        public bool ComprobarDisponibilidadDeJuego(int Documento)
        {

             SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
             SqlCommand oComando = new SqlCommand("ComprobarDisponibilidadDeJuego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter numero = new SqlParameter("@documento", Documento);

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
                    throw new Exception("Evento creado");
                */

                return Convert.ToBoolean(resultado);
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

            int numero;
            DateTime fechaInicio;
            DateTime fechaFinal;
            int cantMovimientos;
            int numJugador;
            int contestacionesok;

            List<Juego> juegos = new List<Juego>();
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Listar_Juego ", oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    fechaInicio = Convert.ToDateTime(oReader["fechaHoraInicio"]);
                    fechaFinal = Convert.ToDateTime(oReader["fechaHoraFinal"]);
                    contestacionesok = Convert.ToInt32(oReader["contestacionesOK"]);
                    cantMovimientos = Convert.ToInt32(oReader["cantMovimientos"]);
                    numJugador = Convert.ToInt32(oReader["numJugador"]);
                    

                    //busco el jugador de la pregunta

                    Jugador jugador = Persistencia.PersistenciaJugador.GetPersistencia().Buscar_Jugador(numJugador);

                    //busco las preguntas del juego
                    List<Pregunta> preguntas = Persistencia.PersistenciaPregunta.GetPersistencia().Buscar_Preguntas(numero); //busca 9 pregunta


                    Juego j = new Juego(numero, fechaInicio, fechaFinal, cantMovimientos,contestacionesok, jugador, preguntas,null);
                    juegos.Add(j);

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
            return juegos;
        }

        public Juego Buscar_Juego_Pendiente(int documento)
        {
            int numero;
            DateTime fechaHInicio;
            
            int cantMovimientos;
            int numJugador;
            List<Juego> juegos = new List<Juego>();
            
            int contestacionesok;
            Juego nuevoJuego = null ;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Juego_Pendiente " + documento, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    cantMovimientos = Convert.ToInt32(oReader["cantMovimientos"]);
                    contestacionesok = Convert.ToInt32(oReader["contestacionesOK"]);
                    fechaHInicio = Convert.ToDateTime(oReader["fechaHoraInicio"]);
                    numJugador = Convert.ToInt32(oReader["numeroJugador"]);

                    Jugador jugador = Persistencia.FabricaPersistencia.getPersistenciaJugador().Buscar_Jugador_xnumJuego(numJugador);
                    List<Pregunta> preguntas = Persistencia.FabricaPersistencia.getPersistenciaPregunta().Buscar_Preguntas(numero);
                    List<int> estados=Persistencia.FabricaPersistencia.getPersistenciaJuego().Buscar_Estado_Juego(numero);
                    nuevoJuego = new Juego(numero, fechaHInicio,DateTime.Now, cantMovimientos, contestacionesok, jugador, preguntas,estados);

                   
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
            return nuevoJuego;
        }

        public void Guardar_Juego(Juego j, bool finalizado)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);

            SqlCommand oComando = new SqlCommand("Guardar_Juego", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter numero = new SqlParameter("@numero", j.Numero);
            SqlParameter fechaHoraInicio = new SqlParameter("@fechaHoraInicio", j.FechaHoraInicio);


            SqlParameter fechaHoraFinal=null;

          
                fechaHoraFinal = new SqlParameter("@fechaHoraFin", j.FechaHoraFinal);
        
            
            SqlParameter cantMovimientos = new SqlParameter("@cantMovimientos", j.CantMovimientos);
            SqlParameter numjugador = new SqlParameter("@numeroJugador", j.Player.Documento);
            SqlParameter contestacionesOk = new SqlParameter("@contestacionesOK", j.ContestacionesOK);
            SqlParameter estado1 = new SqlParameter("@estado1", j.EstadosPreguntas[0]);
            SqlParameter estado2 = new SqlParameter("@estado2", j.EstadosPreguntas[1]);
            SqlParameter estado3 = new SqlParameter("@estado3", j.EstadosPreguntas[2]);
            SqlParameter estado4 = new SqlParameter("@estado4", j.EstadosPreguntas[3]);
            SqlParameter estado5 = new SqlParameter("@estado5", j.EstadosPreguntas[4]);
            SqlParameter estado6 = new SqlParameter("@estado6", j.EstadosPreguntas[5]);
            SqlParameter estado7 = new SqlParameter("@estado7", j.EstadosPreguntas[6]);
            SqlParameter estado8 = new SqlParameter("@estado8", j.EstadosPreguntas[7]);
            SqlParameter estado9 = new SqlParameter("@estado9", j.EstadosPreguntas[8]);
            SqlParameter sefinaliza = new SqlParameter("@finalizado", finalizado);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(numero);
            oComando.Parameters.Add(fechaHoraInicio);
          
            oComando.Parameters.Add(fechaHoraFinal);
          
            oComando.Parameters.Add(cantMovimientos);
            oComando.Parameters.Add(numjugador);
            oComando.Parameters.Add(contestacionesOk);
            oComando.Parameters.Add(estado1);
            oComando.Parameters.Add(estado2);
            oComando.Parameters.Add(estado3);
            oComando.Parameters.Add(estado4);
            oComando.Parameters.Add(estado5);
            oComando.Parameters.Add(estado6);
            oComando.Parameters.Add(estado7);
            oComando.Parameters.Add(estado8);
            oComando.Parameters.Add(estado9);
            oComando.Parameters.Add(sefinaliza);
            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

                if (resultado == -1)
                    throw new Exception("Error al guardar el juego");


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

        public List<int> Buscar_Estado_Juego(int numeroJuego)
        {
            List<int> estadosBotones = new List<int>();

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Estado_Juego " + numeroJuego, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {
                    estadosBotones.Add(Convert.ToInt32(oReader["estado"]));
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
            return estadosBotones;
        }
     }
}

