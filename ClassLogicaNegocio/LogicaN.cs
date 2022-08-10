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

        public DataTable consultaObra()
        {
            string msg = "";
            string query = "select ID_Obra,Nom_Obra,Direccion,Fecha_Inicio,Fecha_Termino,Nombre_Dueno, Nom_Encargado from Obra join Dueno on Obra.ID_Dueno = Dueno.ID_Dueno " +
                " join EncargadoObra on EncargadoObra.ID_Encargado = Obra.ID_Encargado";

            return Dal.ConsultaDS(query, ref msg).Tables[0];
        }

        public DataTable consultaProve()
        {
            string msg = "";
            string query = "select p.Recibio,p.Entrega,p.Cantidad, Fecha_Entre, Precio, " +
                "o.Nom_Obra, m.Descripcion_Mat,pro.Razon " +
                "from Provee_De_Materi_Obra p join Obra o on o.ID_Obra = p.ID_Obra " +
                " join Material m on m.ID_Material = p.ID_Material " +
                "join Proveedor pro on pro.ID_Proveedor = p.ID_Proveedor";

            return Dal.ConsultaDS(query, ref msg).Tables[0];
        }
        public DataTable consultaObraId(int id)
        {
            string query = "select ID_Obra,Nom_Obra,Direccion,Fecha_Inicio,Fecha_Termino, Nom_Encargado " +
                " from Obra join Dueno on Obra.ID_Dueno = Dueno.ID_Dueno" +
                " join EncargadoObra on EncargadoObra.ID_Encargado = Obra.ID_Encargado " +
                " where Obra.ID_Dueno = " + id;
            string msg = "";
            return Dal.ConsultaDS(query, ref msg).Tables[0];
        }
        public string InsertarMaterial(ref string msg, List<SqlParameter> lista)
        {

            string query = "insert into Material values( @desc, @marca, @presentacion,@tipo );";


            bool resultado = Dal.Operaciones(query, ref msg,lista);

            if (resultado)
            {
                msg = "Tarea Realizada";
            }
            else
                msg = "No se realizo";

            return msg;
        }

        public string InsertarObra(ref string msg, List<SqlParameter> lista)
        {
            string query = "insert into Obra values(@nombre,@direccion,@fecha1,@fecha2,@dueno,@encargado);";
            bool resultado = Dal.Operaciones(query, ref msg, lista);
            if (resultado)
            {
                msg = "Tarea Realizada";
            }
            else
                msg = "No se realizo";

            return msg;

        }

        public string InsertarProv(ref string msg, List<SqlParameter> lista)
        {
            string query = "insert into Provee_De_Materi_Obra " +
                " values(@recibio,@entrega,@cantidad,@fecha,@precio,@obra,@material,@proveedor)";
            bool resultado = Dal.Operaciones(query, ref msg, lista);
            if (resultado)
            {
                msg = "Tarea Realizada";
            }
            else
                msg = "No se realizo";

            return msg;

        }
        public string eliminarObra( ref  string msg, List<SqlParameter> lista) {
            string query = "delete from Obra where ID_Obra=@obra";
            bool resultado = Dal.Operaciones(query, ref msg, lista);
            if (resultado)
            {
                msg = "Se elimino Correctamente";
            }
            else
                msg = "No se realizo";

            return msg;
        }
    }
}
