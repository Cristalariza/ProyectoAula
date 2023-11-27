using BLL;
using Entity;
using Presentacion.VentanasPrincipales;
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
    public partial class FormFacturacion : Form
    {
        ClienteService clienteService;
        ProductoService productoService;
        Cliente cliente;
        Producto producto;
        List<DetalleFactura> detalleList;
        List<Producto> productosLlevados;
        FacturaService facturaService;

        public FormFacturacion()
        {
            InitializeComponent();
            clienteService = new ClienteService();
            productoService = new ProductoService();
            facturaService = new FacturaService();
            TxtProdId.Enabled = false;
            TxtCantidad.Enabled = false;
            BtnAgregar.Enabled = false;
            detalleList = new List<DetalleFactura>();
            button1.Enabled = false;
            productosLlevados = new List<Producto>();
            SetupDataGridView();
        }

        private void FormFacturacion_Load(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int cantidad = int.Parse(TxtCantidad.Text);
                if (producto.CantidadEnStock < cantidad)
                {
                    MessageBox.Show("No hay stock disponible para ese producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if the product is already in the list
                var existingDetail = detalleList.FirstOrDefault(d => d.IdProducto == producto.IdProducto);
                if (existingDetail != null)
                {
                    // Product is already in the cart, just update the quantity
                    if (producto.CantidadEnStock < (existingDetail.Cantidad + cantidad))
                    {
                        MessageBox.Show("No hay stock disponible para aumentar la cantidad de este producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        existingDetail.Cantidad += cantidad;
                        producto.CantidadEnStock -= cantidad;
                    }
                }
                else
                {
                    // Product is not in the cart, create a new detail and add it to the list
                    DetalleFactura detalle = new DetalleFactura
                    {
                        IdProducto = producto.IdProducto,
                        Cantidad = cantidad,
                        Producto = producto
                    };

                    producto.CantidadEnStock -= cantidad;

                    detalleList.Add(detalle);
                    productosLlevados.Add(producto);
                }

                button1.Enabled = true;

                lblTotal.Text =  CalcularSubTotal().ToString();
                // After updating the list, refresh the DataGridView to show changes
                LlenarTablaProductos();
            }
            catch
            {
                MessageBox.Show("Solo puede ingresar números en esta cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SetupDataGridView()
        {
            // Prevent automatic column generation
            dataGridView1.AutoGenerateColumns = false;

            // Create and add custom columns
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Producto",
                DataPropertyName = "IdProducto" // This should match the property name in DetalleFactura
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cantidad",
                DataPropertyName = "Cantidad"
            });
        }

        private void LlenarTablaProductos()
        {
            try
            {
                dataGridView1.DataSource = null; // Reset the DataSource


                // Set the data source
                dataGridView1.DataSource = detalleList;

                // Refresh the DataGridView to display data
                dataGridView1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los productos: " + ex.Message);
            }
        }

        private decimal CalcularSubTotal()
        {
            decimal subtotal = 0;
            foreach (var detalle in detalleList)
            {
                subtotal = subtotal + detalle.CalcularSubTotal();
            }
            return subtotal;
        }

        private void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtClienteId.Text))
            {
                MessageBox.Show("Llene la ID del cliente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                cliente = clienteService.ObtenerClientePorId(TxtClienteId.Text);
                LblNombreCliente.Text = cliente.Nombre;
                TxtProdId.Enabled = true;
                TxtCantidad.Enabled = true;
                BtnAgregar.Enabled = true;
            }
            catch
            {
                MessageBox.Show("No se encontro el cliente, ingreselo primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnBuscarProd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtProdId.Text))
            {
                MessageBox.Show("Llene la ID del producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                producto = productoService.ObtenerProductoPorId(TxtProdId.Text);
                foreach (var prod in productosLlevados)
                {
                    if (prod.IdProducto == producto.IdProducto)
                    {
                        producto.CantidadEnStock = prod.CantidadEnStock;
                    }
                }

                LblNombreProd.Text = producto.Nombre;
                LblPrecioProd.Text = producto.Precio.ToString();
                LblCantProd.Text = producto.CantidadEnStock.ToString();
            }
            catch
            {
                MessageBox.Show("No se encontro el producto, ingreselo primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Factura factura = new Factura();
                factura.DetallesDeFactura = detalleList;
                factura.Total = CalcularSubTotal();
                factura.Fecha = DateTime.Now;
                factura.IdCliente = cliente.IdCliente;
                factura.IdEmpleado = FrmPrincipal._usuario.IdUsuario ?? null;
                var msg = facturaService.InsertarFactura(factura, detalleList);

                MessageBox.Show(msg, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
                detalleList.Clear();
                productosLlevados.Clear();
                TxtCantidad.Text = "";
                TxtClienteId.Text = "";
                TxtProdId.Text = "";
                TxtProdId.Enabled = false;
                TxtCantidad.Enabled = false;
                BtnAgregar.Enabled = false;
                button1.Enabled = false;
            }
            catch {
                MessageBox.Show("Error al facturar...", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }


        }
    }
}
