using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using EntidadesCompartidas;

public partial class FrmEstadisticasJuegos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            //obtengo un documento xml creado con los datos de la BD
            XmlDocument _DocumentXML = Logica.FabricaLogica.getLogicaJuego().ObtenerDocumentoXmlJuego();
            XDocument _DocumentoX=XDocument.Parse(_DocumentXML.OuterXml);
           
            //filtro LINQ
            var juegos = from j in _DocumentoX.Descendants("Juego") select j;



            List<Juego> listaJuegoGrid = new List<Juego>();
            foreach (XElement j in juegos)
            {
                
                Juego juego = new Juego();

                juego.Numero=Convert.ToInt32(j.Element("Numero").Value);
                juego.FechaHoraInicio =Convert.ToDateTime(j.Element("FechaHoraInicio").Value);
                juego.FechaHoraFinal=Convert.ToDateTime(j.Element("FechaHoraFinal").Value);
                juego.CantMovimientos= Convert.ToInt32(j.Element("cantMovimientos").Value);
                juego.ContestacionesOK = Convert.ToInt32(j.Element("ContestacionesOk").Value);
                juego.Player.Nombre = j.Element("Jugador").Value;

                listaJuegoGrid.Add(juego);
                    
            }
            GridView1.DataSource = listaJuegoGrid;
            GridView1.DataBind();

        }
        catch (Exception es)
        {
            lblError.Text = es.Message;
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        try
        {
            //obtengo un documento xml creado con los datos de la BD
            XmlDocument _DocumentXML = Logica.FabricaLogica.getLogicaJuego().ObtenerDocumentoXmlJuego();
            XDocument _DocumentoX = XDocument.Parse(_DocumentXML.OuterXml);

            var juegos = from j in _DocumentoX.Descendants("Juego")
                         orderby Convert.ToInt32(j.Element("cantMovimientos").Value) descending
                         select new
                         {
                             
                             Numero = j.Element("Numero").Value,
                             FechaHoraInicio = j.Element("FechaHoraInicio").Value,
                             FechaHoraFinal = j.Element("FechaHoraFinal").Value,
                             CantMovimientos = j.Element("cantMovimientos").Value,
                             ContestacionesOk=j.Element("ContestacionesOK").Value,
                             Player = j.Element("Jugador").Value
                         };

            List<Juego> juegosOrdenados = new List<Juego>();

            //agrego los resultados a una lista de juegos
            foreach (var game in juegos)
            {
                
                 int Numero = Convert.ToInt32(game.Numero);
                 DateTime FechaHoraInicio = Convert.ToDateTime(game.FechaHoraInicio);
                 DateTime FechaHoraFinal = Convert.ToDateTime(game.FechaHoraFinal);
                 int CantMovimientos = Convert.ToInt32(game.CantMovimientos);
                 int ContestacionesOk = Convert.ToInt32(game.ContestacionesOk); 
                 Jugador jugador=new Jugador();
                 jugador.Nombre = game.Player;

                Juego _juego = new Juego(Numero,FechaHoraInicio,FechaHoraFinal,CantMovimientos,ContestacionesOk,jugador,null,null);
                juegosOrdenados.Add(_juego);

            }

            GridView1.DataSource = juegosOrdenados;
            GridView1.DataBind();
        }
        catch (Exception es) { lblError.Text = es.Message; }
    }
    protected void Button4_Click(object sender, EventArgs e)
    {  
        try
        {
        //obtengo un documento xml creado con los datos de la BD
            XmlDocument _DocumentXML = Logica.FabricaLogica.getLogicaJuego().ObtenerDocumentoXmlJuego();
            XDocument _DocumentoX = XDocument.Parse(_DocumentXML.OuterXml);

            var juegos = from j in _DocumentoX.Descendants("Juego")
                       
                         orderby ((Convert.ToDateTime(j.Element("FechaHoraFinal").Value))-(Convert.ToDateTime(j.Element("FechaHoraInicio").Value))) descending
                         select new
                         {
                             
                             Numero = j.Element("Numero").Value,
                             FechaHoraInicio = j.Element("FechaHoraInicio").Value,
                             FechaHoraFinal = j.Element("FechaHoraFinal").Value,
                             CantMovimientos = j.Element("cantMovimientos").Value,
                             ContestacionesOK=j.Element("ContestacionesOk").Value,
                             Player = j.Element("Jugador").Value
                         };

            List<Juego> juegosOrdenados = new List<Juego>();

            //agrego los resultados a una lista de juegos
            foreach (var game in juegos)
            {
                
                 int Numero = Convert.ToInt32(game.Numero);
                 DateTime FechaHoraInicio = Convert.ToDateTime(game.FechaHoraInicio);
                 DateTime FechaHoraFinal = Convert.ToDateTime(game.FechaHoraFinal);
                 int CantMovimientos = Convert.ToInt32(game.CantMovimientos);
                 int ContestacionesOk=Convert.ToInt32(game.ContestacionesOK);
                 Jugador jugador=new Jugador();
                 jugador.Nombre = game.Player;

                Juego _juego = new Juego(Numero,FechaHoraInicio,FechaHoraFinal,ContestacionesOk,CantMovimientos,jugador,null,null);
                juegosOrdenados.Add(_juego);

            }

            GridView1.DataSource = juegosOrdenados;
            GridView1.DataBind();
        }
        catch (Exception es) { lblError.Text = es.Message; }
    }
}