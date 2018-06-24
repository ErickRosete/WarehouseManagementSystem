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
        public void InsertarProducto(string[] arreglo){
            //miforma.Clave = "";
            //miforma.Descripcion = "";
            //miforma.Unidad = "";
            //miforma.Marca = "";
            //miforma.PC = "";
            //miforma.PV = "";
            //miforma.Cantidad = "";
            //miforma.Localizacion = "";
            objetoCD.Insertar(arreglo[0], arreglo[1], arreglo[2], arreglo[3],Convert.ToDouble(arreglo[4]), Convert.ToDouble(arreglo[5]),Convert.ToInt32(arreglo[6]),arreglo[7]);
        }
        public void EditarProducto(string[] arreglo)
        {
            objetoCD.Editar(arreglo[0], arreglo[1], arreglo[2], arreglo[3], Convert.ToDouble(arreglo[4]), Convert.ToDouble(arreglo[5]), Convert.ToInt32(arreglo[6]), arreglo[7]);
        }
        public void EliminarProducto(string clave)
        {
            objetoCD.Eliminar(clave);
        }
 
        public DataTable Buscar(string desc,string columna)
        {
            CD_Productos objetoCD = new CD_Productos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.Buscar(desc,columna);
            return tabla;
        }
        public DataTable Buscar2(string desc, string columna)
        {
            CD_Productos objetoCD = new CD_Productos();
            DataTable tabla = new DataTable();
            tabla = objetoCD.Buscar2(desc, columna);
            return tabla;
        }
    }
}
