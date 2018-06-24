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
    public partial class Producto : Form
    {
        private string clave;
        private string marca;
        private string descripcion;
        private string unidad;
        private string pc;
        private string pv;
        private string cantidad;
        private string local;


        public string Clave
        {
            set
            {
                clave = value;
                txtClave.Text = clave;

            }
        }
        public string Marca
        {
            set
            {
                marca = value;
                txtMarca.Text = marca;

            }
        }
        public string Descripcion
        {
            set
            {
                descripcion = value;
                txtDesc.Text = descripcion;

            }
        }
        public string Unidad
        {
            set
            {
                unidad = value;
                txtUni.Text = unidad;

            }
        }
        public string PC
        {
            set
            {
                pc = value;
                txtPC.Text = pc;

            }
        }
        public string PV
        {
            set
            {
                pv = value;
                txtPV.Text = pv;

            }
        }
        public string Cantidad
        {
            set
            {
                cantidad = value;
                txtStock.Text = cantidad;

            }
        }
        public string Localizacion
        {
            set
            {
                local = value;
                txtLocal.Text = local;

            }
        }
        public string[] escrito
        {
            get
            {
                string[] arreglo = { txtClave.Text, txtDesc.Text, txtUni.Text, txtMarca.Text, txtPC.Text , txtPV.Text, txtStock.Text , txtLocal.Text };
                return arreglo;
                
            }

        }
        public Producto()
        {
            InitializeComponent();
        }

        private void Producto_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Object result = null;
            int myInt;
            Double myDouble;
            bool parsed = Double.TryParse(txtPC.Text, out myDouble);
            bool parsed2 = Double.TryParse(txtPV.Text, out myDouble);
            bool parsed3 = Int32.TryParse(txtStock.Text, out myInt);
            if (parsed && parsed2 && parsed3)
            {
                //MessageBox.Show("won");

                //// Do something with myInt or other logic
                //this.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show("Favor de introducir valores numericos para precio de compra, venta y cantidad");

            }

            #region Singleton
            //private static MainViewModel instance;
            //public static MainViewModel GetInstance()
            //{
            //    if (instance == null)
            //    {
            //        return new MainViewModel();
            //    }
            //    return instance;
            //}
            #endregion
            //patron singleton para referenciar una unica instancia de la mainviewmodel,evitar multiples instancias de esa clase
            //MainViewModel.GetInstance().Lands = new LandsViewModel();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
