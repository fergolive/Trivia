using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntidadesCompartidas;

namespace WindowsTrivia
{
    public partial class FrmLogueo : Form
    {
        public FrmLogueo()
        {
            InitializeComponent();
            userControlLogueo1.AutenticarUsuario += new EventHandler(VerificoDatosIngresados);
        }

        public void VerificoDatosIngresados(object sender, EventArgs e)
        {
            try
            {
                String user = userControlLogueo1.Usuario.ToString();
                String pass = userControlLogueo1.Contraseña.ToString();
                Jugador usuarioEncontrado = (Jugador)Logica.FabricaLogica.getLogicaUsuario().Logueo_Usuario(user, pass);

                if (usuarioEncontrado == null)
                    lblError.Text = "Usuario o Contraseña Invalidos";
                else
                {
                    this.Hide();
                    Form nuevoForm = new FrmPrincipal(usuarioEncontrado);
                    nuevoForm.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       
    }
}
   

