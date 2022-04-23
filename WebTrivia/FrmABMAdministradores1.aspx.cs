using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class FrmABMAdministradores1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void txtDocumento_TextChanged(object sender, EventArgs e)
    {
        try
        {

            int numero = 0;

            numero = Convert.ToInt32(txtDocumento.Text);
            Administrador administradorEncontrado = Logica.FabricaLogica.getLogicaAdministrador().Buscar_Administrador(numero);

            if (administradorEncontrado != null)
            {
                Session["AdministradorEncontrado"] = administradorEncontrado;

                //mostrar datos del administrador encontrado
                txtNombre.Text = administradorEncontrado.Nombre.ToString();
                txtPass.Text = administradorEncontrado.Pass.ToString();
                txtUser.Text = administradorEncontrado.User.ToString();
                if (administradorEncontrado.GenEstadisticas)
                { chkEstadisticas.Checked = true; }
                else { chkEstadisticas.Checked = false; }

                //habilitar/deshabilitar botones
                btnAlta.Enabled = false;
                btnBaja.Enabled = true;
                btnModificacion.Enabled = true;
            }
            else { lblError.Text = "No existe un usuario con ese documento"; }


        }
        catch (Exception es) { MostrarError(es); }
    }

    private void MostrarError(Exception es)
    {
        lblError.Text = "Error: " + es.Message;
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        int documento = 0;
        String mensajeDeError = "Falta ingresar: ";

        try { documento = Convert.ToInt32(txtDocumento.Text); }
        catch { mensajeDeError += "documento; "; }

        try
        {
            //declaracion de datos

            String user = txtUser.Text;
            String pass = txtPass.Text;
            String nombre = txtNombre.Text;
            bool genEstadisticas = false;

            //chequeo de datos

            if (user == "") { mensajeDeError += "Usuario, "; }
            if (pass == "") { mensajeDeError += "Contrasena, "; }
            if (nombre == "") { mensajeDeError += "Nombre, "; }
            if (chkEstadisticas.Checked) { genEstadisticas = true; }
            else { genEstadisticas = false; }

            //mostrar error / ingresar administrador

            if (mensajeDeError == "Falta ingresar: ")
            {

                Administrador administrador = new Administrador(documento, user, pass, nombre, genEstadisticas);  //creo el administrador
                Logica.FabricaLogica.getLogicaAdministrador().Alta_Administrador(administrador);     //doy de alta el administrador
                Response.Redirect("~/FrmABMPreguntas.aspx", false);                                            //vuelvo a la pagina principal

            }
            else { lblError.Text = mensajeDeError; }



        }
        catch (Exception es) { lblError.Text = "Error: " + es.Message; }
    }
    protected void btnModificacion_Click(object sender, EventArgs e)
    {

        String mensajeDeError = "Falta ingresar: ";
        int documento = 0;

        try { documento = Convert.ToInt32(txtDocumento.Text); }
        catch { mensajeDeError += "Documento, "; }
        try
        {
            //declaracion de datos
            String user = txtUser.Text;
            String pass = txtPass.Text;
            String nombre = txtNombre.Text;
            bool genEstadisticas = false;

            //chequeo de datos
            if (user == "") { mensajeDeError += "Usuario, "; }
            if (pass == "") { mensajeDeError += "Contrasena, "; }
            if (nombre == "") { mensajeDeError += "Nombre, "; }
            if (chkEstadisticas.Checked) { genEstadisticas = true; }

            //mostrar error / ingresar administrador
            if (mensajeDeError == "Falta ingresar: ")
            {

                Administrador administrador = new Administrador(documento, user, pass, nombre, genEstadisticas);  //creo el administrador
                Logica.FabricaLogica.getLogicaAdministrador().Modificacion_Administrador(administrador);     //doy de alta el administrador
                Response.Redirect("~/FrmABMPreguntas.aspx", false);                                          //vuelvo a la pagina principal

            }
            else { lblError.Text = mensajeDeError; }

        }
        catch (Exception es) { MostrarError(es); }
    }
    protected void btnBaja_Click(object sender, EventArgs e)
    {

        try
        {
            if (Session["AdministradorEncontrado"] != null)
            {

                Administrador administradorEncontrado = (Administrador)Session["AdministradorEncontrado"];
                Logica.FabricaLogica.getLogicaAdministrador().Baja_Administrador(administradorEncontrado);     //doy de baja el administrador
                Response.Redirect("~/FrmABMPreguntas.aspx", false);                                                    //vuelvo a la pagina principal
              
            }

        }
        catch (Exception es) { lblError.Text = "Error: " + es.Message; }
    }
}