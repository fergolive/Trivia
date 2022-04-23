using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace ServicioRemoting
{
    public class ServicioPregunta
    {
        private Persistencia.IPersistenciaPregunta unaPersistencia;

        public ServicioPregunta()
        {
            Servicio.CreoServicio();

            unaPersistencia = Persistencia.FabricaPersistencia.GetPersistenciaPregunta();
        }

        public void Alta_Pregunta(Pregunta p)
        {
            unaPersistencia.Alta_Pregunta(p);
        }

        public void Baja_Pregunta(Pregunta p)
        {
            unaPersistencia.Baja_Pregunta(p);
        }

        public List<Pregunta> Listar_Pregunta()
        {
           return unaPersistencia.Listar_Pregunta();
        }

        public Pregunta Buscar_Pregunta(Pregunta p)
        {
            return unaPersistencia.Buscar_Pregunta(p);
        }

    }
}
