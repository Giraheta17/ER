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
    public partial class FormNombreDiagrama: Form
    {
        public string NombreDiagrama { get; set; } 
        public FormNombreDiagrama()
        {
            InitializeComponent();
        }

        private void btnconfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            { 
                MessageBox.Show("Por favor, ingresa un nombre para el diagrama.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //guardamos el nombre del diagrama
            NombreDiagrama = txtnombre.Text.Trim();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormNombreDiagrama_Load(object sender, EventArgs e)
        {
            this.txtnombre.Focus();
        }
    }
}
