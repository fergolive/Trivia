using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace EntidadesCompartidas
{

    public class Pregunta
    {
        private int numero;
        private String tipo;
        private String texto;
        private List<Respuesta> respuestas; //3 respuestas

        public Pregunta()
        {

            numero = 0;
            tipo = "sin tipo";
            texto = "sin texto de pregunta";
            respuestas = new List<Respuesta>();
        }


        public Pregunta(int num, String _tipo, String text, List<Respuesta> _respuestas)
        {

            numero = num;
            tipo = _tipo;
            texto = text;
            respuestas = _respuestas;

        }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public String Texto
        {
            get { return texto; }
            set { texto = value; }
        }

        public List<Respuesta> Respuestas
        {
            get { return respuestas; }
            set { respuestas = value; }
        }
    }
}
