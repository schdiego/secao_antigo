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
    public partial class SecaoTransversal : Form
    {
        List<PictureBox> BotoesList = new List<PictureBox>();
        //Formulários
        public static Retangular retangular;
        public static Circular circular;
        public static FormatoEle formatoEle;
        public static FormatoTe formatoTe;
        public static Poligonal poligonal;

        //formaberto
        List<Form> FormsList = new List<Form>();
        int FormAtivo = 0;


        public SecaoTransversal()
        {
            InitializeComponent();
            CarregarBotoesList();
            CarregarForms();
        }

        private void CarregarBotoesList()
        {
            BotoesList.Add(pBoxRetangular);
            BotoesList.Add(pBoxCircular);
            BotoesList.Add(pBoxEle);
            BotoesList.Add(pBoxTe);
            BotoesList.Add(pBoxPoligonal);
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

            //adiciona formulários na lista
            FormsList.Add(retangular);
            FormsList.Add(circular);
            FormsList.Add(formatoEle);
            FormsList.Add(formatoTe);
            FormsList.Add(poligonal);

            //adiciona o retangular no form
            pBoxRetangular_Click(null, null);
        }
        private void pBoxRetangular_Click(object sender, EventArgs e)
        {
            //muda cor do botão
            foreach (var item in BotoesList)
            {
                item.BorderStyle = BorderStyle.FixedSingle;
                item.BackColor = Color.White;
            }
            pBoxRetangular.BackColor = Color.Gainsboro;
            pBoxRetangular.BorderStyle = BorderStyle.Fixed3D;
            //adiciona form
            panelForm.Controls.Remove(FormsList[FormAtivo]);
            panelForm.Controls.Add(retangular);
            FormAtivo = 0;
            //gerar desenho e Lista
            retangular.gerarListaGeometria();
        }

        private void pBoxCircular_Click(object sender, EventArgs e)
        {            
            //muda cor do botão
            foreach (var item in BotoesList)
            {
                item.BorderStyle = BorderStyle.FixedSingle;
                item.BackColor = Color.White;
            }
            pBoxCircular.BackColor = Color.Gainsboro;
            pBoxCircular.BorderStyle = BorderStyle.Fixed3D;
            //adiciona form
            panelForm.Controls.Remove(FormsList[FormAtivo]);
            panelForm.Controls.Add(circular);
            FormAtivo = 1;
            //gerar desenho e Lista
            circular.gerarListaGeometria();
        }
    }
}
