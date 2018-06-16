using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Capa_Data
{
    class CD_conexion
    {
        //public string strMySqlConnectionString =
        //       @"SERVER=localhost;" +
        //       @"DATABASE=Practica;" +
        //       @"UID=root;" +
        //       @"PASSWORD=LiaAshanti123";
        //"datasource=localhost;port=3306;username=root;password=LiaAshanti123"
        private MySqlConnection myConn = new MySqlConnection(@"SERVER=localhost;" +
               @"DATABASE=Practica;" +
               @"UID=root;" +
               @"PASSWORD=LiaAshanti123");
        public MySqlConnection AbrirConexion()
        {
            if (myConn.State == ConnectionState.Closed)
                myConn.Open();
            return myConn;
        }
        public MySqlConnection CerrarConexion()
        {
            if (myConn.State == ConnectionState.Open)
                myConn.Close();
            return myConn;
        }
        //MySqlDataAdapter myDataAdapter = new MySqlDataAdapter();
        //myDataAdapter.SelectCommand = new MySqlCommand(" select * mysql.db ;", myConn);
        ////databasecallaed database with table edata
        //MySqlCommandBuilder cb = new MySqlCommandBuilder(myDataAdapter);
        //myConn.Open();
        ////DataSet ds = new DataSet();
        //MessageBox.Show("Connected");
        //myConn.Close();
    }
}
