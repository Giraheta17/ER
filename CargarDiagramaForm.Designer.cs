namespace DiagramaER
{
    partial class CargarDiagramaForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btncargar = new System.Windows.Forms.Button();
            this.btneliminar = new System.Windows.Forms.Button();
            this.btnregresar = new System.Windows.Forms.Button();
            this.dgvdiagramas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocal = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvdiagramas)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLocal);
            this.groupBox1.Controls.Add(this.btncargar);
            this.groupBox1.Controls.Add(this.btneliminar);
            this.groupBox1.Controls.Add(this.btnregresar);
            this.groupBox1.Location = new System.Drawing.Point(7, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(850, 95);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controles";
            // 
            // btncargar
            // 
            this.btncargar.Location = new System.Drawing.Point(491, 26);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(137, 53);
            this.btncargar.TabIndex = 2;
            this.btncargar.Text = "Cargar";
            this.btncargar.UseVisualStyleBackColor = true;
            this.btncargar.Click += new System.EventHandler(this.btncargar_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.Location = new System.Drawing.Point(689, 26);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(137, 53);
            this.btneliminar.TabIndex = 1;
            this.btneliminar.Text = "Eliminar";
            this.btneliminar.UseVisualStyleBackColor = true;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btnregresar
            // 
            this.btnregresar.Location = new System.Drawing.Point(19, 26);
            this.btnregresar.Name = "btnregresar";
            this.btnregresar.Size = new System.Drawing.Size(137, 53);
            this.btnregresar.TabIndex = 0;
            this.btnregresar.Text = "Regresar";
            this.btnregresar.UseVisualStyleBackColor = true;
            this.btnregresar.Click += new System.EventHandler(this.btnregresar_Click);
            // 
            // dgvdiagramas
            // 
            this.dgvdiagramas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvdiagramas.Location = new System.Drawing.Point(7, 178);
            this.dgvdiagramas.Name = "dgvdiagramas";
            this.dgvdiagramas.RowHeadersWidth = 51;
            this.dgvdiagramas.RowTemplate.Height = 24;
            this.dgvdiagramas.Size = new System.Drawing.Size(848, 330);
            this.dgvdiagramas.TabIndex = 2;
            this.dgvdiagramas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvdiagramas_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 52);
            this.label1.TabIndex = 3;
            this.label1.Text = "Lista de diagramas existentes";
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(261, 26);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(137, 53);
            this.btnLocal.TabIndex = 3;
            this.btnLocal.Text = "Abrir Local";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // CargarDiagramaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 520);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvdiagramas);
            this.Controls.Add(this.groupBox1);
            this.Name = "CargarDiagramaForm";
            this.Text = "CargarDiagramaForm";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvdiagramas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvdiagramas;
        private System.Windows.Forms.Button btncargar;
        private System.Windows.Forms.Button btneliminar;
        private System.Windows.Forms.Button btnregresar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLocal;
    }
}