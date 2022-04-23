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
    public partial class FrmPrincipal : Form
    {
        Jugador jugadorLogueado = null;

        public FrmPrincipal(Jugador jugador)
        {
            InitializeComponent();
            lblUsuario.Text = jugador.NomPublico;
            jugadorLogueado = jugador;

            //COMPROBAR DISPONIBILIDAD DE JUEGO ,confirmo si debo continuar un juego o si puedo empezar uno nuevo
            bool disponible = Logica.FabricaLogica.getLogicaJuego().ComprobarDisponibilidadDeJuego(jugador.Documento);

            if(disponible==true)
            {
                btnNuevo.Enabled=true;
                btnContinuar.Enabled=false;
            }
            else
            {
                btnNuevo.Enabled=false;
                btnContinuar.Enabled=true;
            
            }
        }


    
        //SALIR
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();
                Form nuevoForm = new FrmLogueo();
                nuevoForm.ShowDialog();
                this.Close();
            }
            catch (Exception es) { lblError.Text = es.Message; }
        }


        //CONTINUAR JUEGO PENDIENTE
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            try
            {

                //buscar juego pendiente sin finalizar
                Juego nuevo = Logica.FabricaLogica.getLogicaJuego().Buscar_Juego_Pendiente(jugadorLogueado.Documento);

                this.Hide();
                Form nuevoForm = new FrmCrearJuego(jugadorLogueado, nuevo, false);
                nuevoForm.ShowDialog();
                this.Close();
            }
            catch (Exception es) { lblError.Text = es.Message; }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                //creo un juego nuevo
             

                this.Hide();
                Form nuevoForm = new FrmCrearJuego(jugadorLogueado, null, false);
                nuevoForm.ShowDialog();
                this.Close();


            }
            catch (Exception es) 
            { 
                lblError.Text = es.Message; 
            }
        }




 

       
    }
}
