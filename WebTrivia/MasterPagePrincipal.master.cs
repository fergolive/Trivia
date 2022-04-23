using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class MasterPagePrincipal : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
          
            if (Session["UsuarioAutenticado"] != null)
            {
                Administrador usuarioLogueado = (Administrador)Session["UsuarioAutenticado"];
                Menu1.Enabled = true;
                Menu1.Visible = true;

                //muestro el nombre del usuario logueado
                lblNombreCompleto.Text =usuarioLogueado.Nombre;

            }
            else
            { //mostrar menu publico
       
            }
        }
        catch(Exception es)
        {
            lblError.Text = es.Message;
        }
    }

    protected void Button1_Click(object sender, EventArgs e) //boton para desloguearse
    {
        Response.Redirect("~/WebPrincipal.aspx"); //la web principal es mla web donde el usuario se loguea
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            lblNombreCompleto.Text = "";
            Session["UsuarioAutenticado"] = null;
            Menu1.Enabled = false;
            Menu1.Visible = false;
            Response.Redirect("~/FrmPrincipal.aspx", false);
        }
        catch (Exception es) { lblError.Text = es.Message; }
    }
}
