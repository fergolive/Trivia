using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace ServicioRemoting
{
    public class ServicioRespuesta
    {
        private Persistencia.IPersistenciaRespuesta unaPersistencia;

        public ServicioRespuesta()
        {
            Servicio.CreoServicio();

            unaPersistencia = Persistencia.FabricaPersistencia.GetPersistenciaRespuesta();
        }

        public void Alta_Respuesta(Respuesta p)
        {
            unaPersistencia.Alta_Respuesta(p);
        }

        public void Baja_Respuesta(Respuesta p)
        {
            unaPersistencia.Baja_Respuesta(p);
        }

        public List<Respuesta> Listar_Respuesta()
        {
           return unaPersistencia.Listar_Respuesta();
        }

        public Respuesta Buscar_Respuesta(Respuesta p)
        {
            return unaPersistencia.Buscar_Respuesta(p);
        }

    }
}
