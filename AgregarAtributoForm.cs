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
    public partial class AgregarAtributoForm : Form
    {
        public string NombreAtributo { get; private set; }
        public FiguraControl FiguraSeleccionada { get; private set; }
        public string TipoDato { get; private set; }
        public string DestinoLlave { get; set; }
        public string TipoLlave { get; private set; }
        public AgregarAtributoForm()
        {
            InitializeComponent();
            cbtipodato.Items.AddRange(new string[]
                {
                    "int",               // Números enteros  
                    "varchar(50)",       // Texto variable (50 chars)  
                    "varchar(100)",      // Texto variable (100 chars)  
                    "nvarchar(50)",      // Unicode (50 chars)  
                    "nvarchar(100)",     // Unicode (100 chars)  
                    "char(10)",          // Texto fijo (10 chars)  
                    "date",              // Fecha (YYYY-MM-DD)  
                    "datetime",          // Fecha y hora  
                    "datetime2",         // Fecha y hora (precisión alta)  
                    "smalldatetime",     // Fecha y hora (precisión baja)  
                    "time",              // Hora (HH:MM:SS)  
                    "float",             // Decimal aproximado  
                    "decimal(10,2)",     // Decimal exacto (10,2)  
                    "numeric(10,2)",     // = decimal(10,2)  
                    "bit",               // Booleano (0/1)  
                    "bigint",            // Entero grande (±9.2e18)  
                    "smallint",          // Entero pequeño (±32k)  
                    "tinyint",           // Entero miniatura (0-255)  
                    "money",             // Monetario (4 decimales)  
                    "smallmoney",        // Monetario pequeño  
                    "binary(50)",        // Binario (50 bytes)  
                    "varbinary(100)",    // Binario variable (100 bytes)  
                    "uniqueidentifier",   // GUID (16 bytes)  
                    "xml",               // Datos XML  
                    "json",              // Datos JSON  
                    "text",              // Texto largo (obsoleto)  
                    "ntext",             // Texto Unicode largo (obsoleto)  
                });

            cbtipodato.SelectedIndex = 0;
        }

        private void btnconfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtnombre.Text))
            {
                MessageBox.Show("Debe ingresarle un nombre al atributo", "advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (string.IsNullOrEmpty(cbtipodato.Text))
            {
                MessageBox.Show("Debe asignarle un dato al atributo", "advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            NombreAtributo = txtnombre.Text.Trim();
            TipoDato = cbtipodato.SelectedItem.ToString();

            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbtipodato_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void AgregarAtributoForm_Load(object sender, EventArgs e)
        {
           
        }
    }
}
