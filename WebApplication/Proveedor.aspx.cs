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
    public partial class Proveedor : System.Web.UI.Page
    {
        ClassLogicaNegocio.LogicaN logica = new ClassLogicaNegocio.LogicaN();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataTable tablaDrop1 = logica.llenarDrop("select ID_Obra,Nom_Obra from Obra");
                DataTable tablaDrop2 = logica.llenarDrop(" select ID_Material, Descripcion_Mat from Material");
                DataTable tablaDrop3 = logica.llenarDrop("select ID_Proveedor, Razon from Proveedor");

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

            table = logica.consultaProve();
            GridView1.DataSource = table;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            SqlParameter reci = new SqlParameter("@recibio", SqlDbType.VarChar);
            SqlParameter entreg = new SqlParameter("@entrega", SqlDbType.VarChar);
            SqlParameter cant = new SqlParameter("@cantidad", SqlDbType.Int);
            SqlParameter fecha1 = new SqlParameter("@fecha", SqlDbType.Date);
            SqlParameter precio = new SqlParameter("@precio", SqlDbType.Float);
            SqlParameter obra = new SqlParameter("@obra", SqlDbType.Int);
            SqlParameter material = new SqlParameter("@material", SqlDbType.Int);
            SqlParameter prov = new SqlParameter("@proveedor", SqlDbType.Int);

            reci.Value = recibio.Text;
            entreg.Value = entrega.Text;
            cant.Value = cantidad.Text;
            fecha1.Value = fecha.Text;
            precio.Value = Precio.Text;
            obra.Value = DropDownList1.SelectedValue;
            material.Value = DropDownList2.SelectedValue;
            prov.Value = DropDownList3.SelectedValue;

            List<SqlParameter> lista = new List<SqlParameter>() {
                reci, entreg, cant, fecha1, precio,obra,material,prov};




            string msg = "";

            msg = logica.InsertarProv(ref msg, lista);
            Label1.Text = msg;
        }
    }
}