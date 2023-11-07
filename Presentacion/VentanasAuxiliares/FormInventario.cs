using BLL;
using Entity;
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
    public partial class FrmInventario : Form
    {
        ProductoService _service;

        public FrmInventario()
        {
            InitializeComponent();
            _service = new ProductoService();
            button1.Enabled = false;
            try
            {
                LlenarTablaProductos();
            }
            catch { }
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {

        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }
        private void LimpiarFormulario()
        {
            TxtIdProd.Text = "";
            TxtNombreProd.Text = "";
            TxtPrecio.Text = "";
            TxtCantidad.Text = "";
        }

        private void Agregar()
        {
            // Asegúrate de que todos los campos estén llenos antes de intentar agregar el producto
            if (string.IsNullOrWhiteSpace(TxtIdProd.Text) ||
                string.IsNullOrWhiteSpace(TxtNombreProd.Text) ||
                string.IsNullOrWhiteSpace(TxtPrecio.Text) ||
                string.IsNullOrWhiteSpace(TxtCantidad.Text))
            {
                MessageBox.Show("Por favor, llene todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Crear una nueva instancia de Producto
                Producto nuevoProducto = new Producto
                {
                    IdProducto = TxtIdProd.Text.ToUpper(),
                    Nombre = TxtNombreProd.Text.ToUpper(),
                    Precio = decimal.Parse(TxtPrecio.Text), // Asegúrate de que el precio sea un valor decimal válido
                    CantidadEnStock = int.Parse(TxtCantidad.Text) // Asegúrate de que la cantidad sea un número entero
                };

                // Llamar a la capa BLL para agregar el producto
                string resultado = _service.InsertarOActualizarProducto(nuevoProducto);
                LimpiarFormulario();
                LlenarTablaProductos();
                button1.Enabled = false;
                // Mostrar el resultado al usuario
                MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opcional: Actualizar la lista/grid de productos si tienes una
                // ActualizarListaDeProductos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, introduzca valores válidos para el código, precio y cantidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otro tipo de error que no haya sido previsto
                MessageBox.Show($"Ocurrió un error al intentar agregar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void LlenarTablaProductos()
        {
            try
            {
                // Supongamos que tienes un método que obtiene todos los productos
                var listaProductos = _service.ObtenerTodosLosProductos();

                // Establecer el origen de datos del DataGridView
                dataGridView1.DataSource = listaProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los productos: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                // Actualiza los campos de texto con los valores de las celdas de la fila seleccionada
                TxtIdProd.Text = row.Cells["IdProducto"].Value.ToString();
                TxtNombreProd.Text = row.Cells["Nombre"].Value.ToString();
                TxtPrecio.Text = row.Cells["Precio"].Value.ToString();
                TxtCantidad.Text = row.Cells["CantidadEnStock"].Value.ToString();
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Asegúrate de que hay una fila seleccionada
            if (dataGridView1.CurrentRow != null)
            {
                // Obtiene el IdProducto de la fila seleccionada
                string idProducto = dataGridView1.CurrentRow.Cells["IdProducto"].Value.ToString();

                // Confirmar con el usuario antes de eliminar
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?",
                                             "Confirmar eliminación",
                                             MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar al servicio para eliminar el producto
                        string resultado = _service.EliminarProducto(idProducto);

                        // Mostrar el resultado al usuario
                        MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualizar la tabla para reflejar la eliminación
                        LlenarTablaProductos();
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al intentar eliminar el producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
