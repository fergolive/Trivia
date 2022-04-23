using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface ILogicaJugador
    {
        void Alta_Jugador(Jugador j);
        void Baja_Jugador(Jugador j);
        void Modificacion_Jugador(Jugador j);
		Jugador Buscar_Jugador(int numdoc);
		List<Jugador> Listar_Jugador();
        List<Jugador> ListarJugadoresJuegosFinalizados();
      
    }
}
