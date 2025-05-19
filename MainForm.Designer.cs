namespace DiagramaER
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnNuevoDiagrama = new System.Windows.Forms.Button();
            this.btnCargarDiagrama = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.BackColor = System.Drawing.Color.SeaGreen;
            this.lblTitulo.Font = new System.Drawing.Font("Montserrat ExtraBold", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Location = new System.Drawing.Point(50, 35);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(700, 55);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Programa para Crear Diagramas de Entidad Relación";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNuevoDiagrama
            // 
            this.btnNuevoDiagrama.BackColor = System.Drawing.Color.LightGray;
            this.btnNuevoDiagrama.FlatAppearance.BorderSize = 0;
            this.btnNuevoDiagrama.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnNuevoDiagrama.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnNuevoDiagrama.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoDiagrama.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoDiagrama.Location = new System.Drawing.Point(103, 380);
            this.btnNuevoDiagrama.Name = "btnNuevoDiagrama";
            this.btnNuevoDiagrama.Size = new System.Drawing.Size(255, 60);
            this.btnNuevoDiagrama.TabIndex = 1;
            this.btnNuevoDiagrama.Text = "Nuevo Diagrama";
            this.btnNuevoDiagrama.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevoDiagrama.UseVisualStyleBackColor = false;
            this.btnNuevoDiagrama.Click += new System.EventHandler(this.btnNuevoDiagrama_Click);
            this.btnNuevoDiagrama.MouseEnter += new System.EventHandler(this.btnNuevoDiagrama_MouseEnter);
            this.btnNuevoDiagrama.MouseLeave += new System.EventHandler(this.btnNuevoDiagrama_MouseLeave);
            // 
            // btnCargarDiagrama
            // 
            this.btnCargarDiagrama.BackColor = System.Drawing.Color.LightGray;
            this.btnCargarDiagrama.FlatAppearance.BorderSize = 0;
            this.btnCargarDiagrama.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnCargarDiagrama.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnCargarDiagrama.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCargarDiagrama.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargarDiagrama.Location = new System.Drawing.Point(425, 380);
            this.btnCargarDiagrama.Name = "btnCargarDiagrama";
            this.btnCargarDiagrama.Size = new System.Drawing.Size(255, 60);
            this.btnCargarDiagrama.TabIndex = 2;
            this.btnCargarDiagrama.Text = "Cargar Diagrama";
            this.btnCargarDiagrama.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCargarDiagrama.UseVisualStyleBackColor = false;
            this.btnCargarDiagrama.Click += new System.EventHandler(this.btnCargarDiagrama_Click);
            this.btnCargarDiagrama.MouseEnter += new System.EventHandler(this.btnCargarDiagrama_MouseEnter);
            this.btnCargarDiagrama.MouseLeave += new System.EventHandler(this.btnCargarDiagrama_MouseLeave);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.ForestGreen;
            this.btnSalir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGreen;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Location = new System.Drawing.Point(332, 488);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(118, 49);
            this.btnSalir.TabIndex = 3;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(243, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(321, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(113, 389);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.DarkGray;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(433, 389);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // MainForm
            // 
            this.BackColor = System.Drawing.Color.Honeydew;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnCargarDiagrama);
            this.Controls.Add(this.btnNuevoDiagrama);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Programa para Crear Diagramas de Entidad Relación";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnNuevoDiagrama;
        private System.Windows.Forms.Button btnCargarDiagrama;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
