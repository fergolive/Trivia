using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica.Interface
{
    public interface ILogicaJugador
    {
        void Alta_Jugador(Jugador j);
        void Baja_Jugador(Jugador j);
        void Modificacion_Jugador(Jugador j);
		Jugador Buscar_Jugador(Jugador j);
		List<Jugador> Listar_Jugador();

    }
}
