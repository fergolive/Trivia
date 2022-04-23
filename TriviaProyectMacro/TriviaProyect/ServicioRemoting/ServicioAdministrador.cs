using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace ServicioRemoting
{
    public class ServicioAdministrador
    {
        private Persistencia.IPersistenciaAdministrador unaPersistencia;

        public ServicioAdministrador()
        {
            Servicio.CreoServicio();

            unaPersistencia = Persistencia.FabricaPersistencia.GetPersistenciaAdministrador();
        }

        public void Alta_Administrador(Administrador j)
        {
            unaPersistencia.Alta_Administrador(j);
        }

        public void Baja_Administrador(Administrador j)
        {
            unaPersistencia.Baja_Administrador(j);
        }

        public List<Administrador> Listar_Administrador()
        {
           return unaPersistencia.Listar_Administrador();
        }

        public Administrador Buscar_Administrador(Administrador a)
        {
            return unaPersistencia.Buscar_Administrador(a);
        }

    }
}
