using BLL;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace Presentacion.VentanasAuxiliares
{
    public partial class FormConfiguracion : Form
    {
        FacturaService _service;
        public FormConfiguracion()
        {
            InitializeComponent();
            tablaDetalles.Visible = false;
            lblDetalles.Visible = false;
            _service = new FacturaService();
        }

        private void TxtBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIdentificacion.Text))
            {
                MessageBox.Show("Identifcacion no puede estar en blanco");
            }
            else
            {
                var result = _service.ObtenerFacturasPorCliente(txtIdentificacion.Text);
                if (result == null)
                {
                    MessageBox.Show("Esa identificacion no tiene facturas asociadas");
                    return;
                }
                else
                {
                    tablaFacturas.DataSource = result;
                }
            }
        }
        string idFactura = "";
        private void tablaFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tablaFacturas.Rows[e.RowIndex];

                // Actualiza los campos de texto con los valores de las celdas de la fila seleccionada
                idFactura = row.Cells["IdFactura"].Value.ToString();
            }

            Thread.Sleep(100);

            ValidateDetales();
        }

        private void ValidateDetales()
        {
            tablaDetalles.Visible = true;
            lblDetalles.Visible = true;
            lblDetalles.Text = "Detalles de factura Numero: " + idFactura;

            var result = _service.ObtenerDetallesPorFactura(Convert.ToInt16(idFactura));
            if (result == null || result.Count == 0)
            {
                MessageBox.Show("Esa factura no tiene detalles asociadas");
                return;
            }
            else
            {
                // Establece el modo de generación de columnas en manual para un control total
                tablaDetalles.AutoGenerateColumns = false;
                tablaDetalles.Columns.Clear(); // Limpia las columnas existentes

                // Agrega las columnas que desees mostrar
                tablaDetalles.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "IdProducto", // Nombre de la propiedad en la lista de detalles
                    HeaderText = "ID Producto", // Texto del encabezado
                    Width = 100 // Anchura de la columna
                });
                tablaDetalles.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "NombreProducto", // Usa la propiedad expuesta
                    HeaderText = "Nombre Producto",
                    Width = 150
                });
                tablaDetalles.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "Cantidad",
                    HeaderText = "Cantidad",
                    Width = 100
                });
                tablaDetalles.Columns.Add(new DataGridViewTextBoxColumn
                {
                    DataPropertyName = "PrecioProducto",
                    HeaderText = "Precio Unitario",
                    Width = 100,
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } // Formato de moneda
                });

                decimal totalFactura = 0;

                foreach (var detalle in result)
                {
                    // Usar la función para obtener la información del producto

                    decimal subtotal = detalle.Cantidad * detalle.Producto.Precio;
                    totalFactura += subtotal;
                }

                lblDetalles.Text = $"Factura ID: {idFactura} - Total Facturado: {totalFactura}";

                // Puedes seguir agregando columnas según las propiedades que desees mostrar.

                // Asigna la lista de resultados como la fuente de datos del DataGridView
                tablaDetalles.DataSource = new BindingList<DetalleFactura>(result);
            }
        }

    }
}
