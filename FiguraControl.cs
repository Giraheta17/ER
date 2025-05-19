using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DiagramaER
{
    public class FiguraControl : Control
    {
        public string TipoFigura { get; set; } = "Entidad Fuerte";
        public string Texto { get; set; } = "Entidad";
        public FiguraControl FiguraDestino { get; set; } // Para llaves foráneas
        public string TipoDato { get; set; } = "VARCHAR(100)"; // Para atributos

        private bool arrastrando = false;
        private Point offset;

        public FiguraControl()
        {
            this.Size = new Size(120, 70);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.DoubleBuffered = true;

            this.MouseDown += FiguraControl_MouseDown;
            this.MouseMove += FiguraControl_MouseMove;
            this.MouseUp += FiguraControl_MouseUp;
        }

        private EditorForm EncontrarEditorForm()
        {
            Control current = this;
            while (current != null)
            {
                if (current is EditorForm editor)
                    return editor;
                current = current.Parent;
            }
            return null;
        }

        private void FiguraControl_MouseDown(object sender, MouseEventArgs e)
        {
            EditorForm editorForm = EncontrarEditorForm();

            if (editorForm != null && editorForm.ModoEditarNombre && e.Button == MouseButtons.Left)
            {
                editorForm.EditarNombreFigura(this);
                return;
            }

            arrastrando = true;
            offset = e.Location;
            this.BringToFront();
        }

        private void FiguraControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrando)
            {
                this.Left += e.X - offset.X;
                this.Top += e.Y - offset.Y;

                // Redibujar conexiones mientras se mueve
                EditorForm editor = EncontrarEditorForm();
                if (editor != null)
                {
                    editor.PanelDiagrama.Invalidate();
                }
            }
        }

        private void FiguraControl_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrando = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Pen pen = new Pen(Color.Black, 2);
            Rectangle rect = new Rectangle(5, 5, this.Width - 10, this.Height - 10);

            switch (TipoFigura)
            {
                case "Entidad Fuerte":
                    e.Graphics.DrawRectangle(pen, rect);
                    break;

                case "Entidad Débil":
                    e.Graphics.DrawRectangle(pen, rect);
                    rect.Inflate(-4, -4);
                    e.Graphics.DrawRectangle(pen, rect);
                    break;

                case "Relación Normal":
                    DrawDiamond(e.Graphics, pen, rect);
                    break;

                case "Relación de Identificación":
                    DrawDiamond(e.Graphics, pen, rect);
                    Rectangle innerDiamond = new Rectangle(rect.X + 6, rect.Y + 6, rect.Width - 12, rect.Height - 12);
                    DrawDiamond(e.Graphics, pen, innerDiamond);
                    break;

                case "Atributo Normal":
                case "Atributo Multivaluado":
                case "Atributo Derivado":
                    DrawAtributo(e.Graphics, pen, rect);
                    break;
            }

            // Dibujar el texto
            Font font = new Font("Montserrat", 8, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Black);
            Rectangle textRect = this.ClientRectangle;

            if (Tag != null && Tag.ToString() == "Llave Primaria")
            {
                font = new Font(font, FontStyle.Bold | FontStyle.Underline);
            }
            else if (Tag != null && Tag.ToString() == "Llave Foránea")
            {
                brush = new SolidBrush(Color.Blue);
            }

            using (font)
            using (brush)
            using (StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(this.Texto, font, brush, textRect, sf);
            }

            // Dibujar icono de llave
            if (Tag != null && (Tag.ToString() == "Llave Primaria" || Tag.ToString() == "Llave Foránea"))
            {
                DrawKeyIcon(e.Graphics);
            }


            //para cuando se cargue el diagrama ya con cosas adentro jeje
            base.OnPaint(e);
            var g = e.Graphics;
            using (Pen lapicero = new Pen(Color.Black, 2))
            {
                if (TipoFigura == "Entidad")
                {
                    g.DrawRectangle(lapicero, 0, 0, Width - 1, Height - 1);
                }
                else if (TipoFigura == "Atributo")
                {
                    if (this.TipoFigura == "Atributo")
                    {
                        g.DrawEllipse(lapicero, 0, 0, Width - 1, Height - 1);
                        this.Size = new Size(100, 60);
                    }
                }
            }

            /*using (var al = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
            {
                g.DrawString(Texto, Font, Brushes.Black, ClientRectangle, al);
            }*/
        }
          

        private void DrawDiamond(Graphics g, Pen pen, Rectangle rect)
        {
            Point[] diamondPoints = {
                new Point(rect.Left + rect.Width / 2, rect.Top),
                new Point(rect.Right, rect.Top + rect.Height / 2),
                new Point(rect.Left + rect.Width / 2, rect.Bottom),
                new Point(rect.Left, rect.Top + rect.Height / 2)
            };
            g.DrawPolygon(pen, diamondPoints);
        }

        private void DrawAtributo(Graphics g, Pen pen, Rectangle rect)
        {
            if (TipoFigura == "Atributo Multivaluado")
            {
                g.DrawEllipse(pen, rect);
                rect.Inflate(-4, -4);
                g.DrawEllipse(pen, rect);
            }
            else if (TipoFigura == "Atributo Derivado")
            {
                Pen dashedPen = new Pen(Color.Black, 2)
                {
                    DashStyle = DashStyle.Dash
                };
                g.DrawEllipse(dashedPen, rect);
            }
            else
            {
                g.DrawEllipse(pen, rect);
            }
        }

        private void DrawKeyIcon(Graphics g)
        {
            Rectangle keyRect = new Rectangle(this.Width - 25, 5, 20, 20);
            using (Font font = new Font("Montserrat", 10, FontStyle.Bold))
            using (Brush brush = new SolidBrush(Color.Goldenrod))
            {
                g.DrawString("🔑", font, brush, keyRect);
            }
        }

        public FiguraControl Clonar()
        {
            FiguraControl clon = new FiguraControl();
            clon.TipoFigura = this.TipoFigura;
            clon.Texto = this.Texto;
            clon.Size = this.Size;
            clon.Location = this.Location;
            clon.Tag = this.Tag;
            clon.FiguraDestino = this.FiguraDestino;

            clon.MouseDown += FiguraControl_MouseDown;
            clon.MouseMove += FiguraControl_MouseMove;
            clon.MouseUp += FiguraControl_MouseUp;

            return clon;
        }
    }
}
