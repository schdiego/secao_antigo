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

namespace AUTHENTY_SECAO.FormsSecoesTransversais
{
    public partial class FormatoTe : Form
    {
        double Hc;
        double Ht;
        double Bf;
        double Bw;
        double angulo;
        public FormatoTe()
        {
            InitializeComponent();
        }

        private void tBoxHc_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxHc);
        }

        private void tBoxHc_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxHc, Idioma.txtInserirDados, Variaveis.arredComp, false, false, false);
            if (tBoxHc.BackColor != Color.Red)
            {
                Hc = Convert.ToDouble(tBoxHc.Text);
            }
        }

        private void tBoxHt_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxHt);
        }

        private void tBoxHt_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxHt, Idioma.txtInserirDados, Variaveis.arredComp, false, false, false);
            if (tBoxHt.BackColor != Color.Red)
            {
                Ht = Convert.ToDouble(tBoxHt.Text);
            }
        }

        private void tBoxBf_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxBf);
        }

        private void tBoxBf_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxBf, Idioma.txtInserirDados, Variaveis.arredComp, false, false, false);
            if (tBoxBf.BackColor != Color.Red)
            {
                Bf = Convert.ToDouble(tBoxBf.Text);
            }
        }

        private void tBoxBw_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxBw);
        }

        private void tBoxBw_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxBw, Idioma.txtInserirDados, Variaveis.arredComp, false, false, false);
            if (tBoxBw.BackColor != Color.Red)
            {
                Bw = Convert.ToDouble(tBoxBw.Text);
            }
        }

        private void tBoxAngulo_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxAngulo);
        }

        private void tBoxAngulo_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxAngulo, Idioma.txtInserirDados, Variaveis.arredComp, false, true, true);
            if (tBoxAngulo.BackColor != Color.Red)
            {
                angulo = Convert.ToDouble(tBoxAngulo.Text);
            }
        }
        public void gerarListaGeometria()
        {
            //limparLista
            Variaveis.GeometriaList.Clear();
            //Gerar lista
            double aba = (Bf - Bw) / 2;
            List<DiscretizacaoList> GeometriaAnguloZero = new List<DiscretizacaoList>();

            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(aba, 0, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(aba + Bw, 0, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(aba + Bw, Hc - Ht, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(Bf, Hc - Ht, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(Bf, Hc, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(0, Hc, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(0, Hc - Ht, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(aba, Hc - Ht, 0));


            //MUDA ANGULO
            Variaveis.GeometriaList = Calculos.MudaCoordenadasAngulo(GeometriaAnguloZero, angulo);

        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            tBoxHc_Leave(null, null);
            tBoxHt_Leave(null, null);
            tBoxBf_Leave(null, null);
            tBoxBw_Leave(null, null);
            tBoxAngulo_Leave(null, null);
            gerarListaGeometria();
            MDI.F_SecaoTransversal.desenharSecao();
        }


    }
}
