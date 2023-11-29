namespace Presentacion.VentanasAuxiliares
{
    partial class FormConfiguracion
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
            this.tablaFacturas = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tablaDetalles = new System.Windows.Forms.DataGridView();
            this.lblDetalles = new System.Windows.Forms.Label();
            this.TxtBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaFacturas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDetalles)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaFacturas
            // 
            this.tablaFacturas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaFacturas.Location = new System.Drawing.Point(12, 60);
            this.tablaFacturas.Name = "tablaFacturas";
            this.tablaFacturas.RowHeadersWidth = 51;
            this.tablaFacturas.RowTemplate.Height = 24;
            this.tablaFacturas.Size = new System.Drawing.Size(806, 170);
            this.tablaFacturas.TabIndex = 41;
            this.tablaFacturas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaFacturas_CellClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(699, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 29);
            this.label4.TabIndex = 37;
            this.label4.Text = "Facturas";
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(15, 28);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(163, 22);
            this.txtIdentificacion.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 31;
            this.label1.Text = "Identificacion Cliente:";
            // 
            // tablaDetalles
            // 
            this.tablaDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablaDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDetalles.Location = new System.Drawing.Point(12, 274);
            this.tablaDetalles.Name = "tablaDetalles";
            this.tablaDetalles.RowHeadersWidth = 51;
            this.tablaDetalles.RowTemplate.Height = 24;
            this.tablaDetalles.Size = new System.Drawing.Size(798, 164);
            this.tablaDetalles.TabIndex = 42;
            // 
            // lblDetalles
            // 
            this.lblDetalles.AutoSize = true;
            this.lblDetalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetalles.Location = new System.Drawing.Point(241, 242);
            this.lblDetalles.Name = "lblDetalles";
            this.lblDetalles.Size = new System.Drawing.Size(105, 29);
            this.lblDetalles.TabIndex = 43;
            this.lblDetalles.Text = "Detalles";
            // 
            // TxtBuscar
            // 
            this.TxtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TxtBuscar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBuscar.Image = global::Presentacion.Properties.Resources.informacion__1_;
            this.TxtBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TxtBuscar.Location = new System.Drawing.Point(220, 7);
            this.TxtBuscar.Name = "TxtBuscar";
            this.TxtBuscar.Size = new System.Drawing.Size(126, 43);
            this.TxtBuscar.TabIndex = 30;
            this.TxtBuscar.Text = "Buscar";
            this.TxtBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TxtBuscar.UseVisualStyleBackColor = true;
            this.TxtBuscar.Click += new System.EventHandler(this.TxtBuscar_Click);
            // 
            // FormConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(822, 450);
            this.Controls.Add(this.lblDetalles);
            this.Controls.Add(this.tablaDetalles);
            this.Controls.Add(this.tablaFacturas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtBuscar);
            this.Name = "FormConfiguracion";
            this.Text = "Gestion De Facturas";
            ((System.ComponentModel.ISupportInitialize)(this.tablaFacturas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDetalles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaFacturas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TxtBuscar;
        private System.Windows.Forms.DataGridView tablaDetalles;
        private System.Windows.Forms.Label lblDetalles;
    }
}