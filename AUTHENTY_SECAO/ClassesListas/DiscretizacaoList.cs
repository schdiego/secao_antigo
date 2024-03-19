using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTHENTY_SECAO.ClassesListas
{
    public class DiscretizacaoList
    {
        public DiscretizacaoList() { }
        public double  dX { get; set; }
        public double dY { get; set; }
        public double Area { get; set; }
        public DiscretizacaoList(double dx, double dy, double area)
        {
            this.dX = dx;
            this.dY = dy;
            this.Area = area;
        }

    }
}
