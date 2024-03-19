using AUTHENTY_SECAO.ClassesListas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults; //Contains the already defined types
using LiveCharts.Wpf;

namespace AUTHENTY_SECAO
{
    public partial class FormGrafico : Form
    {

        static Bitmap Desenho = new Bitmap(500 , 500);
        static Graphics Imagem;
        public FormGrafico()
        {
            InitializeComponent();
            label1.Text = "Maxima compressão: " + Variaveis.NcRd.ToString("#,00");
            label2.Text = "Maxima tração: " + Variaveis.NtRd.ToString("#,00");
        }


        public void DesenhaSecao(List<DiscretizacaoList> lista)
        {
            //desenha gráfico
            ChartValues<ObservablePoint> Pontos = new ChartValues<ObservablePoint>();
            ChartValues<ObservablePoint> ZeroZero = new ChartValues<ObservablePoint>();
            foreach (DiscretizacaoList item in lista)
            {
                Pontos.Add(new ObservablePoint(item.dX, item.dY));
            }
            ZeroZero.Add(new ObservablePoint(0, 0));

            //Cartesian Chart
            cartesianChart1.Zoom = ZoomingOptions.Xy;
            cartesianChart1.DisableAnimations = true;
            cartesianChart1.Hoverable = false;
            cartesianChart1.LegendLocation = LegendLocation.Top;

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Diagrama de interação",
                    Values = Pontos,

                    PointGeometrySize = 5

                },
                new LineSeries
                {
                    Title = "Ponto 0,0",
                    Values = ZeroZero,

                    PointGeometrySize = 15

                }

            };
            
        }
    }
}
