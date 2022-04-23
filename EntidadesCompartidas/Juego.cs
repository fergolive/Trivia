using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace EntidadesCompartidas
{
    public class Juego
    {
        private int numero;
        private DateTime fechaHoraInicio;
        private DateTime fechaHoraFinal;
        private int cantMovimientos;
        private int contestacionesOK;
        private Jugador player;
        private List<Pregunta> preguntas; //9 preguntas
        private List<int> estadosPreguntas; //si fueron contestadas correctamente o no 1:contestada correctamente 0:no ha sido contestada



        public Juego()
        {
            numero = 0;
            fechaHoraInicio = DateTime.Now;
            fechaHoraFinal = DateTime.Now;
            cantMovimientos = 0;
            contestacionesOK = 0;
            player = new Jugador();
            preguntas = new List<Pregunta>();
            estadosPreguntas = new List<int>();
        }


        public Juego(int num, DateTime fHoraInicio, DateTime fHoraFin, int cantMoves,int contestaciones, Jugador _jugador, List<Pregunta> _preguntas,List<int> estPreguntas)
        {

            numero = num;
            fechaHoraInicio = fHoraInicio;
            fechaHoraFinal = fHoraFin;
            cantMovimientos = cantMoves;
            contestacionesOK=contestaciones;
            player = _jugador;
            preguntas = _preguntas;
            estadosPreguntas = estPreguntas;
        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public DateTime FechaHoraInicio
        {
            get { return fechaHoraInicio; }
            set { fechaHoraInicio = value; }
        }

        public DateTime FechaHoraFinal
        {
            get { return fechaHoraFinal; }
            set { fechaHoraFinal = value; }
        }


        public int CantMovimientos
        {
            get { return cantMovimientos; }
            set { cantMovimientos = value; }
        }

        public int ContestacionesOK
        {
            get { return contestacionesOK; }
            set { contestacionesOK = value; }
        }

        public Jugador Player
        {
            get { return player; }
            set { player = value; }
        }

        public List<Pregunta> Preguntas
        {

            get { return preguntas; }
            set { preguntas = value; }
        }

        public String Nombrejugador
        {
            get { return player.Nombre; }
        }

        public List<int> EstadosPreguntas
        {
            get { return estadosPreguntas; }
            set { estadosPreguntas = value; }
        }
    }
}