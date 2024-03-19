using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTHENTY_SECAO.Classes
{
    public class Materiais
    {
        
        public static double CalculoTensaoConcreto(double deformacao, double epsilonCu, double epsilonC2, double fck, double fcd)//valores em kN/cm²
        {
            //ver nbr 6118
            double Tensao = 0;
            double n;
            
            //ajustando o n
            if (fck * 10 > 50)
            {
                n = 1.4 + 23.4 * Math.Pow(((90 - (fck * 10)) / 100), 4);
            }
            else
            {
                n = 2;
            }

            //deformação negativa = compressão
            if (deformacao <= 0 && epsilonC2 <= deformacao)
            {
                Tensao = -0.85 * fcd * (1 - Math.Pow(1 - deformacao / epsilonC2, n));
            }
            else if (deformacao <= epsilonC2 && epsilonCu <= deformacao)
            {
                Tensao = -0.85 * fcd;
            }
            else
            {
                Tensao = 0;
            }

            return Tensao;
        }
        public static double CalculoTensaoAco(double deformacao, double epsilonFy, double fyd)//valores em kN/cm²
        {
            double Tensao = 0;

            if (Math.Abs(deformacao) >= epsilonFy)
            {
                if (deformacao > 0)
                {
                    Tensao = fyd;
                }
                else
                {
                    Tensao = -fyd;
                }
                
            }
            else
            {
                Tensao = (fyd / epsilonFy) * deformacao;
            }

            return Tensao;
        }

    }
}
