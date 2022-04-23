using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace ServicioRemoting
{
    public class ServicioJuego
    {
        private Persistencia.IPersistenciaJuego unaPersistencia;

        public ServicioJuego()
        {
            Servicio.CreoServicio();

            unaPersistencia = Persistencia.FabricaPersistencia.GetPersistenciaJuego();
        }

        public void Alta_Juego(Juego j)
        {
            unaPersistencia.Alta_Juego(j);
        }

        public void Baja_Juego(Juego j)
        {
            unaPersistencia.Baja_Juego(j);
        }

        public List<Juego> Listar_Juego()
        {
           return unaPersistencia.Listar_Juego();
        }

        public Juego Buscar_Juego(Juego j)
        {
            return unaPersistencia.Buscar_Juego(j);
        }

    }
}
