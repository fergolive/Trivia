using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica.Logica
{
	internal class LogicaPregunta:ILogicaPregunta
	{

			private static LogicaPregunta miInstancia=null;
			private LogicaPregunta(){};

			public static ILogicaPregunta GetMiInstancia()
			{

				if(miInstancia==null)
				miInstancia=new LogicaPregunta()

				return miInstancia;
			}

			private Persistencia.IPersistenciaPregunta unaPersistencia = Persistencia.FabricaPersistencia.GetPersistenciaPregunta();


			public void Alta_Pregunta(Pregunta p)
			{

				unaPersistencia.Alta_Pregunta(p);

			}

			public void Baja_Pregunta(Pregunta p)
			{
				
				unaPersistencia.Baja_Pregunta(p)
				
			}

			public void Modificacion_Pregunta(Pregunta p)
			{

				unaPersistencia.Modificacion_Pregunta(p)

			}

			public List<Pregunta> Buscar_Pregunta(Pregunta p) 
			{

				return naPersistencia.Buscar_Pregunta(p);

			}

			public Pregunta Listar_Pregunta() 
			{
				
				return unaPersistencia.Listar_Pregunta()

			}

	}
}