using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ClassAccesoDatos
{
    public class DAL
    {
        private string cadConexion;

        public DAL(string cadenaBD)
        {
            cadConexion = cadenaBD;
        }
        public SqlConnection AbrirConexion(ref string mensaje) // Metodo con parametros de referencia
        {
            SqlConnection conexion1 = new SqlConnection();
            conexion1.ConnectionString = cadConexion;
            try
            {
                conexion1.Open();
                mensaje = "Conexión abierta CORRECTAMENTE";
            }
            catch (Exception r)
            {
                conexion1 = null; //Devuelve una conexion nula
                mensaje = "Error: " + r.Message;
            }
            return conexion1;
        }


        public DataSet ConsultaDS(string querySql, ref string mensaje)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            DataSet DS_salida = new DataSet();
            SqlConnection conAbierta = AbrirConexion(ref mensaje);
            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                DS_salida = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(DS_salida, "Consulta1");
                    mensaje = "Consulta Correcta en DataSet";
                }
                catch (Exception a)
                {
                    mensaje = "Error!" + a.Message;
                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return DS_salida;
        }

        public SqlDataReader ConsultarReader(string querySql, SqlConnection conAbierta, ref string mensaje)
        {
            SqlCommand carrito = null;
            SqlDataReader contenedor = null;

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                contenedor = null;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                try
                {
                    contenedor = carrito.ExecuteReader();
                    mensaje = "Consulta Correcta DataReader";
                }
                catch (Exception a)
                {
                    contenedor = null;
                    mensaje = "Error!" + a.Message;
                }
            }
            return contenedor;
        }

        public Boolean Operaciones(string query, ref string msg, List<SqlParameter> parametros)
        {
            Boolean result = false;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = AbrirConexion(ref msg);
           

            if (connection == null)
            {
                msg = "Sin conexion a la base de datos";
            }
            else
            {
                command.CommandText = query;
                foreach (var parametro in parametros)
                {
                    command.Parameters.Add(parametro);
                }
                command.Connection = connection;
                try
                {
                    command.ExecuteNonQuery();
                    msg = "Se ha realizado correctamente la tarea";
                    result = true;
                }
                catch (Exception ex)
                {
                    msg = "Error: " + ex.Message;
                    result = false;
                }
            }
            

            return result;
        }

        public Boolean MultiplesConsultasDataSet(string querySql, SqlConnection conAbierta, ref string mensaje, ref DataSet dataset1, string nomConsulta)
        {
            SqlCommand carrito = null;
            SqlDataAdapter trailer = null;
            Boolean salida = false;

            if (conAbierta == null)
            {
                mensaje = "No hay conexion a la BD";
                salida = false;
            }
            else
            {
                carrito = new SqlCommand();
                carrito.CommandText = querySql;
                carrito.Connection = conAbierta;

                trailer = new SqlDataAdapter();
                trailer.SelectCommand = carrito;

                try
                {
                    trailer.Fill(dataset1, nomConsulta);
                    mensaje = "Consulta correcta en el DataSet";
                    salida = true;
                }
                catch (Exception a)
                {
                    mensaje = "Error: " + a.Message;
                }
                conAbierta.Close();
                conAbierta.Dispose();
            }
            return salida;
        }

    }
}
