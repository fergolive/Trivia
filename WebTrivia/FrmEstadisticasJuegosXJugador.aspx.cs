using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;


public partial class FrmEstadisticasJuegosXJugador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            try
            {

                List<Jugador> jugadores = Logica.FabricaLogica.getLogicaJugador().ListarJugadoresJuegosFinalizados();
                Repeater1.DataSource = jugadores;
                Repeater1.DataBind();

            }
            catch (Exception es) { lblError.Text = es.Message; }
        }
    }


    protected void repeater_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            int documento = Convert.ToInt32(e.CommandArgument);

            List<Juego> juegos = Logica.FabricaLogica.getLogicaJuego().Buscar_Juegos_xJugador(documento);
            RepJuegos.DataSource = juegos;
            RepJuegos.DataBind();
        }
        catch(Exception es)
        { lblError.Text = es.Message; }
    }

    protected void repeaterj_OnCommand(object sender, CommandEventArgs e)
    {
        try
        {
            int numero = Convert.ToInt32(e.CommandArgument);

            List<Pregunta> preguntas = Logica.FabricaLogica.getLogicaPregunta().Buscar_Preguntas(numero);
            RepPreguntas.DataSource = preguntas;
            RepPreguntas.DataBind();
        }
        catch (Exception es)
        { lblError.Text = es.Message; }
    }



}