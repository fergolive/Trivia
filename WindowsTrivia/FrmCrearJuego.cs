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
    public partial class FrmCrearJuego : Form
    {

        Jugador jugadorLogueado = null;
        Juego juego = null;
        bool finalizado = false;

        public FrmCrearJuego(Jugador jugador, Juego juegoPendiente, bool juegoFinalizado)
        {
            InitializeComponent();

            txtUser.Text = jugador.NomPublico; //mostrar usuario logueado
            jugadorLogueado = jugador; //guardar jugador logueado
            juego = juegoPendiente;
            finalizado = juegoFinalizado;

            if (juegoPendiente == null)
            {
                //juego nuevo
                btnNuevo.Enabled = true;
                btnJugar.Enabled = false;

            }
            else 
            { 


                //mostrar datos del juego pendiente a continuar

                if (finalizado == false)
                {

                    btnJugar.Enabled = true;
                    lblFechaHoraFin.Text = "sin fecha";
                    lbltitulo.Text = "Ultimo juego...";

                }
                else
                {
                    btnNuevo.Enabled = true;
                    btnJugar.Enabled = false;
                    lblFechaHoraFin.Text = juego.FechaHoraFinal.ToString();
                    lbltitulo.Text = "Tienes un juego que terminar...";
                }


               
                btnNuevo.Enabled = false;
               lblCantMovimientos.Text = juegoPendiente.CantMovimientos.ToString();
                lblContestOk.Text = juegoPendiente.ContestacionesOK.ToString(); 
                lblFechaHoraInicio.Text = juego.FechaHoraInicio.ToString();
                lblNumero.Text = juego.Numero.ToString();
            
            }
        }

        private void btnJugar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form nuevoForm = new FrmJuugar(juego);
            nuevoForm.ShowDialog();
            this.Close();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            Juego nuevoJuego = new Juego();
            nuevoJuego.FechaHoraInicio = DateTime.Now;
            nuevoJuego.Player = jugadorLogueado;
            nuevoJuego.CantMovimientos = 0;
            nuevoJuego.ContestacionesOK = 0;

            juego = Logica.FabricaLogica.getLogicaJuego().Alta_Juego(nuevoJuego);//doy de alta un nuevo juego y lo retorno

            //muestro los nuevos datos
            lblCantMovimientos.Text = juego.CantMovimientos.ToString();
            lblContestOk.Text = juego.CantMovimientos.ToString();
            lblFechaHoraFin.Text = "sin fecha";
            lblFechaHoraInicio.Text = juego.FechaHoraInicio.ToString();
            lblNumero.Text = juego.Numero.ToString();
            lbltitulo.Text = "Haz creado un nuevo juego.";

            btnNuevo.Enabled = false;
            btnJugar.Enabled = true;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form nuevoForm = new FrmPrincipal(jugadorLogueado);
            nuevoForm.ShowDialog();
            this.Close();
        }




   
    

       
    }
}
