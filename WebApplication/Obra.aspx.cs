using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Obra : System.Web.UI.Page
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
                    DropDownList1.Items.Add(
                        new ListItem(
                           value: dr[0].ToString(),
                           text: dr[1].ToString()
                            ));
                }
                foreach (DataRow dr in tablaDrop2.Rows)
                {
                    DropDownList2.Items.Add(
                        new ListItem(
                           value: dr[0].ToString(),
                           text: dr[1].ToString()
                            ));
                }
                foreach (DataRow dr in tablaDrop3.Rows)
                {
                    DropDownList3.Items.Add(
                        new ListItem(
                           value: dr[0].ToString(),
                           text: dr[1].ToString()
                            ));
                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            table = logica.consultaObra();

            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            SqlParameter nombre_para = new SqlParameter("@nombre",SqlDbType.VarChar);
            SqlParameter direccion = new SqlParameter("@direccion",SqlDbType.VarChar);
            SqlParameter fechaini = new SqlParameter("@fecha1",SqlDbType.Date);
            SqlParameter fechafin = new SqlParameter("@fecha2",SqlDbType.Date);
            SqlParameter dueno_obra = new SqlParameter("@dueno",SqlDbType.Int);
            SqlParameter encargado_obra = new SqlParameter("@encargado",SqlDbType.Int);

            nombre_para.Value = Nombre.Text;
            direccion.Value = Direccion.Text;
            fechaini.Value = Fecha1.Text;
            fechafin.Value = Fecha2.Text;
            dueno_obra.Value = DropDownList1.SelectedValue;
            encargado_obra.Value = DropDownList2.SelectedValue;

            List<SqlParameter> lista = new List<SqlParameter>() { nombre_para,
                direccion, fechafin, fechaini,dueno_obra, encargado_obra };

            string msg = "";

            msg = logica.InsertarObra(ref msg, lista);
            Label1.Text = msg;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            SqlParameter obra = new SqlParameter("@obra", SqlDbType.Int);

            obra.Value = DropDownList3.SelectedValue;
            List<SqlParameter> lista = new List<SqlParameter>() { obra };

            string msg = "";

            msg = logica.eliminarObra(ref msg, lista);
            Label1.Text = msg;
        }
    }
}