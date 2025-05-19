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
    public partial class SeleccionarFiguraForm : Form
    {
        public SeleccionarFiguraForm()
        {
            InitializeComponent();
        }

        private string tipo;

        public SeleccionarFiguraForm(string tipo)
        {
            InitializeComponent();
            this.tipo = tipo;
            CargarOpciones();
        }

        private void CargarOpciones()
        {
            lstFiguras.Items.Clear();

            if (tipo == "Entidad")
            {
                lblTitulo.Text = "Selecciona un tipo de Entidad:";
                lstFiguras.Items.Add("Entidad Fuerte");
                lstFiguras.Items.Add("Entidad Débil");
            }
            else if (tipo == "Relacion")
            {
                lblTitulo.Text = "Selecciona un tipo de Relación:";
                lstFiguras.Items.Add("Relación Normal");
                lstFiguras.Items.Add("Relación de Identificación");
            }
            else if (tipo == "Atributo")
            {
                lblTitulo.Text = "Selecciona un tipo de Atributo:";
                lstFiguras.Items.Add("Atributo Normal");
                lstFiguras.Items.Add("Atributo Multivaluado");
                lstFiguras.Items.Add("Atributo Derivado");
            }
        }

        public string FiguraSeleccionada { get; private set; }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (lstFiguras.SelectedItem != null)
            {
                FiguraSeleccionada = lstFiguras.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor selecciona una opción.");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SeleccionarFiguraForm_Load(object sender, EventArgs e)
        {

        }
    }
}
