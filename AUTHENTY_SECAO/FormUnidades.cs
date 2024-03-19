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
    public partial class FormUnidades : Form
    {
        double[] convertComp = { 1, 100, 2.54 };
        double[] convertForca = { 1, 10, 0.01, 0.0044482216 };
        double[] convertMomento = { 1, 0.01, 10, 0.1, 0.01, 0.00001, 0.0001129848, 0.0013558179 };
        double[] convertTensao = { 1, 10, 0.001, 0.1, 0.00000980665, 0.006894757 };
        double[] convertAs = { 1, 0.0001, 0.155 };
        double[] convertAsComp = { 1, 0.01, 0.3047999, 0.0254 };
        string[] arred = { "0", "0.#", "0.##", "0.###", "0.####", "0.#####", "0.######", "0.#######" };



        public FormUnidades()
        {
            InitializeComponent();
            //seleciona o default
            try
            {
               lerDefault();
            }
            catch
            {
                MessageBox.Show("Está faltando o arquivo de configuração das Unidades", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //adiciona a lista anterior
            Variaveis.UnitsAnterior.Add(comboBox1.SelectedIndex);
            Variaveis.UnitsAnterior.Add(comboBox2.SelectedIndex);
            Variaveis.UnitsAnterior.Add(comboBox3.SelectedIndex);
            Variaveis.UnitsAnterior.Add(comboBox4.SelectedIndex);
            Variaveis.UnitsAnterior.Add(comboBox5.SelectedIndex);
            Variaveis.UnitsAnterior.Add(comboBox6.SelectedIndex);

        }
        private void gravaDefaultCoeficientes()
        {
            List<string> ListaCoeficientes = new List<string>();
            ListaCoeficientes.Add("Comprimento");
            ListaCoeficientes.Add(comboBox1.SelectedIndex.ToString());
            ListaCoeficientes.Add("Força");
            ListaCoeficientes.Add(comboBox2.SelectedIndex.ToString());
            ListaCoeficientes.Add("Momento");
            ListaCoeficientes.Add(comboBox3.SelectedIndex.ToString());
            ListaCoeficientes.Add("Tensao");
            ListaCoeficientes.Add(comboBox4.SelectedIndex.ToString());
            ListaCoeficientes.Add("Area de aco");
            ListaCoeficientes.Add(comboBox5.SelectedIndex.ToString());
            ListaCoeficientes.Add("As por comprimento");
            ListaCoeficientes.Add(comboBox6.SelectedIndex.ToString());
            ListaCoeficientes.Add("Arred Comprimento");
            ListaCoeficientes.Add(comboBox7.SelectedIndex.ToString());
            ListaCoeficientes.Add("Arred Força");
            ListaCoeficientes.Add(comboBox8.SelectedIndex.ToString());
            ListaCoeficientes.Add("Arred Momento");
            ListaCoeficientes.Add(comboBox9.SelectedIndex.ToString());
            ListaCoeficientes.Add("Arred Tensao");
            ListaCoeficientes.Add(comboBox10.SelectedIndex.ToString());
            ListaCoeficientes.Add("Arred Area de aco");
            ListaCoeficientes.Add(comboBox11.SelectedIndex.ToString());
            ListaCoeficientes.Add("Arred As por comprimento");
            ListaCoeficientes.Add(comboBox12.SelectedIndex.ToString());
            ListaCoeficientes.Add("Unid Comprimento");
            ListaCoeficientes.Add(comboBox1.Text);
            ListaCoeficientes.Add("Unid Força");
            ListaCoeficientes.Add(comboBox2.Text);
            ListaCoeficientes.Add("Unid Momento");
            ListaCoeficientes.Add(comboBox3.Text);
            ListaCoeficientes.Add("Unid Tensao");
            ListaCoeficientes.Add(comboBox4.Text);
            ListaCoeficientes.Add("Unid Area de aco");
            ListaCoeficientes.Add(comboBox5.Text);
            ListaCoeficientes.Add("Unid As por comprimento");
            ListaCoeficientes.Add(comboBox6.Text);

            ListaCoeficientes.Add("ConvertComp");
            ListaCoeficientes.Add(convertComp[comboBox1.SelectedIndex].ToString());
            ListaCoeficientes.Add("ConvertForca");
            ListaCoeficientes.Add(convertForca[comboBox2.SelectedIndex].ToString());
            ListaCoeficientes.Add("ConvertMomento");
            ListaCoeficientes.Add(convertMomento[comboBox3.SelectedIndex].ToString());
            ListaCoeficientes.Add("ConvertTensao");
            ListaCoeficientes.Add(convertTensao[comboBox4.SelectedIndex].ToString());
            ListaCoeficientes.Add("ConvertAs");
            ListaCoeficientes.Add(convertAs[comboBox5.SelectedIndex].ToString());
            ListaCoeficientes.Add("ConvertAsComp");
            ListaCoeficientes.Add(convertAsComp[comboBox6.SelectedIndex].ToString());

            ListaCoeficientes.Add("arredComp");
            ListaCoeficientes.Add(arred[comboBox7.SelectedIndex].ToString());
            ListaCoeficientes.Add("arredForca");
            ListaCoeficientes.Add(arred[comboBox8.SelectedIndex].ToString());
            ListaCoeficientes.Add("arredMomento");
            ListaCoeficientes.Add(arred[comboBox9.SelectedIndex].ToString());
            ListaCoeficientes.Add("arredTensao");
            ListaCoeficientes.Add(arred[comboBox10.SelectedIndex].ToString());
            ListaCoeficientes.Add("arredAs");
            ListaCoeficientes.Add(arred[comboBox11.SelectedIndex].ToString());
            ListaCoeficientes.Add("arredAsComp");
            ListaCoeficientes.Add(arred[comboBox12.SelectedIndex].ToString());

            //escreve no arquivo
            string filename = Padroes.LocalPadraoUnidades;
            Ferramentas.EscreverArquivoEmTexto(filename, ListaCoeficientes);
        }
        private void lerDefault()
        {
            string fileDefault = Padroes.LocalPadraoUnidades;
            List<string> CoefLido = new List<string>();
            Ferramentas.LerArquivoEmTexto(fileDefault, CoefLido);

            int c1 = CoefLido.IndexOf("Comprimento");
            comboBox1.SelectedIndex = Convert.ToInt32(CoefLido[c1 + 1]);
            int c2 = CoefLido.IndexOf("Força");
            comboBox2.SelectedIndex = Convert.ToInt32(CoefLido[c2 + 1]);
            int c3 = CoefLido.IndexOf("Momento");
            comboBox3.SelectedIndex = Convert.ToInt32(CoefLido[c3 + 1]);
            int c4 = CoefLido.IndexOf("Tensao");
            comboBox4.SelectedIndex = Convert.ToInt32(CoefLido[c4 + 1]);
            int c5 = CoefLido.IndexOf("Area de aco");
            comboBox5.SelectedIndex = Convert.ToInt32(CoefLido[c5 + 1]);
            int c6 = CoefLido.IndexOf("As por comprimento");
            comboBox6.SelectedIndex = Convert.ToInt32(CoefLido[c6 + 1]);
            int c7 = CoefLido.IndexOf("Arred Comprimento");
            comboBox7.SelectedIndex = Convert.ToInt32(CoefLido[c7 + 1]);
            int c8 = CoefLido.IndexOf("Arred Força");
            comboBox8.SelectedIndex = Convert.ToInt32(CoefLido[c8 + 1]);
            int c9 = CoefLido.IndexOf("Arred Momento");
            comboBox9.SelectedIndex = Convert.ToInt32(CoefLido[c9 + 1]);
            int c10 = CoefLido.IndexOf("Arred Tensao");
            comboBox10.SelectedIndex = Convert.ToInt32(CoefLido[c10 + 1]);
            int c11 = CoefLido.IndexOf("Arred Area de aco");
            comboBox11.SelectedIndex = Convert.ToInt32(CoefLido[c11 + 1]);
            int c12 = CoefLido.IndexOf("Arred As por comprimento");
            comboBox12.SelectedIndex = Convert.ToInt32(CoefLido[c12 + 1]);

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void buttonOK_Click(object sender, EventArgs e)
        {
            gravaDefaultCoeficientes();

            //altera unidades nas variaveis
            Variaveis.unidComp = comboBox1.Text;
            Variaveis.unidForca = comboBox2.Text;
            Variaveis.unidMomento = comboBox3.Text;
            Variaveis.unidTensao = comboBox4.Text;
            Variaveis.unidAs = comboBox5.Text;
            Variaveis.unidAsComp = comboBox6.Text;

            Variaveis.convertComp = convertComp[comboBox1.SelectedIndex];
            Variaveis.convertForca = convertForca[comboBox2.SelectedIndex];
            Variaveis.convertMomento = convertMomento[comboBox3.SelectedIndex];
            Variaveis.convertTensao = convertTensao[comboBox4.SelectedIndex];
            Variaveis.convertAs = convertAs[comboBox5.SelectedIndex];
            Variaveis.convertAsComp = convertAsComp[comboBox6.SelectedIndex];

            Variaveis.arredComp = arred[comboBox7.SelectedIndex];
            Variaveis.arredForca = arred[comboBox8.SelectedIndex];
            Variaveis.arredMomento = arred[comboBox9.SelectedIndex];
            Variaveis.arredTensao = arred[comboBox10.SelectedIndex];
            Variaveis.arredAs = arred[comboBox11.SelectedIndex];
            Variaveis.arredAsComp = arred[comboBox12.SelectedIndex];


            if (!MDI.aberturaInicial)
            {
                MDI.F_Materiais.AtualizarUnidades();
            }




            this.Hide();

        }

        private void buttonSI_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
        }

        private void buttonMKS_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 2;
            comboBox3.SelectedIndex = 4;
            comboBox4.SelectedIndex = 3;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
        }

        private void buttonImperial_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 2;
            comboBox2.SelectedIndex = 3;
            comboBox3.SelectedIndex = 6;
            comboBox4.SelectedIndex = 5;
            comboBox5.SelectedIndex = 2;
            comboBox6.SelectedIndex = 2;
        }
        bool mouseClicked;
        Point clickedAt;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            mouseClicked = true;
            clickedAt = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseClicked)
            {
                this.Location = new Point(Cursor.Position.X - clickedAt.X, Cursor.Position.Y - clickedAt.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseClicked = false;
        }
        

    }
}
