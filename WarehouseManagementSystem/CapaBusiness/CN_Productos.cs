using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Capa_Data;

namespace CapaBusiness
{
    public class CN_Productos
    {
        CD_Productos objetoCD = new CD_Productos();
        public DataTable MostrarProd()
        {
            CD_Productos objetoCD = new CD_Productos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarProducto(string nombre, string desc, string marca, string precio, string stock){
            objetoCD.Insertar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock));
        }
        public void EditarProducto(string nombre, string desc, string marca, string precio, string stock,string id)
        {
            objetoCD.Editar(nombre, desc, marca, Convert.ToDouble(precio), Convert.ToInt32(stock),Convert.ToInt32(id));
        }
        public void EliminarProducto(string id)
        {
            objetoCD.Eliminar(Convert.ToInt32(id));
        }
 
        public DataTable Buscar(string desc)
        {
            CD_Productos objetoCD = new CD_Productos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.Buscar(desc);
            return tabla;
        }
    }
}
