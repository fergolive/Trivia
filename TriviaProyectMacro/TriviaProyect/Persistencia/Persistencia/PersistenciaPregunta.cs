using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia.Persistencia 
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

        public void Alta_Pregunta(Pregunta r)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Alta_Pregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter texto = new SqlParameter("@texto", r.texto);
           
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(texto);
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


       public void Modificacion_Pregunta(Pregunta p)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Modificacion_Pregunta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter numero = new SqlParameter("@numero", p.numero);
            SqlParameter texto = new SqlParameter("@texto", p.texto);
          
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(numero);
            oComando.Parameters.Add(texto);
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

            SqlParameter numero = new SqlParameter("@numero", p.numero);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(numero);

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
            bool correcto;
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
                    texto = (String)oReader["texto"];

                    Respuesta respuestas = Persistencia.FabricaPersistencia.GetPersistenciaRespuesta().Listar_Pregunta(numero);
                    Pregunta pregunta=new Pregunta(numero,texto,respuestas);
                    Preguntas.add(pregunta);
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

        public Pregunta Buscar_Pregunta(Pregunta p) 
        {
            int numero;
            String texto;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Pregunta " + p.numero ,oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    texto = (String)oReader["texto"];

                    Respuesta respuestas = Persistencia.FabricaPersistencia.GetPersistenciaRespuesta().Listar_Pregunta(numero);
                    Pregunta pregunta=new Pregunta(numero,texto,respuestas);
                    Preguntas.add(pregunta);
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
            return Pregunta;
        } 

      
    }
}
