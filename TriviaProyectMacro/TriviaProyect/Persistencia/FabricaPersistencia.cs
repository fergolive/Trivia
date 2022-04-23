using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public class FabricaPersistencia:MarshalByRefObject
    {
        
        public static IPersistenciaJugador getPersistenciaJugador()
        {
            return (PersistenciaJugador.GetPersistencia());
        }

        public static IPersistenciaAdministrador getPersistenciaAdministrador()
        {
            return (PersistenciaAdministrador.GetPersistencia());
        }

        public static IPersistenciaJuego getPersistenciaJuego()
        {
            return (PersistenciaJuego.GetPersistencia());
        }

        public static IPersistenciaPregunta getPersistenciaPregunta()
        {
            return (PersistenciaPregunta.GetPersistencia());
        }

        public static IPersistenciaRespuesta getPersistenciaRespuesta()
        {
            return (PersistenciaRespuesta.GetPersistencia());
        }

       
       
    }
}
