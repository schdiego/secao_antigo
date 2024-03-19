using AUTHENTY_SECAO.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTHENTY_SECAO.FormsSecoesTransversais
{
    public partial class Retangular : Form
    {
        double Altura;
        double Largura;
        public Retangular()
        {
            InitializeComponent();

        }

        private void tBoxLargura_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxLargura);
        }

        private void tBoxLargura_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxLargura, Idioma.txtInserirDados, Variaveis.arredComp, false, false, false);
            if (tBoxLargura.BackColor != Color.Red)
            {
               Largura = Convert.ToDouble(tBoxLargura.Text);
            }
        }

        private void tBoxAltura_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxAltura);
        }

        private void tBoxAltura_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxAltura, Idioma.txtInserirDados, Variaveis.arredComp, false, false, false);
            if (tBoxAltura.BackColor != Color.Red)
            {
                Altura = Convert.ToDouble(tBoxAltura.Text);
            }
        }

        public void gerarListaGeometria()
        {
            //limparLista

            Variaveis.GeometriaList.Clear();
            //Gerar lista
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(0, 0, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(Largura, 0, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(Largura, Altura, 0));
            Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(0, Altura, 0));
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            tBoxLargura_Leave(null, null);
            tBoxAltura_Leave(null, null);
            gerarListaGeometria();
            MDI.F_SecaoTransversal.desenharSecao();
            
        }
    }
}
