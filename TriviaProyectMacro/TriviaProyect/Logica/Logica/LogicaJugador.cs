using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica.Logica
{
	internal class LogicaJugador:ILogicaJugador
	{

			private static LogicaJugador miInstancia=null;
			private LogicaJugador(){};

			public static ILogicaJugador GetMiInstancia()
			{

				if(miInstancia==null)
				miInstancia=new LogicaJugador()

				return miInstancia;
			}

			private Persistencia.IPersistenciaJugador unaPersistencia = Persistencia.FabricaPersistencia.GetPersistenciaJugador();
			

			public void Alta_Jugador(Jugador j)
			{

				unaPersistencia.Alta_Jugador(j);

			}

			public void Baja_Jugador(Jugador j)
			{
				
				unaPersistencia.Baja_Jugador(j)
				
			}

			public void Modificacion_Jugador(Jugador j)
			{

				unaPersistencia.Modificacion_Jugador(j)

			}

			public List<Jugador> Buscar_Jugador()
			{

				return naPersistencia.Buscar_Jugador();

			}

			public Jugador Listar_Jugador()
			{
				
				return unaPersistencia.Listar_Jugador(j)

			}

	}
}