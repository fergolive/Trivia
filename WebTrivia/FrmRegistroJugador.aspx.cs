using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class FrmRegistroJugador : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String mensajeDeError = "Falta ingresar: ";
        int documento=0;

        try {  documento = Convert.ToInt32(txtDocumento.Text); }
        catch { mensajeDeError += "Documento, "; }

        try 
        { 
            //declaracion de datos

            
            String user=txtUser.Text;
            String pass=txtPass.Text;
            String nombre=txtNombre.Text;
            String nomPublico=txtNomPublico.Text;

            

            //chequeo de datos
            
            if(user==""){mensajeDeError+="Usuario, ";}
            if(pass==""){mensajeDeError+="Contrasena, ";}
            if(nombre==""){mensajeDeError+="Nombre Completo, ";}
            if(nomPublico==""){mensajeDeError+="Nombre Publico, ";}
            
            //mostrar error / ingresar Jugador

            if(mensajeDeError=="Falta ingresar: ")
            {

                Jugador miJugador=new Jugador(documento,user,pass,nombre,nomPublico);  //creo el Jugador
                Logica.FabricaLogica.getLogicaJugador().Alta_Jugador(miJugador);     //doy de alta el Jugador
                Response.Redirect("~/FrmDescargaJuego.aspx", false);                                         //vuelvo a la pagina principal
            
            }
            else{lblError.Text=mensajeDeError;}
            
        }
        catch (Exception es) { lblError.Text = "Error: " + es.Message; }
    
    }
    
    protected void txtDocumento_TextChanged(object sender, EventArgs e)
    {
         int documento = 0;
        try
        {
            documento = Convert.ToInt32(txtDocumento.Text);
        }
        catch (Exception es) { MostrarError(es); }

        try
        {

            Jugador jugadorEncontrado = Logica.FabricaLogica.getLogicaJugador().Buscar_Jugador(documento);
   
           

            if (jugadorEncontrado != null)
            {

                Session["JugadorEcontrado"] = jugadorEncontrado;

                //mustro los datos de la pregunta

                txtDocumento.Text = jugadorEncontrado.Documento.ToString();
                txtNombre.Text=jugadorEncontrado.Nombre.ToString();
                txtNomPublico.Text=jugadorEncontrado.NomPublico.ToString();
                txtPass.Text=jugadorEncontrado.Pass.ToString();
                txtUser.Text=jugadorEncontrado.User.ToString();
                    
            }
            else { lblError.Text = "No existe un jugador con el documento: " + documento;
                LimpiarCampos();
            }
        }
        catch (Exception es) { MostrarError(es); }
    }

     private void MostrarError(Exception es)
    {
        lblError.Text="Error: "+   es.Message;
    }

    private void LimpiarCampos()
    {
    
    }
}