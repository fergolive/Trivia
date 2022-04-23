using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface IPersistenciaJugador
    {
        void Alta_Jugador(Jugador j);
        void Baja_Jugador(Jugador j);
        void Modificacion_Jugador(Jugador j);
		Jugador Buscar_Jugador(int numJugador);
		List<Jugador> Listar_Jugador();
        Jugador Logueo_Jugador(String user,String pass);
        Jugador Buscar_Jugador_xnumJuego(int numJugador);
        List<Jugador> ListarJugadoresJuegosFinalizados();
    }
}
