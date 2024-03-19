using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTHENTY_SECAO.ClassesListas
{
    public class ListDesenho
    {
        public ListDesenho() { }
        public double  X { get; set; }
        public double Y { get; set; }
        public int Tipo { get; set; }
        public double Diametro { get; set; }
        public int Brush { get; set; }
        public int Pen { get; set; }
        public int Font { get; set; }
        public List<PointF> List { get; set; }


        public ListDesenho(List<PointF> list, double x, double y, int tipo, double diametro, int brush, int pen, int font)
        {
            this.X = x;
            this.Y = y;
            this.Diametro = diametro;
            this.Tipo = tipo;
            this.Brush = brush;
            this.Pen = pen;
            this.Font = font;
            this.List = list;

        }

    }
}
