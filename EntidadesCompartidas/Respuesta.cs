using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace EntidadesCompartidas
{

    public class Respuesta
    {
        private int numero;
        private String texto;
        private bool correcta;

        public Respuesta()
        {

            numero = 0;
            texto = "sin texto";
            correcta = false;
        }


        public Respuesta(int num, String _text, bool _correcta)
        {

            numero = num;
            texto = _text;
            correcta = _correcta;

        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public String Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public bool Correcta
        {

            get { return correcta; }
            set { correcta = value; }

        }
    }
}