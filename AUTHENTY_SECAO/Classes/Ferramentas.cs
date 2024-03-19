using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTHENTY_SECAO
{
    class Ferramentas
    {
        public static void EscreverArquivoEmTexto(string Filename, List<string> lista)
        {
            //escreve no arquivo
            StreamWriter file = new StreamWriter(Filename);
            foreach (var item in lista)
            {
                file.WriteLine(item);
            }
            file.Dispose();
        }
        public static void LerArquivoEmTexto(string Filename, List<string> lista)
        {

            string[] TextoLido = File.ReadAllLines(Filename);

            foreach (var item in TextoLido)
            {
                lista.Add(item);
            }

        }
        /*
   public static void Save(string fileName)
   {

       if (fileName == "Novo Arquivo")
       {
           SaveAs("flx");

       }
       else
       {
           if (VerificaAlteracoes() == true)
           {
               EscreverNoArquivo(fileName);
           }

       }


   }




   //quando gravar o arquivo iguala o stringList atual e anterior
   public static void igualaArquivoSalvar()
   {
      Variaveis.TextoSalvarListAnterior.Clear();
       foreach (var item in Variaveis.TextoSalvarListAtual)
       {
          Variaveis.TextoSalvarListAnterior.Add(item);
       }

   }
   private static void EscreverNoArquivo(string fileName)
   {
       StreamWriter file = new StreamWriter(fileName);
       SalvarTexto(file);
       file.Dispose();
       igualaArquivoSalvar();
   }

   static int cont = 0;
   public static void LerArquivo(string fileName)
   {

       cont += 1;

       string[] TextoLido = File.ReadAllLines(fileName);
       if (Variaveis.TextoAbrirArquivo.Count > 0)
       {
           Variaveis.TextoAbrirArquivo.Clear();
       }
       foreach (var item in TextoLido)
       {
           Variaveis.TextoAbrirArquivo.Add(item);
       }

   }

       //SALVAR COMO
   public static void SaveAs(string extensao)
   {
       SaveFileDialog saveFileDialog1 = new SaveFileDialog();

       saveFileDialog1.Filter = extensao + " files (*." + extensao + ")|*." + extensao + "|All files (*.*)|*.*";
       saveFileDialog1.FilterIndex = 1;
       saveFileDialog1.RestoreDirectory = true;
       saveFileDialog1.FileName = Principal_form.Identificacao;

       if (saveFileDialog1.ShowDialog() == DialogResult.OK)
       {
           string Filename = saveFileDialog1.FileName.ToString();
           Principal_form.FILENAME = Filename;
           EscreverNoArquivo(Filename);
       }
       else
       {                
           Principal_form.fechar = false;
       }

   }
   public static void SalvarTexto(StreamWriter file)
   {

       foreach (var item in Variaveis.TextoSalvarListAtual)
       {
           file.WriteLine(item);
       }
   }

   public static bool VerificaAlteracoes()
   {
       bool alterou = false;
       Debug.WriteLine(">>>Verificando Alterações<<<");
       int i = 0;
       while (alterou == false)
       {

           if (i == Variaveis.TextoSalvarListAtual.Count || i ==Variaveis.TextoSalvarListAnterior.Count)

               break;

           if (Variaveis.TextoSalvarListAtual[i] ==Variaveis.TextoSalvarListAnterior[i])
           {
               alterou = false;
           }
           else
           {
               alterou = true;
           }


           i++;

       }
       Debug.WriteLine(alterou);
       return alterou;
   }
   public static void newTool(string NomePrograma)
   {
       if (VerificaAlteracoes() == true)
       {
           if (contarSaida == 0)
           {
               var result = MessageBox.Show("Você quer salvar as alterações?", NomePrograma,
               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
               switch (result)
               {
                   case DialogResult.Yes:
                       contarSaida = 0;
                       Save(Principal_form.FILENAME);
                       Principal_form.fechar = true;
                       Reinicia();
                       Principal_form.formPrincipal.tabPage.SelectedIndex = 0;
                       break;
                   case DialogResult.No:
                       contarSaida = 0;
                       Principal_form.fechar = true;
                       Reinicia();
                       Principal_form.formPrincipal.tabPage.SelectedIndex = 0;
                       break;
                   case DialogResult.Cancel:
                       contarSaida = 0;
                       Principal_form.fechar = false;
                       break;
               }
           }
       }
       contarSaida = 0;
       Principal_form.fechar = true;
       Reinicia();
       Principal_form.formPrincipal.tabPage.SelectedIndex = 0;
   }
   private static void Reinicia()
   {
       Principal_form.formPrincipal.rtBox1.Visible = false;
       Principal_form.frm.rtBox1.Visible = false;
       Principal_form.FILENAME = "Novo Arquivo";
       Principal_form.frm.inicializaLaje();
       Principal_form.formPrincipal.inicializar();
       Principal_form.formPrincipal.rtBox1.Visible = true;
       Principal_form.frm.rtBox1.Visible = true;

   }

   public static int contarSaida = 0;
   public static void Close(string NomePrograma, string fileName)
   {
       try
       {
           if (VerificaAlteracoes() == true)
           {

               if (contarSaida == 0)
               {
                   var result = MessageBox.Show("Você quer salvar as alterações?", NomePrograma,
                   MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                   switch (result)
                   {
                       case DialogResult.Yes:
                           contarSaida = 1;
                           Save(Principal_form.FILENAME);
                           if (Principal_form.fechar == true)
                           {
                               Principal_form.fechar = true;
                               Application.Exit();
                           }
                           else
                           {
                               contarSaida = 0;
                               Principal_form.fechar = false;
                           }
                           break;
                       case DialogResult.No:
                           contarSaida = 1;
                           Principal_form.fechar = true;
                           Application.Exit();
                           break;
                       case DialogResult.Cancel:
                           contarSaida = 0;
                           Principal_form.fechar = false;
                           break;
                   }

               }
           }
           else
           {
               Application.Exit();
           }
       }
       catch
       {
           MessageBox.Show("Ocorreu um erro", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
           Application.Exit();
       }

   }
   public static void LerArquivoAbrir(string extensao)
   {
       OpenFileDialog openFile = new OpenFileDialog();
       openFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
       openFile.Filter = extensao + " files (*." + extensao + ")|*." + extensao + "|All files (*.*)|*.*";
       if (openFile.ShowDialog() == DialogResult.OK)
       {
           string Filename = openFile.FileName.ToString();

           LerArquivo(Filename);
           string VersaoSoftwareString = AppConfig.versao;
           string VersaoArquivoString = VariaveisSalvar.TextoAbrirArquivo[0];
           double VersaoSoftware = Convert.ToDouble(VersaoSoftwareString.Substring(0, 3));
           double VersaoArquivo = Convert.ToDouble(VersaoArquivoString.Substring(0, 3));

           if (VersaoArquivo <= VersaoSoftware)//verifica versão
           {
               Principal_form.FILENAME = Filename;
               Principal_form.formPrincipal.ColarDadosAbrir();
               Principal_form.formPrincipal.AlteraTituloFormSeSalvo();
               Principal_form.formPrincipal.atualizarUnidade();
               Principal_form.formPrincipal.diametrosArmaduras();
               Principal_form.formPrincipal.atualiza_variaveis();
               Principal_form.frm.atualizarUnidadeLaje();
               Principal_form.frm.atualiza_variaveis();
           }
           else
           {
               var result = MessageBox.Show("Arquivo salvo em versão mais recente \n"
                   + "Versão do Arquivo - " + VersaoArquivoString + "\n"
                   + "Versão do Software - " + VersaoSoftwareString + "\n",
                   "ERRO VERSÃO", MessageBoxButtons.OK, MessageBoxIcon.Error);

           }


       }

   }



   public static Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
   {
       Bitmap result = new Bitmap(width, height);
       using (Graphics g = Graphics.FromImage(result))
       {
           g.DrawImage(bmp, 0, 0, width, height);
       }

       return result;
   }
   */
    }
}
