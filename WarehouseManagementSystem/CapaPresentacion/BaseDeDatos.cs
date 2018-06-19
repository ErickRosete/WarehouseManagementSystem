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
        private bool Editar = false;
        public BaseDeDatos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProductos();
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Insertar
            if (Editar == false)
            {
                try
                {
                    objetoCN.InsertarProducto(txtClave.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se inserto Correctamente");
                    MostrarProductos();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo insertar por:" + ex);
                }
            }
            //Editar
            if (Editar == true)
            {
                try
                {
                    objetoCN.EditarProducto(txtClave.Text, txtDesc.Text, txtMarca.Text, txtPrecio.Text, txtStock.Text, idProducto);
                    MessageBox.Show("Se edito Correctamente");
                    MostrarProductos();
                    limpiarForm();
                    Editar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo editar por:" + ex);
                    
                }
            }

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                //escrito["Nombre"] como en la base de datos
                txtClave.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                txtMarca.Text = dataGridView1.CurrentRow.Cells["Marca"].Value.ToString();
                txtDesc.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                txtClave.Text = dataGridView1.CurrentRow.Cells["Nombre"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("seleccionar una fila por favor");
            }
        }
        private void limpiarForm()
        {
            txtDesc.Clear();
            txtMarca.Text = "";
            txtPrecio.Clear();
            txtStock.Clear();
            txtClave.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objetoCN.EliminarProducto(idProducto);
                MessageBox.Show("Eliminado Correctamente");
                MostrarProductos();
            }
            else
            {
                MessageBox.Show("seleccionar una fila por favor");
            }
        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtDescBusqueda.Text);
            try
            {
                
                dataGridView1.DataSource = objetoCN.Buscar(txtDescBusqueda.Text);
                MessageBox.Show("Se busco Correctamente");
                //MostrarProductos();
                //limpiarForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se buscar por:" + ex);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
