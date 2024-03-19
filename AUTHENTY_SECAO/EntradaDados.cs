using AUTHENTY_SECAO.Classes;
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
    public partial class EntradaDados : Form
    {
        public EntradaDados()
        {
            InitializeComponent();
            Iniciar();
            
        }
        internal void Iniciar()
        {
            tBoxLargura_TextChanged(null, null);
            tBoxAltura_TextChanged(null, null);

            textBox5_TextChanged(null, null);

            textBox8_TextChanged(null, null);
            textBox9_TextChanged(null, null);
            textBox10_TextChanged(null, null);




            
            

           
           // button2_Click(null, null);

        }
        private void CriaListaGeometria()
        {
            //viga retangular
            
            Variaveis.GeometriaList.Clear();
            //Retangulo
            /*
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(0, 0, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(Variaveis.LarguraViga, 0, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(Variaveis.LarguraViga, Variaveis.AlturaViga, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(0, Variaveis.AlturaViga, 0));
            */

            //L
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(0, 0, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(40, 0, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(40, 15, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(15.5, 15.5, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(15, 40, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(0, 40, 0));



        }

        private void tBoxLargura_TextChanged(object sender, EventArgs e)
        {
            Variaveis.LarguraViga = Convert.ToDouble(tBoxLargura.Text);
        }

        private void tBoxAltura_TextChanged(object sender, EventArgs e)
        {
            Variaveis.AlturaViga = Convert.ToDouble(tBoxAltura.Text);
        }


        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            Variaveis.angulo = Convert.ToDouble(textBox5.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CriaListaGeometria();
            Variaveis.CoordenadasPontos.Clear();
            Variaveis.CoordenadasPontos = Discretizacao.CoordenadasPontos(Variaveis.GeometriaList, Variaveis.TamElemento);
            //Desenhos.DesenhaGeometria(Variaveis.GeometriaList);
            Desenhos.DesenhaRetangulos(Variaveis.CoordenadasPontos, MDI.F_SecaoTransversal.pBoxDesenho);
            Calculos.ListaDiscretizacao();
            Desenhos.DesenhaBarras(Variaveis.ListBarrasPassivas);
            Variaveis.ListConcreto.Clear();
            Discretizacao.CriarListaConcreto();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cálculo do centro de gravidade
            Variaveis.CG = Operacoes.CentroDeGravidade(Variaveis.GeometriaList);
            Desenhos.DesenhaCG(Variaveis.CG);

                //label19.Text = Calculos.LinhaNeutra(35).ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            Variaveis.TamElemento = Convert.ToDouble(textBox8.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Calculos.CalcularSecao(Variaveis.NSd, Variaveis.GeometriaList, Variaveis.ListConcreto, Variaveis.ListBarrasPassivas, Variaveis.ListBarrasAtivas, Variaveis.ListBarrasGFRP);
       
        }


        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            Variaveis.NSd = Convert.ToDouble(textBox9.Text);
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            Variaveis.tolerancia = Convert.ToDouble(textBox10.Text);
        }
    }
}
