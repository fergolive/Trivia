using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntidadesCompartidas;


namespace Persistencia.Persistencia 
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

        public void Alta_Respuesta(Respuesta r)
        {

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Alta_Respuesta", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter texto = new SqlParameter("@texto", r.texto);
            SqlParameter correcto = new SqlParameter("@correcto", r.correcto);
           
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(texto);
            oComando.Parameters.Add(correcto);
          
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

            SqlParameter numero = new SqlParameter("@numero", r.numero);
            SqlParameter texto = new SqlParameter("@texto", r.texto);
            SqlParameter correcto = new SqlParameter("@correcto", r.correcto);
          
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            int resultado = -1;

            oComando.Parameters.Add(numero);
            oComando.Parameters.Add(texto);
            oComando.Parameters.Add(correcto);

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

            SqlParameter numero = new SqlParameter("@numero", r.numero);
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
            bool correcto;
            List<Respuesta> Respuestas = new List<Respuesta>();

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

                    Respuesta p=new Respuesta(numero,texto,correcto);
                    respuestas.add(Respuesta);
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
            return Respuestas;
        } 

        public Respuesta Buscar_Respuesta(Respuesta r) 
        {
            int numero;
            String texto;

            SqlConnection oConexion = new SqlConnection(Conexion.ConectBD);
            SqlCommand oComando = new SqlCommand("Exec Buscar_Respuesta " + r.numero ,oConexion);
            SqlDataReader oReader;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();
                if (oReader.Read())
                {

                    numero = Convert.ToInt32(oReader["numero"]);
                    texto = (String)oReader["texto"];
                    correcto = Convert.ToBoolean(oReader["correcto"]);
                    Respuesta respuesta=new Respuesta(numero,texto,correcto);
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
