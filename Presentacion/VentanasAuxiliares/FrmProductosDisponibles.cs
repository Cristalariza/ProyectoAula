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
    public partial class FrmProductosDisponibles : Form
    {
        ProductoService _service;
        public FrmProductosDisponibles()
        {
            InitializeComponent();
            _service = new ProductoService();
            try
            {
                dataGridView1.DataSource = _service.ObtenerTodosLosProductos();
            }
            catch
            {

            }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
