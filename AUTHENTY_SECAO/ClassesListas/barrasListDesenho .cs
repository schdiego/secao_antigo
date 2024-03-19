using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTHENTY_SECAO.ClassesListas
{
    public class barrasListDesenho
    {
        public barrasListDesenho() { }
        public double  dX { get; set; }
        public double dY { get; set; }
        public string Tipo { get; set; }
        public double Diametro { get; set; }


        public barrasListDesenho(double dx, double dy, double diametro, string tipo)
        {
            this.dX = dx;
            this.dY = dy;
            this.Diametro = diametro;
            this.Tipo = tipo;

        }

    }
}
