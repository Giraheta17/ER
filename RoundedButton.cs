﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DiagramaER
{
    namespace DiagramaER
    {
        public class RoundedButton : Button
        {
            public int CornerRadius { get; set; } = 20;

            protected override void OnPaint(PaintEventArgs pevent)
            {
                base.OnPaint(pevent);

                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
                GraphicsPath path = new GraphicsPath();

                int radius = CornerRadius;
                path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
                path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                this.Region = new Region(path);

                // 🔹 Pintar solo el fondo del botón (sin borde)
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    pevent.Graphics.FillPath(brush, path);
                }

                // 🔸 Pintar el texto (centrado)
                TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, rect, this.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }
    }
}
