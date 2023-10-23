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
        public FrmLogin()
        {
            InitializeComponent();
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
                if (textBox1.Text == "")
                {
                    textBox1.Text = "Ingrese su usuario";
                    return;
                }
                textBox1.ForeColor = Color.Black;
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
                if (textBox2.Text == "")
                {
                    textBox2.Text = "Contraseña";
                        return;
                }
                textBox2.ForeColor = Color.Black;
                panel7.Visible = false;
            }
            catch
            {

            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll(); 
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.SelectAll();

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor= Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Ingrese su usuario")
            {
                panel5.Visible = true;
                textBox1.Focus();
                return;
            }
            if (textBox2.Text == "Contraseña")
            {
                panel7.Visible = true;
                textBox2.Focus();
                return;
            }

            FrmPrincipal frmPrincipal = new FrmPrincipal();
            frmPrincipal.ShowDialog();
        }
    }
}
