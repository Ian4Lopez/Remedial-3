using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Consulta : System.Web.UI.Page
    {
        ClassLogicaNegocio.LogicaN logica = new ClassLogicaNegocio.LogicaN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tablaDrop1 = logica.llenarDrop("select ID_Dueno, Nombre_Dueno from Dueno");
                DataTable tablaDrop2 = logica.llenarDrop("select ID_Encargado, Nom_Encargado from EncargadoObra");
                DataTable tablaDrop3 = logica.llenarDrop("select ID_Obra,Nom_Obra from Obra");

                foreach (DataRow dr in tablaDrop1.Rows)
                {
                    ListBox1.Items.Add(
                        new ListItem(
                           value: dr[0].ToString(),
                           text: dr[1].ToString()
                            ));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ListBox1.SelectedValue);
            DataTable table = new DataTable();

            table = logica.consultaObraId(id);
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}