using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace EntidadesCompartidas
{

    public class Usuario
    {
        private int documento;
        private String user;
        private String pass;
        private String nombre;

        public Usuario()
        {

            documento = 0;
            user = "sin usuario";
            pass = "sin contraseña";
            nombre = "sin nombre";
        }


        public Usuario(int doc, String _user, String _pass, String _nombre)
        {

            documento = doc;
            user = _user;
            pass = _pass;
            nombre = _nombre;
        }

        public int Documento
        {
            get { return documento; }
            set { documento = value; }
        }

        public String User
        {
            get { return user; }
            set { user = value; }
        }

        public String Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        public String Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}