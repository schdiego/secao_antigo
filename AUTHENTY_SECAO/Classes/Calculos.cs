
using AUTHENTY_SECAO.Classes;
using AUTHENTY_SECAO.ClassesListas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTHENTY_SECAO
{
    public class Calculos
    {
        static double largElementoDx;
        static double largElementoDy;
                
        public static void ListaDiscretizacao()
        {
            //adicionar barras na lista
            Variaveis.ListBarrasPassivas.Clear();
            Variaveis.ListBarrasPassivas.Add(new DiscretizacaoList(4, 4,   0.8));
            Variaveis.ListBarrasPassivas.Add(new DiscretizacaoList(11, 4,  0.8));
            Variaveis.ListBarrasPassivas.Add(new DiscretizacaoList(36, 4,  0.8));
            Variaveis.ListBarrasPassivas.Add(new DiscretizacaoList(36, 11, 0.8));
            Variaveis.ListBarrasPassivas.Add(new DiscretizacaoList(11, 11, 0.8));
            Variaveis.ListBarrasPassivas.Add(new DiscretizacaoList(11, 36, 0.8));
            Variaveis.ListBarrasPassivas.Add(new DiscretizacaoList(4, 36,  0.8));
            Variaveis.ListBarrasPassivas.Add(new DiscretizacaoList(4, 11,  0.8));
        }
        private static double CalculodoD(List<DiscretizacaoList> ListaGeometria, List<DiscretizacaoList> ListaBarrasPassivas, List<DiscretizacaoList> ListaBarrasAtivas, List<DiscretizacaoList> ListaBarrasGFRP)
        {
            double d = 0;
            double CoordMinAco;
            double CoordMaxConcreto;
            List<double> CoordenadaBarra = new List<double>();
            List<double> ListaConcretoCoordenadas = new List<double>();
            
            foreach (var item in ListaGeometria)
            {
                ListaConcretoCoordenadas.Add(item.dY);
            }

            foreach (var item in ListaBarrasPassivas)
            {
                CoordenadaBarra.Add(item.dY);
            }
            foreach (var item in ListaBarrasAtivas)
            {
                CoordenadaBarra.Add(item.dY);
            }
            foreach (var item in ListaBarrasGFRP)
            {
                CoordenadaBarra.Add(item.dY);
            }


            CoordMinAco = CoordenadaBarra.Min();
            CoordMaxConcreto = ListaConcretoCoordenadas.Max();
            d = CoordMaxConcreto - CoordMinAco;

            return d;
        }

        public static List<DiscretizacaoList> MudaCoordenadasAngulo(List<DiscretizacaoList> Lista, double angulo)
        {
            List<DiscretizacaoList> ListaCorrigida = new List<DiscretizacaoList>();
            angulo = angulo * (Math.PI / 180);
            foreach (var item in Lista)
            {
                ListaCorrigida.Add(new DiscretizacaoList(item.dX * Math.Cos(angulo) + item.dY * Math.Sin(angulo), -item.dX * Math.Sin(angulo) + item.dY * Math.Cos(angulo), item.Area));
            }
            return ListaCorrigida;
        }

        public static void CalcularSecao(double Nd, List<DiscretizacaoList> ListaGeometria, List<DiscretizacaoList> ListaConcreto, List<DiscretizacaoList> ListaBarrasPassivas, List<DiscretizacaoList> ListaBarrasAtivas, List<DiscretizacaoList> ListaBarrasGFRP)
        {
            int QuantidadeDeCalculos = Convert.ToInt32(360 / Variaveis.angulo);
            double anguloPorCalculo = 360 / QuantidadeDeCalculos;
            //double anguloPorCalculo = Variaveis.angulo;

            //corrige listas para o cg
            Variaveis.ListaGeometriaCG.Clear();
            Variaveis.ListaConcretoCG.Clear();
            Variaveis.ListaBarrasPassivasCG.Clear();
            Variaveis.ListaBarrasAtivasCG.Clear();
            Variaveis.ListaBarrasGFRP_CG.Clear();


            Variaveis.CG = Operacoes.CentroDeGravidade(Variaveis.GeometriaList);

            //muda a planilha para o CG
            foreach (var item in ListaGeometria)
            {
                Variaveis.ListaGeometriaCG.Add(new DiscretizacaoList(item.dX - Variaveis.CG[0].dX, item.dY - Variaveis.CG[0].dY, item.Area));
            }
            foreach (var item in ListaConcreto)
            {
                Variaveis.ListaConcretoCG.Add(new DiscretizacaoList(item.dX - Variaveis.CG[0].dX, item.dY - Variaveis.CG[0].dY, item.Area));
            }
            foreach (var item in ListaBarrasPassivas)
            {
                Variaveis.ListaBarrasPassivasCG.Add(new DiscretizacaoList(item.dX - Variaveis.CG[0].dX, item.dY - Variaveis.CG[0].dY, item.Area));
            }
            foreach (var item in ListaBarrasAtivas)
            {
                Variaveis.ListaBarrasAtivasCG.Add(new DiscretizacaoList(item.dX - Variaveis.CG[0].dX, item.dY - Variaveis.CG[0].dY, item.Area));
            }
            foreach (var item in ListaBarrasGFRP)
            {
                Variaveis.ListaBarrasGFRP_CG.Add(new DiscretizacaoList(item.dX - Variaveis.CG[0].dX, item.dY - Variaveis.CG[0].dY, item.Area));
            }
            //listas finais

            List<DiscretizacaoList> ListaConcretoAngulo = new List<DiscretizacaoList>();
            List<DiscretizacaoList> ListaGeometriaAngulo = new List<DiscretizacaoList>();
            List<DiscretizacaoList> ListaPassivaAngulo = new List<DiscretizacaoList>();
            List<DiscretizacaoList> ListaAtivaAngulo = new List<DiscretizacaoList>();
            List<DiscretizacaoList> ListaGFRPAngulo = new List<DiscretizacaoList>();
            Variaveis.CoordenadasGrafico.Clear();

            //verificar se suporta o NSd

            Variaveis.NcRd = CalculoDoNRdCompressao();
            Variaveis.NtRd = CalculoDoNRdTracao();
            if (Variaveis.NSd < 0)
            {
                if (CalculoDoNRdCompressao() > Variaveis.NSd)
                {
                    MessageBox.Show("Seção não suporta o NcSd", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (CalculoDoNRdTracao() < Variaveis.NSd)
                {
                    MessageBox.Show("Seção não suporta o NtSd", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }




            //for (int i = 1; i < 2; i++)
            for (int i = 0; i <= QuantidadeDeCalculos; i++)
            {
                //double anguloRad = Variaveis.angulo * (Math.PI / 180);
                double anguloRad = anguloPorCalculo * i * (Math.PI / 180);
                //converter as listas para o angulo

                ListaConcretoAngulo.Clear();
                ListaConcretoAngulo = MudaCoordenadasAngulo(Variaveis.ListaConcretoCG, i * anguloPorCalculo);

                ListaGeometriaAngulo.Clear();
                ListaGeometriaAngulo = MudaCoordenadasAngulo(Variaveis.ListaGeometriaCG, i * anguloPorCalculo);

                ListaPassivaAngulo.Clear();
                ListaPassivaAngulo = MudaCoordenadasAngulo(Variaveis.ListaBarrasPassivasCG, i * anguloPorCalculo);

                ListaAtivaAngulo.Clear();
                ListaAtivaAngulo = MudaCoordenadasAngulo(Variaveis.ListaBarrasAtivasCG, i * anguloPorCalculo);

                ListaGFRPAngulo.Clear();
                ListaGFRPAngulo = MudaCoordenadasAngulo(Variaveis.ListaBarrasGFRP_CG, i * anguloPorCalculo);


                //calcular 
                double d = CalculodoD(ListaGeometriaAngulo, ListaPassivaAngulo, ListaAtivaAngulo, ListaGFRPAngulo);
                Variaveis.LN = LinhaNeutra(d, Nd, anguloRad, ListaGeometriaAngulo, ListaConcretoAngulo, ListaPassivaAngulo, ListaAtivaAngulo, ListaGFRPAngulo);
                
                double momentoResistenteX = 0;
                double momentoResistenteY = 0;
                momentoResistenteX = -(Math.Round(MomentoX(), 2));
                momentoResistenteY = -(Math.Round(MomentoY(), 2));
                Console.WriteLine("Angulo: " + (anguloRad / (Math.PI / 180)) + "|| dominio: " + dominio + " || LN: " + Variaveis.LN.ToString("#.00") + " || Mx: " + momentoResistenteX.ToString("#.00") + " || My: " + momentoResistenteY.ToString("#.00"));
                Variaveis.CoordenadasGrafico.Add(new DiscretizacaoList(momentoResistenteX, momentoResistenteY, 0));

                //finaliza quando existe problema

            }
            
            //desenha grafico
            FormGrafico formG = new FormGrafico();

            formG.Show();
            formG.DesenhaSecao(Variaveis.CoordenadasGrafico);

        }

        public static double LinhaNeutra(double d, double Nd, double angle, List<DiscretizacaoList> ListaGeometria, List<DiscretizacaoList> ListaConcreto, List<DiscretizacaoList> ListaBarrasPassivas, List<DiscretizacaoList> ListaBarrasAtivas, List<DiscretizacaoList> ListaBarrasGFRP)
        {
            double linhaNeutra = 0;
            double xMin = -1;
            double xMax = d;
            double xi = xMin;
            double fxMin = 0;
            double fxMax = 0;
            double tol = Variaveis.tolerancia;
            double FxLN = 0;

            int BreakA = 0;
            int BreakB = 0;
            int BreakC = 0;

            while (CalculaFxLN(xMin, d, angle, Nd, ListaGeometria, ListaConcreto, ListaBarrasPassivas, ListaBarrasAtivas, ListaBarrasGFRP) > 0)
            {
                xMax = xMin;
                xMin = 2 * xMin;
                //limite
                if(BreakA > 950)
                {
                    //MessageBox.Show("Não foi possível calcular o intervalo da linha neutra", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;                    
                }
                BreakA++;
            }
            while (CalculaFxLN(xMax, d, angle, Nd, ListaGeometria, ListaConcreto, ListaBarrasPassivas, ListaBarrasAtivas, ListaBarrasGFRP) < 0)
            {
                xMin = xMax;
                xMax = 2 * xMax;
                //limite
                if (BreakB > 950)
                {
                    //MessageBox.Show("Não foi possível calcular o intervalo da linha neutra", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                BreakB++;
            }

            while (Math.Abs(CalculaFxLN(xi, d, angle, Nd, ListaGeometria, ListaConcreto, ListaBarrasPassivas, ListaBarrasAtivas, ListaBarrasGFRP)) > tol)
            {
                               
                //calcular o f(x) máximo e mínimo
                fxMin = CalculaFxLN(xMin, d, angle, Nd, ListaGeometria, ListaConcreto, ListaBarrasPassivas, ListaBarrasAtivas, ListaBarrasGFRP);
                fxMax = CalculaFxLN(xMax, d, angle, Nd, ListaGeometria, ListaConcreto, ListaBarrasPassivas, ListaBarrasAtivas, ListaBarrasGFRP);
                //calcular a aproximação da linha neutra
                if(fxMax == fxMin)
                {
                    fxMax = fxMax + 1;
                }
                xi = (xMin * fxMax - xMax * fxMin) / (fxMax - fxMin);
                //calcular novos x(mín) e x(máx)
                double Fxi = CalculaFxLN(xi, d, angle, Nd, ListaGeometria, ListaConcreto, ListaBarrasPassivas, ListaBarrasAtivas, ListaBarrasGFRP);
                if (Fxi > 0)
                {
                    xMin = xi;
                }
                else
                {
                    xMax = xi;
                }

                //limite
                if (BreakC > 950)
                {
                    fxMin = CalculaFxLN(xMin, d, angle, Nd, ListaGeometria, ListaConcreto, ListaBarrasPassivas, ListaBarrasAtivas, ListaBarrasGFRP);
                    fxMax = CalculaFxLN(xMax, d, angle, Nd, ListaGeometria, ListaConcreto, ListaBarrasPassivas, ListaBarrasAtivas, ListaBarrasGFRP);
                   // MessageBox.Show("Não foi possível encontrar a solução.\n" + "Angulo - "+ angle, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }
                BreakC++;
                

            }
            Console.WriteLine(BreakC);
            return xi;
        }
        static int dominio=0;

        static List<double> yConcreto = new List<double>();
        
        public static double CalculaFxLN(double xLN, double d, double angle, double Nd, List<DiscretizacaoList> ListaGeometria, List<DiscretizacaoList> ListaConcreto, List<DiscretizacaoList> ListaBarrasPassivas, List<DiscretizacaoList> ListaBarrasAtivas, List<DiscretizacaoList> ListaBarrasGFRP)
        {
            Variaveis.DeformacoesConcreto.Clear();
            Variaveis.DeformacoesBarras.Clear();
            Variaveis.TensoesAco.Clear();
            Variaveis.TensoesConcreto.Clear();
            yConcreto.Clear();

            //cria tabelas de barras e concreto
            foreach (var item in ListaGeometria)
            {
                yConcreto.Add(item.dY);
            }
            //ALTURA DA VIGA
            double Max = yConcreto.Max();
            double Min = yConcreto.Min();
            double AlturaViga = Max - Min;

            //variaveis
            double FxLN = 0;
            
            double Phi=0;
            double EpsilonCG=0;
            double yLinSup = Math.Abs(yConcreto.Min());
            double yLinInf = d - Math.Abs(yLinSup);

            //determinação do domínio
            double LimD2 = (-Variaveis.epsilonCu / (-Variaveis.epsilonCu + Variaveis.epsilonAs)) * d;
            if (xLN <= LimD2)
            {
                dominio = 2;
                Phi = -Variaveis.epsilonAs / (d - xLN);
                EpsilonCG = Variaveis.epsilonAs + (Phi * yLinInf);
                
            }
            else if (xLN <= AlturaViga)
            {
                dominio = 4;
                Phi = Variaveis.epsilonCu / xLN;
                EpsilonCG = Phi * (xLN-yLinSup);

            }
            else if(xLN >= AlturaViga)
            {
                dominio = 5;

                double EpsilonSi = 0.014 * ((xLN - d) / (7 * xLN - 3 * AlturaViga));
                Phi = -EpsilonSi / (xLN - d);
                EpsilonCG = Phi * (xLN - yLinSup);

            }

            //cria lista para o cálculo das tensões


            foreach (DiscretizacaoList List in ListaConcreto)
            {
                double Epsilon = EpsilonCG - Phi * List.dY;
                Variaveis.DeformacoesConcreto.Add(Epsilon);

            }
            foreach (DiscretizacaoList List in ListaBarrasPassivas)
            {
                double Epsilon = EpsilonCG - Phi * List.dY;
                Variaveis.DeformacoesBarras.Add(Epsilon);

            }
            //falta listas de protensão e gfrp


            //calcula a tensão em cada ponto concreto
            int i = 0;
            foreach (DiscretizacaoList list in ListaConcreto)
            {
                double Tensao = Materiais.CalculoTensaoConcreto(Variaveis.DeformacoesConcreto[i], Variaveis.epsilonCu, Variaveis.epsilonC2, Variaveis.fck, Variaveis.fcd);
                Variaveis.TensoesConcreto.Add(new TensaoList(Tensao, list.dX, list.dY));

                i++;
            }

            //calcula a tensão no concreto na mesma posição do aço para fins de desconto das barras comprimidas
            int m = 0;
            foreach (DiscretizacaoList list in ListaBarrasPassivas)
            {
                double Tensao = Materiais.CalculoTensaoConcreto(Variaveis.DeformacoesBarras[m], Variaveis.epsilonCu, Variaveis.epsilonC2, Variaveis.fck, Variaveis.fcd);
                Variaveis.TensoesConcretoPosAco.Add(new TensaoList(Tensao, list.dX, list.dY));
                m++;
            }

            //calcula a tensão no aço
            int j = 0;
            foreach (DiscretizacaoList list in ListaBarrasPassivas)
            {
                double Tensao = Materiais.CalculoTensaoAco(Variaveis.DeformacoesBarras[j], Variaveis.epsilonAsFy, Variaveis.fyd);
                Variaveis.TensoesAco.Add(new TensaoList(Tensao, list.dX, list.dY));

                j++;
            }

            //calcula força no concreto
            int k = 0;
            double ForcaConcreto = 0;
            foreach (DiscretizacaoList List in ListaConcreto)
            {
                ForcaConcreto += Variaveis.TensoesConcreto[k].Tensao * List.Area;

                k++;
            }
            //calcula força no aço
            int l = 0;
            double ForcaAco = 0;
            foreach (DiscretizacaoList List in ListaBarrasPassivas)
            {
                ForcaAco += Variaveis.TensoesAco[l].Tensao * List.Area;

                l++;
            }

            FxLN = Nd - ForcaConcreto - ForcaAco;



            return FxLN;
        }
        public static double MomentoX()
        {
           
            double Mx=0;
            double ForcaConcreto = 0;
            //somatório de forças no concreto
            int k = 0;
            foreach (DiscretizacaoList List in Variaveis.ListaConcretoCG)
            {
                ForcaConcreto += Variaveis.TensoesConcreto[k].Tensao * List.Area * List.dY;

                k++;
            }


            int l = 0;
            double ForcaAco = 0;
            foreach (DiscretizacaoList List in Variaveis.ListaBarrasPassivasCG)
            {
                if(Variaveis.TensoesAco[l].Tensao < 0) //barra comprimida
                {
                    ForcaAco += (Variaveis.TensoesAco[l].Tensao + Variaveis.TensoesConcretoPosAco[l].Tensao) * List.Area * List.dY;
                }
                else
                {
                    ForcaAco += Variaveis.TensoesAco[l].Tensao * List.Area * List.dY;
                }

                l++;
            }

            Mx = (ForcaConcreto + ForcaAco)/(Variaveis.GamaF3*100);

            return Mx;
        }
        public static double MomentoY()
        {

            double My = 0;
            double ForcaConcreto = 0;
            //somatório de forças no concreto
            int k = 0;
            foreach (DiscretizacaoList List in Variaveis.ListaConcretoCG)
            {
                ForcaConcreto += Variaveis.TensoesConcreto[k].Tensao * List.Area * List.dX;

                k++;
            }
            int l = 0;
            double ForcaAco = 0;
            foreach (DiscretizacaoList List in Variaveis.ListaBarrasPassivasCG)
            {
                if (Variaveis.TensoesAco[l].Tensao < 0) //barra comprimida
                {
                    ForcaAco += (Variaveis.TensoesAco[l].Tensao + Variaveis.TensoesConcretoPosAco[l].Tensao) * List.Area * List.dX;
                }
                else
                {
                    ForcaAco += Variaveis.TensoesAco[l].Tensao * List.Area * List.dX;
                }
                l++;
            }

            My = (-ForcaConcreto - ForcaAco) / (Variaveis.GamaF3 * 100);

            return My;
        }

        public static double CalculoDoNRdCompressao()
        {

            double NcRd = 0;
            double ForcaConcreto = 0;
            double ForcaAco = 0;
            double AreaConcreto = 0;
            double AreaPassiva = 0;

            //cálculo das áreas
            for (int i = 0; i < Variaveis.ListaConcretoCG.Count; i++)
            {
                AreaConcreto += Variaveis.ListaConcretoCG[i].Area;
            }
            for (int i = 0; i < Variaveis.ListaBarrasPassivasCG.Count; i++)
            {
                AreaPassiva += Variaveis.ListaBarrasPassivasCG[i].Area;
            }

            double tensaoMaxconcreto = Materiais.CalculoTensaoConcreto(Variaveis.epsilonC2, Variaveis.epsilonCu, Variaveis.epsilonC2, Variaveis.fck, Variaveis.fcd);
            double tensaoMaxPassiva = Materiais.CalculoTensaoAco(Variaveis.epsilonC2, Variaveis.epsilonAsFy, Variaveis.fyd);
            ForcaConcreto = AreaConcreto * tensaoMaxconcreto;
            ForcaAco = (AreaPassiva * tensaoMaxPassiva) - (AreaPassiva * tensaoMaxconcreto);


            NcRd = ((ForcaConcreto + ForcaAco) / (Variaveis.GamaF3));

            return NcRd;
        }
        public static double CalculoDoNRdTracao()
        {

            double NtRd = 0;
            double ForcaAco = 0;
            double AreaPassiva = 0;

            //cálculo das áreas
            for (int i = 0; i < Variaveis.ListaBarrasPassivasCG.Count; i++)
            {
                AreaPassiva += Variaveis.ListaBarrasPassivasCG[i].Area;
            }


            double tensaoMaxPassiva = Materiais.CalculoTensaoAco(Variaveis.epsilonAs, Variaveis.epsilonAsFy, Variaveis.fyd);
            ForcaAco = AreaPassiva * tensaoMaxPassiva;


            NtRd = ((ForcaAco) / (Variaveis.GamaF3));

            return NtRd;
        }

    }
}
