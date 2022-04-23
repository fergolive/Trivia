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
    public partial class FrmJuugar : Form
    {
        String respCorrecta="";
        Juego nuevoJuego=null;
 
        Button botonSeleccionado=null;
        bool guardarUltimo = true;
        bool finalizado = false;
        bool banderaRecienContestada = false;

        public FrmJuugar(Juego j)
        {
            InitializeComponent();
            nuevoJuego = j;
            lblUser.Text = nuevoJuego.Player.NomPublico;
        }

        int movRealizados;
        int movPermitidos;

        private void InicializarDatos() 
        {
            btnTirarDados.Enabled = true;
           
            //estadisticas
            movRealizados = nuevoJuego.CantMovimientos;
            lblMovRealliz.Text ="Movimientos realizados: "+ movRealizados;
            movPermitidos = -1;
            lblMovPermitidos.Text = "Movimientos Permitidos: 0";
            lblContestCorrectas.Text ="Contestaciones Ok: "+ Convert.ToString(nuevoJuego.ContestacionesOK);

            //etiquetas
            lblAvisoRespuesta.Text = "";
            lblerror.Text = "Para comenzar tire los dados...";
            lblUser.Text = nuevoJuego.Player.NomPublico;

            //deshanilito cuadricula de butons
            foreach (Control c in panel1.Controls)
            {
                ((Button)c).Enabled = false;
            }
  
        }

        private void buttons_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                lblerror.Text = "";

                if (botonSeleccionado != null)
                {

                    if ((botonSeleccionado.Text != "x") && (movPermitidos == 0))
                    {
                        if (e.KeyCode == Keys.Space)
                        {

                            panelPregResp.Enabled = true;
                            panelPregResp.Visible = true;

                            //muestro los datos de la pregunta que eligio
                            foreach (Pregunta preg in nuevoJuego.Preguntas)
                            {
                                if (preg.Numero == Convert.ToInt32(botonSeleccionado.Text))
                                {
                                    txtPregunta.Text = "[" + preg.Numero + "][" + preg.Tipo + "] - " + preg.Texto; //pregunta
                                    rdb1.Text = preg.Respuestas[0].Texto; //respuesta1
                                    rdb2.Text = preg.Respuestas[1].Texto; //respuesta2
                                    rdb3.Text = preg.Respuestas[2].Texto; //respuesta3

                                    //busco la respuesta correcta y la guardo en respCorrecta xra compararla mas adelante
                                    foreach (Respuesta resp in preg.Respuestas)
                                    {
                                        if (resp.Correcta == true)
                                        {
                                            respCorrecta = resp.Texto;//guardo la respuesta correcta
                                        }
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        if (movPermitidos > 0)
                        {

                            lblerror.Text = "Tiene movimientos para realizar";

                        }
                        if (botonSeleccionado.Text == "x")
                        {
                            lblerror.Text = "Tire los dados nuevamente!";
                            btnTirarDados.Enabled = true;
                        }
                    }

                }
                else { lblerror.Text = "Tiene movimientos para realizar"; }
            }
            catch (Exception es)
            {
                lblerror.Text = "Error: " + es.Message;
            }
        }

   
        private void FrmJuugar_Load(object sender, EventArgs e)
        {
            InicializarDatos();
            txtPregunta.Text = "";
            panelPregResp.Enabled = false;
            panelPregResp.Visible = false;
            btnResponder.Enabled = false;
           
            //deschequeo los radio butons
            foreach (Control rb in panel2.Controls)
            {
                ((RadioButton)rb).Checked = false;
                ((RadioButton)rb).Text = "";
            }

            //pintar botones y enumerarlos
            for (int i = 0; i < nuevoJuego.Preguntas.Count; i++)
            {
                ((Button)panel1.Controls[i]).Text = nuevoJuego.Preguntas[i].Numero.ToString();
                if (nuevoJuego.Preguntas[i].Tipo == "Deporte")
                {((Button)panel1.Controls[i]).BackColor = System.Drawing.Color.Red; }
                if (nuevoJuego.Preguntas[i].Tipo == "Ciencia")
                { ((Button)panel1.Controls[i]).BackColor = System.Drawing.Color.YellowGreen; }
                if (nuevoJuego.Preguntas[i].Tipo == "Geografia")
                { ((Button)panel1.Controls[i]).BackColor = System.Drawing.Color.RoyalBlue; }
            }

            //marcar los botones que tenian x la ultima vez guardada
            if (nuevoJuego.EstadosPreguntas != null)
            {
                //posiciones de preguntas conestadas (almaceno las posiciones de preg contestadas como 1 en una coleccion)
                for (int i = 0; i < nuevoJuego.EstadosPreguntas.Count; i++)
                {
                    if (nuevoJuego.EstadosPreguntas[i] == 1)
                    {
                        panel1.Controls[i].Text = "x";
                        panel1.Controls[i].BackColor = System.Drawing.Color.Gray;
                    }
                }
            }

        }

        private void button1_Enter(object sender, EventArgs e)
        {    
           // lblerror.Text = "";
            try
            {
                    if (movPermitidos == 0)
                    {
                        //bandera para guardar ultimo
                        if (guardarUltimo == true)
                        {
                            botonSeleccionado = ((Button)sender);
                            guardarUltimo = false;
                        }

                         if ( (((Button)sender).Text == "x") && (movPermitidos==0) && (banderaRecienContestada==false))
                        {
                            lblerror.Text = "Ya ha respondido esta pregunta, presione espacio";
                            
                        }
   
                    }
                }
            catch (Exception es) { lblerror.Text = es.Message; }
        }

        private void MostrarAviso(bool respuesta)
        {
            if (respuesta == true)
            {
                lblAvisoRespuesta.Text = "Respuesta Correcta";
                lblContestCorrectas.Text="Contestaciones ok: "+nuevoJuego.ContestacionesOK.ToString();
              
            }
            else
            { 
                lblAvisoRespuesta.Text = "Respuesta Incorrecta"; 
            }
        }

        private void btnTirarDados_Click(object sender, EventArgs e)
        {
            lblAvisoRespuesta.Text = "";
            lblerror.Text = "";
            try
            {

                //habilito botones
                foreach (Control c in panel1.Controls)
                {
                    ((Button)c).Enabled = true;
                }
                if (movPermitidos == -1)
                {
                    movPermitidos = 3;
                }
                else
                {
                    movPermitidos = 3;
                    botonSeleccionado.Focus();
                    botonSeleccionado = null;
                }


                lblMovPermitidos.Text = "Movimientos Permitidos: " + movPermitidos;
                guardarUltimo = true;

                

                btnTirarDados.Enabled = false;//deshabilito este boton
            }
            catch (Exception es) { lblerror.Text = "No se ha podido tirar los dados, Error: " + es.Message; }
        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            btnResponder.Enabled = true;
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            btnResponder.Enabled = true;
        }

        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            btnResponder.Enabled = true;
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            lblAvisoRespuesta.Text = "";
            banderaRecienContestada = false;

            RadioButton rbdCheq = null;
            foreach (RadioButton rbt in panel2.Controls)
            {
                if (rbt.Checked == true)
                {
                    rbdCheq = rbt;
                }
            }


            if (rbdCheq != null)
            {
                if (rbdCheq.Text == respCorrecta)
                {

                    lblAvisoRespuesta.Text = "Respuesta Correcta";
                    banderaRecienContestada = true;
                    
                    nuevoJuego.ContestacionesOK += 1;   
                    lblContestCorrectas.Text = "Contestaciones Ok: " + nuevoJuego.ContestacionesOK.ToString();
                    botonSeleccionado.BackColor = System.Drawing.Color.Gray;
                    botonSeleccionado.Text = "x";

                    if (nuevoJuego.ContestacionesOK == 9)
                    {
                        finalizado = true;
                        lblerror.Text = "Juego Finalizado, Presiones guardar";
                    }
                }
                else
                {
                    lblAvisoRespuesta.Text = "";
                    lblAvisoRespuesta.Text = "Respuesta Incorrecta";
                }

            }

            
                txtPregunta.Text = "";
                foreach (Control rb in panel2.Controls)
                {
                    ((RadioButton)rb).Checked = false;
                    ((RadioButton)rb).Text = "";
                }

                panelPregResp.Enabled = false;
                panelPregResp.Visible = false;
                btnResponder.Enabled = false;

                if (finalizado == false)
                {
                    btnTirarDados.Enabled = true;
                    btnTirarDados.Focus();
                }
            
        }
        private void button1_Leave(object sender, EventArgs e)
        {
            if (movPermitidos - 1 == 0)
            {
                lblerror.Text = "No tiene mas movimientos, presione espacio para ver la pregunta";
            }

            if (movPermitidos > 0)
            {
                movPermitidos -= 1;
                movRealizados += 1;

                //guardo movimientos en el juego
                nuevoJuego.CantMovimientos = movRealizados;
                
                lblMovPermitidos.Text = "Mov Permitidos = " + movPermitidos;
                lblMovRealliz.Text = "Mov Realizados = " + movRealizados;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                nuevoJuego.EstadosPreguntas = new List<int>();

                finalizado = true;

                //guardar posicion de boton x
                for (int i = 0; i < panel1.Controls.Count; i++)
                {
                    //if (((Button)panel1.Controls[i]).Text == "x")
                    //{
                        nuevoJuego.EstadosPreguntas.Add(1); //si es x el texto del boton guardo un 1
                       
                    //}
                   // else
                    //{
                    //    nuevoJuego.EstadosPreguntas.Add(0); // si no es x el texto del boton guardo 0
                      
                    //}
                }

                Logica.FabricaLogica.getLogicaJuego().Guardar_Juego(nuevoJuego, finalizado);

                if (finalizado == true)
                {
                    this.Hide();
                    FrmCrearJuego nuevoForm = new FrmCrearJuego(nuevoJuego.Player,nuevoJuego,true); //jugador / juego / juego finalizado
                    nuevoForm.ShowDialog();
   
                    this.Close();
                }
                else
                {
                    lblerror.Text = "juego guardado exitosamente!";
                }
            }
            catch (Exception es)
            {
                lblerror.Text = "No se ha podido guardar el juego, Error: " + es.Message;
            }
        }

      

   

      

    }
}
