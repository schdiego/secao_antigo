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

namespace AUTHENTY_SECAO
{
    public partial class FormDesenho : Form
    {
        //ZOOM COM SCROLL
        public bool ScrollpBoxDesenho;
        public static float factorZoom;
        public static int xMouse;
        public static int yMouse;
        public static int testeZoom;
        
        //bitmap
        static Bitmap DesenhoBMP = new Bitmap(1500, 1500);
        static Graphics graphic = Graphics.FromImage(DesenhoBMP);
        //lista de Penas
        List<Pen> penasList = new List<Pen>();
        //listas Brush
        List<Brush> brushesList = new List<Brush>();
        //listas Font
        List<Font> fontList = new List<Font>();
        int tamanhoFonte = 2;


        public FormDesenho()
        {
            InitializeComponent();
            adicionaListaDePenas();
            adicionaListaDeBrushes();
            adicionaListaFontes();

        }
        private void adicionaListaDePenas()
        {
            penasList.Add(new Pen(Brushes.Red)); //0
            penasList.Add(new Pen(Brushes.Yellow)); //1
            penasList.Add(new Pen(Brushes.Green)); //2
            penasList.Add(new Pen(Brushes.Cyan));//3
            penasList.Add(new Pen(Brushes.Blue));//4
            penasList.Add(new Pen(Brushes.Magenta));//5
            penasList.Add(new Pen(Brushes.Black));//6
            penasList.Add(new Pen(Brushes.Gray));//7
            penasList.Add(new Pen(Brushes.LightGray));//8
            penasList.Add(new Pen(Brushes.Brown));//9
        }
        private void adicionaListaDeBrushes()
        {
            brushesList.Add(Brushes.Red); //0
            brushesList.Add(Brushes.Yellow); //1
            brushesList.Add(Brushes.Green); //2
            brushesList.Add(Brushes.Cyan);//3
            brushesList.Add(Brushes.Blue);//4
            brushesList.Add(Brushes.Magenta);//5
            brushesList.Add(Brushes.Black);//6
            brushesList.Add(Brushes.Gray);//7
            brushesList.Add(Brushes.LightGray);//8
            brushesList.Add(Brushes.Brown);//9
        }
        private void adicionaListaFontes()
        {
            fontList.Add(new Font("Arial", tamanhoFonte, FontStyle.Regular, GraphicsUnit.Pixel));//0
            fontList.Add(new Font("Calibri", tamanhoFonte, FontStyle.Regular, GraphicsUnit.Pixel));//1
            fontList.Add(new Font("Times New Roman", tamanhoFonte, FontStyle.Regular, GraphicsUnit.Pixel));//2
        }
        public void Desenhar(List<PointF> poligonais)
        {
            graphic.Clear(Color.White);

            //desenha hachuras
            
            graphic.FillPolygon(brushesList[8], poligonais.ToArray());


            //desenha linhas

            graphic.DrawPolygon(penasList[6], poligonais.ToArray());

            //desenha barras

            if(MDI.FormAtivo == 2)
            {
                for (int i = 0; i < Variaveis.ListBarrasPassivas.Count; i++)
                {
                    float diametro = Convert.ToSingle(Math.Sqrt(Variaveis.ListBarrasPassivas[i].Area * 4 / Math.PI));
                    float point1X = (Variaveis.ArmPassivasList[i].X) - (diametro / 2) * factorZoom;
                    float point1Y = (Variaveis.ArmPassivasList[i].Y) - (diametro / 2) * factorZoom;
                    RectangleF rectangle = new RectangleF(point1X, point1Y, diametro * factorZoom, diametro * factorZoom);
                    graphic.FillEllipse(brushesList[0], rectangle);
                }
            }


            //desenha
            pictureBox1.CreateGraphics();
            pictureBox1.Image = DesenhoBMP;
        }


