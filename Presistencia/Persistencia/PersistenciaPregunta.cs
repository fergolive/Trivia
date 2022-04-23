using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia
{
    internal class PersistenciaPregunta:MarshalByRefObject,IPersistenciaPregunta
    {
        //singleton
        private static PersistenciaPregunta _miPersistencia=null;
        private PersistenciaPregunta() { }
        public static PersistenciaPregunta GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaPregunta();
            return _miPersistencia;
        }

        public int Alta_Pregunta(Pregunta p)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Alta_Pregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter texto = new SqlParameter("@texto", p.Texto);
            SqlParameter tipo = new SqlParameter("@tipo", p.Tipo);
           
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(texto);
            oComando.Parameters.Add(tipo);
            oComando.Parameters.Add(retorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();
                resultado = (int)oComando.Parameters["@Retorno"].Value;

            
             
                if (resultado == -3)
                    throw new Exception("ya existe una pregunta con ese texto");

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


       public void Modificacion_Pregunta(Pregunta pregunta)
        {


            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Modificacion_Pregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter numeroPregunta = new SqlParameter("@numeroPregunta", pregunta.Numero);
      
            SqlParameter textoPregunta = new SqlParameter("@textoPregunta", pregunta.Texto);
            SqlParameter tipo = new SqlParameter("@tipo", pregunta.Tipo);

            SqlParameter numero = new SqlParameter("@numero", pregunta.Respuestas[0].Numero);
            SqlParameter texto = new SqlParameter("@texto", pregunta.Respuestas[0].Texto);
            SqlParameter correcta = new SqlParameter("@correcto", pregunta.Respuestas[0].Correcta);

            SqlParameter numero1 = new SqlParameter("@numero1", pregunta.Respuestas[1].Numero);
            SqlParameter texto1 = new SqlParameter("@texto1", pregunta.Respuestas[1].Texto);
            SqlParameter correcta1 = new SqlParameter("@correcto1", pregunta.Respuestas[1].Correcta);

            SqlParameter numero2 = new SqlParameter("@numero2", pregunta.Respuestas[2].Numero);
            SqlParameter texto2 = new SqlParameter("@texto2", pregunta.Respuestas[2].Texto);
            SqlParameter correcta2 = new SqlParameter("@correcto2", pregunta.Respuestas[2].Correcta);

            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(numeroPregunta);
            oComando.Parameters.Add(textoPregunta);
            oComando.Parameters.Add(tipo);
            oComando.Parameters.Add(numero);
            oComando.Parameters.Add(numero1);
            oComando.Parameters.Add(numero2);
            oComando.Parameters.Add(texto);
            oComando.Parameters.Add(texto1);
            oComando.Parameters.Add(texto2);
            oComando.Parameters.Add(correcta);
            oComando.Parameters.Add(correcta1);
            oComando.Parameters.Add(correcta2);

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

        public void Baja_Pregunta(Pregunta p) 
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Baja_Pregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter numero = new SqlParameter("@numero", p.Numero);
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

        public List<Pregunta> Listar_Pregunta() 
        {
          
            int numero;
            String texto;
            String tipo;
            int idRespuesta1;
            int idRespuesta2;
            int idRespuesta3;
            List<Respuesta> respuestas = null;
            List<Pregunta> Preguntas = new List<Pregunta>();

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Listar_Pregunta" ,oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    tipo = (String)oReader["tipo"]; 
                    texto = (String)oReader["texto"];
                    idRespuesta1 = Convert.ToInt32(oReader["idRespuesta1"]);
                    idRespuesta2= Convert.ToInt32(oReader["idRespuesta2"]);
                    idRespuesta3 = Convert.ToInt32(oReader["idRespuesta3"]);
                    
                    Respuesta respuesta1 = Persistencia.PersistenciaRespuesta.GetPersistencia().Buscar_Respuesta(idRespuesta1);
                    Respuesta respuesta2 = Persistencia.PersistenciaRespuesta.GetPersistencia().Buscar_Respuesta(idRespuesta2);
                    Respuesta respuesta3 = Persistencia.PersistenciaRespuesta.GetPersistencia().Buscar_Respuesta(idRespuesta3);

                    respuestas.Add(respuesta1);
                    respuestas.Add(respuesta2);
                    respuestas.Add(respuesta3);

                    Pregunta pregunta=new Pregunta(numero,tipo,texto,respuestas);
                    Preguntas.Add(pregunta);
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
            return Preguntas;
        } 

        public Pregunta Buscar_Pregunta(int num)
        {
            int numero;
            String texto;
            String tipo;
            int idRespuesta1;
            int idRespuesta2;
            int idRespuesta3;
            Pregunta pregunta = null;
            List<Respuesta> respuestas = new List<Respuesta>();
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Pregunta " + num ,oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    tipo = (String)oReader["tipo"];
                    texto = (String)oReader["texto"];
                    idRespuesta1 = Convert.ToInt32(oReader["idRespuesta1"]);
                    idRespuesta2 = Convert.ToInt32(oReader["idRespuesta2"]);
                    idRespuesta3 = Convert.ToInt32(oReader["idRespuesta3"]);

                    Respuesta respuesta1 = Persistencia.PersistenciaRespuesta.GetPersistencia().Buscar_Respuesta(idRespuesta1);
                    Respuesta respuesta2 = Persistencia.PersistenciaRespuesta.GetPersistencia().Buscar_Respuesta(idRespuesta2);
                    Respuesta respuesta3 = Persistencia.PersistenciaRespuesta.GetPersistencia().Buscar_Respuesta(idRespuesta3);

                    respuestas.Add(respuesta1);
                    respuestas.Add(respuesta2);
                    respuestas.Add(respuesta3);

                    pregunta=new Pregunta(numero,tipo,texto,respuestas);
                    
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
            return pregunta;
        }

        public List<Pregunta> Buscar_Preguntas(int numJuego) //devuelve las 9 preguntas del juego
        {
            int numero;
            String texto;
            String tipo;
            int idRespuesta1;
            int idRespuesta2;
            int idRespuesta3;

            List<Pregunta> preguntas = new List<Pregunta>();

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Preguntas_xnumJuego " + numJuego, oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    tipo = (String)oReader["tipo"];
                    texto = (String)oReader["texto"];
                    idRespuesta1 = Convert.ToInt32(oReader["idRespuesta1"]);
                    idRespuesta2 = Convert.ToInt32(oReader["idRespuesta2"]);
                    idRespuesta3 = Convert.ToInt32(oReader["idRespuesta3"]);

                    Respuesta respuesta1 = Persistencia.PersistenciaRespuesta.GetPersistencia().Buscar_Respuesta(idRespuesta1);
                    Respuesta respuesta2 = Persistencia.PersistenciaRespuesta.GetPersistencia().Buscar_Respuesta(idRespuesta2);
                    Respuesta respuesta3 = Persistencia.PersistenciaRespuesta.GetPersistencia().Buscar_Respuesta(idRespuesta3);

                    List<Respuesta> respuestas = new List<Respuesta>();

                    respuestas.Add(respuesta1);
                    respuestas.Add(respuesta2);
                    respuestas.Add(respuesta3);

                    Pregunta pregunta = new Pregunta(numero, tipo, texto, respuestas);
                    preguntas.Add(pregunta);

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
            return preguntas;
        } 
    }
}
