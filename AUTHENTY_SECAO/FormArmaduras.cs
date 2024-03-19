using AUTHENTY_SECAO.FormsArmaduras;
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
    public partial class FormArmaduras : Form
    {
        FormPassiva F_Passiva;
        public FormArmaduras()
        {
            InitializeComponent();
            CarregarBotoesList();
            CarregarForms();
        }
       
        private void btnApagarLinha_Click(object sender, EventArgs e)
        {
            F_Passiva.ApagarLinha_Passiva();
        }
        private void CarregarBotoesList()
        {

        }
        private void CarregarForms()
        {

            //Desenho
            Variaveis.F_DesenhoArmadura = new FormDesenho();
            Variaveis.F_DesenhoArmadura.TopLevel = false;
            Variaveis.F_DesenhoArmadura.Visible = true;
            pBoxDesenho.Controls.Add(Variaveis.F_DesenhoArmadura);

            F_Passiva = new FormPassiva();
            //F_Passiva.TopLevel = false;
            F_Passiva.Visible = true;

        }
        public void desenharSecao()
        {
            //Variaveis.PoligonaisListZoom = Variaveis.PoligonaisList;
            Variaveis.F_DesenhoArmadura.Desenhar(Variaveis.PoligonaisListZoom);
        }

        private void btnAtiva_Click(object sender, EventArgs e)
        {
            panelForm.Controls.Add(F_Passiva);
        }

        public void button1_Click(object sender, EventArgs e)
        {
            float tol = 5;
            float xMin = (Variaveis.PontoXY_Tela.X - tol);
            float xMax = (Variaveis.PontoXY_Tela.X + tol);
            float yMin = (Variaveis.PontoXY_Tela.Y - tol);
            float yMax = (Variaveis.PontoXY_Tela.Y + tol);

            foreach (var item in Variaveis.PoligonaisListZoom)
            {
                if (item.X > xMin && item.X < xMax && item.Y > yMin && item.Y < yMax)
                {
                    Variaveis.ListBarrasPassivas.Add(new ClassesListas.DiscretizacaoList(item.X+5, item.Y-5, 2));
                }
            }
        }
    }
}

