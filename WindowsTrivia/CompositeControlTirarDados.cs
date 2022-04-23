using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

using System.ComponentModel;



namespace WindowsTrivia
{
    public class CompositeControlTirarDados: CompositeControl
    {

        Label lblResultado;
        Button btnTirarDados;   


        protected override void CreateChildControls()
        {
            Controls.Clear();

            lblResultado = new Label();
            lblResultado.ID = "lblResultado";
            lblResultado.Text = "0";

            btnTirarDados = new Button();
            btnTirarDados.ID = "btnTirarDados";
            btnTirarDados.Text = "Tirar Dados";

            this.Controls.Add(lblResultado);
            this.Controls.Add(btnTirarDados);
                
    
           // base.CreateChildControls();
        }

        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
           // base.Render(writer);
            lblResultado.RenderControl(writer);
            btnTirarDados.RenderControl(writer);
        }



    }
}
