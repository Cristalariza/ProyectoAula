using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.VentanasPrincipales
{
    public partial class FrmPrincipal : Form
    {
        //fields 
        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm; 

        //constructor
        public FrmPrincipal()
        {
            InitializeComponent();
            random = new Random();
        }
        //metodos
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index){
               index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnsender)
        {
            if (btnsender != null)
            {
                if (currentButton != (Button)btnsender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnsender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(224, 224, 224);
                    previousBtn.ForeColor = Color.Black;
                    previousBtn.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }

        private void OpenClidForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            } ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text; 
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            OpenClidForm(new VentanasAuxiliares.FrmInventario(),sender);

        }

        private void btnfacturacion_Click(object sender, EventArgs e)
        {
            OpenClidForm(new VentanasAuxiliares.FormFacturacion(), sender);
        }

        private void btnInforme_Click(object sender, EventArgs e)
        {
            OpenClidForm(new VentanasAuxiliares.FormInforme(), sender);
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            OpenClidForm(new VentanasAuxiliares.FormCliente(), sender);
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            OpenClidForm(new VentanasAuxiliares.FormEmpleados(), sender);
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            OpenClidForm(new VentanasAuxiliares.FormConfiguracion(), sender);
        }

        private void panelDesktopPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
