using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    public enum eMarca
    {
        Nada,
        Cruz,
        Circulo,
        Imagen
    }

    public partial class EtiquetaAviso : Control
    {

        private int width;
        private int height;
        private int x;
        private int y;

        public EtiquetaAviso()
        {
            InitializeComponent();
        }

        private eMarca marca = eMarca.Nada;
        [Category("Appearance")]
        [Description("Indica el tipo de marca que aparece junto al texto")]
        public eMarca Marca
        {
            set
            {
                marca = value;
                this.Refresh();
            }
            get
            {
                return marca;
            }
        }

        private bool degradado = false;
        [Category("Appearance")]
        [Description("Pone un fondo degradado")]
        public bool Degradado
        {
            set
            {
                degradado = value;
                this.Refresh();
            }
            get
            {
                return degradado;
            }
        }

        private Color colorInicio;
        [Category("Appearance")]
        [Description("Color de inicio para el fondo degradado")]
        public Color ColorInicio
        {
            set
            {
                colorInicio = value;
                this.Refresh();
            }
            get
            {
                return colorInicio;
            }
        }

        private Color colorFinal;
        [Category("Appearance")]
        [Description("Color final para el fondo degradado")]
        public Color ColorFinal
        {
            set
            {
                colorFinal = value;
                this.Refresh();
            }
            get
            {
                return colorFinal;
            }
        }

        private Image imagenMarca;
        [Category("Appearance")]
        [Description("Imagen para el componente cuando Marca es Imagen")]
        public Image ImagenMarca
        {
            set
            {
                imagenMarca = value;
                this.Refresh();
            }
            get
            {
                return imagenMarca;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;
            int grosor = 0;
            int offsetX = 0;
            int offsetY = 0;
            int h = this.Font.Height;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (degradado)
            {
                LinearGradientBrush gradiente = new LinearGradientBrush(
                    new PointF(0, 0),
                    new PointF(this.Width, this.Height),
                    colorInicio,
                    colorFinal);

                g.FillRectangle(gradiente, new RectangleF(0, 0, this.Width, this.Height));
            }

            switch (Marca)
            {
                case eMarca.Circulo:
                    grosor = 5;
                    g.DrawEllipse(new Pen(Color.Green, grosor), grosor, grosor, h, h);
                    offsetX = h + grosor;
                    offsetY = grosor;
                    x = grosor;
                    y = grosor;
                    width = h;
                    height = h;
                    break;

                case eMarca.Cruz:
                    grosor = 5;
                    Pen lapiz = new Pen(Color.Red, grosor);
                    g.DrawLine(lapiz, grosor, grosor, h, h);
                    g.DrawLine(lapiz, h, grosor, grosor, h);
                    offsetX = h + grosor;
                    offsetY = grosor / 2;
                    x = grosor;
                    y = grosor;
                    width = h;
                    height = h;
                    lapiz.Dispose();
                    break;

                case eMarca.Imagen:
                    if (imagenMarca != null)
                    {
                        grosor = 10;
                        int altoImagen = h;
                        int anchoImagen = (imagenMarca.Width * h) / imagenMarca.Height;
                        g.DrawImage(imagenMarca, grosor, grosor, anchoImagen, altoImagen);
                        offsetX = anchoImagen + grosor;
                        offsetY = grosor;

                        x = grosor;
                        y = grosor;
                        width = anchoImagen;
                        height = altoImagen;
                    }
                    break;
            }

            SolidBrush b = new SolidBrush(this.ForeColor);
            g.DrawString(this.Text, this.Font, b, offsetX+grosor, offsetY);
            Size tam = g.MeasureString(this.Text, this.Font).ToSize();
            this.Size = new Size(tam.Width + offsetX + grosor, tam.Height + offsetY * 2);
            b.Dispose();
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            this.Refresh();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.X >= this.x && e.X <= this.x + width && e.Y >= this.y && e.Y <= height)
            {
                ClickEnMarca?.Invoke(this, EventArgs.Empty);
            }
        }

        [Category("Click en marca")]
        [Description("Se lanza cuando se hace click en marca")]
        public event System.EventHandler ClickEnMarca;

    }
}
