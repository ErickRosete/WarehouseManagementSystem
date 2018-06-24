using CapaPresentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Ventas : Form
    {
        DataTable final = new DataTable();
        object sumObject;

        public Ventas()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (btnPagar.Text == "Finalizar")
            {
                lblMensaje.Text = "Introduzca Cantidad en efectivo";
                btnPagar.Text = "Cobrar";
                return;
            }
            lblMensaje.Text = "Captura el codigo del articulo ";
            btnPagar.Text = "Finalizar";

        }

        private void txtFuncion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtFuncion.Text);
            try
            {
                
                DataTable tabla = BaseDeDatos.GetInstance().ObjetoCN.Buscar2(txtFuncion.Text, "Clave");
               
                if (tabla != null)
                {
                    // Don't use rows.Count. That's asking for how many rows exist.If there are many, it will take some time to count them.All you really want to know is "is there at least one?" You don't care if there are 10 or 1000 or a billion. You just want to know if there is at least one. If I give you a box and ask you if there are any marbles in it, will you dump the box on the table and start counting? Of course not. Using LINQ, you might think that this would work:
                    bool hasRows = tabla.Rows.GetEnumerator().MoveNext();
                    //if (tabla.Rows.Count > 0)
                    if (hasRows)
                    {
                        //do your code
                        //tabla.Columns.Add("Cantidad", typeof(int));
                        //tabla.Columns.Add("Subtotal", typeof(float));
                        if (final.Columns["Clave"] == null)
                            final.Columns.Add("Clave", typeof(string));
                        if (final.Columns["Descripcion"] == null)
                            final.Columns.Add("Descripcion", typeof(string));
                        if (final.Columns["Cantidad"] == null)
                            final.Columns.Add("Cantidad", typeof(int));
                        if (final.Columns["Precio_Venta"] == null)
                            final.Columns.Add("Precio_Venta", typeof(float));
                        if (final.Columns["Subtotal"] == null)
                            final.Columns.Add("Subtotal", typeof(float));

                        string clave = tabla.Rows[0].Field<string>("Clave");
                        bool bandera = true;

                        foreach(DataRow row in final.Rows)
                        {
                            if (row.Field<string>("Clave").Equals(clave))
                            {
                                row.SetField("Cantidad", row.Field<int>("Cantidad") + 1);
                                row.SetField("Subtotal", row.Field<int>("Cantidad") * row.Field<float>("Precio_Venta"));
                                bandera = false;
                                break;
                            }
                        }
                        
                        if (bandera)
                        {
                            DataRow newRow = final.NewRow();
                            string desc = tabla.Rows[0].Field<string>("Descripcion");
                            float price = tabla.Rows[0].Field<float>("Precio_Venta");
                            newRow["Clave"] = clave;
                            newRow["Descripcion"] = desc;
                            newRow["Cantidad"] = 1;
                            newRow["Precio_Venta"] = price;
                            newRow["Subtotal"] = price;
                            final.Rows.Add(newRow);
                        }
                        //int a;
                        //if (final.Columns["Cantidad"] != null)
                        //{ 
                        //    if (final.Rows["Clave" Y tEXTBOX]["Cantidad"] != null)
                        //        a = final.Rows[txtFuncion.Text].GetColumnsInError["Cantidad"]Field<int>("Cantidad") + 1;
                        //    else
                        //        a = 1;
                        //}

                        //tabla.Columns["Cantidad"].Expression ="'"+ a.ToString()+"'";



                        //if (final.Columns["Subtotal"] == null)
                        //    final.Columns.Add("Subtotal", typeof(float));

                        //foreach (DataRow row in final.Rows)
                        //    row.SetField("Subtotal", row.Field<int>("Cantidad") * row.Field<float>("Precio_Venta"));


                        //DataRow dr = final.NewRow();

                        //dr["Cantidad"] = "ALFKI";
                        //newCustomersRow["CompanyName"] = "Alfreds Futterkiste";

                        //dataSet1.Tables["Customers"].Rows.Add(newCustomersRow);
                        final.Columns[0].ColumnMapping = MappingType.Hidden;

                        dgvVentas.DataSource = final;
                        sumObject = final.Compute("Sum(Subtotal)", string.Empty);
                        MessageBox.Show("Se busco Correctamente " + tabla.Rows.Count.ToString());
                        lblpago.Text = "Por pagar(M.N): $" + sumObject.ToString();



                    }
                    else
                    {
                        MessageBox.Show("No hubo resultados");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("No se buscar por:" + ex);
            }
        }

        private void Productos_Load(object sender, EventArgs e)
        {

        }

        
    }
}
