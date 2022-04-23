using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsTrivia.controles
{
    public partial class UserControlLogin : UserControl
    {
        public UserControlLogin()
        {
            InitializeComponent();
           
        }


        public String Usuario
        {
            get { return (txtUsuario.Text.Trim()); }
        }

        public String Contraseña
        {
            get { return (txtPass.Text.Trim()); }
        }



        //defino evento para logueo
        public event EventHandler AutenticarUsuario;

        private void button1_Click(object sender, EventArgs e)
        {
            //provoco el evento de logueo cuando se presiona el boton
            AutenticarUsuario(this, new EventArgs());
        }

   

    }
}
