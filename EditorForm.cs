using DiagramaER.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DiagramaER
{
    public partial class EditorForm : Form
    {
        // Variables globales
        private string tipoSeleccionActual = ""; 
        private bool arrastrando = false;
        private Point offset;
        private Control figuraSeleccionadaControl;
        private bool modoEditarNombre = false;
        public bool ModoEditarNombre => modoEditarNombre;
        private bool modoConectarFiguras = false;
        private FiguraControl figuraOrigen = null;
        private List<Conexion> conexiones = new List<Conexion>();
        private Stack<ActionEstado> pilaDeshacer = new Stack<ActionEstado>();
        private Stack<ActionEstado> pilaRehacer = new Stack<ActionEstado>();
        public Panel PanelDiagrama => panelDiagrama;



        public EditorForm()
        {
            InitializeComponent();
            this.panelDiagrama.Paint += new PaintEventHandler(this.PanelDiagrama_Paint);
            this.panelDiagrama.Paint += new PaintEventHandler(this.PanelDiagrama_Paint);

        }
        private void CrearFigura(string figuraSeleccionada)
        {
            GuardarEstado();
            FiguraControl figura = new FiguraControl();
            figura.TipoFigura = figuraSeleccionada;
            figura.Texto = figuraSeleccionada;
            figura.Location = new Point(50, 50);

            figura.MouseDown += FiguraControl_MouseDown;
            figura.MouseMove += Figura_MouseMove;
            figura.MouseUp += Figura_MouseUp;

            

            figura.Click += (s, e) =>
            {
                atributoSeleccionadoManual = (FiguraControl)s;
                foreach (var f in panelDiagrama.Controls.OfType<FiguraControl>())
                { 
                    f.BackColor = Color.White;
                }
                atributoSeleccionadoManual.BackColor = Color.White; // Resaltar la figura seleccionada
            };
            panelDiagrama.Controls.Add(figura);
        }

        private void AbrirSeleccionarFigura()
        {
            SeleccionarFiguraForm seleccionForm = new SeleccionarFiguraForm(tipoSeleccionActual);
            if (seleccionForm.ShowDialog() == DialogResult.OK)
            {
                string figuraSeleccionada = seleccionForm.FiguraSeleccionada;
                CrearFigura(figuraSeleccionada);
            }
        }        

        private void Figura_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando && figuraSeleccionadaControl != null)
            {
                Point newLocation = figuraSeleccionadaControl.Location;
                newLocation.X += e.X - offset.X;
                newLocation.Y += e.Y - offset.Y;
                figuraSeleccionadaControl.Location = newLocation;
            }
        }

        private void Figura_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrando = false;
        }

        private void btnEditarNombre_Click(object sender, EventArgs e)
        {
            modoEditarNombre = true;
            MessageBox.Show("Haz clic en una figura para editar su nombre.", "Editar Nombre", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnEntidad_Click(object sender, EventArgs e)
        {
            tipoSeleccionActual = "Entidad";
            AbrirSeleccionarFigura();
        }

        private void btnRelacion_Click(object sender, EventArgs e)
        {
            tipoSeleccionActual = "Relacion";
            AbrirSeleccionarFigura();
        }

        private void btnAtributo_Click(object sender, EventArgs e)
        {
            tipoSeleccionActual = "Atributo";

            SeleccionarFiguraForm seleccionForm = new SeleccionarFiguraForm(tipoSeleccionActual);
            if (seleccionForm.ShowDialog() == DialogResult.OK)
            {
                string tipoatributo = seleccionForm.FiguraSeleccionada;
                AgregarAtributoForm agregarform = new AgregarAtributoForm();
                if (agregarform.ShowDialog() == DialogResult.OK)
                {
                    string tipoDato = string.IsNullOrWhiteSpace(agregarform.TipoDato)
                                    ? "int"
                                    : agregarform.TipoDato;

                    FiguraControl figura = new FiguraControl();
                    figura.TipoFigura = tipoatributo;
                    figura.Texto = agregarform.NombreAtributo;
                    figura.Tag = $"{tipoDato}|Normal"; 
                    figura.Location = new Point(50, 50);
                    figura.MouseDown += FiguraControl_MouseDown;
                    figura.MouseMove += Figura_MouseMove;
                    figura.MouseUp += Figura_MouseUp;

                    figura.Click += (s, es) =>
                    {
                        atributoSeleccionadoManual = (FiguraControl)s;
                        foreach (var f in panelDiagrama.Controls.OfType<FiguraControl>())
                        {
                            f.BackColor = Color.White;
                        }
                        atributoSeleccionadoManual.BackColor = Color.White; // Resaltar la figura seleccionada
                    };

                    panelDiagrama.Controls.Add(figura);
                }
            }
        }

        public void EditarNombreFigura(FiguraControl figura)
        {
            GuardarEstado();
            string nuevoNombre = Prompt.ShowDialog("Nuevo nombre para la figura:", "Editar Nombre");

            if (!string.IsNullOrWhiteSpace(nuevoNombre))
            {
                figura.Texto = nuevoNombre;
                figura.Invalidate(); // Redibuja para mostrar el nuevo texto
            }

            modoEditarNombre = false; // <-- SOLO después de cambiar nombre, salimos de modo edición
        }

        private void btnConectarFiguras_Click(object sender, EventArgs e)
        {
            // Obtener todas las figuras que hay en el diagrama
            List<FiguraControl> figuras = new List<FiguraControl>();
            foreach (var control in panelDiagrama.Controls)
            {
                if (control is FiguraControl figura)
                    figuras.Add(figura);
            }

            // Mostrar formulario de selección
            SeleccionarConexionForm seleccionarConexion = new SeleccionarConexionForm(figuras);
            if (seleccionarConexion.ShowDialog() == DialogResult.OK)
            {
                // Crear la conexión
                GuardarEstado();
                Conexion nuevaConexion = new Conexion(seleccionarConexion.OrigenSeleccionado, seleccionarConexion.DestinoSeleccionado, seleccionarConexion.TipoRelacionSeleccionado);
                conexiones.Add(nuevaConexion);
                panelDiagrama.Invalidate(); // Redibujar el diagrama para mostrar la nueva línea
            }
        }

        private void FiguraControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (modoConectarFiguras && sender is FiguraControl figuraClickeada)
            {
                if (figuraOrigen == null)
                {
                    figuraOrigen = figuraClickeada;
                }
                else
                {
                    FiguraControl figuraDestino = figuraClickeada;
                    conexiones.Add(new Conexion(figuraOrigen, figuraDestino, "Sin especificar"));
                    figuraOrigen = null;
                    modoConectarFiguras = false;
                    panelDiagrama.Invalidate(); // Redibujar
                }
                return;
            }
        }

        private void PanelDiagrama_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5);

                foreach (var conexion in conexiones)
                {
                    Point origenCentro = new Point(conexion.Origen.Left + conexion.Origen.Width / 2, conexion.Origen.Top + conexion.Origen.Height / 2);
                    Point destinoCentro = new Point(conexion.Destino.Left + conexion.Destino.Width / 2, conexion.Destino.Top + conexion.Destino.Height / 2);

                    e.Graphics.DrawLine(pen, origenCentro, destinoCentro);

                    // Dibujar el tipo de relación (1:1, 1:N, N:N) en el medio de la línea
                    Point medio = new Point((origenCentro.X + destinoCentro.X) / 2, (origenCentro.Y + destinoCentro.Y) / 2);
                    using (Font font = new Font("Montserrat", 8, FontStyle.Bold))
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        e.Graphics.DrawString(conexion.TipoRelacion, font, brush, medio);
                    }
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (panelDiagrama.Controls.Count == 0)
            {
                MessageBox.Show("No hay figuras para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FiguraControl figuraSeleccionada = SeleccionarFigura();

            if (figuraSeleccionada != null)
            {
                var resultado = MessageBox.Show($"¿Deseas eliminar la figura \"{figuraSeleccionada.Texto}\"?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    GuardarEstado();
                    // 1. Eliminar conexiones relacionadas
                    conexiones.RemoveAll(c => c.Origen == figuraSeleccionada || c.Destino == figuraSeleccionada);

                    // 2. Eliminar figura del panel
                    panelDiagrama.Controls.Remove(figuraSeleccionada);

                    // 3. Redibujar el diagrama
                    panelDiagrama.Invalidate();
                }
            }
        }

        private FiguraControl SeleccionarFigura()
        {
            List<FiguraControl> figuras = new List<FiguraControl>();
            foreach (var control in panelDiagrama.Controls)
            {
                if (control is FiguraControl figura)
                    figuras.Add(figura);
            }

            if (figuras.Count == 0)
                return null;

            using (Form seleccionarForm = new Form())
            {
                seleccionarForm.Text = "Seleccionar Figura";
                seleccionarForm.Size = new Size(300, 200);
                seleccionarForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                seleccionarForm.StartPosition = FormStartPosition.CenterParent;

                ComboBox cmbFiguras = new ComboBox() { Left = 20, Top = 20, Width = 240 };
                foreach (var fig in figuras)
                {
                    cmbFiguras.Items.Add(fig.Texto);
                }
                cmbFiguras.SelectedIndex = 0;

                Button btnOK = new Button() { Text = "Aceptar", Left = 80, Width = 120, Top = 70, DialogResult = DialogResult.OK };
                seleccionarForm.Controls.Add(cmbFiguras);
                seleccionarForm.Controls.Add(btnOK);
                seleccionarForm.AcceptButton = btnOK;

                if (seleccionarForm.ShowDialog() == DialogResult.OK)
                {
                    return figuras[cmbFiguras.SelectedIndex];
                }
            }
            return null;
        }
        private void GuardarEstado()
        {
            pilaDeshacer.Push(GuardarEstadoActual());
            pilaRehacer.Clear();
        }
        private void btnDeshacer_Click(object sender, EventArgs e)
        {
            if (pilaDeshacer.Count > 0)
            {
                var estadoAnterior = pilaDeshacer.Pop(); // 1. Recupera el anterior
                pilaRehacer.Push(GuardarEstadoActual()); // 2. Guarda lo actual
                RestaurarEstado(estadoAnterior); // 3. Restaura
                panelDiagrama.Refresh(); // Redibuja el panel
            }
        }

        private void btnRehacer_Click(object sender, EventArgs e)
        {
            if (pilaRehacer.Count > 0)
            {
                var estado = pilaRehacer.Pop(); // 1. Recupera el siguiente
                pilaDeshacer.Push(GuardarEstadoActual()); // 2. Guarda lo actual
                RestaurarEstado(estado); // 3. Restaura
                panelDiagrama.Refresh(); // Redibuja el panel
            }
        }

        private ActionEstado GuardarEstadoActual()
        {
            // Clonar todas las figuras
            List<FiguraControl> figurasActuales = new List<FiguraControl>();
            Dictionary<FiguraControl, FiguraControl> mapaFiguras = new Dictionary<FiguraControl, FiguraControl>();

            foreach (Control control in panelDiagrama.Controls)
            {
                if (control is FiguraControl figuraOriginal)
                {
                    var figuraCopia = figuraOriginal.Clonar();
                    figurasActuales.Add(figuraCopia);
                    mapaFiguras.Add(figuraOriginal, figuraCopia);
                }
            }

            // Clonar conexiones apuntando a las nuevas copias
            List<Conexion> conexionesActuales = new List<Conexion>();
            foreach (var conexion in conexiones)
            {
                conexionesActuales.Add(conexion.Clonar(mapaFiguras));
            }

            return new ActionEstado(figurasActuales, conexionesActuales);
        }

        private void RestaurarEstado(ActionEstado estado)
        {
            panelDiagrama.Controls.Clear();
            conexiones.Clear();

            foreach (var figura in estado.Figuras)
            {
                // Volver a asignar los eventos
                figura.MouseDown += FiguraControl_MouseDown;
                figura.MouseMove += Figura_MouseMove;
                figura.MouseUp += Figura_MouseUp;

                panelDiagrama.Controls.Add(figura);
            }

            conexiones.AddRange(estado.Conexiones);

            panelDiagrama.Invalidate();
        }
        private void btnNuevaPlantilla_Click(object sender, EventArgs e)
        {
            GuardarEstado();
            // Confirmar si realmente se quiere limpiar todo
            var resultado = MessageBox.Show("¿Estás seguro de que deseas limpiar todo el diagrama y comenzar con una nueva plantilla?", "Confirmar nueva plantilla", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                // Limpiar las conexiones
                conexiones.Clear();

                // Eliminar todas las figuras del panel
                panelDiagrama.Controls.Clear();

                // Redibujar el panel
                panelDiagrama.Invalidate();
            }
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
                this.Hide();
                MainForm re = new MainForm();
                re.Show();
        }

        private void panelHerramientas_Paint(object sender, PaintEventArgs e)
        {}

        private List<Nodo> listaNodos = new List<Nodo>();
        private List<Relacion> listaRelaciones = new List<Relacion>();
        private string nombreDiagramaGuardado = null; // Para controlar el nombre fijo
       
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try 
            {
                if (string.IsNullOrEmpty(nombreDiagramaGuardado))
                {
                    FormNombreDiagrama formNombre = new FormNombreDiagrama();
                    if (formNombre.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                  
                     nombreDiagramaGuardado = formNombre.NombreDiagrama;
                }                       

                //Vamos a recopilar los elementos dentro del panel 

                var figuras = panelDiagrama.Controls.OfType<FiguraControl>().ToList();


                //asignar ID 
                Dictionary<FiguraControl, string> figurasID = new Dictionary<FiguraControl, string>();
                for (int i = 0; i <figuras.Count; i++)
                { 
                    figurasID[figuras[i]] = $"fig_{i}"; // Asignar ID único
                }


               var figurasexportadas = figuras.Select(f =>
               {
                   var tagParts = (f.Tag?.ToString() ?? "").Split('|');
                   string tipoDato = tagParts.ElementAtOrDefault(0) ?? "int";
                   string tipoLlave = tagParts.ElementAtOrDefault(1) ?? "Normal";
                   string destinoLlave = tagParts.ElementAtOrDefault(2) ?? "";

                  return new FiguraExportada
                   {
                       ID = figurasID[f],
                       Nombre = f.Texto,
                       Tipo = f.TipoFigura,
                       X = f.Location.X,
                       Y = f.Location.Y,
                       TipoDato = tipoDato,
                       TipoLlave = tipoLlave,
                       DestinoLlave = destinoLlave
                   };
               } ).ToList();

                var conexionesexportadas = conexiones.Select(c => new ConexionExportada
                {
                    Origen = figurasID[c.Origen],
                    Destino = figurasID[c.Destino],
                    TipoRelacion = c.TipoRelacion
                }).ToList();

                //Ahora si el modelER
                var diagramer = new DiagramaERs
                {
                    Nombre = nombreDiagramaGuardado
                };

                var entidades = figuras.Where(f => f.TipoFigura.Contains("Entidad")).ToList();

                foreach (var entidadfi in entidades)
                { 
                    var entidad = new Entidad
                    {
                        Nombre = entidadfi.Texto
                    };

                    var atributosconectado = conexiones
                        .Where(c => c.Origen == entidadfi && c.Destino.TipoFigura.Contains("Atributo"))
                        .Select(c => c.Destino)
                        .ToList();

                    var atributoscercanos = figuras
                        .Where(f => f.TipoFigura.Contains("Atributo") &&
                                     !atributosconectado.Contains(f) &&
                                     Math.Abs(f.Location.X - entidadfi.Location.X) < 150 &&
                                     Math.Abs(f.Location.Y - entidadfi.Location.Y) < 150)
                        .ToList();

                    var atributos = atributosconectado.Concat(atributoscercanos).Distinct().ToList();

                    foreach (var atributo in atributos)
                    { 
                        var tagParts = (atributo.Tag?.ToString() ?? "").Split('|');
                        string tipodato = tagParts.ElementAtOrDefault(0) ?? "int";
                        string tipollave = tagParts.ElementAtOrDefault(1) ?? "Normal";

                        entidad.Campos.Add(new Campoo
                        {
                            Nombre = atributo.Texto,
                            TipoDato = tipodato,
                            EsClaveForanea = tipollave == "FK" || tipollave == "Llave Foranea" || tipollave == "Llave Foránea",
                            EsClavePrimaria = tipollave == "PK" || tipollave == "Llave Primaria",
                            permiteNulo = tipollave != "PK" && tipollave != "llave Primaria",
                        });

                    }
                    diagramer.Entidades.Add(entidad);
                }

                var diagramafinal = new DiagramaImportado
                {
                    Figuras = figuras.Select(f => new FiguraExportada
                    { 
                        ID = f.Texto,
                        Tipo = f.TipoFigura,
                        X = f.Location.X,
                        Y = f.Location.Y,
                        TipoDato = (f.Tag?.ToString() ?? "").Split('|').ElementAtOrDefault(0) ?? "int",
                        TipoLlave = (f.Tag?.ToString() ?? "").Split('|').ElementAtOrDefault(1) ?? "Normal",
                        DestinoLlave = (f.Tag?.ToString() ?? "").Split('|').ElementAtOrDefault(2) ?? "",
                    }).ToList(),
                    Conexiones = conexionesexportadas,
                    DiagramaER = diagramer
                };

                string contenidojson = JsonConvert.SerializeObject(diagramafinal, Newtonsoft.Json.Formatting.Indented);
                Directory.CreateDirectory("diagramas");
                //guardar en la bd 
                using (EREntities2 db = new EREntities2())
                { 
                    var existente = db.Diagramas.FirstOrDefault(d => d.Nombre == nombreDiagramaGuardado);
                    if (existente != null)
                    {
                        existente.ContenidoDiagrama = contenidojson;
                        existente.FechaCreacion = DateTime.Now;
                        
                    }
                    else
                    {
                        db.Diagramas.Add(new Diagramas
                        {
                            Nombre = nombreDiagramaGuardado,
                            ContenidoDiagrama = contenidojson,
                            FechaCreacion = DateTime.Now
                        });
                    }
                    db.SaveChanges();
                }

                MessageBox.Show("Diagrama guardado exitosamente en la base de datos.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el diagrama: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //funciones que ayudan a guarda 

        private string InferirCardinalidad(string tipoRelacion)
        {
            tipoRelacion = tipoRelacion.ToLower();
            if (tipoRelacion.Contains("muchos") || tipoRelacion.Contains("n:n"))
            {
                return "muchos_a_muchos";
            }

            if (tipoRelacion.Contains("1:n") || tipoRelacion.Contains("uno") && tipoRelacion.Contains("muchos"))
            {
                return "uno_a_muchos";
            }

            if (tipoRelacion.Contains("n:1") || tipoRelacion.Contains("muchos") && tipoRelacion.Contains("uno"))
            {
                return "muchos_a_uno";
            }

            if (tipoRelacion.Contains("1:1") || tipoRelacion.Contains("uno_a_uno"))
            {
                return "uno_a_uno";
            }

            return "relacion_desconocida";
        }

        private string ObtenerLlaveForanea(List<FiguraControl> figuras, FiguraControl origen, FiguraControl destino)
        {
            foreach (var fig in figuras)
            {
                if (fig.TipoFigura.Contains("Atributo") && fig.Tag?.ToString() == "Llave Foránea")
                {
                    var dx = Math.Abs(fig.Location.X - origen.Location.X);
                    var dy = Math.Abs(fig.Location.Y - origen.Location.Y);
                    if (dx < 150 && dy < 150)
                        return fig.Texto;
                }
            }
            return null;
        }
        private void AgregarDiagramaAlPanel(string nombreDiagrama)
        {
            // Crear un nuevo control para mostrar el diagrama guardado
            Label lblDiagrama = new Label();
            lblDiagrama.Text = nombreDiagrama;
            lblDiagrama.Location = new Point(10,10);
            panelDiagrama.Controls.Add(lblDiagrama);
        }

        private FiguraControl atributoSeleccionadoManual = null;
        //ASIGNAR LLAVE
        private void button1_Click(object sender, EventArgs e)
        {
            GuardarEstado();
            if (atributoSeleccionadoManual == null || !atributoSeleccionadoManual.TipoFigura.Contains("Atributo"))
            {
                MessageBox.Show("Haz click en un atributo antes de elegir la llave.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<FiguraControl> atributos = panelDiagrama.Controls.OfType<FiguraControl>()
                .Where(f => f.TipoFigura.Contains("Atributo"))
                .ToList();

            using (AsignarLlaveForm form = new AsignarLlaveForm(atributos) )
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string tipoLlave = form.TipoLlaveSeleccionada;
                    var partestag = (atributoSeleccionadoManual.Tag?.ToString() ?? "").Split('|');
                    string tipoDato = partestag.ElementAtOrDefault(0) ?? "int";
                    
                    MessageBox.Show($"Tipo Llave: {tipoLlave}\nTipo Dato: {tipoDato}", "message", MessageBoxButtons.OK);
                    string CampoReferencia = partestag.ElementAtOrDefault(2) ?? "";

                    if (tipoLlave == "Llave Foránea")
                    { 
                        var nombresEntidades = panelDiagrama.Controls.OfType<FiguraControl>()
                            .Where(f => f.TipoFigura.Contains("Entidad"))
                            .ToList();

                        using (var destinoform = new SeleccionarDestinoLlaveForm(nombresEntidades))
                        {                            

                            if (destinoform.ShowDialog() == DialogResult.OK)
                            {
                                entidadDestino = destinoform.EntidadSeleccionada;
                                var entidadFigura = panelDiagrama.Controls.OfType<FiguraControl>()
                                    .FirstOrDefault(f => f.TipoFigura.Contains("Entidad") && f.Texto == entidadDestino);
                                string campoReferencia = "";

                                if (entidadFigura != null)
                                {
                                    var posiblesAtributos = conexiones
                                        .Where(c => c.Origen == entidadFigura && c.Destino != null &&
                                        (c.Destino.TipoFigura.Equals("Atributo", StringComparison.OrdinalIgnoreCase) || c.Destino.TipoFigura.ToLower().Contains("atributo")))
                                        .Select(c => c.Destino)
                                        .ToList();

                                    if (!posiblesAtributos.Any())
                                    {
                                        posiblesAtributos = panelDiagrama.Controls.OfType<FiguraControl>()
                                            .Where(f =>
                                                        f.TipoFigura != null &&
                                                        (f.TipoFigura.Equals("Atributo", StringComparison.OrdinalIgnoreCase) ||
                                                        f.TipoFigura.ToLower().Contains("atributo")) &&
                                                        Math.Abs(f.Location.X - entidadFigura.Location.X) < 150 &&
                                                        Math.Abs(f.Location.Y - entidadFigura.Location.Y) < 150)
                                            .ToList();

                                        MessageBox.Show($"Atributos conectados: {posiblesAtributos.Count}", "DEBUG");
                                    }
                                    var atributoClave = posiblesAtributos.FirstOrDefault(a => a.Texto.ToLower().Contains("id")) ?? posiblesAtributos.FirstOrDefault();
                                    if (atributoClave != null)
                                    {
                                        campoReferencia = atributoClave.Texto;
                                    }
                                    MessageBox.Show($"Tipo Llave: {tipoLlave}\nTipo Dato: {tipoDato} \nEntidad Destino: {entidadDestino} \n CampoReferencia: {campoReferencia}", "message", MessageBoxButtons.OK);

                                }
                                MessageBox.Show($"Tipo Llave: {tipoLlave}\nTipo Dato: {tipoDato} \nEntidad Destino: {entidadDestino} \n CampoReferencia: {campoReferencia}", "message", MessageBoxButtons.OK);
                            }
                            else
                            {
                                MessageBox.Show("No se seleccionó una entidad de destino.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    
                    string tipDato = !string.IsNullOrWhiteSpace(form.TipoDatoSeleccionado) ? form.TipoDatoSeleccionado : partestag.ElementAtOrDefault(0) ?? "int";
                    string tagcompleto = $"{tipoDato}|{tipoLlave}|{entidadDestino}|{CampoReferencia}";
                    atributoSeleccionadoManual.Tag = tagcompleto;

                    //ToolTip 
                    ToolTip tip = new ToolTip();
                    tip.SetToolTip(atributoSeleccionadoManual, tagcompleto);
                    // Color visual
                    switch (tipoLlave)
                    {
                        case "Llave Primaria":
                            atributoSeleccionadoManual.BackColor = Color.LightGreen;
                            break;
                        case "Llave Foránea":
                            atributoSeleccionadoManual.BackColor = Color.LightBlue;
                            break;
                        default:
                            atributoSeleccionadoManual.BackColor = Color.White;
                            break;
                    }

                    // Conectar la llave foránea a la entidad más cercana
                    var entidadcercana = panelDiagrama.Controls.OfType<FiguraControl>()
                        .Where(f => f.TipoFigura.Contains("Entidad"))
                        .OrderBy(f => Math.Abs(f.Left - atributoSeleccionadoManual.Left) + Math.Abs(f.Top - atributoSeleccionadoManual.Top))
                        .FirstOrDefault();

                    if (entidadcercana != null)
                    {
                        bool yaconectado = conexiones.Any(c => c.Origen == entidadcercana && c.Destino == atributoSeleccionadoManual);

                        if (!yaconectado)
                        {
                            conexiones.Add(new Conexion(entidadcercana, atributoSeleccionadoManual, tipoLlave));
                        }
                    }

                    //conectar atributo a entidad destino
                    if (tipoLlave == "Llave Foránea" && !string.IsNullOrEmpty(entidadDestino))
                    {
                        var figuradestino = panelDiagrama.Controls.OfType<FiguraControl>()
                                            .FirstOrDefault(f => f.TipoFigura.Contains("Entidad") && f.Texto == entidadDestino);
                        if (figuradestino != null)
                        {
                           bool yaexiste = conexiones.Any(c => c.Origen == atributoSeleccionadoManual && c.Destino == figuradestino);
                           if (!yaexiste)
                           {
                               conexiones.Add(new Conexion(atributoSeleccionadoManual, figuradestino, "Llave Foranea"));
                           }
                        }
                    }
                   panelDiagrama.Invalidate(); // Redibujar el panel
                }
            }
        }

        private void btnConvertirSQL_Click(object sender, EventArgs e) 
        {
            try
            {
                if (string.IsNullOrEmpty(nombreDiagramaGuardado))
                {
                    MessageBox.Show("No hay un diagrama guardado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var entidades = panelDiagrama.Controls.OfType<FiguraControl>().Where(f => f.TipoFigura.Contains("Entidad")).ToList();

                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"CREATE DATABASE {nombreDiagramaGuardado}");
                sb.AppendLine("GO;");
                sb.AppendLine($"USE {nombreDiagramaGuardado}");
                sb.AppendLine("GO;");
                sb.AppendLine();

                foreach (var entidad in entidades)
                { 
                    string nombreentidad = entidad.Texto;   
                   
                    var atributos = conexiones
                        .Where(c => c.Origen == entidad && c.Destino.TipoFigura.Contains("Atributo")) //revisar este where
                        .Select(c => c.Destino)
                        .ToList();

                    var atributoscercanos = panelDiagrama.Controls.OfType<FiguraControl>()
                        .Where(f => f.TipoFigura.Contains("Atributo") &&
                                     !atributos.Contains(f) &&
                                     Math.Abs(f.Location.X - entidad.Location.X) < 150 &&
                                     Math.Abs(f.Location.Y - entidad.Location.Y) < 150)
                        .ToList();

                    atributos.AddRange(atributoscercanos);

                    var columnas = new List<string>();
                    var llavesPrimarias = new List<string>();
                    var llavesForaneas = new List<string>();
                    
                    foreach (var atributo in atributos)
                    {
                        string nombreatributo = atributo.Texto;
                        var tagParts = (atributo.Tag?.ToString() ?? "").Split('|');

                        string tipoDato = tagParts.ElementAtOrDefault(0)?.Trim() ?? "int";
                        
                        string tipoLlave = tagParts.ElementAtOrDefault(1)?.Trim() ?? "Normal";
                        string tablaReferencia = tagParts.ElementAtOrDefault(2)?.Trim() ?? "";
                        string columnaReferencia = tagParts.ElementAtOrDefault(3)?.Trim() ?? "";

                        columnas.Add($" {nombreatributo} {tipoDato} ");
                        MessageBox.Show($"Tag de {nombreatributo}: {atributo.Tag}", "DEBUG");
                        if (tipoLlave == "PK" || tipoLlave == "Llave Primaria")
                        {
                            llavesPrimarias.Add(nombreatributo);
                        }
                        else if (tipoLlave == "FK" || tipoLlave == "Llave Foránea" || tipoLlave == "Llave Foránea" )
                        {
                            //string columnaReferencia = "ID";
                            llavesForaneas.Add($"FOREIGN KEY ({nombreatributo}) REFERENCES {tablaReferencia}({columnaReferencia})");
                        }
                    }
                  
                    sb.AppendLine($"CREATE TABLE {nombreentidad} (");
                    sb.AppendLine(string.Join(",\n", columnas));
                    
                    if(llavesPrimarias.Any())
                    {
                        sb.AppendLine($"PRIMARY KEY ({string.Join(", ", llavesPrimarias)})");
                    }

                    if (llavesForaneas.Any())
                    {
                        foreach (var fk in llavesForaneas)
                        {
                            sb.AppendLine($"{fk}");
                        }
                    }

                    sb.AppendLine(");");
                    sb.AppendLine("GO;");
                    sb.AppendLine();

                }
                //mostrar
                var ventana = new MesnajeLargoForm(sb.ToString(), "Script SQL generado");
                ventana.ShowDialog();

                SaveFileDialog savedialog = new SaveFileDialog
                {
                    Filter = "SQL Files (*.sql)|*.sql",
                    Title = "Guardar Script SQL"
                };

                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(savedialog.FileName, sb.ToString());
                    MessageBox.Show("Script SQL guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se seleccionó ningún archivo para guardar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al generar la query " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(nombreDiagramaGuardado))
                {
                    FormNombreDiagrama formNombre = new FormNombreDiagrama();
                    if (formNombre.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    nombreDiagramaGuardado = formNombre.NombreDiagrama;
                }

                //Vamos a recopilar los elementos dentro del panel 

                var figuras = panelDiagrama.Controls.OfType<FiguraControl>().ToList();

                //asignar ID 
                Dictionary<FiguraControl, string> figurasID = new Dictionary<FiguraControl, string>();
                for (int i = 0; i < figuras.Count; i++)
                {
                    figurasID[figuras[i]] = $"fig_{i}"; // Asignar ID único
                }


                var figurasexportadas = figuras.Select(f =>
                {
                    var tagParts = (f.Tag?.ToString() ?? "").Split('|');
                    string tipoDato = tagParts.ElementAtOrDefault(0) ?? "int";
                    string tipoLlave = tagParts.ElementAtOrDefault(1) ?? "Normal";
                    string destinoLlave = tagParts.ElementAtOrDefault(2) ?? "";

                    return new FiguraExportada
                    {
                        ID = figurasID[f],
                        Nombre = f.Texto,
                        Tipo = f.TipoFigura,
                        X = f.Location.X,
                        Y = f.Location.Y,
                        TipoDato = tipoDato,
                        TipoLlave = tipoLlave,
                        DestinoLlave = destinoLlave
                    };
                }).ToList();

                var conexionesexportadas = conexiones.Select(c => new ConexionExportada
                {
                    Origen = figurasID[c.Origen],
                    Destino = figurasID[c.Destino],
                    TipoRelacion = c.TipoRelacion
                }).ToList();

                var diagramafinal = new DiagramaImportado
                {
                    Figuras = figurasexportadas,
                    Conexiones = conexionesexportadas
                };

                string contenidojson = JsonConvert.SerializeObject(diagramafinal, Newtonsoft.Json.Formatting.Indented);
                Directory.CreateDirectory("diagramas");

                //Ahora para el guardado local papus 
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Archivos JSON (*.json)|*.json";
                saveFileDialog.FileName = $"{nombreDiagramaGuardado}.json";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, contenidojson);
                    MessageBox.Show("Diagrama exportado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al exportar el diagrama: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
        private void panelDiagrama_Paint_1(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.Black, 2))
            {
                pen.CustomEndCap = new System.Drawing.Drawing2D.AdjustableArrowCap(5, 5);

                foreach (var conexion in conexiones)
                {
                    Point origenCentro = new Point(conexion.Origen.Left + conexion.Origen.Width / 2, conexion.Origen.Top + conexion.Origen.Height / 2);
                    Point destinoCentro = new Point(conexion.Destino.Left + conexion.Destino.Width / 2, conexion.Destino.Top + conexion.Destino.Height / 2);

                    e.Graphics.DrawLine(pen, origenCentro, destinoCentro);

                    // Dibujar el tipo de relación (1:1, 1:N, N:N) en el medio de la línea
                    Point medio = new Point((origenCentro.X + destinoCentro.X) / 2, (origenCentro.Y + destinoCentro.Y) / 2);
                    using (Font font = new Font("Montserrat", 8, FontStyle.Bold))
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        e.Graphics.DrawString(conexion.TipoRelacion, font, brush, medio);
                    }
                }
            }
        }

        public void CargarDesdeJSON(DiagramaImportado diagrama)
        { 
            Dictionary<string, FiguraControl> mapaporID = new Dictionary<string, FiguraControl>();
            conexiones.Clear();

            int figurasCargadas = 0;

            foreach (var figua in diagrama.Figuras)
            {
                string tipoDato = figua.TipoDato ?? "int";
                string tipoLlave = figua.TipoLlave ?? "Normal";
                string destino = figua.DestinoLlave ?? "";
                string tag = tipoLlave == "FK"
                        ? $"{tipoDato}|FK|{destino}|ID" // O usa columna real si tienes esa info
                        : $"{tipoDato}|{tipoLlave}";
                var figuracontrol = new FiguraControl
                {
                    TipoFigura = figua.Tipo,
                    Texto = figua.Nombre,
                    TipoDato= tipoDato,
                    Location = new Point(figua.X, figua.Y),
                    Tag = tag
                };

                panelDiagrama.Controls.Add(figuracontrol);
                figurasCargadas++;

                if (!string.IsNullOrEmpty(figua.ID))
                {
                    mapaporID[figua.ID] = figuracontrol;
                }
                else
                {
                    Console.WriteLine($"⚠️ Figura sin ID: {figua.Nombre}");
                }
            }

            int conexionesagregads = 0;
            int conexionesfallidas = 0;


            foreach (var conexion in diagrama.Conexiones)
            {
                if (mapaporID.TryGetValue(conexion.Origen, out var origen) && mapaporID.TryGetValue(conexion.Destino, out var destino))
                {
                    conexiones.Add(new Conexion(origen, destino, conexion.TipoRelacion)
                    {
                        TipoRelacion = conexion.TipoRelacion
                    });

                    conexionesagregads++;
                }
                else
                {
                    conexionesfallidas++;
                    Console.WriteLine($"⚠️ Conexión fallida: {conexion.Origen} -> {conexion.Destino}");
                } 
            }
            MessageBox.Show($"✅ Figuras cargadas: {figurasCargadas}", "Advertencia",MessageBoxButtons.OK);
            MessageBox.Show($"✅ Conexiones agregadas: {conexionesagregads}" ,"Advertencia", MessageBoxButtons.OK);
            MessageBox.Show($"⚠️ Conexiones fallidas: {conexionesfallidas}", "Advertencia", MessageBoxButtons.OK);
            panelDiagrama.Invalidate(); // Redibujar el panel para mostrar las figuras y conexiones
        }
    }//del partial class
}//del namespace
