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

namespace Presentacion.VentanasPrincipales
{
    public partial class FrmLogin : Form
    {
        UsuarioService _service;

        public FrmLogin()
        {
            InitializeComponent();
            _service = new UsuarioService();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void usuario_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            try
            {
                if (txtUsuario.Text == "")
                {
                    txtUsuario.Text = "Ingrese su usuario";
                    return;
                }
                txtUsuario.ForeColor = Color.Black;
                panel5.Visible = false;
               
            }
            catch
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text == "")
                {
                    txtPassword.Text = "Contraseña";
                        return;
                }
                txtPassword.ForeColor = Color.Black;
                panel7.Visible = false;
            }
            catch
            {

            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            txtUsuario.SelectAll(); 
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            txtPassword.SelectAll();

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            BtnLogin.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            BtnLogin.ForeColor= Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Ingrese su usuario")
            {
                panel5.Visible = true;
                txtUsuario.Focus();
                return;
            }
            if (txtPassword.Text == "Contraseña")
            {
                panel7.Visible = true;
                txtPassword.Focus();
                return;
            }

            if (ValidarSesion(txtUsuario.Text, txtPassword.Text))
            {
                var user = _service.ObtenerProductoPorId(txtUsuario.Text);
                this.Dispose();
                FrmPrincipal frmPrincipal = new FrmPrincipal(user);
                frmPrincipal.ShowDialog();
            }
            else
            {
                return;
            }


        }

        private bool ValidarSesion(string identificacion, string contra)
        {
            if (string.IsNullOrEmpty(identificacion) || string.IsNullOrEmpty(contra))
            {
                MessageBox.Show("Debe ingresar su usuario y contraseña");
                return false;
            }
            else
            {
                var user = _service.ObtenerProductoPorId(identificacion);
                if(user == null) {
                    MessageBox.Show("Usuario no existe");
                    return false;
                }
                else
                {
                    if (user.IdUsuario ==  identificacion && user.Contra == contra)
                    {
                        MessageBox.Show($"Sesion iniciada, bienvenido {user.NombreUsuario}");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta...");
                        return false;
                    }
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