        public void scrollDesenho()
        {
            this.MouseWheel += new MouseEventHandler(picImage_MouseWheel);
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {           
            ScrollpBoxDesenho = true;
            scrollDesenho();
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            ScrollpBoxDesenho = false;
        }
        private void picImage_MouseWheel(object sender, MouseEventArgs e)//zoom
        {
            if (ScrollpBoxDesenho == true)
            {
                factorZoom = 1F;
                //usado somente para zoom no mouse(não estou usando ainda)
                xMouse = e.X;
                yMouse = e.Y;
                // The amount by which we adjust scale per wheel click.
                float scale_per_delta = 0.01F / 25;
                // Update the drawing based upon the mouse wheel scrolling.
                factorZoom += e.Delta * scale_per_delta;
                if (factorZoom < 0.02)factorZoom = 0.02F;
                Variaveis.PoligonaisListZoom = ajusteCoordenadasZoom(xMouse, yMouse, factorZoom, Variaveis.PoligonaisListZoom);
                Desenhar(Variaveis.PoligonaisListZoom);
            }
            return;
        }
        


        public List<PointF> ajusteCoordenadasZoom(int xMouse, int yMouse, float factorZoom, List<PointF> points)
        {
            List<PointF> coordenadasCorr = new List<PointF>();

            for (int i = 0; i < points.Count; i++)
            {
                coordenadasCorr.Add(new PointF(points[i].X + (points[i].X  - Convert.ToSingle(xMouse)) * (factorZoom - 1), points[i].Y + (points[i].Y - Convert.ToSingle(yMouse)) * (factorZoom - 1)));

            }
            return coordenadasCorr;
        }
        //mover desenho
        public List<PointF> ajusteCoordenadasMove(int xMove, int yMove, List<PointF> coordenadas)
        {
            List<PointF> coordenadasCorr = new List<PointF>();

            for (int i = 0; i < coordenadas.Count; i++)
            {
                coordenadasCorr.Add(new PointF(coordenadas[i].X + xMove, coordenadas[i].Y + yMove));
            }
            return coordenadasCorr;
        }
        //mover desenho
        private bool Dragging;
        private int xPosI;
        private int yPosI;
        private int xPosF;
        private int yPosF;
        int xPosAnt;
        int yPosAnt;
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Dragging = false;
            this.Cursor = Cursors.Default;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            xPosAnt = 0;
            yPosAnt = 0;
            if (e.Button == MouseButtons.Middle)
            {
                Dragging = true;
                xPosI = e.X;
                yPosI = e.Y;
            }
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Variaveis.PontoXY_Tela = new PointF(e.X, e.Y);
            label1.Text = "X = " + e.X + "/" + "Y = " + e.Y;/////
            xPosF = e.X;
            yPosF = e.Y;
            int xPos = (xPosF - xPosI);
            int yPos = (yPosF - yPosI);

            if (Dragging == true)
            {
                this.Cursor = Cursors.SizeAll;

                Variaveis.PoligonaisListZoom = ajusteCoordenadasMove((xPos - xPosAnt), (yPos - yPosAnt), Variaveis.PoligonaisListZoom);

                Desenhar(Variaveis.PoligonaisListZoom);
            }
            xPosAnt = xPos;
            yPosAnt = yPos;
        }
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            CentralizarDesenho(Variaveis.PoligonaisListZoom);
        }

        public void CentralizarDesenho(List<PointF> points)
        {
            float Xmin;
            float Xmax;
            float Ymin;
            float Ymax;

            Xmin = points.Min(e => e.X);
            Xmax = points.Max(e => e.X);
            Ymin = points.Min(e => e.Y);
            Ymax = points.Max(e => e.Y);

            float CentroFormX = pictureBox1.Width / 2;
            float CentroFormY = pictureBox1.Height / 2;

            float Xcentro = (Xmin + Xmax) / 2;
            float Ycentro = (Ymin + Ymax) / 2;

            int moveX = Convert.ToInt32(CentroFormX - Xcentro);
            int moveY = Convert.ToInt32(CentroFormY - Ycentro);

            Variaveis.PoligonaisListZoom = ajusteCoordenadasMove(moveX, moveY, Variaveis.PoligonaisListZoom);
            
            Desenhar(Variaveis.PoligonaisListZoom);


        }






        public void Resize(int width, int height)
        {
            this.Height = height;
            this.Width = width;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MDI.F_Armaduras.button1_Click(null, null);
        }
    }
}
