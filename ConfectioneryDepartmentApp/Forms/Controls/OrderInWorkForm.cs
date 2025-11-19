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
  public partial class OrderInWorkForm : Form {
    private int _selectedRowIndex = 0;
    private OrderProvider _OrderProvider = new OrderProvider();
    private Order _SelectOrder = new Order();
    private List<Order> _OrderItem = new List<Order>();
    private OrderItemProvider _OrderItemProvider = new OrderItemProvider();
    private List<OrderItem> _OrderItemL = new List<OrderItem>();
    private Validations _validation = new Validations();

    private RaportBLL _RaportBLL = new RaportBLL();

    public OrderInWorkForm() {
      InitializeComponent();
      DataLoad();
      OrderGridView_CellClick(OrderGridView, new DataGridViewCellEventArgs(1, 0));
    }

    private void OrderGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      // Якщо немає жодного рядка або це службовий рядок без даних
      if (OrderGridView.Rows.Count == 0 ||
          _OrderItem[0].Message == NamesMy.NoDataNames.NoDataInOrders ||
          e.RowIndex < 0) {
        OrderItemGridView.Columns.Clear();
        OrderItemGridView.Refresh();
        TotalPriceTBox.Clear();
        NotesTBox.Clear();
        TotalPurchasesLbl.Text = "Сума всіх закупівель клієнта: 0.00";
        return;
      }

      int SelectedOrderId = Convert.ToInt32(OrderGridView[0, e.RowIndex].Value.ToString());
      _SelectOrder = _OrderProvider.SelectedOrderById(SelectedOrderId);
      _OrderItemL = _OrderItemProvider.GetAllOrderItemsByOrderId(_SelectOrder.OrderId);
      LoadDataInOrderItemL(_OrderItemL);
      TotalPriceTBox.Text = _SelectOrder.ManualTotal.ToString();
      NotesTBox.Text = _SelectOrder.Notes;
      TotalPurchasesLbl.Text = "Сума всіх закупівель клієнта: " +
     _RaportBLL.GetTotalAmountForCustomer(_SelectOrder.CustomerId).ToString();
    }

    private void IssuedBtn_Click(object sender, EventArgs e) {
      if (!IsDataEnteringCorrect()) return;

      // Отримати позиції замовлення
      var items = _OrderItemProvider.GetAllOrderItemsByOrderId(_SelectOrder.OrderId);

      // Спробувати видати замовлення з перевіркою залишків і списанням
      string msg;
      bool ok = _OrderProvider.TryIssueOrderAndDeductStock(_SelectOrder.OrderId, items, out msg);

      // Повідомлення користувачу та оновлення UI
      if (!ok) {
        MessageBox.Show(msg, "Видача неможлива", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      // Якщо успіх — перезавантажуємо дані і повідомляємо
      _OrderItemL.Clear();
      DataLoad();
      OrderGridView_CellClick(OrderGridView, new DataGridViewCellEventArgs(1, 0));
      MessageBox.Show("Замовлення підтверджено!");
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити це замовлення?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _OrderItemProvider.DeleteOrderItemsByOrderId(_SelectOrder.OrderId);
        _OrderProvider.DeleteOrder(_SelectOrder.OrderId);
        _OrderItemL.Clear();
        DataLoad();
        OrderGridView_CellClick(OrderGridView, new DataGridViewCellEventArgs(1, 0));
        MessageBox.Show("Замовлення видалено!");
      }
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (OrderGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = OrderGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _OrderItem = _OrderProvider.GetOrdersByStatus();
        LoadDataInOrderGridView(_OrderItem);
        if (_selectedRowIndex == OrderGridView.Rows.Count) {
          _selectedRowIndex = OrderGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          OrderGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          OrderGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInOrderGridView(List<Order> OrderItem) {
      OrderGridView.DataSource = null;
      OrderGridView.Columns.Clear();
      OrderGridView.AutoGenerateColumns = false;
      OrderGridView.RowHeadersVisible = false;

      OrderGridView.DataSource = OrderItem;

      if (OrderItem.Count > 0) {
        if (OrderItem[0].Message == NamesMy.NoDataNames.NoDataInOrders) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = OrderGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          OrderGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn OrderIdColumn = new DataGridViewTextBoxColumn();
          OrderIdColumn.DataPropertyName = "OrderId";
          OrderGridView.Columns.Add(OrderIdColumn);
          OrderGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          OrderGridView.Columns.Add(numberColumn);

          DataGridViewColumn OrderDateColumn = new DataGridViewTextBoxColumn();
          OrderDateColumn.HeaderText = "Дата замовлення";
          OrderDateColumn.DataPropertyName = "OrderDt";
          OrderDateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";
          OrderDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          OrderDateColumn.Width = 110;
          OrderGridView.Columns.Add(OrderDateColumn);

          DataGridViewColumn FIOColumn = new DataGridViewTextBoxColumn();
          FIOColumn.HeaderText = "Клієнт";
          FIOColumn.DataPropertyName = "FullName";
          FIOColumn.Width = 305;
          OrderGridView.Columns.Add(FIOColumn);
        }
        for (int i = 0; i < OrderGridView.Columns.Count; i++) {
          OrderGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void LoadDataInOrderItemL(List<OrderItem> AllOrderItem) {
      OrderItemGridView.DataSource = null;
      OrderItemGridView.Columns.Clear();
      OrderItemGridView.AutoGenerateColumns = false;
      OrderItemGridView.RowHeadersVisible = false;

      OrderItemGridView.DataSource = AllOrderItem;

      if (AllOrderItem.Count > 0) {
        DataGridViewColumn UsersIdColumn = new DataGridViewTextBoxColumn();
        UsersIdColumn.DataPropertyName = "ProductId";
        UsersIdColumn.Name = "ProductId";
        OrderItemGridView.Columns.Add(UsersIdColumn);
        OrderItemGridView.Columns[0].Visible = false;

        DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
        numberColumn.HeaderText = "№ з/п";
        numberColumn.DataPropertyName = "Number";
        numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        numberColumn.Width = NamesMy.SizeOptins.NumberSize;
        OrderItemGridView.Columns.Add(numberColumn);

        DataGridViewColumn ProductNameColumn = new DataGridViewTextBoxColumn();
        ProductNameColumn.HeaderText = "Продукція";
        ProductNameColumn.DataPropertyName = "ProductName";
        ProductNameColumn.Name = "ProductName";
        ProductNameColumn.Width = 320;
        OrderItemGridView.Columns.Add(ProductNameColumn);

        DataGridViewColumn QtyColumn = new DataGridViewTextBoxColumn();
        QtyColumn.HeaderText = "Кількість";
        QtyColumn.DataPropertyName = "Qty";
        QtyColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        QtyColumn.Width = 80;
        OrderItemGridView.Columns.Add(QtyColumn);

        DataGridViewColumn UnitPriceColumn = new DataGridViewTextBoxColumn();
        UnitPriceColumn.HeaderText = "Ціна продажу";
        UnitPriceColumn.DataPropertyName = "UnitPrice";
        UnitPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        UnitPriceColumn.Width = 120;
        OrderItemGridView.Columns.Add(UnitPriceColumn);

        for (int i = 0; i < OrderItemGridView.Columns.Count; i++) {
          OrderItemGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataConvertToDouble(TotalPriceTBox.Text)) {
        TotalPriceValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        TotalPriceValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

  }
}
