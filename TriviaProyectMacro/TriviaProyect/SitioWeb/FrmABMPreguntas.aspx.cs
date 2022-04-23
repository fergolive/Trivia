using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class FrmABMPreguntas : System.Web.UI.Page
{
    Pregunta preguntaEncontrada;


    protected void Page_Load(object sender, EventArgs e)
    {

        
    }


  
    }

    protected void btnAlta_Pregunta_Click(object sender, EventArgs e)
    {
        try
        {
            //declaracion de datos
            int numero=0;
            String tipo;
            String texto; //200 caracteres max
            String mensajeDeError="falta ingresar: ";

            //asignacion de datos
            if(rbdTipo.checked=="Geografia")
            {tipo="Geografia"}
            if(rbdTipo.checked=="Ciencias")
            {tipo="Ciencias"}
            if(rbdTipo.checked=="Deportes")
            {tipo="Deportes"}
           
            texto=txtTipo.Text;

            //chequeo de datos
            if(tipo==""){mensajeDeError+="tipo, ";}
            if(texto==""){mensajeDeError+="texto, ";}
            else{//chequear cantidad de caracteres}


            if(mensajeDeError=="falta ingresar: ")
            {
                Pregunta p=new Pregunta(numero,tipo,texto); //creo una nueva pregunta
                Logica.FabricaLogica.GetLogicaPregunta().AltaPregunta(p);   //doy de alta la nueva pregunta
            }
            else{lblError.Text=mensajeDeError;}
        }
        catch (Exception es){MostrarError(es)}
        
        
    }

    private void MostrarError(Exception es)
    {

        lblError.Text="Error: "+es.message;
    }

   
}