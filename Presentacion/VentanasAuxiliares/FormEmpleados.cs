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
    public partial class FormEmpleados : Form
    {
        UsuarioService _service;

        public FormEmpleados()
        {
            InitializeComponent();
            _service = new UsuarioService();
            BtnModificar.Enabled = false;
            try
            {
                LlenarTablaClientes();
            }
            catch
            { }
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }


        private void LimpiarFormulario()
        {
            TxtIdentificacion.Text = "";
            TxtNombre.Text = "";
            TxtPassword.Text = "";
            ComboRol.SelectedItem = null;
        }

        private void Agregar()
        {
            // Asegúrate de que todos los campos estén llenos antes de intentar agregar el producto
            if (string.IsNullOrWhiteSpace(TxtIdentificacion.Text) ||
                string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                string.IsNullOrWhiteSpace(TxtPassword.Text) ||
                string.IsNullOrWhiteSpace(ComboRol.SelectedItem.ToString()))
            {
                MessageBox.Show("Por favor, llene todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Crear una nueva instancia de Producto
                Usuario nuevoUser = new Usuario
                {
                    IdUsuario = TxtIdentificacion.Text.ToUpper(),
                    NombreUsuario = TxtNombre.Text.ToUpper(),
                    Contra = TxtPassword.Text,
                    Rol = ComboRol.SelectedItem.ToString()
                };

                // Llamar a la capa BLL para agregar el producto
                string resultado = _service.InsertarOActualizar(nuevoUser);
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
                MessageBox.Show("Por favor, introduzca valores válidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Manejo de cualquier otro tipo de error que no haya sido previsto
                MessageBox.Show($"Ocurrió un error al intentar agregar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarTablaClientes()
        {
            try
            {
                var listaClientes = _service.ObtenerTodos();

                // Establecer el origen de datos del DataGridView
                tablaUsuarios.DataSource = listaClientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los usuarios: " + ex.Message);
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            // Asegúrate de que hay una fila seleccionada
            if (tablaUsuarios.CurrentRow != null)
            {
                string idCliente = tablaUsuarios.CurrentRow.Cells["IdUsuario"].Value.ToString();

                // Confirmar con el usuario antes de eliminar
                var confirmResult = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?",
                                             "Confirmar eliminación",
                                             MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Llamar al servicio para eliminar el producto
                        string resultado = _service.Eliminar(idCliente);

                        // Mostrar el resultado al usuario
                        MessageBox.Show(resultado, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Actualizar la tabla para reflejar la eliminación
                        LlenarTablaClientes();
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ocurrió un error al intentar eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un usuario para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tablaUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.tablaUsuarios.Rows[e.RowIndex];

                // Actualiza los campos de texto con los valores de las celdas de la fila seleccionada
                TxtIdentificacion.Text = row.Cells["IdUsuario"].Value.ToString();
                TxtNombre.Text = row.Cells["NombreUsuario"].Value.ToString();
                TxtPassword.Text = row.Cells["Contra"].Value.ToString();
                ComboRol.SelectedItem = row.Cells["Rol"].Value.ToString();
                BtnModificar.Enabled = true;
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            Agregar();
        }
    }
}
