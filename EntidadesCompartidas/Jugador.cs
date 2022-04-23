using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace EntidadesCompartidas
{

    public class Jugador : Usuario
    {
        private String nomPublico;


    public Jugador(): base()
	{

        nomPublico = "sin nombre publico";
	}


        public Jugador(int doc, String _user, String _pass, String nombre, String _nomPublico)
            : base(doc, _user, _pass, nombre)
        {

            nomPublico = _nomPublico;
        }

        public String NomPublico
        {
            get { return nomPublico; }
            set { nomPublico = value; }
        }
    }
}