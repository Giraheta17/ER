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
    public partial class MesnajeLargoForm : Form
    {
        public MesnajeLargoForm(string mensaje, string titulo = "mensaje")
        {
            InitializeComponent();
            this.Text = titulo; 
            txtmensaje.Text = mensaje;  
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
