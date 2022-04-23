using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace EntidadesCompartidas
{

    public class Administrador : Usuario
    {
        private bool genEstadisticas;

        public Administrador()
            : base()
        {

            genEstadisticas = false;
        }


        public Administrador(int doc, String _user, String _pass, String nombre, bool _genEstadisticas)
            : base(doc, _user, _pass, nombre)
        {

            genEstadisticas = _genEstadisticas;

        }

        public bool GenEstadisticas
        {
            get { return genEstadisticas; }
            set { genEstadisticas = value; }
        }
    }

}