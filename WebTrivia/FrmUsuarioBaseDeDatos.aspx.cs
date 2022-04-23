using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FrmUsuarioBaseDeDatos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //para el usuario de base de datos

            drpPermisos.Items.Add("");
            drpPermisos.Items.Add("db datareader");
            drpPermisos.Items.Add("db datawriter");
            drpPermisos.Items.Add("db datawriter");

            //para el usuario de logueo

            drpRoles.Items.Add("");
            drpRoles.Items.Add("securityadmin");
            drpRoles.Items.Add("sysadmin");
        }
        catch (Exception es) { lblError.Text=es.Message;}
    }

    protected void btnCrear_Click(object sender, EventArgs e)
    {

        try
        {
            String usuario = "";
            String pass = "";
            String mensaje = "Falta ingresar/Seleccionar: ";
            if (usuario == "" || pass == "")
            { mensaje += "Usuario y/o contrasena, "; }

            String rol = "";
            String Permiso = "";
            rol = drpRoles.SelectedValue;
            Permiso = drpPermisos.SelectedValue;

            if (rol == "")
            { mensaje += "el Rol, "; }
            if (Permiso == "")
            { mensaje += "el Permiso, "; }

            if (mensaje == "Falta ingresar/Seleccionar: ")
            {
                Logica.FabricaLogica.getLogicaAdministrador().CrearUsuarioLogueoBD(usuario,pass,rol,Permiso);
            
            }
        }
        catch (Exception es) { lblError.Text = es.Message; }
    }
}