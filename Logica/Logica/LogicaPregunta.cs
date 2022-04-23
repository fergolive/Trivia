using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
	internal class LogicaPregunta:ILogicaPregunta
	{

			private static LogicaPregunta miInstancia=null;
			private LogicaPregunta(){}

			public static ILogicaPregunta GetMiInstancia()
			{

                if (miInstancia == null)
                    miInstancia = new LogicaPregunta();

				return miInstancia;
			}

			private Persistencia.IPersistenciaPregunta unaPersistencia = Persistencia.FabricaPersistencia.getPersistenciaPregunta();


			public int Alta_Pregunta(Pregunta p)
			{

				return (unaPersistencia.Alta_Pregunta(p));

			}

			public void Baja_Pregunta(Pregunta p)
			{

                unaPersistencia.Baja_Pregunta(p);
				
			}

			public void Modificacion_Pregunta(Pregunta p)
			{

                unaPersistencia.Modificacion_Pregunta(p);

			}

			public Pregunta Buscar_Pregunta(int num) 
			{

				return (unaPersistencia.Buscar_Pregunta(num));

			}

            public List<Pregunta> Buscar_Preguntas(int numJuego)
            {

                return (unaPersistencia.Buscar_Preguntas(numJuego));

            }
			public List<Pregunta> Listar_Pregunta() 
			{

                return (unaPersistencia.Listar_Pregunta());

			}

	}
}