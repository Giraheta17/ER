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
    public partial class SeleccionarConexionForm : Form
    {
        private List<FiguraControl> figuras; // Lista de todas las figuras disponibles

        public FiguraControl OrigenSeleccionado { get; private set; }
        public FiguraControl DestinoSeleccionado { get; private set; }
        public string TipoRelacionSeleccionado { get; private set; }

        public SeleccionarConexionForm(List<FiguraControl> figurasDisponibles)
        {
            InitializeComponent();
            figuras = figurasDisponibles;
            LlenarCombos();
        }

        private void LlenarCombos()
        {
            cmbOrigen.Items.Clear();
            cmbDestino.Items.Clear();

            foreach (var figura in figuras)
            {
                cmbOrigen.Items.Add(figura.Texto);
                cmbDestino.Items.Add(figura.Texto);
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            if (cmbOrigen.SelectedIndex >= 0 && cmbDestino.SelectedIndex >= 0 && cmbTipoRelacion.SelectedIndex >= 0)
            {
                OrigenSeleccionado = figuras[cmbOrigen.SelectedIndex];
                DestinoSeleccionado = figuras[cmbDestino.SelectedIndex];
                TipoRelacionSeleccionado = cmbTipoRelacion.SelectedItem.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor selecciona todas las opciones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SeleccionarConexionForm_Load(object sender, EventArgs e)
        {

        }
    }
}
