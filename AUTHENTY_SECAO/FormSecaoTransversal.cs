using AUTHENTY_SECAO.Classes;
using AUTHENTY_SECAO.FormsSecoesTransversais;
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
    public partial class FormSecaoTransversal : Form
    {
        List<Button> BotoesList = new List<Button>();
        //Formulários
        public static Retangular retangular;
        public static Circular circular;
        public static FormatoEle formatoEle;
        public static FormatoTe formatoTe;
        public static Poligonal poligonal;

        //formaberto
        List<Form> FormsList = new List<Form>();
        int FormAtivo = 0;
        


        public FormSecaoTransversal()
        {
            InitializeComponent();
            CarregarBotoesList();
            CarregarForms();
           
        }

        private void CarregarBotoesList()
        {
            BotoesList.Add(btnRetangular);
            BotoesList.Add(btnCircular);
            BotoesList.Add(btnEle);
            BotoesList.Add(btnTe);
            BotoesList.Add(btnPoligonal);
        }
        private void CarregarForms()
        {
            //retangular
            retangular = new Retangular();
            retangular.TopLevel = false;
            retangular.Visible = true;

            //circular
            circular = new Circular();
            circular.TopLevel = false;
            circular.Visible = true;
            //Formato Ele
            formatoEle = new FormatoEle();
            formatoEle.TopLevel = false;
            formatoEle.Visible = true;
            //Formato te
            formatoTe = new FormatoTe();
            formatoTe.TopLevel = false;
            formatoTe.Visible = true;
            //Poligonal
            poligonal = new Poligonal();
            poligonal.TopLevel = false;
            poligonal.Visible = true;
            //Desenho
            //desenhos
            Variaveis.F_DesenhoSecao = new FormDesenho();///
            Variaveis.F_DesenhoSecao.TopLevel = false;///
            Variaveis.F_DesenhoSecao.Visible = true;///////////////////////
            pBoxDesenho.Controls.Add(Variaveis.F_DesenhoSecao);//////

            //adiciona formulários na lista
            FormsList.Add(retangular);
            FormsList.Add(circular);
            FormsList.Add(formatoEle);
            FormsList.Add(formatoTe);
            FormsList.Add(poligonal);

            //adiciona o retangular no form
            btnRetangular_Click(null, null);



        }

        private void btnRetangular_Click(object sender, EventArgs e)
        {
            //muda cor do botão
            foreach (var item in BotoesList)
            {
                item.FlatAppearance.BorderColor = Color.White;
                item.BackColor = Color.White;
            }
            btnRetangular.FlatAppearance.BorderSize = 1;
            btnRetangular.FlatAppearance.BorderColor = Color.Black;
            btnRetangular.BackColor = Color.LightGray;
            //adiciona form
            panelForm.Controls.Remove(FormsList[FormAtivo]);
            panelForm.Controls.Add(retangular);
            FormAtivo = 0;
           
        }

        private void btnCircular_Click(object sender, EventArgs e)
        {
            //muda cor do botão
            foreach (var item in BotoesList)
            {
                item.FlatAppearance.BorderColor = Color.White;
                item.BackColor = Color.White;
            }
            btnCircular.FlatAppearance.BorderColor = Color.Black;
            btnCircular.FlatAppearance.BorderSize = 1;
            btnCircular.BackColor = Color.LightGray;
            //adiciona form
            panelForm.Controls.Remove(FormsList[FormAtivo]);
            panelForm.Controls.Add(circular);
            FormAtivo = 1;
        }

        private void btnEle_Click(object sender, EventArgs e)
        {
            //muda cor do botão
            foreach (var item in BotoesList)
            {
                item.FlatAppearance.BorderColor = Color.White;
                item.BackColor = Color.White;
            }
            btnEle.FlatAppearance.BorderColor = Color.Black;
            btnEle.FlatAppearance.BorderSize = 1;
            btnEle.BackColor = Color.LightGray;
            //adiciona form
            panelForm.Controls.Remove(FormsList[FormAtivo]);
            panelForm.Controls.Add(formatoEle);
            FormAtivo = 2;
        }

        private void btnTe_Click(object sender, EventArgs e)
        {
            //muda cor do botão
            foreach (var item in BotoesList)
            {
                item.FlatAppearance.BorderColor = Color.White;
                item.BackColor = Color.White;
            }
            btnTe.FlatAppearance.BorderColor = Color.Black;
            btnTe.FlatAppearance.BorderSize = 1;
            btnTe.BackColor = Color.LightGray;
            //adiciona form
            panelForm.Controls.Remove(FormsList[FormAtivo]);
            panelForm.Controls.Add(formatoTe);
            FormAtivo = 3;
        }

        private void btnPoligonal_Click(object sender, EventArgs e)
        {
            //ajusta altura do formulario
            poligonal.ResizeForm();
            //muda cor do botão
            foreach (var item in BotoesList)
            {
                item.FlatAppearance.BorderColor = Color.White;
                item.BackColor = Color.White;
            }
            btnPoligonal.FlatAppearance.BorderColor = Color.Black;
            btnPoligonal.FlatAppearance.BorderSize = 1;
            btnPoligonal.BackColor = Color.LightGray;
            //adiciona form
            panelForm.Controls.Remove(FormsList[FormAtivo]);
            panelForm.Controls.Add(poligonal);
            FormAtivo = 4;
        }
        public void desenharSecao()
        {
            
            Variaveis.PoligonaisList.Clear();
            foreach (var item in Variaveis.GeometriaList)
            {
                Variaveis.PoligonaisList.Add(new PointF(Convert.ToSingle(item.dX), Convert.ToSingle(-item.dY)));
            }

            Variaveis.PoligonaisListZoom = Variaveis.PoligonaisList;
            Variaveis.F_DesenhoSecao.Desenhar(Variaveis.PoligonaisListZoom);
            Variaveis.F_DesenhoSecao.CentralizarDesenho(Variaveis.PoligonaisListZoom);

        }

    }
}
