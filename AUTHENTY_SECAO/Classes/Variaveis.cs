using AUTHENTY_SECAO.ClassesListas;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUTHENTY_SECAO
{
    class Variaveis
    {
        public static double AlturaViga { get; set; }
        public static double LarguraViga { get; set; }
        public static double fck { get; set; }
        public static double fcd { get; set; }
        public static double Beta { get; set; }
        public static double fyk { get; set; }
        public static double fyd { get; set; }
        public static double Es { get; set; }
        public static double Ec { get; set; }
        public static double angulo { get; set; }
        public static double NSd { get; set; }

        public static double NcRd { get; set; }
        public static double NtRd { get; set; }
        public static double epsilonCu { get; set; } //convenção = negativo é compressão (ou deformação de compressão no concreto).
        public static double epsilonC2 = -0.002; 
        public static double epsilonAs { get; set; }
        public static double epsilonAsFy = 0.002;
        public static double TamElemento = 1;
        public static double TamElementoFinalX;
        public static double TamElementoFinalY;
        public static double areaPoligono;
        public static double tolerancia = 0.1;

        public static double GamaF3 = 1.0;
        public static double GamaC { get; set; }
        public static double GamaS { get; set; }

        //calculos

        public static double LN { get; set; }

        public static List<DiscretizacaoList> ListConcreto = new List<DiscretizacaoList>();
        public static List<DiscretizacaoList> ListBarrasPassivas = new List<DiscretizacaoList>();
        public static List<DiscretizacaoList> ListBarrasAtivas = new List<DiscretizacaoList>();
        public static List<DiscretizacaoList> ListBarrasGFRP = new List<DiscretizacaoList>();
        public static List<DiscretizacaoList> GeometriaList = new List<DiscretizacaoList>();
        public static List<DiscretizacaoList> CoordenadasPontos = new List<DiscretizacaoList>();
        public static List<DiscretizacaoList> CoordenadasGrafico = new List<DiscretizacaoList>();

        public static List<DiscretizacaoList> CG = new List<DiscretizacaoList>();
        public static List<double> DeformacoesConcreto = new List<double>();
        public static List<double> DeformacoesBarras = new List<double>();
        public static List<TensaoList> TensoesConcreto = new List<TensaoList>();
        public static List<TensaoList> TensoesAco = new List<TensaoList>();
        public static List<TensaoList> TensoesConcretoPosAco = new List<TensaoList>();
        //Listas com o CG correto
        public static List<DiscretizacaoList> ListaGeometriaCG = new List<DiscretizacaoList>();
        public static  List<DiscretizacaoList> ListaConcretoCG = new List<DiscretizacaoList>();
        public static List<DiscretizacaoList> ListaBarrasPassivasCG = new List<DiscretizacaoList>();
        public static List<DiscretizacaoList> ListaBarrasAtivasCG = new List<DiscretizacaoList>();
        public static List<DiscretizacaoList> ListaBarrasGFRP_CG = new List<DiscretizacaoList>();

        //UNIDADES
        public static List<int> UnitsAnterior = new List<int>();
        public static string unidComp { get; set; }
        public static string unidForca { get; set; }
        public static string unidMomento { get; set; }
        public static string unidTensao { get; set; }
        public static string unidAs { get; set; }
        public static string unidAsComp { get; set; }
        public static double convertComp { get; set; }
        public static double convertForca { get; set; }
        public static double convertMomento { get; set; }
        public static double convertTensao { get; set; }
        public static double convertAs { get; set; }
        public static double convertAsComp { get; set; }
        public static string arredComp { get; set; }
        public static string arredForca { get; set; }
        public static string arredMomento { get; set; }
        public static string arredTensao { get; set; }
        public static string arredAs { get; set; }
        public static string arredAsComp { get; set; }

        //SALVAR, ABRIR E FECHAR
        //salvar e abrir
        public static List<string> TextoSalvarListAnterior = new List<string>();
        public static List<string> TextoSalvarListAtual = new List<string>();
        public static List<string> TextoAbrirArquivo = new List<string>();
        public static List<string> TextoNovoArquivo = new List<string>();
        public static string fileName = "Novo Arquivo";
        public static bool fechar;
        public static int Abrindo = 0;

        //email
        public static string emailLogado;

        // desenhos

        public static FormDesenho F_DesenhoSecao;
        public static FormDesenho F_DesenhoArmadura;
        public static List<PointF> PoligonaisList = new List<PointF>();
        public static List<PointF> PoligonaisListZoom = new List<PointF>();
        public static List<PointF> ArmPassivasList = new List<PointF>();
        public static List<PointF> ArmPassivaListZoom = new List<PointF>();
        public static List<PointF> ArmAtivasList = new List<PointF>();
        public static List<PointF> ArmAtivasListZoom = new List<PointF>();
        public static List<PointF> ArmGFRPList = new List<PointF>();
        public static List<PointF> ArmGFRPListZoom = new List<PointF>();

        public static PointF PontoXY_Tela;
        public static float FatorZoomGlobal;
        //Lista de todos os desenhos
        public static List<ClassesListas.ListDesenho> DesenhosListaCompleta = new List<ClassesListas.ListDesenho>();


        public static int FormDesenhoHeight { get; set; }
        public static int FormDesenhoWidth{ get; set; }
    }
}
