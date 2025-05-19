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
    public partial class AsignarLlaveForm: Form
    {
        // Propiedades para devolver los datos seleccionados
        public FiguraControl FiguraSeleccionada { get; private set; }
        public string TipoLlaveSeleccionada { get; set; }

        public string TipoDatoSeleccionado { get; set; }
        public string EntidadDestinoSeleccionada { get; set; }


        // Listado de atributos disponibles para mostrar
        private List<FiguraControl> atributosDisponibles;
        public AsignarLlaveForm(List<FiguraControl> atributos)
        {
            InitializeComponent();
            // Llenar el ComboBox con los nombres de los atributos
            atributosDisponibles = atributos;
            foreach (var atributo in atributos)
            {
                cmbAtributos.Items.Add(atributo.Texto); // Asume que "Texto" es el nombre o texto del atributo
            }

            if (cmbAtributos.Items.Count > 0)
                cmbAtributos.SelectedIndex = 0;  // Selecciona el primer atributo


        }
        public void CargarAtributos(List<FiguraControl> atributos)
        {
            this.atributosDisponibles = atributos;
            cmbAtributos.Items.Clear();

            foreach (var atributo in atributos)
            {
                cmbAtributos.Items.Add(atributo.Texto); // Asume que "Texto" es el nombre o texto del atributo
            }

            if (cmbAtributos.Items.Count > 0)
                cmbAtributos.SelectedIndex = 0;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbAtributos.SelectedIndex >= 0 && cmbTipoLlave.SelectedIndex >= 0)
            {
                // Guardar las selecciones
                FiguraSeleccionada = atributosDisponibles[cmbAtributos.SelectedIndex];
                TipoLlaveSeleccionada = cmbTipoLlave.SelectedItem.ToString();

                // Establecer el resultado del cuadro de diálogo
                this.DialogResult = DialogResult.OK;
                this.Close();  // Cierra el formulario después de aceptar
            }
            else
            {
                MessageBox.Show("Debes seleccionar un atributo y un tipo de llave.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbAtributos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
