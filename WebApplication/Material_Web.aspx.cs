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
    public partial class Material_Web : System.Web.UI.Page
    {
        ClassLogicaNegocio.LogicaN logica = new ClassLogicaNegocio.LogicaN();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable tablaDrop = logica.llenarDrop("select ID_Tipo, Tipo from TipoMaterial");

                foreach(DataRow dr in tablaDrop.Rows)
                {
                    DropDownList1.Items.Add(
                        new ListItem(
                           value: dr[0].ToString(),
                           text: dr[1].ToString()
                            )) ;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            table = logica.consultaMaterial();

            GridView1.DataSource= table;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            

            SqlParameter marca_para = new SqlParameter("@marca",SqlDbType.VarChar);
            SqlParameter descr = new SqlParameter("@desc",SqlDbType.VarChar);
            SqlParameter presentacion = new SqlParameter("@presentacion",SqlDbType.VarChar);
            SqlParameter tipo = new SqlParameter("@tipo",SqlDbType.Int);


            marca_para.Value = Marca.Text;
            descr.Value = Descipcion.Text;
            presentacion.Value = Presentacion.Text;
            tipo.Value = DropDownList1.SelectedValue;

            List<SqlParameter> lista = new List<SqlParameter>() { marca_para, descr, presentacion, tipo};

            string msg = "";

            msg = logica.InsertarMaterial(ref msg, lista);
            Label1.Text= msg;
        }


    }
}