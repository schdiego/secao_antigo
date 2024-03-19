

using System;
using System.Drawing;
using System.Windows.Forms;

namespace AUTHENTY_SECAO
{
    public partial class TabelaPoligonal : UserControl
    {



        double[] listaAreas = { 7.35, 7.9, 3.68, 2.94, 2.45, 2.11, 1.84, 3.69, 2.46, 1.85, 1.48, 1.23, 1.06, 0.92, 2.49, 1.64, 1.23, 0.98, 0.82, 0.71, 0.62, 1.83, 1.22, 0.92, 0.73, 0.61, 0.52, 0.46 };
        public TabelaPoligonal()
        {
            InitializeComponent();
            /*AddReforcoPadrao();
            label1.Text = "Reforço " + (FormQuant.contRef);
            radioButton1.Checked = true;
            groupBox1.Height = 155;
            


            this.Height = 165;


            //adicionando dados de entrada
            if (TipoPadrao == true)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;

            }
            cBox1.SelectedIndex = IndexTela;
            tBoxQuantPadrao.Text = QuantTela;
            tBoxLarg.Text = Largura;
            tBoxComp.Text = Comprimento;
            tBoxQuantPersonal.Text = QuantTela;*/

        }





        /*
        public void calcular()
        {
            iniciar();
            string Tipo;
            string LarguraTable = "0";
            string ComprimentoTable = "0";
            bool ReforcoPadrao = true;

            if (radioButton1.Checked == true)
            {
                areaReforco = listaAreas[cBox1.SelectedIndex] * Quantidade;
                //Listas
                Tipo = cBox1.Text;
                LarguraTable = "---";
                ComprimentoTable = "---";
                ReforcoPadrao = true;
                FormQuant.RefTamanhoList.Add(Tipo);
            }
            else
            {
                areaReforco = (LarguraRef * ComprimentoRef / 10000) * Quantidade;
                //Listas
                Tipo = "---";
                LarguraTable = LarguraRef.ToString();
                ComprimentoTable = ComprimentoRef.ToString();
                ReforcoPadrao = false;
                FormQuant.RefTamanhoList.Add(LarguraTable + " x " + ComprimentoTable);
            }

            if (tBoxComp.BackColor != Color.Red || tBoxLarg.BackColor != Color.Red)
            {
                FormQuant.AreaRefList.Add(areaReforco);
            }

            //add Listas
            FormQuant.RefPadraoList.Add(ReforcoPadrao);
            FormQuant.RefSeleIndexList.Add(cBox1.SelectedIndex);
            FormQuant.QuantidadeList.Add(Quantidade.ToString());
            FormQuant.LarguraList.Add(LarguraTable);
            FormQuant.ComprimentoList.Add(ComprimentoTable);*/


    }


}
