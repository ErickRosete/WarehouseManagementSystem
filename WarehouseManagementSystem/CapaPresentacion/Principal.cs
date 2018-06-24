using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaPresentacion;

namespace CapaPresentacion
{
    //https://www.youtube.com/watch?v=IVoefhMZWCQ
    //https://www.youtube.com/watch?v=y1jftnTaTXU&t=21s
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            Sidepanel.Height = btnProd.Height;
            Sidepanel.Top = btnProd.Top;
            AbrirFormInPanel(new home());
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MenuVertical.Width == 250)
            {
                MenuVertical.Width = 70;
            }
            else
            {
                MenuVertical.Width = 250;
            }
        }

        private void iconCerrar_Click(object sender, EventArgs e)
        {
            //Application.Exit();
            timerfade.Start();
        }

        private void iconmaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            iconrestaurar.Visible = true;
            iconmaximizar.Visible = false;
        }

        private void iconrestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            iconrestaurar.Visible = false;
            iconmaximizar.Visible = true;
        }

        private void iconminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }
        private void AbrirFormInPanel(object Formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }
        private void btnProd_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnProd.Height;
            Sidepanel.Top = btnProd.Top;
            AbrirFormInPanel(new BaseDeDatos());
           
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

            Sidepanel.Height = btnReportes.Height;
            Sidepanel.Top = btnReportes.Top;
            AbrirFormInPanel(new Analitica());
            submenuReportes.Visible = true;
        }

        private void btnrptventa_Click(object sender, EventArgs e)
        {
            submenuReportes.Visible = false;
        }

        private void btnrptcompra_Click(object sender, EventArgs e)
        {
            submenuReportes.Visible = false;
        }

        private void btnrptpagos_Click(object sender, EventArgs e)
        {
            submenuReportes.Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void btnVentas_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnVentas.Height;
            Sidepanel.Top = btnVentas.Top;
            AbrirFormInPanel(new Ventas());
        }

        private void timerfade_Tick(object sender, EventArgs e)
        {
            if(this.Opacity>0.00)
            {
                this.Opacity -= 0.025;
            }
            else
            {
                timerfade.Stop();
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = btnProd.Height;
            Sidepanel.Top = btnProd.Top;
            AbrirFormInPanel(new BaseDeDatos());
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
