using Presentacion.VentanasPrincipales;
using System;
using System.Windows.Forms;

namespace Presentacion.VentanasAuxiliares
{
    public partial class FrmLoading : Form
    {
        public FrmLoading()
        {
            InitializeComponent();
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void Loading()
        {
            Cargar.Increment(1);
            if (Cargar.Value == Cargar.Maximum)
            {
                this.timer1.Stop();
                this.Hide();
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Loading();
        }
    }
}
