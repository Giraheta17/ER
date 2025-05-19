using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramaER
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnNuevoDiagrama_Click(object sender, EventArgs e)
        {
            this.Hide();// Abre el EditorForm
            EditorForm editorForm = new EditorForm();
            editorForm.ShowDialog(); // Abre el EditorForm como modal
            
        }

        private void btnCargarDiagrama_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario actual
            using (CargarDiagramaForm cargarform = new CargarDiagramaForm())
            {
                if (cargarform.ShowDialog() == DialogResult.OK && cargarform.DiagramaSeleccionado != null)
                { 

                    string json = cargarform.DiagramaSeleccionado.ContenidoDiagrama;
                  
                    var ventana = new MesnajeLargoForm(json, cargarform.DiagramaSeleccionado?.ContenidoDiagrama);
                    ventana.ShowDialog();
                    // Si el usuario cierra el mensaje largo, se abre el EditorForm
                    EditorForm editorForm = new EditorForm();
                    ventana.ShowDialog();
                    //editorForm.CargarDiagramas(cargarform.DiagramaSeleccionado);
                    editorForm.Show();
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Botón: Nuevo Diagrama
        private void btnNuevoDiagrama_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.DarkGray;
        }

        private void btnNuevoDiagrama_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = System.Drawing.Color.LightGray;
        }

        // Botón: Cargar Diagrama
        private void btnCargarDiagrama_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackColor = System.Drawing.Color.DarkGray;
        }

        private void btnCargarDiagrama_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.BackColor = System.Drawing.Color.LightGray;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
