using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    internal class LogicaUsuario:ILogicaUsuario
    {
        private static LogicaUsuario miInstancia = null;
        private LogicaUsuario() { }

        public static ILogicaUsuario GetMiInstancia()
        {
            if (miInstancia == null)
                miInstancia = new LogicaUsuario();

            return miInstancia;
        }

        private Persistencia.IPersistenciaUsuario unaPersistencia = Persistencia.FabricaPersistencia.getPersistenciaUsuario();
        private Persistencia.IPersistenciaJugador unaPersistenciaJ = Persistencia.FabricaPersistencia.getPersistenciaJugador();
        private Persistencia.IPersistenciaAdministrador unaPersistenciaA = Persistencia.FabricaPersistencia.getPersistenciaAdministrador();

        public Usuario Logueo_Usuario(String user, String pass)
        {
            Usuario usuarioLogueado = null;
            int tipoUsuario = unaPersistencia.Chequeo_Usuario(user, pass);

            //8=jugador, 9=administrador
            if (tipoUsuario == 8)
            {
                 usuarioLogueado = unaPersistenciaJ.Logueo_Jugador(user,pass);
            }
            if (tipoUsuario == 9)
            {
                usuarioLogueado=unaPersistenciaA.Logueo_Administrador(user, pass);
                           
            }
            return usuarioLogueado;
        }

        
    }
}
