using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.VentanasAuxiliares
{
    public partial class FormInforme : Form
    {
        FacturaService _Service;
        public FormInforme()
        {
            InitializeComponent();
            _Service = new FacturaService();
            var valor = _Service.ObtenerTotalGanancias();
            lblGanancias.Text = valor.ToString("C");
            var emp = _Service.ObtenerMayorVendedor();
            lblEmpleadoVenta.Text = $"{emp.NombreUsuario} - Total Vendido: {emp.VentasTotales}";
            var prod = _Service.ObtenerProductoMasVendido();
            lblProductosVendidos.Text = $"{prod.Nombre} - Cantidad Vendida: {prod.CantidadVendida}";
            var prodMenosVendido = _Service.ObtenerProductoMenosVendido();
            lblProductoMenosVendido.Text = $"{prodMenosVendido.Nombre} - Cantidad Vendida: {prodMenosVendido.CantidadVendida}";
        }

        private void TxtBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ingrese una fecha con formato (yyyy-mm-dd)");
            }
            else
            {
                var result = _Service.ObtenerFacturasDesdeFecha(textBox1.Text);
                dataGridView1.DataSource = result;
             }
        }

        private void FormInforme_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
