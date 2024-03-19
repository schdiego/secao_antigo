using AUTHENTY_SECAO.ClassesListas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTHENTY_SECAO
{
    public class Operacoes
    {
        public static int a { get; set; }
        public static double c { get; set; }
        public static double p { get; set; }
        public static double AreaPoligono(List<List<double>> Coordenadas)
        {
            List<List<double>> Coords = Coordenadas;
            double area = new double();
            double k1 = new double();
            double k2 = new double();

            for (int i = 0; i < Coords.Count; i++)
            {
                if (i - Coords.Count == -1)
                {
                    k1 += Coords[i][0] * Coords[0][1];
                }
                else
                {
                    k1 += Coords[i][0] * Coords[i + 1][1];
                }
            }

            for (int i = 0; i < Coords.Count; i++)
            {
                if (i - Coords.Count == -1)
                {
                    k2 += Coords[i][1] * Coords[0][0];
                }
                else
                {
                    k2 += Coords[i][1] * Coords[i + 1][0];
                }
            }

            area = (k1 - k2) / 2;

            return area;
        }

        public static double MaxMat(double[,] MatA)
        {
            double[,] A = MatA;

            int a = A.GetLength(0);
            int b = A.GetLength(1);

            double m = Math.Abs(A[0, 0]);

            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                {
                    if (m < Math.Abs(A[i, j]))
                    {
                        m = Math.Abs(A[i, j]);
                    }
                }

            return m;
        }

        public static double[,] SubMat(double[,] MatA, double[,] MatB)
        {
            double[,] A = MatA;
            double[,] B = MatB;

            int a = A.GetLength(0);
            int b = A.GetLength(1);

            double[,] C = new double[a, b];

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    C[i, j] = A[i, j] - B[i, j];
                }
            }
            return C;
        }

        public static double[,] SumMat(double[,] MatA, double[,] MatB)
        {
            double[,] A = MatA;
            double[,] B = MatB;

            int a = A.GetLength(0);
            int b = A.GetLength(1);

            double[,] C = new double[a, b];

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }
            return C;
        }

        public static double[,] MultMat(double[,] MatA, double[,] MatB)
        {
            double[,] A = MatA;
            double[,] B = MatB;

            int a = A.GetLength(0);
            int b = A.GetLength(1);
            int c = B.GetLength(0);
            int d = B.GetLength(1);

            double[,] C = new double[a, d];

            if (b != c)
            {
                throw new ArgumentOutOfRangeException(nameof(b), "Não é possível multiplicar essas matrizes");
            }


            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < d; j++)
                {
                    C[i, j] = 0;
                    for (int k = 0; k < b; k++)
                    {
                        C[i, j] += A[i, k] * B[k, j];
                    }
                }
            }

            return C;

        }


        public static List<List<double>> Offset(List<List<double>> geoentrada, double offset)
        {
            List<List<double>> GeoEntrada = geoentrada;
            double Offset = offset;
            //Lista com coeficientes angulares e lineares das novas retas (já com offset)
            List<List<double>> EqRetOffset = new List<List<double>>();
            //Lista da nova geometria
            List<List<double>> GeoOffset = new List<List<double>>();
            List<List<double>> GeoOffsetAjustado = new List<List<double>>();

            //Definição da lista EqRetOffset
            for (int i = 0; i < GeoEntrada.Count; i++)
            {
                if (GeoEntrada.Count - i != 1)
                {
                    //Definição do ponto P, pertencente a nova reta (já com offset)
                    List<double> P = new List<double>();
                    double deltay = GeoEntrada[i+1][1] - GeoEntrada[i][1];
                    double deltax = GeoEntrada[i+1][0] - GeoEntrada[i][0];
                    //Quando deltax for igual a zero a equação da reta é definida apenas com um valor de x, porque a reta é paralela ao eixo y
                    if (deltax == 0)
                    {
                        if (deltay > 0)
                        {
                            EqRetOffset.Add(new List<double> { 0, 0, (GeoEntrada[i + 1][0] - Offset) });
                        }
                        else
                        {
                            EqRetOffset.Add(new List<double> { 0, 0, (GeoEntrada[i + 1][0] + Offset) });
                        }
                    }
                    //Quando deltax não for igual a zero, a reta pode ser definida como y = ax + b
                    else
                    {
                        //Coeficiente angular da reta
                        double a = deltay / deltax;
                        //Ângulo da reta, que varia de - pi/2 a + pi/2 (-90° a + 90°)
                        double teta = Math.Atan(a);
                        if (deltay > 0 && deltax > 0 || deltay < 0 && deltax > 0 || deltay == 0 && deltax > 0)
                        {
                            P.Add(((GeoEntrada[i + 1][0] + GeoEntrada[i][0]) / 2) - (Offset * Math.Sin(teta)));
                            P.Add(((GeoEntrada[i + 1][1] + GeoEntrada[i][1]) / 2) + (Offset * Math.Cos(teta)));
                        }
                        else if (deltay > 0 && deltax < 0 || deltay < 0 && deltax < 0 || deltay == 0 && deltax < 0)
                        {
                            P.Add(((GeoEntrada[i + 1][0] + GeoEntrada[i][0]) / 2) + (Offset * Math.Sin(teta)));
                            P.Add(((GeoEntrada[i + 1][1] + GeoEntrada[i][1]) / 2) - (Offset * Math.Cos(teta)));
                        }
                        double b = P[1] - a * P[0];
                        EqRetOffset.Add(new List<double> { a, b });
                    }
                }
                else
                {
                    //Definição do ponto P, pertencente a nova reta (já com offset)
                    List<double> P = new List<double>();
                    double deltay = GeoEntrada[0][1] - GeoEntrada[i][1];
                    double deltax = GeoEntrada[0][0] - GeoEntrada[i][0];
                    //Quando deltax for igual a zero a equação da reta é definida apenas com um valor de x, porque a reta é paralela ao eixo y
                    if (deltax == 0)
                    {
                        if (deltay > 0)
                        {
                            EqRetOffset.Add(new List<double> { 0, 0, (GeoEntrada[0][0] - Offset) });
                        }
                        else
                        {
                            EqRetOffset.Add(new List<double> { 0, 0, (GeoEntrada[0][0] + Offset) });
                        }
                    }
                    //Quando deltax não for igual a zero, a reta pode ser definida como y = ax + b
                    else
                    {
                        //Coeficiente angular da reta
                        double a = deltay / deltax;
                        //Ângulo da reta, que varia de - pi/2 a + pi/2 (-90° a + 90°)
                        double teta = Math.Atan(a);
                        if (deltay > 0 && deltax > 0 || deltay < 0 && deltax > 0 || deltay == 0 && deltax > 0)
                        {
                            P.Add(((GeoEntrada[0][0] + GeoEntrada[i][0]) / 2) - (Offset * Math.Sin(teta)));
                            P.Add(((GeoEntrada[0][1] + GeoEntrada[i][1]) / 2) + (Offset * Math.Cos(teta)));
                        }
                        else if (deltay > 0 && deltax < 0 || deltay < 0 && deltax < 0 || deltay == 0 && deltax < 0)
                        {
                            P.Add(((GeoEntrada[0][0] + GeoEntrada[i][0]) / 2) + (Offset * Math.Sin(teta)));
                            P.Add(((GeoEntrada[0][1] + GeoEntrada[i][1]) / 2) - (Offset * Math.Cos(teta)));
                        }
                        double b = P[1] - a * P[0];
                        EqRetOffset.Add(new List<double> { a, b });
                    }
                }
            }
            //Definição das coordenadas do polígono com Offset
            for (int i = 0; i < EqRetOffset.Count; i++)
            {
                if (EqRetOffset.Count - i != 1)
                {
                    if (EqRetOffset[i].Count == 3 && EqRetOffset[i + 1].Count == 2)
                    {
                        double x = EqRetOffset[i][2];
                        double y = EqRetOffset[i + 1][0] * x + EqRetOffset[i + 1][1];
                        GeoOffset.Add(new List<double> { x, y });
                    }
                    else if (EqRetOffset[i].Count == 2 && EqRetOffset[i + 1].Count == 3)
                    {
                        double x = EqRetOffset[i + 1][2];
                        double y = EqRetOffset[i][0] * x + EqRetOffset[i][1];
                        GeoOffset.Add(new List<double> { x, y });
                    }
                    else
                    {
                        double x = (EqRetOffset[i + 1][1] - EqRetOffset[i][1]) / (EqRetOffset[i][0] - EqRetOffset[i + 1][0]);
                        double y = EqRetOffset[i + 1][0] * x + EqRetOffset[i + 1][1];
                        GeoOffset.Add(new List<double> { x, y });
                    }
                }
                else
                {
                    if (EqRetOffset[i].Count == 3 && EqRetOffset[0].Count == 2)
                    {
                        double x = EqRetOffset[i][2];
                        double y = EqRetOffset[0][0] * x + EqRetOffset[0][1];
                        GeoOffset.Add(new List<double> { x, y });
                    }
                    else if (EqRetOffset[i].Count == 2 && EqRetOffset[0].Count == 3)
                    {
                        double x = EqRetOffset[0][2];
                        double y = EqRetOffset[i][0] * x + EqRetOffset[i][1];
                        GeoOffset.Add(new List<double> { x, y });
                    }
                    else
                    {
                        double x = (EqRetOffset[0][1] - EqRetOffset[i][1]) / (EqRetOffset[i][0] - EqRetOffset[0][0]);
                        double y = EqRetOffset[0][0] * x + EqRetOffset[0][1];
                        GeoOffset.Add(new List<double> { x, y });
                    }
                }
            }

            //Ajuste das coordenadas para que o primeiro ponto seja o primeiro ponto informado

            GeoOffsetAjustado.Add(GeoOffset[GeoOffset.Count - 1]);
            for (int i = 0; i < GeoOffset.Count-1; i++)
            {
                GeoOffsetAjustado.Add(GeoOffset[i]);
            }
            return GeoOffsetAjustado;
        }

        public static List<List<double>> Polilinha_circulo(double raio, int numero_retas)
        {
            double Raio = raio;
            int retas = numero_retas;
            List<List<double>> polilinha = new List<List<double>>();
            double teta = 2 * Math.PI / numero_retas;

            for (int i = 0; i < numero_retas; i++)
            {
                double x = Math.Cos(teta * i) * Raio;
                double y = Math.Sin(teta * i) * Raio;
                polilinha.Add(new List<double> { x, y });
            }

            return polilinha;
        }

        public static List<double[,]> EsforcosLocaisBarras (List<List<double[,]>> matrizesBarras, List<List<int>> conectividades, double[,] valores)
        {
            List<double[,]> esforcosLocBarras = new List<double[,]>();

            for (int i = 0; i < matrizesBarras.Count; i++)
            {
                double[,] esforcosGlobais = new double[6, 1];
                double[,] esforcosLocais = new double[6, 1];

                double[,] deslocamentosGlobais = new double[6, 1];
                deslocamentosGlobais[0, 0] = valores[conectividades[i][0] * 3, 0];
                deslocamentosGlobais[1, 0] = valores[conectividades[i][0] * 3+1, 0];
                deslocamentosGlobais[2, 0] = valores[conectividades[i][0] * 3+2, 0];
                deslocamentosGlobais[3, 0] = valores[conectividades[i][1] * 3, 0];
                deslocamentosGlobais[4, 0] = valores[conectividades[i][1] * 3+1, 0];
                deslocamentosGlobais[5, 0] = valores[conectividades[i][1] * 3+2, 0];

                esforcosGlobais = Operacoes.MultMat(matrizesBarras[i][0], deslocamentosGlobais);
                esforcosLocais = Operacoes.MultMat(matrizesBarras[i][1], esforcosGlobais);

                esforcosLocBarras.Add(esforcosLocais);
            }
            return esforcosLocBarras;
        }

        public static List<List<List<double>>> IsoValoresDeslocamento (int numeroEscala, List<List<int>> conectividades, List<List<double>> coordenadas, double[,] valores)
        {
            List<List<List<double>>> IsoValoresDeslocamento = new List<List<List<double>>>();
            List<double> deslocVerticais = new List<double>();
            List<double> numEscala = new List<double>();

            List<double> isoValores = new List<double>();

            // Lista de deslocamentos verticais

            for (int i = 0; i < coordenadas.Count; i++)
            {
                deslocVerticais.Add(valores[3 * i + 2, 0]);
            }

            // Definição da escala

            double max = deslocVerticais.Max();
            double min = deslocVerticais.Min();
            double diferenca = max - min;
            double delta = diferenca / (numeroEscala+1);

            for (int i = 0; i < numeroEscala; i++)
            {
                numEscala.Add(min + i * delta);
            }

            // Poligonais de isoValores
            for (int i = 0; i < numEscala.Count; i++)
            {
                IsoValoresDeslocamento.Add(new List<List<double>>());
                for (int j = 0; j < conectividades.Count; j++)
                {
                    if (deslocVerticais[conectividades[j][0]] <= numEscala[i] && deslocVerticais[conectividades[j][1]] >= numEscala[i] || deslocVerticais[conectividades[j][0]] >= numEscala[i] && deslocVerticais[conectividades[j][1]] <= numEscala[i])
                    {
                        double fator = (numEscala[i] - deslocVerticais[conectividades[j][0]]) / (deslocVerticais[conectividades[j][1]] - deslocVerticais[conectividades[j][0]]);
                        double x = (coordenadas[conectividades[j][1]][0] - coordenadas[conectividades[j][0]][0]) * fator + coordenadas[conectividades[j][0]][0];
                        double y = (coordenadas[conectividades[j][1]][1] - coordenadas[conectividades[j][0]][1]) * fator + coordenadas[conectividades[j][0]][1];
                        IsoValoresDeslocamento[i].Add(new List<double> { x, y });
                    }
                }
            }
            
            return IsoValoresDeslocamento;
        }

        public static List<List<double>> retangulos(List<List<double>> coordenadas)
        {
            List<List<double>> retangulos = new List<List<double>>();

            for (int i = 0; i < coordenadas.Count; i++)
            {
                List<double> dadosRetangulo = new List<double>();
                dadosRetangulo.Add(coordenadas[i][0]);
                dadosRetangulo.Add(coordenadas[i][1]);
                retangulos.Add(dadosRetangulo);
            }
            return retangulos;
        }
        public static List<DiscretizacaoList> CentroDeGravidade(List<DiscretizacaoList> GeometriaPoligono)
        {

            //convertendoLista
            List<List<double>> GeometriaPoligonoList = new List<List<double>>();
            foreach (var item in GeometriaPoligono)
            {
                GeometriaPoligonoList.Add(new List<double> { item.dX, item.dY });
            }
            double AreaPoligono = Operacoes.AreaPoligono(GeometriaPoligonoList);


            List<double> CxParcial = new List<double>();
            List<double> CyParcial = new List<double>();
            List<DiscretizacaoList> CG = new List<DiscretizacaoList>();

            for (int i = 0; i < GeometriaPoligono.Count; i++)
            {
                int pulo = 1;
                if(i == GeometriaPoligono.Count - 1)
                {
                    pulo = -i;
                }

                CxParcial.Add((GeometriaPoligono[i].dX + GeometriaPoligono[i + pulo].dX )* (GeometriaPoligono[i].dX * GeometriaPoligono[i + pulo].dY - GeometriaPoligono[i + pulo].dX * GeometriaPoligono[i].dY));
                CyParcial.Add((GeometriaPoligono[i].dY + GeometriaPoligono[i + pulo].dY) * (GeometriaPoligono[i].dX * GeometriaPoligono[i + pulo].dY - GeometriaPoligono[i + pulo].dX * GeometriaPoligono[i].dY));

            }

            double CGx = CxParcial.Sum() / (6 * AreaPoligono);
            double CGy = CyParcial.Sum() / (6 * AreaPoligono);

            CG.Add(new DiscretizacaoList(CGx, CGy, 0));

            return CG;
        }



        /*
        public static List<int> EscalaDeslocamentos(int numeroEscala, List<List<double>> coordenadas, double[,] valores)
        {
            List<int> coresDeslocamentos = new List<int>();
            List<double> deslocVerticais = new List<double>();
            Variaveis.numEscala = new List<double>();

            // Lista de deslocamentos verticais

            for (int i = 0; i < coordenadas.Count; i++)
            {
                deslocVerticais.Add(valores[3 * i + 2, 0]);
            }

            // Definição da escala

            double max = deslocVerticais.Max();
            double min = deslocVerticais.Min();
            double diferenca = max - min;
            double delta = diferenca / (numeroEscala + 1);

            for (int i = 0; i < numeroEscala; i++)
            {
                Variaveis.numEscala.Add(min + i * delta);
            }

            // Lista de cores por nó

            for (int i = 0; i < deslocVerticais.Count; i++)
            {
                for (int j = 0; j < Variaveis.numEscala.Count; j++)
                {
                    if (j == 0 && deslocVerticais[i] < Variaveis.numEscala[j])
                    {
                        coresDeslocamentos.Add(j);
                    }

                    else if ((Variaveis.numEscala.Count - j) != 1)
                    {
                        if (deslocVerticais[i] >= Variaveis.numEscala[j] && deslocVerticais[i] < Variaveis.numEscala[j + 1])
                        {
                            coresDeslocamentos.Add(j);
                        }
                    }
                    else
                    {
                        if (deslocVerticais[i] >= Variaveis.numEscala[j])
                        {
                            coresDeslocamentos.Add(j);
                        }
                    }
                }
            }
            return coresDeslocamentos;
        }*/
    }
}
