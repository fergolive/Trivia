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

            return (LogicaJugador.GetMiAdministrador());
            
        }

        //Juego
        public static ILogicaJuego getLogicaJuego()
        {

            return (LogicaJuego.GetMiInstancia());
            
        }

        //Pregunta
        public static ILogicaPregunta getLogicaPregunta()
        {

            return (LogicaJugador.GetMiPregunta());
            
        }

        //Respuesta
        public static ILogicaRespuesta getLogicaRespuesta()
        {

            return (LogicaJugador.GetMiRespuesta());
          
        }
 
    }
}