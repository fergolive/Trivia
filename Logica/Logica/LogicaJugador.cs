using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
	internal class LogicaJugador:ILogicaJugador
	{

			private static LogicaJugador miInstancia=null;
			private LogicaJugador(){}

			public static ILogicaJugador GetMiInstancia()
			{

                if (miInstancia == null)
                    miInstancia = new LogicaJugador();

				return miInstancia;
			}

			private Persistencia.IPersistenciaJugador unaPersistencia = Persistencia.FabricaPersistencia.getPersistenciaJugador();
			

			public void Alta_Jugador(Jugador j)
			{

				unaPersistencia.Alta_Jugador(j);

			}

			public void Baja_Jugador(Jugador j)
			{

                unaPersistencia.Baja_Jugador(j);
				
			}

			public void Modificacion_Jugador(Jugador j)
			{

                unaPersistencia.Modificacion_Jugador(j);

			}

			public Jugador Buscar_Jugador(int documento)
			{

				return unaPersistencia.Buscar_Jugador(documento);

			}

			public List<Jugador> Listar_Jugador()
			{

                return unaPersistencia.Listar_Jugador();

			}

            public List<Jugador> ListarJugadoresJuegosFinalizados()
            {

                return unaPersistencia.ListarJugadoresJuegosFinalizados();

            }

	}
}