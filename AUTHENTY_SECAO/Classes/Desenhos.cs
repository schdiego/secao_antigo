using AUTHENTY_SECAO.ClassesListas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTHENTY_SECAO.Classes
{
    public class Desenhos
    {
        static Bitmap Desenho = new Bitmap(250, 300);
        static Graphics Imagem;
        

        public static void DesenhaBarras(List<DiscretizacaoList> lista)
        {
           
            Pen black = new Pen(Brushes.Black);
            Brush red = Brushes.Red;

            float escala = 5F;


            foreach (DiscretizacaoList item in lista)
            {
                float diametro = Convert.ToSingle(Math.Sqrt(item.Area * 4 / Math.PI));

                float point1X = (Convert.ToSingle(item.dX) - Convert.ToSingle(diametro / 2)) * escala;
                float point1Y = (Convert.ToSingle(item.dY) - Convert.ToSingle(diametro / 2)) * escala;
                RectangleF rectangle = new RectangleF(point1X, point1Y, diametro * escala, diametro * escala);
                Imagem.FillEllipse(red, rectangle);
            }
               // MDI.F_SecaoTransversal.pictureBox1.Image = Desenho;

        }
        
        public static void DesenhaGeometria(List<DiscretizacaoList> lista, PictureBox pictureBox )
        {
            
            Imagem = Graphics.FromImage(Desenho);
            Imagem.Clear(Color.White);
            float escala = 5F;
            Pen black = new Pen(Brushes.Black);
            Brush red = Brushes.Red;
            var font = new Font("Calibri", 2 * escala, FontStyle.Regular, GraphicsUnit.Pixel);

            List<PointF> Pontos = new List<PointF>();
            foreach (DiscretizacaoList item in lista)
            {
                Pontos.Add(new PointF(Convert.ToSingle(item.dX) * escala + 100F, Convert.ToSingle(item.dY) * escala + 100F)); //tirar o 100F depois

            }
            Pontos.Add(new PointF(Convert.ToSingle(lista[0].dX) * escala + 100F, Convert.ToSingle(lista[0].dY) * escala + 100F));
            Imagem.DrawPolygon(black, Pontos.ToArray());


           pictureBox.Image = Desenho;

        }
        public static void DesenhaRetangulos(List<DiscretizacaoList> lista, PictureBox pictureBox)
        {

            float escala = 5F;
            Pen black = new Pen(Brushes.Black);
            Brush red = Brushes.Red;
            var font = new Font("Calibri", escala, FontStyle.Regular, GraphicsUnit.Pixel);
            float TamanhoX = Convert.ToSingle(Variaveis.TamElementoFinalX);
            float TamanhoY = Convert.ToSingle(Variaveis.TamElementoFinalY);

            foreach (DiscretizacaoList item in lista)
            {
                List<PointF> retangulo = new List<PointF>();
                retangulo.Add(new PointF((Convert.ToSingle(item.dX) - TamanhoX / 2) * escala, (Convert.ToSingle(item.dY) + TamanhoY / 2) * escala));
                retangulo.Add(new PointF((Convert.ToSingle(item.dX) - TamanhoX / 2) * escala, (Convert.ToSingle(item.dY) - TamanhoY / 2) * escala));
                retangulo.Add(new PointF((Convert.ToSingle(item.dX) + TamanhoX / 2) * escala, (Convert.ToSingle(item.dY) - TamanhoY / 2) * escala));
                retangulo.Add(new PointF((Convert.ToSingle(item.dX) + TamanhoX / 2) * escala, (Convert.ToSingle(item.dY) + TamanhoY / 2) * escala));
                retangulo.Add(new PointF((Convert.ToSingle(item.dX) - TamanhoX / 2) * escala, (Convert.ToSingle(item.dY) + TamanhoY / 2) * escala));


                Imagem.DrawPolygon(black, retangulo.ToArray());
            }
            
           pictureBox.Image = Desenho;

        }

        public static void DesenhaCG(List<DiscretizacaoList> CGList)
        {

            float escala = 5F;
            Pen redPen = new Pen(Brushes.Red, 5F);
            Brush red = Brushes.Red;
            var font = new Font("Calibri", escala, FontStyle.Regular, GraphicsUnit.Pixel);


            foreach (DiscretizacaoList item in CGList)
            {
                float X = Convert.ToSingle(item.dX);
                float Y = Convert.ToSingle(item.dY);

                Imagem.DrawLine(redPen, (X - 4) * escala, Y * escala, (X + 4) * escala, Y * escala);
                Imagem.DrawLine(redPen, X * escala, (Y - 4) * escala, X * escala, (Y + 4) * escala);
            }

           // MDI.F_SecaoTransversal.pictureBox1.Image = Desenho;

        }






    }
}
