using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaBusiness;


namespace CapaPresentacion
{
    public partial class BaseDeDatos : Form
    {
        CN_Productos objetoCN = new CN_Productos();
        private string idProducto = null;
        public BaseDeDatos()
        {
            InitializeComponent();
        }
        public CN_Productos ObjetoCN
        {
            get
            {
            return this.objetoCN;
            }
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
            cmbBusqueda.Items.Add("Prueba");
            cmbBusqueda.SelectedIndex = 0;
        }
        private void MostrarProductos()
        {
            dataGridView1.DataSource = objetoCN.MostrarProd();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                //escrito["Nombre"] como en la base de datos
                //txtClave.Text = dataGridView1.CurrentRow.Cells["Clave"].Value.ToString();
              

                Producto miforma = new Producto();
                //miforma.Owner = this;
                //miforma.StartPosition = FormStartPosition.CenterParent;
                int X1 = (this.Parent.Parent.Location.X + (this.Parent.Parent.Width / 2)) - miforma.Width / 2;
                int Y1 = (this.Parent.Parent.Location.Y + (this.Parent.Parent.Height / 2)) - miforma.Height / 2;
                Point location = new Point(X1, Y1);
                MessageBox.Show("Resultado "+X1.ToString() + " " +Y1.ToString());
                MessageBox.Show("BaseDeDatosForm "+this.Top.ToString() + " " + this.Left.ToString());
                MessageBox.Show("Contenedor "+this.Parent.Top.ToString() + " " + this.Parent.Left.ToString());
                MessageBox.Show("Form " + this.Parent.Parent.Top.ToString() + " " + this.Parent.Parent.Left.ToString()+" "+ this.Parent.Parent.Width +" "+ this.Parent.Parent.Height);
                miforma.Clave = dataGridView1.CurrentRow.Cells["Clave"].Value.ToString();
                miforma.Descripcion=dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                miforma.Unidad= dataGridView1.CurrentRow.Cells["Unidad"].Value.ToString();
                miforma.Marca=dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                miforma.PC = dataGridView1.CurrentRow.Cells["Precio_Compra"].Value.ToString();
                miforma.PV = dataGridView1.CurrentRow.Cells["Precio_Venta"].Value.ToString();
                miforma.Cantidad = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
                miforma.Localizacion = dataGridView1.CurrentRow.Cells["Localizacion"].Value.ToString();
                miforma.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                miforma.Location = location;
                DialogResult resultado = miforma.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        //objetoCN.EditarProducto(txtClave.Text, txtDesc.Text, txtMarca.Text, txtPV.Text, txtStock.Text, idProducto);
                        //MessageBox.Show("Se edito Correctamente");
                        ////MostrarProductos();
                        //limpiarForm();
                        //Editar = false;
                        Console.WriteLine("================impresion de txtboxes");
                        string[] arregloaEscribir;
                        arregloaEscribir = miforma.escrito;
                        foreach (var item in arregloaEscribir)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine("================fin de impresion de txtboxes");
                        objetoCN.EditarProducto(arregloaEscribir);
                        MessageBox.Show("Se edito Correctamente ");
                        MostrarProductos();
                        //MessageBox.Show(miforma.escrito);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo editar por:" + ex);

                    }
                }
                if (resultado == DialogResult.Cancel)
                {
                    MessageBox.Show("No ejecutaste la operacion");
                }
                
            }
            else
            {
                MessageBox.Show("seleccionar una fila por favor");
            }
        }
        private void limpiarForm()
        {
            //txtDesc.Clear();
            //txtMarca.Text = "";
            //txtPV.Clear();
            //txtStock.Clear();
            //txtClave.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Estas seguro?", "Confirma", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // user clicked yes
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    idProducto = dataGridView1.CurrentRow.Cells["Clave"].Value.ToString();
                    objetoCN.EliminarProducto(idProducto);
                    MessageBox.Show("Eliminado Correctamente");
                    MostrarProductos();
                }
                else
                {
                    MessageBox.Show("seleccionar una fila por favor");
                }
            }
            else
            {
                // user clicked no
                MessageBox.Show("Operacion Cancelada");
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtDescBusqueda.Text);
            try
            {
                int indice = cmbBusqueda.SelectedIndex;
                string columna = cmbBusqueda.Items[indice].ToString();
                DataTable tabla= objetoCN.Buscar(txtDescBusqueda.Text,columna);

                if (tabla != null)
                {
                    // Don't use rows.Count. That's asking for how many rows exist.If there are many, it will take some time to count them.All you really want to know is "is there at least one?" You don't care if there are 10 or 1000 or a billion. You just want to know if there is at least one. If I give you a box and ask you if there are any marbles in it, will you dump the box on the table and start counting? Of course not. Using LINQ, you might think that this would work:
                    bool hasRows = tabla.Rows.GetEnumerator().MoveNext();
                    //if (tabla.Rows.Count > 0)
                    if(hasRows)
                    {
                        //do your code 
                        dataGridView1.DataSource = tabla;
                        MessageBox.Show("Se busco Correctamente "+tabla.Rows.Count.ToString());
                        //MostrarProductos();
                        //limpiarForm();
                        

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cmbBusqueda.SelectedIndex;
            lblBusqueda.Text ="Busqueda por "+ cmbBusqueda.Items[indice].ToString() +indice.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
       
                Producto miforma = new Producto();
                //miforma.Owner = this;
                //miforma.StartPosition = FormStartPosition.CenterParent;
                int X1 = (this.Parent.Parent.Location.X + (this.Parent.Parent.Width / 2)) - miforma.Width / 2;
                int Y1 = (this.Parent.Parent.Location.Y + (this.Parent.Parent.Height / 2)) - miforma.Height / 2;
                Point location = new Point(X1, Y1);
                MessageBox.Show("Resultado " + X1.ToString() + " " + Y1.ToString());
                MessageBox.Show("BaseDeDatosForm " + this.Top.ToString() + " " + this.Left.ToString());
                MessageBox.Show("Contenedor " + this.Parent.Top.ToString() + " " + this.Parent.Left.ToString());
                MessageBox.Show("Form " + this.Parent.Parent.Top.ToString() + " " + this.Parent.Parent.Left.ToString() + " " + this.Parent.Parent.Width + " " + this.Parent.Parent.Height);
                miforma.Clave = "";
                miforma.Descripcion ="";
                miforma.Unidad ="";
                miforma.Marca = "";
                miforma.PC = "";
                miforma.PV = "";
                miforma.Cantidad = "";
                miforma.Localizacion = "";
                miforma.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                miforma.Location = location;
                DialogResult resultado = miforma.ShowDialog();
                if (resultado == DialogResult.OK)
                {
                    try
                    {
                        //objetoCN.EditarProducto(txtClave.Text, txtDesc.Text, txtMarca.Text, txtPV.Text, txtStock.Text, idProducto);
                        //MessageBox.Show("Se edito Correctamente");
                        ////MostrarProductos();
                        //limpiarForm();
                        //Editar = false;
                        Console.WriteLine("================impresion de txtboxes");
                        string[] arregloaEscribir;
                        arregloaEscribir = miforma.escrito;
                        foreach (var item in arregloaEscribir)
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine("================fin de impresion de txtboxes");              
                        objetoCN.InsertarProducto(arregloaEscribir);
                        MessageBox.Show("Se guardo Correctamente ");
                        MostrarProductos();

                    //MessageBox.Show(miforma.escrito);
                }
                catch (Exception ex)
                    {
                        if (ex.Message.ToLower().Contains("duplicate entry"))
                        {
                            MessageBox.Show("Existe un producto con la clave indicada.", "Producto Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo insertar por:" + ex.Message.ToLower());
                        }

                    }
                }
                if (resultado == DialogResult.Cancel)
                {
                    MessageBox.Show("No ejecutaste la operacion");
                }
        }
        //
        #region Singleton
                private static BaseDeDatos instance;
                    public static BaseDeDatos GetInstance()
                    {
                        if (instance == null)
                        {
                            return new BaseDeDatos();
                        }
                        return instance;
                    }
                   #endregion
    }
}
