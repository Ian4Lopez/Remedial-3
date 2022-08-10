using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Material_Web : System.Web.UI.Page
    {
        ClassLogicaNegocio.LogicaN logica = new ClassLogicaNegocio.LogicaN();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            table = logica.consultaMaterial();

            GridView1.DataSource= table;
            GridView1.DataBind();
        }
    }
}