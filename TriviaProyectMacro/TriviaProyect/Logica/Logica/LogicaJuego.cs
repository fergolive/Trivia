using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica.Logica
{
	internal class LogicaJuego:ILogicaJuego
	{

			private static LogicaJuego miInstancia=null;
			private LogicaJuego(){};

			public static ILogicaJuego GetMiInstancia()
			{

				if(miInstancia==null)
				miInstancia=new LogicaJuego()

				return miInstancia;
			}

			private Persistencia.IPersistenciaJuego unaPersistencia = Persistencia.FabricaPersistencia.GetPersistenciaJuego();


			public void Alta_Juego(Juego j)
			{

				unaPersistencia.Alta_Juego(j);

			}

			public void Baja_Juego(Juego j)
			{
				
				unaPersistencia.Baja_Juego(j)
				
			}

			public void Modificacion_Juego(Juego j)
			{

				unaPersistencia.Modificacion_Juego(j)

			}

			public List<Juego> Buscar_Juego(Juego j) 
			{

				return naPersistencia.Buscar_Juego(j);

			}

			public Juego Listar_Juego() 
			{
				
				return unaPersistencia.Listar_Juego()

			}

	}
}