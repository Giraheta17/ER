using DiagramaER.Modelo;
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
    public partial class SeleccionarDestinoLlaveForm: Form
    {
        public FiguraControl FiguraDestinoSeleccionada { get; private set; }
        public string EntidadSeleccionada { get; private set; } // Add this property
        public string CampoReferenciaSeleccionado { get; private set; }

        private List<FiguraControl> entidades;
        public SeleccionarDestinoLlaveForm(List<FiguraControl> entidadesDisponibles)
        {
            InitializeComponent();

            // Llenar ComboBox con las opciones de destino
            entidades = entidadesDisponibles;

            cmbDestinos.Items.AddRange(entidades.Select(e => e.Texto).ToArray());
            //cmbDestinos.SelectedIndexChanged += CmbDestinos_SelectedIndexChanged;
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (cmbDestinos.SelectedIndex >= 0)
            {
                string textoSeleccionado = cmbDestinos.SelectedItem.ToString();

                if (Owner != null)
                {
                    foreach (var control in Owner.Controls)
                    {
                        if (control is Panel panel)
                        {
                            foreach (Control child in panel.Controls)
                            {
                                if (child is FiguraControl figura && figura.Texto == textoSeleccionado)
                                {
                                    FiguraDestinoSeleccionada = figura;
                                    EntidadSeleccionada = figura.Texto; // Set the selected entity
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbDestinos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
