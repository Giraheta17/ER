namespace DiagramaER
{
    partial class AsignarLlaveForm
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
            this.cmbAtributos = new System.Windows.Forms.ComboBox();
            this.cmbTipoLlave = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbAtributos
            // 
            this.cmbAtributos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAtributos.FormattingEnabled = true;
            this.cmbAtributos.Location = new System.Drawing.Point(12, 65);
            this.cmbAtributos.Name = "cmbAtributos";
            this.cmbAtributos.Size = new System.Drawing.Size(236, 24);
            this.cmbAtributos.TabIndex = 0;
            this.cmbAtributos.SelectedIndexChanged += new System.EventHandler(this.cmbAtributos_SelectedIndexChanged);
            // 
            // cmbTipoLlave
            // 
            this.cmbTipoLlave.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoLlave.FormattingEnabled = true;
            this.cmbTipoLlave.Items.AddRange(new object[] {
            "Llave Primaria",
            "Llave Foránea"});
            this.cmbTipoLlave.Location = new System.Drawing.Point(12, 134);
            this.cmbTipoLlave.Name = "cmbTipoLlave";
            this.cmbTipoLlave.Size = new System.Drawing.Size(236, 24);
            this.cmbTipoLlave.TabIndex = 1;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnAceptar.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAceptar.Location = new System.Drawing.Point(68, 179);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(122, 44);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 27);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccionar Atributo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Montserrat SemiBold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tipo de llave";
            // 
            // AsignarLlaveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 238);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbTipoLlave);
            this.Controls.Add(this.cmbAtributos);
            this.Name = "AsignarLlaveForm";
            this.Text = "AsignarLlaveForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbAtributos;
        private System.Windows.Forms.ComboBox cmbTipoLlave;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}