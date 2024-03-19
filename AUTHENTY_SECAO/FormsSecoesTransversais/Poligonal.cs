using AUTHENTY_SECAO.Classes;
using AUTHENTY_SECAO.ClassesListas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AUTHENTY_SECAO.FormsSecoesTransversais
{
    public partial class Poligonal : Form
    {
        public Poligonal()
        {
            InitializeComponent();
            ConfigurarTabela();
        }
        private void ConfigurarTabela()
        {
            //mudar backcolor header
            dgvTable.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            dgvTable.EnableHeadersVisualStyles = false;
            //desabilitar filtro
            foreach (DataGridViewColumn column in dgvTable.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //desabilita resizable rows
            dgvTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvTable.AllowUserToResizeRows = false;
        }
        public void gerarListaGeometria()
        {
            //limparLista
            Variaveis.GeometriaList.Clear();
            //Gerar lista

            List<DiscretizacaoList> GeometriaListaInterna = new List<DiscretizacaoList>();

            for (int i = 0; i < dgvTable.Rows.Count; i++)
            {
                GeometriaListaInterna.Add(new DiscretizacaoList(Convert.ToDouble(dgvTable.Rows[i].Cells[1].Value), Convert.ToDouble(dgvTable.Rows[i].Cells[2].Value), 0));
            }
            Variaveis.GeometriaList = GeometriaListaInterna;

        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            gerarListaGeometria();
            MDI.F_SecaoTransversal.desenharSecao();

        }

        private void dgvTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvTable.Rows[e.RowIndex - 1].Cells[0].Value = dgvTable.Rows.Count - 1;
        }

        int selectedRowIndex;

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
        }

        private void btnApagarLinha_Click(object sender, EventArgs e)
        {
            //apagar linha
            if(dgvTable.Rows.Count != 1 & selectedRowIndex + 1 != dgvTable.Rows.Count)
            {
                dgvTable.Rows.Remove(dgvTable.Rows[selectedRowIndex]);
            }
            //renumerar vertices
            for (int i = 0; i < dgvTable.Rows.Count - 1; i++)
            {
                dgvTable.Rows[i].Cells[0].Value = i + 1;
            }
            //remover ultimo número do vertice
            dgvTable.Rows[dgvTable.Rows.Count - 1].Cells[0].Value = "";
        }
        public void ResizeForm()
        {
            this.Height = MDI.F_SecaoTransversal.panelForm.Height;
        }
    }
}
