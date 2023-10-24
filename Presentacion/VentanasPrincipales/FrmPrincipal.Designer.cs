namespace Presentacion.VentanasPrincipales
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.btnEmpleados = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnInforme = new System.Windows.Forms.Button();
            this.btnfacturacion = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktopPanel = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelMenu.Controls.Add(this.btnConfiguracion);
            this.panelMenu.Controls.Add(this.btnEmpleados);
            this.panelMenu.Controls.Add(this.btnCliente);
            this.panelMenu.Controls.Add(this.btnInforme);
            this.panelMenu.Controls.Add(this.btnfacturacion);
            this.panelMenu.Controls.Add(this.btnProductos);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 529);
            this.panelMenu.TabIndex = 0;
            this.panelMenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnConfiguracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfiguracion.FlatAppearance.BorderSize = 0;
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracion.Image = global::Presentacion.Properties.Resources.configuracion;
            this.btnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.Location = new System.Drawing.Point(0, 374);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnConfiguracion.Size = new System.Drawing.Size(250, 80);
            this.btnConfiguracion.TabIndex = 6;
            this.btnConfiguracion.Text = "CONFIGURACIÓN";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfiguracion.UseVisualStyleBackColor = false;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // btnEmpleados
            // 
            this.btnEmpleados.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnEmpleados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmpleados.FlatAppearance.BorderSize = 0;
            this.btnEmpleados.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleados.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleados.Image = global::Presentacion.Properties.Resources.Empleado;
            this.btnEmpleados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.Location = new System.Drawing.Point(0, 314);
            this.btnEmpleados.Name = "btnEmpleados";
            this.btnEmpleados.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnEmpleados.Size = new System.Drawing.Size(250, 60);
            this.btnEmpleados.TabIndex = 5;
            this.btnEmpleados.Text = "  EMPLEADOS";
            this.btnEmpleados.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmpleados.UseVisualStyleBackColor = false;
            this.btnEmpleados.Click += new System.EventHandler(this.btnEmpleados_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.Image = global::Presentacion.Properties.Resources.identificacion;
            this.btnCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCliente.Location = new System.Drawing.Point(0, 254);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCliente.Size = new System.Drawing.Size(250, 60);
            this.btnCliente.TabIndex = 4;
            this.btnCliente.Text = "  CLIENTE";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCliente.UseVisualStyleBackColor = false;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnInforme
            // 
            this.btnInforme.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnInforme.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInforme.FlatAppearance.BorderSize = 0;
            this.btnInforme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInforme.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInforme.Image = global::Presentacion.Properties.Resources.informe;
            this.btnInforme.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInforme.Location = new System.Drawing.Point(0, 194);
            this.btnInforme.Name = "btnInforme";
            this.btnInforme.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnInforme.Size = new System.Drawing.Size(250, 60);
            this.btnInforme.TabIndex = 3;
            this.btnInforme.Text = "  INFORME";
            this.btnInforme.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInforme.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInforme.UseVisualStyleBackColor = false;
            this.btnInforme.Click += new System.EventHandler(this.btnInforme_Click);
            // 
            // btnfacturacion
            // 
            this.btnfacturacion.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnfacturacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnfacturacion.FlatAppearance.BorderSize = 0;
            this.btnfacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfacturacion.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfacturacion.Image = global::Presentacion.Properties.Resources.factura;
            this.btnfacturacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfacturacion.Location = new System.Drawing.Point(0, 134);
            this.btnfacturacion.Name = "btnfacturacion";
            this.btnfacturacion.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnfacturacion.Size = new System.Drawing.Size(250, 60);
            this.btnfacturacion.TabIndex = 2;
            this.btnfacturacion.Text = "  FACTURACIÓN";
            this.btnfacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfacturacion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnfacturacion.UseVisualStyleBackColor = false;
            this.btnfacturacion.Click += new System.EventHandler(this.btnfacturacion_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Arial Rounded MT Bold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.Black;
            this.btnProductos.Image = global::Presentacion.Properties.Resources.pedido;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(0, 80);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(250, 54);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "  INVENTARIO";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.Black;
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.ForeColor = System.Drawing.Color.Black;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 80);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(45, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "  KRISBAN";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.DarkGray;
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(250, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(820, 80);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitleBar_Paint);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(280, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "MENU PRINCIPAL";
            // 
            // panelDesktopPanel
            // 
            this.panelDesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPanel.Location = new System.Drawing.Point(250, 80);
            this.panelDesktopPanel.Name = "panelDesktopPanel";
            this.panelDesktopPanel.Size = new System.Drawing.Size(820, 449);
            this.panelDesktopPanel.TabIndex = 2;
            this.panelDesktopPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDesktopPanel_Paint);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1070, 529);
            this.Controls.Add(this.panelDesktopPanel);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnEmpleados;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnInforme;
        private System.Windows.Forms.Button btnfacturacion;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDesktopPanel;
    }
}