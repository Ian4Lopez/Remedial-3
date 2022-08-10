using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassEntidades;
using ClassAccesoDatos;
using System.Configuration;
namespace ClassLogicaNegocio
{
    public class LogicaN
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;
        private DAL Dal = new DAL(cadena);


        public DataTable llenarDrop(string query)
        {
            string mensage = "";
            return Dal.ConsultaDS(query, ref mensage).Tables[0];
        }
        public DataTable consultaMaterial()
        {
            string mensaje = "";
            string query = "Select Descripcion_Mat, Marca, Presentacion, TipoMaterial.Tipo " +
                "from Material join TipoMaterial on TipoMaterial.ID_Tipo = Material.ID_Tipo";

            return Dal.ConsultaDS(query, ref mensaje).Tables[0];
        }
    }
}
