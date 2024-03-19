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
    public partial class Circular : Form
    {
        double Diametro;
        public Circular()
        {
            InitializeComponent();
            
        }

        private void tBoxDiametro_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxDiametro);
        }

        private void tBoxDiametro_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxDiametro, Idioma.txtInserirDados, Variaveis.arredComp, false, false, false);
            if (tBoxDiametro.BackColor != Color.Red)
            {
                Diametro = Convert.ToDouble(tBoxDiametro.Text);
            }
            gerarListaGeometria();
        }
        public void gerarListaGeometria()
        {
            //limparLista
            Variaveis.GeometriaList.Clear();
            //Gerar lista
            for (int i = 0; i < 360; i++)
            {
                double angulo = i * (Math.PI / 180);
                Variaveis.GeometriaList.Add(new ClassesListas.DiscretizacaoList(Math.Cos(angulo)*(Diametro/2), Math.Sin(angulo) * (Diametro / 2), 0));
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            tBoxDiametro_Leave(null, null);
            gerarListaGeometria();
            MDI.F_SecaoTransversal.desenharSecao();
        }
    }
}
