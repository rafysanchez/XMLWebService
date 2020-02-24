using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    web.Service1 webservice2 = new web.Service1();

    protected void Page_Load(object sender, EventArgs e)
    {
        int insertado = webservice2.insertados();
        int erroneo = webservice2.erroneos();
        string texto_insertado = "insertado";
        string texto_error = "error";

        webservice2.Proce_insertar(texto_insertado, insertado);
        webservice2.Proce_erroneos(texto_error, erroneo);
        Label1.Text = "Insertados";
    }
}
