using AUTHENTY_SECAO.Classes;
using AUTHENTY_SECAO.ClassesListas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTHENTY_SECAO.FormsSecoesTransversais
{
    public partial class FormatoEle : Form
    {
        double angulo;
        double hc;
        double hl;
        double bc;
        double bl;
        public FormatoEle()
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
                hc = Convert.ToDouble(tBoxHc.Text);
            }
        }

        private void tBoxHl_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxHl);
        }

        private void tBoxHl_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxHl, Idioma.txtInserirDados, Variaveis.arredComp, false, false, false);
            if (tBoxHl.BackColor != Color.Red)
            {
                hl = Convert.ToDouble(tBoxHl.Text);
            }
        }

        private void tBoxBc_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxBc);
        }

        private void tBoxBc_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxBc, Idioma.txtInserirDados, Variaveis.arredComp, false, false, false);
            if (tBoxBc.BackColor != Color.Red)
            {
                bc= Convert.ToDouble(tBoxBc.Text);
            }
        }

        private void tBoxBl_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxBl);
        }

        private void tBoxBl_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxBl, Idioma.txtInserirDados, Variaveis.arredComp, false, false, false);
            if (tBoxBl.BackColor != Color.Red)
            {
                bl = Convert.ToDouble(tBoxBl.Text);
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

            List<DiscretizacaoList> GeometriaAnguloZero = new List<DiscretizacaoList>();

            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(0, 0, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(bl, 0, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(bl, hc - bc, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(hl, hc - bc, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(hl, hc, 0));
            GeometriaAnguloZero.Add(new ClassesListas.DiscretizacaoList(0, hc, 0));

            //MUDA ANGULO
            Variaveis.GeometriaList = Calculos.MudaCoordenadasAngulo(GeometriaAnguloZero, angulo);

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            tBoxHl_Leave(null, null);
            tBoxHc_Leave(null, null);
            tBoxBc_Leave(null, null);
            tBoxBl_Leave(null, null);
            tBoxAngulo_Leave(null, null);
            gerarListaGeometria();
            MDI.F_SecaoTransversal.desenharSecao();
        }
    }
}
