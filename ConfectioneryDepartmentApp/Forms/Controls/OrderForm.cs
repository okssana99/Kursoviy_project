using ConfectioneryDepartmentApp.AppCode;
using ConfectioneryDepartmentApp.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfectioneryDepartmentApp.Forms.Controls {
  public partial class OrderForm : Form {
    private Validations _validation = new Validations();
    private ProductProvider _ProductPrivider = new ProductProvider();
    private List<Product> _ProductList = new List<Product>();

    private CategoryProvider _CategoryProvider = new CategoryProvider();
    private List<Category> _CategoryList = new List<Category>();
    private OrderItemProvider _OrderItemProvider = new OrderItemProvider();
    private List<OrderItem> _OrderItemList = new List<OrderItem>();
    private OrderProvider _OrderProvider = new OrderProvider();

    private CustomerProvider _CustomerProvider = new CustomerProvider();
    private List<Customer> _CustomerList = new List<Customer>();
    private Customer _selCustomer = new Customer();

    private Product _SelectProduct = new Product();
    private bool _IsCategoryLoad = false;
    private bool _IsProductLoad = false;
    private bool _IsCustomerLoad = false;


    public OrderForm() {
      InitializeComponent();
      LoadAllDate();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsSelectedCorrect()) {
        OrderItem selOrderItem = new OrderItem();
        selOrderItem.ProductId = Convert.ToInt32(ProductCBox.SelectedValue);
        selOrderItem.ProductName = ProductCBox.Text;
        selOrderItem.Qty = Convert.ToInt32(QuantityTBox.Text);
        selOrderItem.UnitPrice = _SelectProduct.SellingPrice;
        _OrderItemList.Add(selOrderItem);
        LoadDataInOrderItemL(_OrderItemList);
      }
    }

    private void OrderBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        int OrderId = 
          _OrderProvider.InsertOrderAndGetId(Convert.ToInt32(CustomerCBox.SelectedValue),
          StatusCBox.Text, DueDtDTP.Value, NotesOrderTBox.Text,
          Convert.ToDouble(ManualTotalWithDiscountTBox.Text));
        for (int i = 0; i < _OrderItemList.Count; i++) {
          _OrderItemList[i].OrderId = OrderId;
        }
        _OrderItemProvider.InsertBatchOrderItems(_OrderItemList);
        MessageBox.Show("Замовлення успішно збережено!", "Зберігання");
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void CategoryCBox_SelectedValueChanged(object sender, EventArgs e) {
      if (_IsCategoryLoad) {
        _ProductList = _ProductPrivider.GetAllProductsByCategoryId(Convert.ToInt32(CategoryCBox.SelectedValue));
        ProductCBox.DataSource = _ProductList;
        ProductCBox.ValueMember = "ProductId";
        ProductCBox.DisplayMember = "ProductName";
        _IsProductLoad = true;
        ProductCBox_SelectedValueChanged(ProductCBox, EventArgs.Empty);
      }
    }

    private void ProductCBox_SelectedValueChanged(object sender, EventArgs e) {
      if (_IsProductLoad) {
        _SelectProduct = _ProductPrivider.SelectedProductById(Convert.ToInt32(ProductCBox.SelectedValue));
        PhotoPBox.SizeMode = PictureBoxSizeMode.StretchImage;
        PhotoPBox.Image = ByteToImage(_SelectProduct.PhotoData);
        BasePriceTBox.Text = _SelectProduct.SellingPrice.ToString();
        NotesTBox.Text = _SelectProduct.Notes;
        UnitLbl.Text = "(Од. вим.: " + _SelectProduct.Unit + ")";
        QuantityLbl.Text = "(Кількість од.: " + _SelectProduct.Quantity.ToString() + ")";
      }
    }

    private void CustomerCBox_SelectedValueChanged(object sender, EventArgs e) {
      if (_IsCustomerLoad) {
        ManualTotalTBox.Text = GetSumOrder().ToString();
        ManualTotalWithDiscountTBox.Text = CalculateDiscountedAmount(Convert.ToDouble(ManualTotalTBox.Text)).ToString();
      }
    }

    public static Bitmap ByteToImage(byte[] blob) {
      // Перевірка на null і порожній масив
      if (blob == null || blob.Length == 0)
        return null;

      using (MemoryStream mStream = new MemoryStream(blob)) {
        try {
          Bitmap bm = new Bitmap(mStream);
          return bm;
        } catch {
          // Якщо дані не є валідним зображенням — повертаємо null
          return null;
        }
      }
    }


    private void ProductsItemsGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.ColumnIndex == 5 && ProductsItemsGridView[0, e.RowIndex].Value.ToString() != _OrderItemList[0].Message) {
        int productId = Convert.ToInt32(ProductsItemsGridView[0, e.RowIndex].Value.ToString());

        for (int i = 0; i < _OrderItemList.Count; i++) {
          if (productId == _OrderItemList[i].ProductId) {
            _OrderItemList.RemoveAt(i);
            break;
          }
        }
        LoadDataInOrderItemL(_OrderItemList);
      }
    }

    private void LoadAllDate() {
      StatusCBox.SelectedIndex = 0;
      _CategoryList = _CategoryProvider.GetAllCategory();
      CategoryCBox.DataSource = _CategoryList;
      CategoryCBox.ValueMember = "CategoryId";
      CategoryCBox.DisplayMember = "CategoryName";
      _IsCategoryLoad = true;

      _CustomerList = _CustomerProvider.GetAllCustomers();
      CustomerCBox.DataSource = _CustomerList; 
      CustomerCBox.ValueMember = "CustomerId";
      CustomerCBox.DisplayMember = "FullName";
      _IsCustomerLoad = true;

      CategoryCBox_SelectedValueChanged(CategoryCBox, EventArgs.Empty);
    }

    private void LoadDataInOrderItemL(List<OrderItem> AllOrderItem) {
      ChangeNumber();
      ManualTotalTBox.Text = GetSumOrder().ToString();
      ManualTotalWithDiscountTBox.Text = CalculateDiscountedAmount(Convert.ToDouble(ManualTotalTBox.Text)).ToString();

      ProductsItemsGridView.DataSource = null;
      ProductsItemsGridView.Columns.Clear();
      ProductsItemsGridView.AutoGenerateColumns = false;
      ProductsItemsGridView.RowHeadersVisible = false;

      ProductsItemsGridView.DataSource = AllOrderItem;

      if (AllOrderItem.Count > 0) {
        DataGridViewColumn UsersIdColumn = new DataGridViewTextBoxColumn();
        UsersIdColumn.DataPropertyName = "ProductId";
        UsersIdColumn.Name = "ProductId";
        ProductsItemsGridView.Columns.Add(UsersIdColumn);
        ProductsItemsGridView.Columns[0].Visible = false;

        DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
        numberColumn.HeaderText = "№ з/п";
        numberColumn.DataPropertyName = "Number";
        numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        numberColumn.Width = NamesMy.SizeOptins.NumberSize;
        ProductsItemsGridView.Columns.Add(numberColumn);

        DataGridViewColumn ProductNameColumn = new DataGridViewTextBoxColumn();
        ProductNameColumn.HeaderText = "Продукція";
        ProductNameColumn.DataPropertyName = "ProductName";
        ProductNameColumn.Name = "ProductName";
        ProductNameColumn.Width = 320;
        ProductsItemsGridView.Columns.Add(ProductNameColumn);

        DataGridViewColumn QuantityColumn = new DataGridViewTextBoxColumn();
        QuantityColumn.HeaderText = "Кількість";
        QuantityColumn.DataPropertyName = "Qty";
        QuantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        QuantityColumn.Width = 80;
        ProductsItemsGridView.Columns.Add(QuantityColumn);

        DataGridViewColumn UnitPriceColumn = new DataGridViewTextBoxColumn();
        UnitPriceColumn.HeaderText = "Ціна покупки";
        UnitPriceColumn.DataPropertyName = "UnitPrice";
        UnitPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        UnitPriceColumn.Width = 120;
        ProductsItemsGridView.Columns.Add(UnitPriceColumn);

        DataGridViewButtonColumn DeleteBtn = new DataGridViewButtonColumn();
        DeleteBtn.Text = "Видалити";
        DeleteBtn.UseColumnTextForButtonValue = true;
        DeleteBtn.ToolTipText = "Видалити";
        DeleteBtn.Width = NamesMy.SizeOptins.DeleteBtnSize;
        ProductsItemsGridView.Columns.Add(DeleteBtn);

        for (int i = 0; i < ProductsItemsGridView.Columns.Count; i++) {
          ProductsItemsGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ChangeNumber() {
      for (int i = 0; i < _OrderItemList.Count; i++) {
        _OrderItemList[i].Number = i + 1;
      }
    }

    // Обчислення суми із знижкою (%)
    public double CalculateDiscountedAmount(double totalAmount) {
      _selCustomer = 
        _CustomerProvider.SelectedCustomerById(Convert.ToInt32(CustomerCBox.SelectedValue.ToString()));
      // Якщо сума менша або дорівнює нулю — повертаємо 0
      if (totalAmount <= 0)
        return 0.0;
      // Якщо знижка відсутня або дорівнює нулю — повертаємо початкову суму
      if (_selCustomer.DiscountPct <= 0)
        return Math.Round(totalAmount, 2);
      // Обмежуємо знижку в межах 0–100 %
      if (_selCustomer.DiscountPct > 100)
        _selCustomer.DiscountPct = 100;
      // Формула розрахунку: сума зі знижкою = сума * (1 - %/100)
      double discountedAmount = totalAmount * (1 - _selCustomer.DiscountPct / 100.0);
      // Округлення до 2 знаків після коми
      return Math.Round(discountedAmount, 2);
    }



    private bool IsProductAdd(int ProductId) {
      for (int i = 0; i < _OrderItemList.Count; i++) {
        if (_OrderItemList[i].ProductId == ProductId) {
          return true;
        }
      }
      return false;
    }

    private double GetSumOrder() {
      double allSum = 0;
      for (int i = 0; i < _OrderItemList.Count; i++) {
        allSum += _OrderItemList[i].Qty * _OrderItemList[i].UnitPrice;
      }
      return allSum;
    }

    private bool IsSelectedCorrect() {
      bool isCorrect = true;
      if (Convert.ToInt32(ProductCBox.SelectedValue) > 0) {
        ProductValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ProductValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      double quantityValue;

      // Перевіряємо, чи можна перетворити введений текст у число
      if (double.TryParse(QuantityTBox.Text, out quantityValue)) {
        // Якщо вдалося перетворити — перевіряємо діапазон
        if (_validation.IsDataInThisScope(1, 1000, quantityValue)) {
          QuantityValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
        } else {
          QuantityValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
          isCorrect = false;
        }
      } else {
        // Якщо введено нечислове значення
        QuantityValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (IsProductAdd(_SelectProduct.ProductId)) {
        MessageBox.Show("Обрана продукція вже додана у список замовлення", "Увага!");
        isCorrect = false;
      }
      return isCorrect;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_OrderItemList.Count <= 0) {
        MessageBox.Show("Необхідно додати хоча б одну позицію для замовлення", "Увага!");
        isCorrect = false;
      }
      return isCorrect;
    }


  }
}
