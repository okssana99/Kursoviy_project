using ConfectioneryDepartmentApp.AppCode;
using ConfectioneryDepartmentApp.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfectioneryDepartmentApp.Forms.Controls {
  public partial class SupplyInvoicesFinishForm : Form {
    private int _selectedRowIndex = 0;
    private SupplyInvoicesProvider _SupplyInvoicesProvider = new SupplyInvoicesProvider();
    private SupplyInvoices _SelectSupplyInvoices = new SupplyInvoices();
    private List<SupplyInvoices> _SupplyItems = new List<SupplyInvoices>();
    private SupplyItemsProvider _SupplyItemsProvider = new SupplyItemsProvider();
    private List<SupplyItems> _SupplyItemsL = new List<SupplyItems>();
    private Validations _validation = new Validations();

    private RaportBLL _RaportBLL = new RaportBLL();

    public SupplyInvoicesFinishForm() {
      InitializeComponent();
      DataLoad();
      SupplyInvoicesGridView_CellClick(SupplyInvoicesGridView, new DataGridViewCellEventArgs(1, 0));
    }

    private void SupplyInvoicesGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      // Якщо немає жодного рядка або це службовий рядок без даних
      if (SupplyInvoicesGridView.Rows.Count == 0 ||
          _SupplyItems[0].Message == NamesMy.NoDataNames.NoDataInSupplyInvoices ||
          e.RowIndex < 0) {
        SupplyItemsGridView.Columns.Clear();
        SupplyItemsGridView.Refresh();
        TotalPriceTBox.Clear();
        NotesTBox.Clear();
        TotalPurchasesLbl.Text = "Сума всіх постачань постачальника: 0.00";
        return;
      }

      int SelectedSupplyInvoicesId = Convert.ToInt32(SupplyInvoicesGridView[0, e.RowIndex].Value.ToString());
      _SelectSupplyInvoices = _SupplyInvoicesProvider.SelectedSupplyById(SelectedSupplyInvoicesId);
      _SupplyItemsL = _SupplyItemsProvider.GetAllSupplyItemsBySupplyId(_SelectSupplyInvoices.SupplyId);
      LoadDataInSupplyItemsL(_SupplyItemsL);
      TotalPriceTBox.Text = _SelectSupplyInvoices.ManualTotal.ToString();
      NotesTBox.Text = _SelectSupplyInvoices.Notes;
      TotalPurchasesLbl.Text = "Сума всіх постачань постачальника: " +
     _RaportBLL.GetTotalAmountForSupplier(_SelectSupplyInvoices.SupplyId).ToString();
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити це постачання?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _SupplyItemsProvider.DeleteSupplyItemsBySupplyId(_SelectSupplyInvoices.SupplyId);
        _SupplyInvoicesProvider.DeleteSupply(_SelectSupplyInvoices.SupplyId);
        _SupplyItemsL.Clear();
        DataLoad();
        SupplyInvoicesGridView_CellClick(SupplyInvoicesGridView, new DataGridViewCellEventArgs(1, 0));
        MessageBox.Show("Постачання видалено!");
      }
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (SupplyInvoicesGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = SupplyInvoicesGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _SupplyItems = _SupplyInvoicesProvider.GetFinishedSupplies();
        LoadDataInSupplyInvoicesGridView(_SupplyItems);
        if (_selectedRowIndex == SupplyInvoicesGridView.Rows.Count) {
          _selectedRowIndex = SupplyInvoicesGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          SupplyInvoicesGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          SupplyInvoicesGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInSupplyInvoicesGridView(List<SupplyInvoices> SupplyItems) {
      SupplyInvoicesGridView.DataSource = null;
      SupplyInvoicesGridView.Columns.Clear();
      SupplyInvoicesGridView.AutoGenerateColumns = false;
      SupplyInvoicesGridView.RowHeadersVisible = false;

      SupplyInvoicesGridView.DataSource = SupplyItems;

      if (SupplyItems.Count > 0) {
        if (SupplyItems[0].Message == NamesMy.NoDataNames.NoDataInSupplyInvoices) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = SupplyInvoicesGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          SupplyInvoicesGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn SupplyIdColumn = new DataGridViewTextBoxColumn();
          SupplyIdColumn.DataPropertyName = "SupplyId";
          SupplyInvoicesGridView.Columns.Add(SupplyIdColumn);
          SupplyInvoicesGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          SupplyInvoicesGridView.Columns.Add(numberColumn);

          DataGridViewColumn DueDtColumn = new DataGridViewTextBoxColumn();
          DueDtColumn.HeaderText = "Термін";
          DueDtColumn.DataPropertyName = "DueDt";
          DueDtColumn.DefaultCellStyle.Format = "dd.MM.yyyy";
          DueDtColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          DueDtColumn.Width = 110;
          SupplyInvoicesGridView.Columns.Add(DueDtColumn);

          DataGridViewColumn FIOColumn = new DataGridViewTextBoxColumn();
          FIOColumn.HeaderText = "Постачальник";
          FIOColumn.DataPropertyName = "SupplierName";
          FIOColumn.Width = 305;
          SupplyInvoicesGridView.Columns.Add(FIOColumn);
        }
        for (int i = 0; i < SupplyInvoicesGridView.Columns.Count; i++) {
          SupplyInvoicesGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void LoadDataInSupplyItemsL(List<SupplyItems> AllSupplyItems) {
      SupplyItemsGridView.DataSource = null;
      SupplyItemsGridView.Columns.Clear();
      SupplyItemsGridView.AutoGenerateColumns = false;
      SupplyItemsGridView.RowHeadersVisible = false;

      SupplyItemsGridView.DataSource = AllSupplyItems;

      if (AllSupplyItems.Count > 0) {
        DataGridViewColumn UsersIdColumn = new DataGridViewTextBoxColumn();
        UsersIdColumn.DataPropertyName = "ProductId";
        UsersIdColumn.Name = "ProductId";
        SupplyItemsGridView.Columns.Add(UsersIdColumn);
        SupplyItemsGridView.Columns[0].Visible = false;

        DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
        numberColumn.HeaderText = "№ з/п";
        numberColumn.DataPropertyName = "Number";
        numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        numberColumn.Width = NamesMy.SizeOptins.NumberSize;
        SupplyItemsGridView.Columns.Add(numberColumn);

        DataGridViewColumn ProductNameColumn = new DataGridViewTextBoxColumn();
        ProductNameColumn.HeaderText = "Продукція";
        ProductNameColumn.DataPropertyName = "ProductName";
        ProductNameColumn.Name = "ProductName";
        ProductNameColumn.Width = 320;
        SupplyItemsGridView.Columns.Add(ProductNameColumn);

        DataGridViewColumn QtyColumn = new DataGridViewTextBoxColumn();
        QtyColumn.HeaderText = "Кількість";
        QtyColumn.DataPropertyName = "Qty";
        QtyColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        QtyColumn.Width = 80;
        SupplyItemsGridView.Columns.Add(QtyColumn);

        DataGridViewColumn UnitCostColumn = new DataGridViewTextBoxColumn();
        UnitCostColumn.HeaderText = "Ціна закупівлі";
        UnitCostColumn.DataPropertyName = "UnitCost";
        UnitCostColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        UnitCostColumn.Width = 120;
        SupplyItemsGridView.Columns.Add(UnitCostColumn);

        for (int i = 0; i < SupplyItemsGridView.Columns.Count; i++) {
          SupplyItemsGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }


  }
}
