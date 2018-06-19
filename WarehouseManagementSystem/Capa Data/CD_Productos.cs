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
        public DataTable Buscar(string desc)
        {
            comando.Connection = conexion.AbrirConexion();
            //transact SQL
            //comando.CommandText = "Select * from Productos";
            //por procedimiento estructurado
            string cadenaCaracteres = null;
            cadenaCaracteres = "\"%" + desc + "%\"";

            MessageBox.Show(cadenaCaracteres);
            //transact SQL
            string cadenaSql = "Select * from Productos WHERE descripcion like " + cadenaCaracteres + ";";
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
        public void Insertar(string nombre,string desc,string marca, double precio, int stock)
        {
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
            comando.Parameters.AddWithValue("_nombre", nombre);
            comando.Parameters.AddWithValue("_descripcion", desc);
            comando.Parameters.AddWithValue("_marca", marca);
            comando.Parameters.AddWithValue("_precio", precio);
            comando.Parameters.AddWithValue("_stock", stock);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();


        }
        public void Editar(string nombre, string desc, string marca, double precio, int stock,int id)
        {
            //por procedimiento estructurado
            comando.Connection = conexion.AbrirConexion();

            comando.CommandText = "EditarProductos";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_nombre", nombre);
            comando.Parameters.AddWithValue("_descripcion", desc);
            comando.Parameters.AddWithValue("_marca", marca);
            comando.Parameters.AddWithValue("_precio", precio);
            comando.Parameters.AddWithValue("_stock", stock);
            comando.Parameters.AddWithValue("_id", id);

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
        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EliminarProducto";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("_id", id);

            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

    }
}
