namespace DiagramaER
{
    partial class EditorForm
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

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.panelHerramientas = new System.Windows.Forms.Panel();
            this.panelDiagrama = new System.Windows.Forms.Panel();
            this.btnDeshacer = new System.Windows.Forms.Button();
            this.btnRehacer = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnConvertirSQL = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnAsignarLlave = new System.Windows.Forms.Button();
            this.btnConectarFiguras = new System.Windows.Forms.Button();
            this.btnNuevaPlantilla = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditarNombre = new System.Windows.Forms.Button();
            this.btnAtributo = new System.Windows.Forms.Button();
            this.btnEntidad = new System.Windows.Forms.Button();
            this.panelHerramientas.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHerramientas
            // 
            this.panelHerramientas.BackColor = System.Drawing.Color.LightGray;
            this.panelHerramientas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHerramientas.Controls.Add(this.btnExportar);
            this.panelHerramientas.Controls.Add(this.btnAsignarLlave);
            this.panelHerramientas.Controls.Add(this.btnConectarFiguras);
            this.panelHerramientas.Controls.Add(this.btnNuevaPlantilla);
            this.panelHerramientas.Controls.Add(this.btnEliminar);
            this.panelHerramientas.Controls.Add(this.btnEditarNombre);
            this.panelHerramientas.Controls.Add(this.btnAtributo);
            this.panelHerramientas.Controls.Add(this.btnEntidad);
            this.panelHerramientas.Location = new System.Drawing.Point(12, 12);
            this.panelHerramientas.Name = "panelHerramientas";
            this.panelHerramientas.Size = new System.Drawing.Size(235, 649);
            this.panelHerramientas.TabIndex = 0;
            this.panelHerramientas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHerramientas_Paint);
            // 
            // panelDiagrama
            // 
            this.panelDiagrama.BackColor = System.Drawing.Color.White;
            this.panelDiagrama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDiagrama.Location = new System.Drawing.Point(265, 78);
            this.panelDiagrama.Name = "panelDiagrama";
            this.panelDiagrama.Size = new System.Drawing.Size(942, 583);
            this.panelDiagrama.TabIndex = 1;
            this.panelDiagrama.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDiagrama_Paint_1);
            // 
            // btnDeshacer
            // 
            this.btnDeshacer.BackColor = System.Drawing.Color.LightGray;
            this.btnDeshacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeshacer.Font = new System.Drawing.Font("Montserrat", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDeshacer.Location = new System.Drawing.Point(265, 12);
            this.btnDeshacer.Name = "btnDeshacer";
            this.btnDeshacer.Size = new System.Drawing.Size(173, 60);
            this.btnDeshacer.TabIndex = 2;
            this.btnDeshacer.Text = "Deshacer";
            this.btnDeshacer.UseVisualStyleBackColor = false;
            this.btnDeshacer.Click += new System.EventHandler(this.btnDeshacer_Click);
            // 
            // btnRehacer
            // 
            this.btnRehacer.BackColor = System.Drawing.Color.LightGray;
            this.btnRehacer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRehacer.Font = new System.Drawing.Font("Montserrat", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRehacer.Location = new System.Drawing.Point(444, 12);
            this.btnRehacer.Name = "btnRehacer";
            this.btnRehacer.Size = new System.Drawing.Size(169, 60);
            this.btnRehacer.TabIndex = 3;
            this.btnRehacer.Text = "Rehacer";
            this.btnRehacer.UseVisualStyleBackColor = false;
            this.btnRehacer.Click += new System.EventHandler(this.btnRehacer_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightGray;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Montserrat", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Location = new System.Drawing.Point(619, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(171, 60);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Font = new System.Drawing.Font("Montserrat", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnRegresar.ForeColor = System.Drawing.Color.White;
            this.btnRegresar.Location = new System.Drawing.Point(1026, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(181, 60);
            this.btnRegresar.TabIndex = 6;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnConvertirSQL
            // 
            this.btnConvertirSQL.BackColor = System.Drawing.Color.LightGray;
            this.btnConvertirSQL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertirSQL.Font = new System.Drawing.Font("Montserrat", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnConvertirSQL.Image = global::DiagramaER.Properties.Resources.sqnuevo;
            this.btnConvertirSQL.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnConvertirSQL.Location = new System.Drawing.Point(796, 12);
            this.btnConvertirSQL.Name = "btnConvertirSQL";
            this.btnConvertirSQL.Size = new System.Drawing.Size(224, 60);
            this.btnConvertirSQL.TabIndex = 5;
            this.btnConvertirSQL.Text = "  Convertir a SQL";
            this.btnConvertirSQL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConvertirSQL.UseVisualStyleBackColor = false;
            this.btnConvertirSQL.Click += new System.EventHandler(this.btnConvertirSQL_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportar.Image = global::DiagramaER.Properties.Resources.btnexpor;
            this.btnExportar.Location = new System.Drawing.Point(119, 119);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(110, 120);
            this.btnExportar.TabIndex = 8;
            this.btnExportar.Text = "Exportar JSON";
            this.btnExportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnAsignarLlave
            // 
            this.btnAsignarLlave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAsignarLlave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarLlave.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.btnAsignarLlave.Image = global::DiagramaER.Properties.Resources.ickey;
            this.btnAsignarLlave.Location = new System.Drawing.Point(4, 9);
            this.btnAsignarLlave.Name = "btnAsignarLlave";
            this.btnAsignarLlave.Size = new System.Drawing.Size(225, 95);
            this.btnAsignarLlave.TabIndex = 7;
            this.btnAsignarLlave.Text = "   Asignar Llave";
            this.btnAsignarLlave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAsignarLlave.UseVisualStyleBackColor = false;
            this.btnAsignarLlave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConectarFiguras
            // 
            this.btnConectarFiguras.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnConectarFiguras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectarFiguras.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.btnConectarFiguras.Image = global::DiagramaER.Properties.Resources.btncone;
            this.btnConectarFiguras.Location = new System.Drawing.Point(4, 539);
            this.btnConectarFiguras.Name = "btnConectarFiguras";
            this.btnConectarFiguras.Size = new System.Drawing.Size(225, 95);
            this.btnConectarFiguras.TabIndex = 6;
            this.btnConectarFiguras.Text = "     Conectar Figuras";
            this.btnConectarFiguras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConectarFiguras.UseVisualStyleBackColor = false;
            this.btnConectarFiguras.Click += new System.EventHandler(this.btnConectarFiguras_Click);
            // 
            // btnNuevaPlantilla
            // 
            this.btnNuevaPlantilla.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNuevaPlantilla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaPlantilla.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevaPlantilla.Image = global::DiagramaER.Properties.Resources.btneso;
            this.btnNuevaPlantilla.Location = new System.Drawing.Point(119, 396);
            this.btnNuevaPlantilla.Name = "btnNuevaPlantilla";
            this.btnNuevaPlantilla.Size = new System.Drawing.Size(110, 120);
            this.btnNuevaPlantilla.TabIndex = 5;
            this.btnNuevaPlantilla.Text = "Nueva Plantilla";
            this.btnNuevaPlantilla.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNuevaPlantilla.UseVisualStyleBackColor = false;
            this.btnNuevaPlantilla.Click += new System.EventHandler(this.btnNuevaPlantilla_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.Image = global::DiagramaER.Properties.Resources.btneliminar;
            this.btnEliminar.Location = new System.Drawing.Point(3, 396);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 120);
            this.btnEliminar.TabIndex = 4;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditarNombre
            // 
            this.btnEditarNombre.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEditarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarNombre.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditarNombre.Image = global::DiagramaER.Properties.Resources.btntext1;
            this.btnEditarNombre.Location = new System.Drawing.Point(119, 260);
            this.btnEditarNombre.Name = "btnEditarNombre";
            this.btnEditarNombre.Size = new System.Drawing.Size(110, 120);
            this.btnEditarNombre.TabIndex = 3;
            this.btnEditarNombre.Text = "Editar Nombre";
            this.btnEditarNombre.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditarNombre.UseVisualStyleBackColor = false;
            this.btnEditarNombre.Click += new System.EventHandler(this.btnEditarNombre_Click);
            // 
            // btnAtributo
            // 
            this.btnAtributo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAtributo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtributo.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.btnAtributo.Image = global::DiagramaER.Properties.Resources.btnatributo;
            this.btnAtributo.Location = new System.Drawing.Point(3, 260);
            this.btnAtributo.Name = "btnAtributo";
            this.btnAtributo.Size = new System.Drawing.Size(110, 120);
            this.btnAtributo.TabIndex = 2;
            this.btnAtributo.Text = "Atributo";
            this.btnAtributo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAtributo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAtributo.UseVisualStyleBackColor = false;
            this.btnAtributo.Click += new System.EventHandler(this.btnAtributo_Click);
            // 
            // btnEntidad
            // 
            this.btnEntidad.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnEntidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntidad.Font = new System.Drawing.Font("Montserrat", 10F, System.Drawing.FontStyle.Bold);
            this.btnEntidad.Image = global::DiagramaER.Properties.Resources.entibut;
            this.btnEntidad.Location = new System.Drawing.Point(3, 119);
            this.btnEntidad.Name = "btnEntidad";
            this.btnEntidad.Size = new System.Drawing.Size(110, 120);
            this.btnEntidad.TabIndex = 0;
            this.btnEntidad.Text = "Entidad";
            this.btnEntidad.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntidad.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEntidad.UseVisualStyleBackColor = false;
            this.btnEntidad.Click += new System.EventHandler(this.btnEntidad_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1219, 673);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.btnConvertirSQL);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnRehacer);
            this.Controls.Add(this.btnDeshacer);
            this.Controls.Add(this.panelDiagrama);
            this.Controls.Add(this.panelHerramientas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Diagrama ER";
            this.panelHerramientas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHerramientas;
        private System.Windows.Forms.Button btnEntidad;
        private System.Windows.Forms.Button btnAtributo;
        private System.Windows.Forms.Button btnEditarNombre;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnNuevaPlantilla;
        private System.Windows.Forms.Button btnConectarFiguras;
        private System.Windows.Forms.Panel panelDiagrama;
        private System.Windows.Forms.Button btnDeshacer;
        private System.Windows.Forms.Button btnRehacer;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnConvertirSQL;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnAsignarLlave;
        private System.Windows.Forms.Button btnExportar;
    }
}
