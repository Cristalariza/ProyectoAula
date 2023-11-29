namespace Presentacion.VentanasAuxiliares
{
    partial class FormInforme
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
            this.label13 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TxtBuscar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblEmpleadoVenta = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGanancias = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblProductosVendidos = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProductoMenosVendido = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(6, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(258, 32);
            this.label13.TabIndex = 81;
            this.label13.Text = "INGRESE FECHA DESDE:  (yyyy-mm-dd) \r\nEJ (2023-11-07):";
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(306, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 22);
            this.textBox1.TabIndex = 82;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(22, 67);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(683, 235);
            this.dataGridView1.TabIndex = 83;
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtBuscar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Image = global::Presentacion.Properties.Resources.informacion__1_1;
            this.TxtBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TxtBuscar.Location = new System.Drawing.Point(550, 6);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(116, 39);
            this.TxtBuscar.TabIndex = 84;
            this.TxtBuscar.Text = "Buscar";
            this.TxtBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TxtBuscar.UseVisualStyleBackColor = true;
            this.TxtBuscar.Click += new System.EventHandler(this.TxtBuscar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(740, 357);
            this.tabControl1.TabIndex = 85;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.TxtBuscar);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(732, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Reporte por Fecha";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblProductoMenosVendido);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.lblProductosVendidos);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lblEmpleadoVenta);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.lblGanancias);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(732, 328);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Reportes Generales";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblEmpleadoVenta
            // 
            this.lblEmpleadoVenta.AutoSize = true;
            this.lblEmpleadoVenta.Location = new System.Drawing.Point(268, 56);
            this.lblEmpleadoVenta.Name = "lblEmpleadoVenta";
            this.lblEmpleadoVenta.Size = new System.Drawing.Size(24, 16);
            this.lblEmpleadoVenta.TabIndex = 85;
            this.lblEmpleadoVenta.Text = "0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 16);
            this.label2.TabIndex = 84;
            this.label2.Text = "EMPLEADO CON MAYOR VENTAS:";
            // 
            // lblGanancias
            // 
            this.lblGanancias.AutoSize = true;
            this.lblGanancias.Location = new System.Drawing.Point(209, 20);
            this.lblGanancias.Name = "lblGanancias";
            this.lblGanancias.Size = new System.Drawing.Size(24, 16);
            this.lblGanancias.TabIndex = 83;
            this.lblGanancias.Text = "0.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 16);
            this.label1.TabIndex = 82;
            this.label1.Text = "GANANCIAS TOTALES: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 16);
            this.label3.TabIndex = 86;
            this.label3.Text = "PRODUCTO MAS VENDIDO:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProductosVendidos
            // 
            this.lblProductosVendidos.AutoSize = true;
            this.lblProductosVendidos.Location = new System.Drawing.Point(235, 95);
            this.lblProductosVendidos.Name = "lblProductosVendidos";
            this.lblProductosVendidos.Size = new System.Drawing.Size(24, 16);
            this.lblProductosVendidos.TabIndex = 87;
            this.lblProductosVendidos.Text = "0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 16);
            this.label4.TabIndex = 88;
            this.label4.Text = "PRODUCTO MENOS VENDIDO:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lblProductoMenosVendido
            // 
            this.lblProductoMenosVendido.AutoSize = true;
            this.lblProductoMenosVendido.Location = new System.Drawing.Point(250, 140);
            this.lblProductoMenosVendido.Name = "lblProductoMenosVendido";
            this.lblProductoMenosVendido.Size = new System.Drawing.Size(24, 16);
            this.lblProductoMenosVendido.TabIndex = 89;
            this.lblProductoMenosVendido.Text = "0.0";
            // 
            // FormInforme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(764, 377);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormInforme";
            this.Text = "Informe de Ventas";
            this.Load += new System.EventHandler(this.FormInforme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button TxtBuscar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label lblGanancias;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblEmpleadoVenta;
        private System.Windows.Forms.Label lblProductosVendidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblProductoMenosVendido;
    }
}