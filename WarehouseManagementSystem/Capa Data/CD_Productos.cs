using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Capa_Data
{
  
    public class CD_Productos
    {
        private CD_conexion conexion = new CD_conexion();
        MySqlDataReader leer;
        DataTable tabla = new DataTable();
        MySqlCommand comando = new MySqlCommand();
        //aqui se uso encapsulamiento de las variables
        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            //transact SQL
            //comando.CommandText = "Select * from Productos";
            //por procedimiento estructurado
            comando.CommandText = "MostrarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable Buscar(string desc,string columna)
        {
            comando.Connection = conexion.AbrirConexion();
            //transact SQL
            //comando.CommandText = "Select * from Productos";
            //por procedimiento estructurado
            string cadenaCaracteres = null;
            cadenaCaracteres = "\"%" + desc + "%\"";

            MessageBox.Show(cadenaCaracteres);
            //transact SQL
            string cadenaSql = "Select * from Productos WHERE "+columna+" like " + cadenaCaracteres + ";";
            MessageBox.Show(cadenaSql);
            comando.CommandText =cadenaSql;
            comando.CommandType = CommandType.Text;
            //comando.CommandText = "BuscarDescripcionProductos";
            //comando.CommandType = CommandType.StoredProcedure;
            //comando.Parameters.AddWithValue("_descripcion", cadenaCaracteres);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }
        public DataTable Buscar2(string desc, string columna)
        {
            comando.Connection = conexion.AbrirConexion();
            //transact SQL
            //comando.CommandText = "Select * from Productos";
            //por procedimiento estructurado
            string cadenaCaracteres = null;
            cadenaCaracteres = '"'+ desc + '"';

            MessageBox.Show(cadenaCaracteres);
            //transact SQL
            string cadenaSql = "Select Clave,Descripcion,Precio_Venta from Productos WHERE " + columna + "=" + cadenaCaracteres + ";";
            MessageBox.Show(cadenaSql);
            comando.CommandText = cadenaSql;
            comando.CommandType = CommandType.Text;
            //comando.CommandText = "BuscarDescripcionProductos";
            //comando.CommandType = CommandType.StoredProcedure;
            //comando.Parameters.AddWithValue("_descripcion", cadenaCaracteres);
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string clave,string desc, string unidad, string marca, double precioc,double preciov, int cantidad,string local)
        {
            //miforma.Clave = "";
            //miforma.Descripcion = "";
            //miforma.Unidad = "";
            //miforma.Marca = "";
            //miforma.PC = "";
            //miforma.PV = "";
            //miforma.Cantidad = "";
            //miforma.Localizacion = "";
            MySqlCommand comando = new MySqlCommand();
            comando.Connection = conexion.AbrirConexion();
            //transact SQL
            //
            //comando.CommandText = "INSERT INTO Productos Values (null,'" + nombre + "','" + desc + "','" + marca + "'," + precio + "," + stock + ");";
            //System.Windows.Forms.MessageBox.Show("INSERT INTO Productos Values (null,'" + nombre + "','" + desc + "','" + marca + "'," + precio + "," + stock + ");");
            //comando.CommandType = CommandType.Text;

            //por procedimiento estructurado
            comando.CommandText = "InsertarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_clave", clave);
            comando.Parameters.AddWithValue("_descripcion", desc);
            comando.Parameters.AddWithValue("_unidad", unidad);
            comando.Parameters.AddWithValue("_marca", marca);
            comando.Parameters.AddWithValue("_precioc", precioc);
            comando.Parameters.AddWithValue("_preciov", preciov);
            comando.Parameters.AddWithValue("_cantidad", cantidad);
            comando.Parameters.AddWithValue("_localizacion", local);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }
        public void Editar(string clave, string desc, string unidad, string marca, double precioc, double preciov, int cantidad, string local)
        {
            //por procedimiento estructurado
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_clave", clave);
            comando.Parameters.AddWithValue("_descripcion", desc);
            comando.Parameters.AddWithValue("_unidad", unidad);
            comando.Parameters.AddWithValue("_marca", marca);
            comando.Parameters.AddWithValue("_precioc", precioc);
            comando.Parameters.AddWithValue("_preciov", preciov);
            comando.Parameters.AddWithValue("_cantidad", cantidad);
            comando.Parameters.AddWithValue("_localizacion", local);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }
        //MSqlConnDummy.CreateCommand();

        //mSqlCmdSelectCustomers.CommandText = @"select * from customers limit 10";

        //MSqlConnDummy.Open();
        //mSqlReader_Customers = mSqlCmdSelectCustomers.ExecuteReader();
        //dtCustomers.Load(mSqlReader_Customers);
        //foreach(DataRow in tabla.Rows){
        //{Console.WriteLine(row["customerName"].ToString());
        //}
        public void Eliminar(string clave)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_clave", clave);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
