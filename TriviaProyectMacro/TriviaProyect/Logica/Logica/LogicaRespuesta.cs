using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica.Logica
{
	internal class LogicaRespuesta:ILogicaRespuesta
	{

			private static LogicaRespuesta miInstancia=null;
			private LogicaRespuesta(){};

			public static ILogicaRespuesta GetMiInstancia()
			{

				if(miInstancia==null)
				miInstancia=new LogicaRespuesta()

				return miInstancia;
			}

			private Persistencia.IPersistenciaRespuesta unaPersistencia = Persistencia.FabricaPersistencia.GetPersistenciaRespuesta();


			public void Alta_Respuesta(Respuesta r)
			{

				unaPersistencia.Alta_Respuesta(r);

			}

			public void Baja_Respuesta(Respuesta r)
			{
				
				unaPersistencia.Baja_Respuesta(r)
				
			}

			public void Modificacion_Respuesta(Respuesta r)
			{

				unaPersistencia.Modificacion_Respuesta(r)

			}

			public List<Respuesta> Buscar_Respuesta(Respuesta r) 
			{

				return naPersistencia.Buscar_Respuesta(r);

			}

			public Respuesta Listar_Respuesta() 
			{
				
				return unaPersistencia.Listar_Respuesta()

			}

	}
}