using AUTHENTY_SECAO.ClassesListas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTHENTY_SECAO
{
    public class Discretizacao
    {
        public static List<DiscretizacaoList> CoordenadasPontos(List<DiscretizacaoList> GeometriaPoligono, double tamanhoElemento)
        {
            List<List<int>> conectcord = new List<List<int>>();
            List<double> CoordGeoX = new List<double>();
            List<double> CoordGeoY = new List<double>();
            List<List<double>> grid = new List<List<double>>();
            List<DiscretizacaoList> CoordenadasPontos = new List<DiscretizacaoList>();
            List<List<double>> coordGeometria = new List<List<double>>();
            List<List<double>> GeometriaPoligonoList = new List<List<double>>();
            List<List<double>> coordDef = new List<List<double>>();


            foreach (var item in GeometriaPoligono)
            {
                GeometriaPoligonoList.Add(new List<double> { item.dX, item.dY });
            }


            double offset = tamanhoElemento / 2;
            coordGeometria = Operacoes.Offset(GeometriaPoligonoList, offset);

            for (int i = 0; i < coordGeometria.Count; i++)
            {
                if (i - coordGeometria.Count == -1)
                {
                    conectcord.Add(new List<int> { i, 0 });
                }
                else
                {
                    conectcord.Add(new List<int> { i, i + 1 });
                }
            }

            for (int i = 0; i < coordGeometria.Count; i++)
            {
                CoordGeoX.Add(coordGeometria[i][0]);
                CoordGeoY.Add(coordGeometria[i][1]);
            }

            double xMin = CoordGeoX.Min();
            double xMax = CoordGeoX.Max();
            double NumEleX;
            double TamEleX = 0;
            double NumEleY;
            double TamEleY = 0;


            NumEleX = (int)Math.Ceiling((xMax - xMin) / tamanhoElemento);
            TamEleX = (xMax - xMin) / NumEleX;

            double yMin = CoordGeoY.Min();
            double yMax = CoordGeoY.Max();

            NumEleY = (int)Math.Ceiling((yMax - yMin) / tamanhoElemento);
            TamEleY = (yMax - yMin) / NumEleY;

            //isso tem que arrumar se fizer uma classe genérica
            Variaveis.TamElementoFinalX = TamEleX;
            Variaveis.TamElementoFinalY = TamEleY;


            for (int i = 0; i <= NumEleY; i++)
            {
                for (int j = 0; j <= NumEleX; j++)
                {
                    grid.Add(new List<double> { xMin + TamEleX * j, yMax - TamEleY * i });
                }
            }

            for (int i = 0; i < grid.Count; i++)
            {
                int teste = 0;
                int teste2 = 0;
                int teste3 = 0;
                for (int j = 0; j < conectcord.Count; j++)
                {
                    if ((grid[i][1] <= CoordGeoY[conectcord[j][0]] && grid[i][1] >= CoordGeoY[conectcord[j][1]]) || (grid[i][1] >= CoordGeoY[conectcord[j][0]] && grid[i][1] <= CoordGeoY[conectcord[j][1]]))
                    {
                        double a = (CoordGeoY[conectcord[j][1]] - grid[i][1]);
                        double b = (CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]);
                        double c = (CoordGeoX[conectcord[j][1]] - CoordGeoX[conectcord[j][0]]);
                        double d = a * c / b;
                        double e = CoordGeoX[conectcord[j][1]] - d;

                        if (a == 0)
                        {
                            if (c != 0)
                            {
                                if (conectcord.Count - j != 1)
                                {
                                    if (((CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]) * (CoordGeoY[conectcord[j + 1][1]] - CoordGeoY[conectcord[j + 1][0]])) <= 0 && e - grid[i][0] >= 0)
                                    {
                                        teste += 1;
                                    }
                                }
                                else
                                {
                                    if (((CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]) * (CoordGeoY[conectcord[0][1]] - CoordGeoY[conectcord[0][0]])) <= 0 && e - grid[i][0] >= 0)
                                    {
                                        teste += 1;
                                    }
                                }
                            }
                            else
                            {
                                if ((CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]) > 0)
                                {
                                    if (conectcord.Count - j != 1)
                                    {
                                        if (((CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]) * (CoordGeoY[conectcord[j + 1][1]] - CoordGeoY[conectcord[j + 1][0]])) <= 0 && e - grid[i][0] >= 0)
                                        {
                                            teste += 1;
                                        }
                                    }
                                    else
                                    {
                                        if (((CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]) * (CoordGeoY[conectcord[0][1]] - CoordGeoY[conectcord[0][0]])) <= 0 && e - grid[i][0] >= 0)
                                        {
                                            teste += 1;
                                        }
                                    }
                                }
                                else if ((CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]) < 0 && e - grid[i][0] > 0)
                                {
                                    teste2 += 1;
                                }
                            }
                        }
                        else
                        {
                            teste3 += 1;
                            if ((CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]) > 0 && e - grid[i][0] >= 0)
                            {
                                teste += 1;
                            }
                            else if ((CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]) < 0 && e - grid[i][0] > 0)
                            {
                                if (j != 0)
                                {
                                    if ((CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]) == a)
                                    {
                                        if ((CoordGeoY[conectcord[j - 1][1]] - CoordGeoY[conectcord[j - 1][0]]) == 0 && grid[i][0] < CoordGeoX[conectcord[j - 1][1]] && grid[i][0] > CoordGeoX[conectcord[j - 1][0]])
                                        {

                                        }
                                        else
                                        {
                                            teste2 += 1;
                                        }
                                    }
                                    else
                                    {
                                        teste2 += 1;
                                    }
                                }
                                else
                                {
                                    if ((CoordGeoY[conectcord[j][1]] - CoordGeoY[conectcord[j][0]]) == a)
                                    {
                                        if ((CoordGeoY[conectcord[conectcord.Count - 1][1]] - CoordGeoY[conectcord[conectcord.Count - 1][0]]) == 0 && grid[i][0] < CoordGeoX[conectcord[conectcord.Count - 1][1]] && grid[i][0] > CoordGeoX[conectcord[conectcord.Count - 1][0]])
                                        {

                                        }
                                        else
                                        {
                                            teste2 += 1;
                                        }
                                    }
                                    else
                                    {
                                        teste2 += 1;
                                    }
                                }
                            }
                        }
                    }
                }
                if (teste % 2 != 0)
                {
                    if (teste3 != 0)
                    {
                        if (teste2 % 2 == 0)
                        {
                            if (coordDef.Contains(grid[i]))
                            {

                            }
                            else
                            {
                                coordDef.Add(grid[i]);
                            }
                        }
                    }
                    else
                    {
                        if (coordDef.Contains(grid[i]))
                        {

                        }
                        else
                        {
                            coordDef.Add(grid[i]);
                        }
                    }
                }
                else
                {
                    if (teste3 != 0)
                    {
                        if (teste2 % 2 != 0)
                        {
                            if (coordDef.Contains(grid[i]))
                            {

                            }
                            else
                            {
                                coordDef.Add(grid[i]);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < coordDef.Count; i++)
            {
                CoordenadasPontos.Add(new DiscretizacaoList(coordDef[i][0], coordDef[i][1],0));
            }


            return CoordenadasPontos;
        }
        public static void CriarListaConcreto()
        {
            foreach (DiscretizacaoList item in Variaveis.CoordenadasPontos)
            {
                Variaveis.ListConcreto.Add(new DiscretizacaoList(item.dX, item.dY, Variaveis.TamElementoFinalX * Variaveis.TamElementoFinalY));
            }
        }

    }
}
