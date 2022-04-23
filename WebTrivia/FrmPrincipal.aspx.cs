using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;

public partial class FrmPrincipal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Login2_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            Usuario usuarioAutenticado = Logica.FabricaLogica.getLogicaUsuario().Logueo_Usuario(Login2.UserName.Trim(), Login2.Password.Trim());
            if (usuarioAutenticado != null)
            {
                //guardar el usuario autenticado en la session....

                Session["UsuarioAutenticado"] = usuarioAutenticado;

                if (usuarioAutenticado is Jugador)
                {
                    Response.Redirect("~/FrmDescargaJuego.aspx", false);
                }
                else { Response.Redirect("~/FrmABMPreguntas.aspx", false); }

            }
            else
            {

                lblError.Text = "Usuario y/o contraseña incorrecto/s";

            }


        }
        catch (Exception es)
        {
            lblError.Text = es.Message;
        }
    }
}