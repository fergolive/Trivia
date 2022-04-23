using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
	internal class LogicaRespuesta:ILogicaRespuesta
	{

			private static LogicaRespuesta miInstancia=null;
			private LogicaRespuesta(){}

			public static ILogicaRespuesta GetMiInstancia()
			{

                if (miInstancia == null)
                    miInstancia = new LogicaRespuesta();

				return miInstancia;
			}

			private Persistencia.IPersistenciaRespuesta unaPersistencia = Persistencia.FabricaPersistencia.getPersistenciaRespuesta();


			public void Alta_Respuestas(Pregunta pregunta)
			{

				unaPersistencia.Alta_Respuestas(pregunta);

			}

			public void Baja_Respuesta(Respuesta r)
			{

                unaPersistencia.Baja_Respuesta(r);
				
			}

			public void Modificacion_Respuesta(Respuesta r)
			{

                unaPersistencia.Modificacion_Respuesta(r);

			}

			public Respuesta Buscar_Respuesta(int numRespuesta) 
			{

				return (unaPersistencia.Buscar_Respuesta(numRespuesta));

			}

			public List<Respuesta> Listar_Respuesta() 
			{

                return unaPersistencia.Listar_Respuesta();

			}

	}
}