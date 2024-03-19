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

namespace AUTHENTY_SECAO
{
    public partial class FormMateriais : Form
    {
        public FormMateriais()
        {
            InitializeComponent();
            Iniciar();
        }
        public void Iniciar()
        {
            tBoxGamaC_Leave(null, null);
            tBoxFck_Leave(null, null);
            tBoxBeta_Leave(null, null);            
            tBoxEcu_Leave(null, null);
            tBoxEc2_Leave(null, null);
            tBoxGamaS_Leave(null, null);
            tBoxFyk_Leave(null, null);
            tBoxEpsilonFy_Leave(null, null);
            tBoxEpsilonSLim_Leave(null, null);
            tBoxEs_Leave(null, null);
        }
        public void AtualizarUnidades()
        {
            lbl_MPa_1.Text = Variaveis.unidTensao;
            lbl_MPa_2.Text = Variaveis.unidTensao;
            lbl_MPa_3.Text = Variaveis.unidTensao;
        }



        private void tBoxFck_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxFck);
        }

        private void tBoxFck_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxFck, Idioma.txtInserirDados, Variaveis.arredTensao, false, false, false);
            if (tBoxFck.BackColor != Color.Red && Convert.ToDouble(tBoxFck.Text) > 90 / Variaveis.convertTensao)
            {
                MessageBox.Show(Idioma.txtFckMaiorQue + (90 / Variaveis.convertTensao).ToString(Variaveis.arredTensao) + " " + Variaveis.unidTensao, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tBoxFck.BackColor = Color.Red;
                tBoxFck.Focus();
            }
            if (tBoxFck.BackColor != Color.Red)
            {
                Variaveis.fck = (Convert.ToDouble(tBoxFck.Text)/10) * Variaveis.convertTensao;
                Variaveis.fcd = Variaveis.fck / Variaveis.GamaC;
            }
        }

        private void tBoxBeta_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxBeta);
        }

        private void tBoxBeta_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxBeta, Idioma.txtInserirDados, Variaveis.arredTensao, false, false, false);
            if (tBoxBeta.BackColor != Color.Red)
            {
                Variaveis.Beta = Convert.ToDouble(tBoxBeta.Text);
            }
        }

        private void tBoxGamaC_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxGamaC);
        }

        private void tBoxGamaC_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxGamaC, Idioma.txtInserirDados, Variaveis.arredTensao, false, false, false);
            if (tBoxGamaC.BackColor != Color.Red)
            {
                Variaveis.GamaC = Convert.ToDouble(tBoxGamaC.Text);
            }
        }

        private void tBoxEcu_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxEcu);
        }

        private void tBoxEcu_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxEcu, Idioma.txtInserirDados, Variaveis.arredTensao, false, false, false);
            if (tBoxEcu.BackColor != Color.Red)
            {
                Variaveis.epsilonCu = -Convert.ToDouble(tBoxEcu.Text) / 1000;
            }
        }

        private void tBoxEc2_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxEc2);
        }

        private void tBoxEc2_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxEc2, Idioma.txtInserirDados, Variaveis.arredTensao, false, false, false);
            if (tBoxEc2.BackColor != Color.Red)
            {
                Variaveis.epsilonC2 = -Convert.ToDouble(tBoxEc2.Text) / 1000;
            }
        }

        private void tBoxFyk_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxFyk);
        }

        private void tBoxFyk_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxFyk, Idioma.txtInserirDados, Variaveis.arredTensao, false, false, false);
            if (tBoxFyk.BackColor != Color.Red)
            {
                Variaveis.fyk = (Convert.ToDouble(tBoxFyk.Text) / 10) * Variaveis.convertTensao;
                Variaveis.fyd = Variaveis.fyk / Variaveis.GamaS;
            }
        }

        private void tBoxGamaS_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxGamaS);
        }

        private void tBoxGamaS_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxGamaS, Idioma.txtInserirDados, Variaveis.arredTensao, false, false, false);
            if (tBoxGamaS.BackColor != Color.Red)
            {
                Variaveis.GamaS = Convert.ToDouble(tBoxGamaS.Text);
            }

        }

        private void tBoxEpsilonFy_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxEpsilonFy);
        }

        private void tBoxEpsilonFy_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxEpsilonFy, Idioma.txtInserirDados, Variaveis.arredTensao, false, false, false);
            if (tBoxEpsilonFy.BackColor != Color.Red)
            {
                Variaveis.epsilonAsFy = Convert.ToDouble(tBoxEpsilonFy.Text) / 1000;
            }
        }
        private void tBoxEpsilonSLim_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxEpsilonSLim);
        }

        private void tBoxEpsilonSLim_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxEpsilonSLim, Idioma.txtInserirDados, Variaveis.arredTensao, false, false, false);
            if (tBoxEpsilonSLim.BackColor != Color.Red)
            {
                Variaveis.epsilonAs = Convert.ToDouble(tBoxEpsilonSLim.Text) / 1000;
            }
        }
        private void tBoxEs_TextChanged(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_TextChange(tBoxEs);
        }

        private void tBoxEs_Leave(object sender, EventArgs e)
        {
            FrontEnd.conferirTbox_Leave(tBoxEs, Idioma.txtInserirDados, Variaveis.arredTensao, false, false, false);
            if (tBoxEs.BackColor != Color.Red)
            {
                Variaveis.Es = Convert.ToDouble(tBoxEs.Text) * Variaveis.convertTensao;
            }
        }

        private void btnNBR6118_Click(object sender, EventArgs e)
        {
            tBoxEcu.Text = "3.5";
            tBoxEc2.Text = "2";

            tBoxEcu_Leave(null, null);
            tBoxEc2_Leave(null, null);

        }

        private void lbl_MPa_1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
