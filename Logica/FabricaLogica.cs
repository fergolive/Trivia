using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    
    public class FabricaLogica
    {
        //Jugador
        public static ILogicaJugador getLogicaJugador()
        {
            
            return (LogicaJugador.GetMiInstancia());
            
        }

        //Administrador
        public static ILogicaAdministrador getLogicaAdministrador()
        {

            return (LogicaAdministrador.GetMiInstancia());
            
        }

        //Juego
        public static ILogicaJuego getLogicaJuego()
        {

            return (LogicaJuego.GetMiInstancia());
            
        }

        //Pregunta
        public static ILogicaPregunta getLogicaPregunta()
        {

            return (LogicaPregunta.GetMiInstancia());
            
        }

        //Respuesta
        public static ILogicaRespuesta getLogicaRespuesta()
        {
            return (LogicaRespuesta.GetMiInstancia()); 
        }

        //Usuario
        public static ILogicaUsuario getLogicaUsuario()
        {
            return (LogicaUsuario.GetMiInstancia());
        }
 
    }
}