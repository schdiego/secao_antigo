using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTHENTY_SECAO.ClassesListas
{
    public class TensaoList
    {
        public TensaoList() { }
        public double dY { get; set; }
        public double dX { get; set; }
        public double Tensao { get; set; }
        public TensaoList(double tensao, double dx, double dy)
        {
            this.Tensao = tensao;
            this.dX = dx;
            this.dY = dy;
        }

    }
}
