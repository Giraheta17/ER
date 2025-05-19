using DiagramaER.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiagramaER
{
    public partial class CargarDiagramaForm : Form
    {
        public string JsonDiagrama { get; private set; }
        public bool DiagramaCargado { get; private set; } = false;
        public Diagramas DiagramaSeleccionado { get; private set; }
        public CargarDiagramaForm()
        {
            InitializeComponent();
            CargarDiagramasBD();
        }
        //Botones
        private void btnregresar_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide(); // Oculta el formulario actual
        }

        private void btnLocal_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json|Todos los archivos (*.*)|*.*",
                Title = "Seleccionar diagrama ER"
            };

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string JsonDiagrama = File.ReadAllText(openDialog.FileName);
                    //validar json 
                    var diagrama = JsonConvert.DeserializeObject<DiagramaImportado>(JsonDiagrama);
                    if (diagrama == null || diagrama.Figuras == null)
                    {
                        MessageBox.Show("El archivo JSON no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var ventana = new MesnajeLargoForm(JsonDiagrama, "Contenido del diagrama");
                    ventana.ShowDialog();

                    this.Hide(); // Oculta el formulario actual

                    //crear objeto tipo diagrama 
                    var diagramatemporal = new Diagramas
                    {
                        Nombre = Path.GetFileNameWithoutExtension(openDialog.FileName),
                        ContenidoDiagrama = JsonDiagrama
                    };

                    //mostrar el json en la ventana de mensaje largo
                    EditorForm editorForm = new EditorForm();
                    editorForm.CargarDesdeJSON(diagrama);
                    //editorForm.CargarDiagramas(diagramatemporal);
                    editorForm.Show();

                    MessageBox.Show("Diagrama cargado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch(Exception ex)
                { 
                    MessageBox.Show("Error al leer el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            if (dgvdiagramas.SelectedRows.Count == 0)
            { 
                MessageBox.Show("Seleccione un diagrama de la lista", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idDiagrama = (int)dgvdiagramas.SelectedRows[0].Cells["IdDiagrama"].Value;

            try
            {
                using (EREntities2 db = new EREntities2())
                { 
                    var diagramaBD = db.Diagramas.Find(idDiagrama);
                    if (diagramaBD != null)
                    {
                        string ContenidoJSON = diagramaBD.ContenidoDiagrama;
                        DiagramaImportado diagramaimpor = JsonConvert.DeserializeObject<DiagramaImportado>(ContenidoJSON);

                        if (diagramaimpor == null)
                        {
                            MessageBox.Show("El diagrama no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        //cargar el diagrama en el editor

                        this.Hide(); // Oculta el formulario actual
                        EditorForm editar = new EditorForm();
                        editar.CargarDesdeJSON(diagramaimpor);
                        editar.Show();
                    }
                    else
                    {
                        MessageBox.Show("Diagrama no encontrado en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el diagrama: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (dgvdiagramas.SelectedRows.Count == 0)
            {
                return;
            }

            int idDiagrama = (int)dgvdiagramas.SelectedRows[0].Cells["IdDiagrama"].Value;
            string nombreDiagrama = dgvdiagramas.SelectedRows[0].Cells["Nombre"].Value.ToString();

            var confirmacion = MessageBox.Show($"¿Está seguro de que desea eliminar el diagrama '{nombreDiagrama}'?", "Confirmación eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    using (EREntities2 db = new EREntities2())
                    {
                        var diagrama = db.Diagramas.Find(idDiagrama);
                        if (diagrama != null)
                        {
                            db.Diagramas.Remove(diagrama);
                            db.SaveChanges();
                            MessageBox.Show("Diagrama eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarDiagramasBD(); // Recargar la lista de diagramas
                        }
                        else
                        {
                            MessageBox.Show("Diagrama no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el diagrama: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                return;
            }

        }

        //funciones de las god
        private void CargarDiagramasBD()
        {
            try 
            {
                using (EREntities2 db = new EREntities2())
                { 
                    var diagramas = db.Diagramas.OrderByDescending(d => d.FechaCreacion).ToList();
                    dgvdiagramas.DataSource = diagramas.Select(d => new
                    {
                        d.IdDiagrama,
                        d.Nombre,
                        d.FechaCreacion
                    }).ToList();
                }
            }
            catch(Exception ex)
            { 
                MessageBox.Show("Error al cargar los diagramas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDiagramasDesdeJSON()
        {
            var diagrama = JsonConvert.DeserializeObject<Diagrama>(File.ReadAllText("diagrama.json"));
        }

        private void dgvdiagramas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 1)
            {
                btncargar_Click(sender, e);
            }
        }

      
    }
}
