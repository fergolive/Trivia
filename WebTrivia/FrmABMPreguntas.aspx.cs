using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class FrmABMPreguntas : System.Web.UI.Page
{
   List<Respuesta> respuestas=new List<Respuesta>();
    
    Pregunta preguntaEncontrada=null;
    
   

    protected void Page_Load(object sender, EventArgs e)
    {
        Respuesta respuesta1 = new Respuesta();
        Respuesta respuesta2 = new Respuesta();
        Respuesta respuesta3 = new Respuesta();

        respuestas.Add(respuesta1);
        respuestas.Add(respuesta2);
        respuestas.Add(respuesta3);

        //genero tres numeros del 1 al 3 
        List<int> lista = generarNumerosDeRespuestas();
        //los muestro en cada radio button
        rbdlistCorrecta.Items[0].Text= lista[0].ToString();
        rbdlistCorrecta.Items[1].Text= lista[1].ToString();
        rbdlistCorrecta.Items[2].Text= lista[2].ToString();
        //asigno los numeros a cada respuesta
        respuestas[0].Numero = Convert.ToInt32(lista[0]);
        respuestas[1].Numero = Convert.ToInt32(lista[1]);
        respuestas[2].Numero = Convert.ToInt32(lista[2]);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
         try
        {
            //declaracion de datos para la pregunta
            int numero=0;
            String tipo="";
            String texto; //200 caracteres max
            String mensajeDeError="falta ingresar: ";
            

            //asignacion de datos
            if(rbdListTipo.Items[0].Selected)
            {tipo="Geografia";}
            if(rbdListTipo.Items[1].Selected)
            {tipo="Ciencia";}
            if(rbdListTipo.Items[2].Selected)
            {tipo="Deporte";}
           
            texto=txtPregunta.Text;
            respuestas[0].Texto=txtRespuesta1.Text;
            respuestas[1].Texto=txtRespuesta2.Text;
            respuestas[2].Texto=txtRespuesta3.Text;

            if (rbdlistCorrecta.Items[0].Selected)
            { respuestas[0].Correcta = true; }
            else { respuestas[0].Correcta = false; }
            if (rbdlistCorrecta.Items[1].Selected)
            { respuestas[1].Correcta = true; }
            else { respuestas[1].Correcta = false; }
            if (rbdlistCorrecta.Items[2].Selected)
            { respuestas[2].Correcta = true; }
            else { respuestas[2].Correcta = false; }


            //chequeo de datos
         
            if(texto==""){mensajeDeError+="texto, ";}
            if (texto.Length > 200) { mensajeDeError += "texto contiene mas de 200 caracteres, "; }

            
            if(rbdlistCorrecta.SelectedItem==null){mensajeDeError+="respuesta correcta, ";}
            if(respuestas[0].Texto=="sin respuesta"){mensajeDeError+="respuesta 1, ";}
            if(respuestas[1].Texto=="sin respuesta"){mensajeDeError+="respuesta 2, ";}
            if(respuestas[2].Texto=="sin respuesta"){mensajeDeError+="respuesta 3, ";}

            if(respuestas[0].Texto.Length>70){mensajeDeError += "respuesta 1 contiene mas de 70 caracteres, "; }
            if(respuestas[1].Texto.Length>70){mensajeDeError+="respuesta 2 contiene mas de 70 caracteres, ";}
            if(respuestas[2].Texto.Length>70){mensajeDeError+="respuesta 3 contiene mas de 70 caracteres, ";}

            if(mensajeDeError=="falta ingresar: ")
            {
                Pregunta p=new Pregunta(numero,tipo,texto,respuestas); //creo una nueva pregunta
               
                Logica.FabricaLogica.getLogicaRespuesta().Alta_Respuestas(p);
               /*
                LimpiarCampos();
                lblError.Text = "Se ha creado una nueva pregunta";
                txtNumero.Text = "";
            
                */
                Response.Redirect("~/FrmABMPreguntas.aspx", false);          
                }
           
            else{lblError.Text=mensajeDeError;}
         }
            catch (Exception es){MostrarError(es);}
    
      }
   
            
    protected void  btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Pregunta preguntaEncontrada = (Pregunta)Session["PreguntaEcontrada"];

            if(preguntaEncontrada!=null)
            {
                Logica.FabricaLogica.getLogicaPregunta().Baja_Pregunta(preguntaEncontrada);
                Response.Redirect("~/FrmABMPreguntas.aspx", false);  

            }
        }
        catch(Exception es){MostrarError(es);}
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        int numero=0;

        try { numero = Convert.ToInt32(txtNumero.Text); }
        catch { lblError.Text="Debe ingresar el numero de la pregunta"; }


         try
        {
            //declaracion de datos para la pregunta
            
            String tipo="";
            String texto; //200 caracteres max
            String mensajeDeError="falta ingresar: ";
            

            //asignacion de datos
            if(rbdListTipo.Items[0].Selected)
            {tipo="Geografia";}
            if(rbdListTipo.Items[1].Selected)
            {tipo="Ciencia";}
            if(rbdListTipo.Items[2].Selected)
            {tipo="Deporte";}
           
            texto=txtPregunta.Text;
            respuestas[0].Texto=txtRespuesta1.Text;
            respuestas[1].Texto=txtRespuesta2.Text;
            respuestas[2].Texto=txtRespuesta3.Text;

            if (rbdlistCorrecta.Items[0].Selected)
            { respuestas[0].Correcta = true; }
            else { respuestas[0].Correcta = false; }
            if (rbdlistCorrecta.Items[1].Selected)
            { respuestas[1].Correcta = true; }
            else { respuestas[1].Correcta = false; }
            if (rbdlistCorrecta.Items[2].Selected)
            { respuestas[2].Correcta = true; }
            else { respuestas[2].Correcta = false; }


            //chequeo de datos
         
            if(texto==""){mensajeDeError+="texto, ";}
            else{//chequear cantidad de caracter
            }
            if(rbdlistCorrecta.SelectedItem==null){mensajeDeError+="respuesta correcta, ";}
            if(respuestas[0].Texto=="sin respuesta"){mensajeDeError+="respuesta 1, ";}
            if(respuestas[1].Texto=="sin respuesta"){mensajeDeError+="respuesta 2, ";}
            if(respuestas[2].Texto=="sin respuesta"){mensajeDeError+="respuesta 3, ";}


            if(mensajeDeError=="falta ingresar: ")
            {
                Pregunta p=new Pregunta(numero,tipo,texto,respuestas); //creo una nueva pregunta
               
                Logica.FabricaLogica.getLogicaPregunta().Modificacion_Pregunta(p);

                Response.Redirect("~/FrmABMPreguntas.aspx", false);  
            }
            else{lblError.Text=mensajeDeError;}
         }
            catch (Exception es){MostrarError(es);}
   
    }

    private void MostrarError(Exception es)
    {
        lblError.Text="Error: "+   es.Message;
    }

    private List<int> generarNumerosDeRespuestas()
    {
      Random r = new Random();
      List<int> lista = new List<int>(3);
      while (lista.Count < 3)
      {

        int a = r.Next(1, 4);
        if (!lista.Contains(a))
        {
          lista.Add(a);
        }
      }
      return lista;
    }


    protected void txtNumero_TextChanged(object sender, EventArgs e)
    {
        int numero = 0;

        try
        {


            numero = Convert.ToInt32(txtNumero.Text);

        }
        catch (Exception es) { MostrarError(es); }

        try
        {

            preguntaEncontrada = Logica.FabricaLogica.getLogicaPregunta().Buscar_Pregunta(numero);

            //Session["PreguntaEcontrada"] = new Pregunta();
            Session["PreguntaEcontrada"] = preguntaEncontrada;

            if (preguntaEncontrada != null)
            {
                //mustro los datos de la pregunta

                txtPregunta.Text = preguntaEncontrada.Texto;

                if (preguntaEncontrada.Tipo == "Geografia")
                { rbdListTipo.Items[0].Selected = true; }
                if (preguntaEncontrada.Tipo == "Ciencia")
                { rbdListTipo.Items[1].Selected = true; }
                if (preguntaEncontrada.Tipo == "Deporte")
                { rbdListTipo.Items[2].Selected = true; }

                
                //muestro la primera respuesta
                if (preguntaEncontrada.Respuestas[0].Correcta == true) //si es la correcta la marco en el form
                { rbdlistCorrecta.Items[0].Selected = true; }
                txtRespuesta1.Text =preguntaEncontrada.Respuestas[0].Texto; //muestro el texto de la misma
                rbdlistCorrecta.Items[0].Text =preguntaEncontrada.Respuestas[0].Numero.ToString(); //mustro el numero de la respuesta

                //muestro la segunda respuesta
                if (preguntaEncontrada.Respuestas[1].Correcta == true)
                { rbdlistCorrecta.Items[1].Selected = true; }
                txtRespuesta2.Text =preguntaEncontrada.Respuestas[1].Texto;
                rbdlistCorrecta.Items[1].Text =preguntaEncontrada.Respuestas[1].Numero.ToString();

                //muestro la tercera respuesta
                if (preguntaEncontrada.Respuestas[2].Correcta == true)
                { rbdlistCorrecta.Items[2].Selected = true; }
                txtRespuesta3.Text =preguntaEncontrada.Respuestas[2].Texto;
                rbdlistCorrecta.Items[2].Text =preguntaEncontrada.Respuestas[2].Numero.ToString();

                //habilito botones para eliminar y modificar
                btnBaja.Enabled = true;
                btnModificar.Enabled = true;
                btnAgregar.Enabled = false;

            }
            else { lblError.Text = "No existe una Pregunta con el numero: " + numero;
            LimpiarCampos();
            btnAgregar.Enabled = true;
            }
        }
        catch (Exception es) { MostrarError(es); }
    }

    public void LimpiarCampos()
    {
        
        txtPregunta.Text="";
        rbdlistCorrecta.Items[0].Selected = false;
        rbdlistCorrecta.Items[1].Selected = false;
        rbdlistCorrecta.Items[2].Selected = false;

        rbdListTipo.Items[0].Selected = false;
        rbdListTipo.Items[1].Selected = false;
        rbdListTipo.Items[2].Selected = false;

        txtRespuesta1.Text = "";
        txtRespuesta2.Text = "";
        txtRespuesta3.Text = "";
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnBaja.Enabled = false;

    }
  
}
