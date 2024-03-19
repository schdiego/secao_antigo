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
    public partial class MDI : Form
    {
        //Variaveis independentes
        public static bool aberturaInicial = true;
        //forms
        public static FormMateriais F_Materiais;
        public static FormSecaoTransversal F_SecaoTransversal;
        public static FormArmaduras F_Armaduras;
        public static FormEsforco F_Esforcos;
        public static FormResultado F_Resultado;
        public static FormUnidades F_Unidades;
        public static EntradaDados F_Entrada;

        //formaberto
        List<Form> FormsList = new List<Form>();
        public static int FormAtivo = 0;

        //Lista de botões
        List<Button> BotoesList = new List<Button>();
        List<ToolStripMenuItem> MenuList = new List<ToolStripMenuItem>();

        public MDI()
        {
            InitializeComponent();
            CarregarBotoesList();
            CarregarForms();
            //deixar por último
            aberturaInicial = false;
            MDI_Resize(null, null);
        }
        private void CarregarBotoesList()
        {
            BotoesList.Add(btnMateriais);
            BotoesList.Add(btnSecaoTransversal);
            BotoesList.Add(btnArmaduras);
            BotoesList.Add(btnEsforcos);
            BotoesList.Add(btnResultado);
            //botoes do menu
            MenuList.Add(fileMenu);
            MenuList.Add(unidadesItem);
            MenuList.Add(idiomaItem);
            MenuList.Add(helpMenu);
        }


        private void CarregarForms()
        {
            //carregar unidades
            F_Unidades = new FormUnidades();
            F_Unidades.buttonOK_Click(null, null);
            //materiais
            F_Materiais = new FormMateriais();
            F_Materiais.TopLevel = false;
            F_Materiais.Visible = true;
            //seção transversal
            F_SecaoTransversal = new FormSecaoTransversal();
            F_SecaoTransversal.TopLevel = false;
            F_SecaoTransversal.Visible = true;
            //armaaduras
            F_Armaduras = new FormArmaduras();
            F_Armaduras.TopLevel = false;
            F_Armaduras.Visible = true;

            F_Entrada = new EntradaDados();
            F_Entrada.TopLevel = false;
            F_Entrada.Visible = true;



            panel1.Controls.Add(F_Materiais);






            //adiciona formulários na lista
            FormsList.Add(F_Materiais);
            FormsList.Add(F_SecaoTransversal);
            FormsList.Add(F_Armaduras);
            FormsList.Add(F_Esforcos);
            FormsList.Add(F_Resultado);
            FormsList.Add(F_Entrada);
        }

        private void unidadesItem_Click(object sender, EventArgs e)
        {
            using(Form Unidades = new FormUnidades())
            {
                Unidades.ShowDialog();
            }
        }

        private void btnMateriais_Click(object sender, EventArgs e)
        {
            //muda cor do botão
            foreach (var item in BotoesList)
            {
                item.BackColor = Color.FromArgb(50, 148, 213);
            }
            btnMateriais.BackColor = Color.FromArgb(126, 188, 228);
            //ativaFormulário
            panel1.Controls.Remove(FormsList[FormAtivo]);
            panel1.Controls.Add(F_Materiais);
            //ativa o numero do formulário
            FormAtivo = 0;

        }

        private void btnSecaoTransversal_Click(object sender, EventArgs e)
        {
            //muda cor do botão
            foreach (var item in BotoesList)
            {
                item.BackColor = Color.FromArgb(50, 148, 213);
            }
            btnSecaoTransversal.BackColor = Color.FromArgb(126, 188, 228);
            //ativaFormulário
            F_SecaoTransversal.Dock = DockStyle.Fill;
            panel1.Controls.Remove(FormsList[FormAtivo]);
            panel1.Controls.Add(F_SecaoTransversal);
            //ativa o formulário
            FormAtivo = 1;

        }
        private void btnArmaduras_Click(object sender, EventArgs e)
        {
            //muda cor do botão
            foreach (var item in BotoesList)
            {
                item.BackColor = Color.FromArgb(50, 148, 213);
            }
            btnArmaduras.BackColor = Color.FromArgb(126, 188, 228);
            //ativaFormulário
            panel1.Controls.Remove(FormsList[FormAtivo]);
            panel1.Controls.Add(F_Armaduras);
            F_Armaduras.desenharSecao();
            //ativa o numero do formulário
            FormAtivo = 2;
        }
        private void fileMenu_MouseEnter(object sender, EventArgs e)
        {
            //muda cor do texto dos outros botões
            foreach (var item in MenuList)
            {
                item.ForeColor = Color.White;
            }
            fileMenu.ForeColor = Color.Black;
        }

        private void fileMenu_MouseLeave(object sender, EventArgs e)
        {
            if (!menuDropOpen)
            {
                fileMenu.ForeColor = Color.White;
            }
        }

        private void unidadesItem_MouseEnter(object sender, EventArgs e)
        {
            //muda cor do texto dos outros botões
            foreach (var item in MenuList)
            {
                item.ForeColor = Color.White;
            }
            unidadesItem.ForeColor = Color.Black;
        }

        private void unidadesItem_MouseLeave(object sender, EventArgs e)
        {
            if (!menuDropOpen)
            {
                unidadesItem.ForeColor = Color.White;
            } 
        }

        private void idiomaItem_MouseEnter(object sender, EventArgs e)
        {
            //muda cor do texto dos outros botões
            foreach (var item in MenuList)
            {
                item.ForeColor = Color.White;
            }
            idiomaItem.ForeColor = Color.Black;
        }

        private void idiomaItem_MouseLeave(object sender, EventArgs e)
        {
            if (!menuDropOpen)
            {
                idiomaItem.ForeColor = Color.White;
            }
              
        }

        private void helpMenu_MouseEnter(object sender, EventArgs e)
        {
            //muda cor do texto dos outros botões
            foreach (var item in MenuList)
            {
                item.ForeColor = Color.White;
            }
            helpMenu.ForeColor = Color.Black;
        }

        private void helpMenu_MouseLeave(object sender, EventArgs e)
        {
            if (!menuDropOpen)
            {  
                helpMenu.ForeColor = Color.White;
            }
                
        }

        bool menuDropOpen;

        private void Item_DropDownOpened(object sender, EventArgs e)
        {
            menuDropOpen = true;
        }

        private void Item_DropDownClosed(object sender, EventArgs e)
        {
            menuDropOpen = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Variaveis.CoordenadasPontos.Clear();
            //Variaveis.CoordenadasPontos = Discretizacao.CoordenadasPontos(Variaveis.GeometriaList, Variaveis.TamElemento);
            //Desenhos.DesenhaRetangulos(Variaveis.CoordenadasPontos, MDI.F_SecaoTransversal.pBoxDesenho);
            //Calculos.ListaDiscretizacao();
            //Desenhos.DesenhaBarras(Variaveis.ListBarrasPassivas);
            //Variaveis.ListConcreto.Clear();
            //Discretizacao.CriarListaConcreto();
            panel1.Controls.Remove(FormsList[FormAtivo]);
            panel1.Controls.Add(F_Entrada);
            //ativa o numero do formulário
            FormAtivo = 5;


        }

        private void MDI_Resize(object sender, EventArgs e)
        {
            //formSeção Transversal

            //form Armaduras
            F_Armaduras.Height = panel1.Height;
            F_Armaduras.Width = panel1.Width;


            FormSecaoTransversal.poligonal.ResizeForm();
            Variaveis.FormDesenhoWidth = F_SecaoTransversal.pBoxDesenho.Width;
            Variaveis.FormDesenhoHeight = F_SecaoTransversal.pBoxDesenho.Height;
            Variaveis.F_DesenhoSecao.Resize(Variaveis.FormDesenhoWidth, Variaveis.FormDesenhoHeight);
        }


    }
}
