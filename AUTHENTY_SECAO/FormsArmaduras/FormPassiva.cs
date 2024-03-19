using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AUTHENTY_SECAO.ClassesListas;

namespace AUTHENTY_SECAO.FormsArmaduras
{
    public partial class FormPassiva : UserControl
    {
        public FormPassiva()
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

        private void dgvTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dgvTable.Rows[e.RowIndex - 1].Cells[0].Value = dgvTable.Rows.Count - 1;
        }

        int selectedRowIndex;

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRowIndex = e.RowIndex;
        }

        public void ApagarLinha_Passiva()
        {
            //apagar linha
            if (dgvTable.Rows.Count != 1 & selectedRowIndex + 1 != dgvTable.Rows.Count)
            {
                dgvTable.Rows.Remove(dgvTable.Rows[selectedRowIndex]);
            }
            //renumerar id
            for (int i = 0; i < dgvTable.Rows.Count - 1; i++)
            {
                dgvTable.Rows[i].Cells[0].Value = i + 1;
            }
            //remover ultimo número do vertice
            dgvTable.Rows[dgvTable.Rows.Count - 1].Cells[0].Value = "";
        }
        public void gerarListaGeometria()
        {
            
            //limparLista
            Variaveis.ListBarrasPassivas.Clear();
            //Gerar lista
            for (int i = 0; i < dgvTable.Rows.Count-1; i++)
            {
                double areaBarra = Math.PI * Math.Pow(Convert.ToDouble(dgvTable.Rows[i].Cells[1].Value), 2) / 4;
                Variaveis.ListBarrasPassivas.Add(new DiscretizacaoList(Convert.ToDouble(dgvTable.Rows[i].Cells[2].Value), Convert.ToDouble(dgvTable.Rows[i].Cells[3].Value), areaBarra));
            }
            //gerar lista para desenho
            for (int i = 0; i < dgvTable.Rows.Count - 1; i++)
            {
                Variaveis.ArmPassivasList.Add(new PointF(Convert.ToSingle(dgvTable.Rows[i].Cells[2].Value), Convert.ToSingle(dgvTable.Rows[i].Cells[3].Value)));
            }

        }

        private void dgvTable_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            gerarListaGeometria();
            MDI.F_Armaduras.desenharSecao();
        }
    }
}
