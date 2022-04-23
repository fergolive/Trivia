using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace ServicioRemoting
{
    public class ServicioJugador
    {
        private Persistencia.IPersistenciaJugador unaPersistencia;

        public ServicioJugador()
        {
            Servicio.CreoServicio();

            unaPersistencia = Persistencia.FabricaPersistencia.GetPersistenciaJugador();
        }

        public void Alta_Jugador(Jugador j)
        {
            unaPersistencia.Alta_Jugador(j);
        }

        public void Baja_Jugador(Jugador j)
        {
            unaPersistencia.Baja_Jugador(j);
        }

        public List<Jugador> Listar_Jugador()
        {
           return unaPersistencia.Listar_Jugador();
        }

        public Jugador Buscar_Jugador(jugador j)
        {
            return unaPersistencia.Buscar_Jugador(j);
        }

    }
}
