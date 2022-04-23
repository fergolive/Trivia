using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia
{
    internal class PersistenciaRespuesta:MarshalByRefObject,IPersistenciaRespuesta
    {
        //singleton
        private static PersistenciaRespuesta _miPersistencia=null;
        private PersistenciaRespuesta() { }
        public static PersistenciaRespuesta GetPersistencia()
        {
            if (_miPersistencia == null)
            _miPersistencia = new PersistenciaRespuesta();
            return _miPersistencia;
        }

        public void Alta_Respuestas(Pregunta pregunta)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Alta_Respuestas", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            
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


       public void Modificacion_Respuesta(Respuesta r)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Modificacion_Respuesta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter numero = new SqlParameter("@numero", r.Numero);
            SqlParameter texto = new SqlParameter("@texto", r.Texto);
            SqlParameter correcta = new SqlParameter("@correcta", r.Correcta);
          
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(numero);
            oComando.Parameters.Add(texto);
            oComando.Parameters.Add(correcta);

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

        public void Baja_Respuesta(Respuesta r) 
        {
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Baja_Respuesta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter numero = new SqlParameter("@numero", r.Numero);
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

        public List<Respuesta> Listar_Respuesta() 
        {
          
            int numero;
            String texto;
            bool correcto;
            List<Respuesta> respuestas = new List<Respuesta>();

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Listar_Respuesta" ,oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    texto = (String)oReader["texto"];
                    correcto = Convert.ToBoolean(oReader["correcto"]);

                    Respuesta resp=new Respuesta(numero,texto,correcto);
                    respuestas.Add(resp);
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
            return respuestas;
        } 

        public Respuesta Buscar_Respuesta(int numRespuesta) 
        {
            int numero;
            String texto;
            bool correcto;
            Respuesta respuesta = null;
            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Respuesta " + numRespuesta ,oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                while (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    texto = (String)oReader["texto"];
                    correcto = Convert.ToBoolean(oReader["correcto"]);
                    respuesta=new Respuesta(numero,texto,correcto);
                   
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
            return respuesta;
        } 

      
    }
}
