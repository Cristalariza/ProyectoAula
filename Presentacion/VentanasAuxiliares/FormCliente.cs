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
    public partial class FormCliente : Form
    {
        ClienteService _service;
        public FormCliente()
        {
            InitializeComponent();
            _service = new ClienteService();
            BtnModificar.Enabled = false;
            try
            {
                LlenarTablaClientes();
            }catch
            { }
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
                Cliente nuevoCliente = new Cliente
                {
                    IdCliente = TxtIdProd.Text.ToUpper(),
                    Nombre = TxtNombreProd.Text.ToUpper(),
                    Telefono = TxtPrecio.Text, 
                    Email = TxtCantidad.Text.ToUpper() 
                };

                // Llamar a la capa BLL para agregar el producto
                string resultado = _service.InsertarActualizarCliente(nuevoCliente);
                LimpiarFormulario();
                LlenarTablaClientes();
                BtnModificar.Enabled = false;
                // Mostrar el resultado al usuario
                MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Opcional: Actualizar la lista/grid de productos si tienes una
                // ActualizarListaDeProductos();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor, introduzca valores válidos para el código, telefono y email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otro tipo de error que no haya sido previsto
                MessageBox.Show($"Ocurrió un error al intentar agregar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void LlenarTablaClientes()
        {
            try
            {
                var listaClientes = _service.ObtenerTodosLosClientes();

                // Establecer el origen de datos del DataGridView
                dataGridView1.DataSource = listaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los clientes: " + ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Asegúrate de que hay una fila seleccionada
            if (dataGridView1.CurrentRow != null)
            {
                string idCliente = dataGridView1.CurrentRow.Cells["IdCliente"].Value.ToString();

                // Confirmar con el usuario antes de eliminar
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?",
                                             "Confirmar eliminación",
                                             MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar al servicio para eliminar el producto
                        string resultado = _service.EliminarCliente(idCliente);

                        // Mostrar el resultado al usuario
                        MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualizar la tabla para reflejar la eliminación
                        LlenarTablaClientes();
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al intentar eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Agregar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                // Actualiza los campos de texto con los valores de las celdas de la fila seleccionada
                TxtIdProd.Text = row.Cells["IdCliente"].Value.ToString();
                TxtNombreProd.Text = row.Cells["Nombre"].Value.ToString();
                TxtPrecio.Text = row.Cells["Telefono"].Value.ToString();
                TxtCantidad.Text = row.Cells["Email"].Value.ToString();
                BtnModificar.Enabled = true;
            }
        }
    }
}
