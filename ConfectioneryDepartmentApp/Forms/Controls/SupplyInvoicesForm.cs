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
  public partial class SupplyInvoicesForm : Form {
    private Validations _validation = new Validations();
    private ProductProvider _ProductPrivider = new ProductProvider();
    private List<Product> _ProductList = new List<Product>();

    private CategoryProvider _CategoryProvider = new CategoryProvider();
    private List<Category> _CategoryList = new List<Category>();
    private SupplyItemsProvider _SupplyItemsProvider = new SupplyItemsProvider();
    private List<SupplyItems> _SupplyItemsList = new List<SupplyItems>();
    private SupplyInvoicesProvider _SupplyInvoicesProvider = new SupplyInvoicesProvider();

    private SupplierProvider _SupplierProvider = new SupplierProvider();
    private List<Supplier> _SupplierList = new List<Supplier>();
    private Supplier _selSupplier = new Supplier();

    private Product _SelectProduct = new Product();
    private bool _IsCategoryLoad = false;
    private bool _IsProductLoad = false;
    private bool _IsSupplierLoad = false;


    public SupplyInvoicesForm() {
      InitializeComponent();
      LoadAllDate();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsSelectedCorrect()) {
        SupplyItems selSupplyItems = new SupplyItems();
        selSupplyItems.ProductId = Convert.ToInt32(ProductCBox.SelectedValue);
        selSupplyItems.ProductName = ProductCBox.Text;
        selSupplyItems.Qty = Convert.ToInt32(QuantityTBox.Text);
        selSupplyItems.UnitCost = _SelectProduct.BasePrice;
        _SupplyItemsList.Add(selSupplyItems);
        LoadDataInSupplyItemsL(_SupplyItemsList);
      }
    }
    private void SupplyInvoicesBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        int SupplyInvoicesId = _SupplyInvoicesProvider.InsertSupplyAndGetId(Convert.ToInt32(SupplierCBox.SelectedValue), StatusCBox.Text, DueDtDTP.Value, NotesSapTBox.Text,
          Convert.ToDouble(ManualTotalTBox.Text));
        for (int i = 0; i < _SupplyItemsList.Count; i++) {
          _SupplyItemsList[i].SupplyId = SupplyInvoicesId;
        }
        _SupplyItemsProvider.InsertBatchSupplyItems(_SupplyItemsList);
        MessageBox.Show("Замовлення на постачання успішно збережено!", "Зберігання");
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
        SellingPriceTBox.Text = _SelectProduct.BasePrice.ToString();
        NotesTBox.Text = _SelectProduct.Notes;
        UnitLbl.Text = "(Од. вим.: " + _SelectProduct.Unit + ")";
        QuantityLbl.Text = "(Кількість од.: " + _SelectProduct.Quantity.ToString() + ")";
      }
    }

    private void SupplierCBox_SelectedValueChanged(object sender, EventArgs e) {
      if (_IsSupplierLoad) {
        ManualTotalTBox.Text = GetSumSupplyInvoices().ToString();
      }
    }

    private void SupplyItemsGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.ColumnIndex == 5 && SupplyItemsGridView[0, e.RowIndex].Value.ToString() != _SupplyItemsList[0].Message) {
        int productId = Convert.ToInt32(SupplyItemsGridView[0, e.RowIndex].Value.ToString());

        for (int i = 0; i < _SupplyItemsList.Count; i++) {
          if (productId == _SupplyItemsList[i].ProductId) {
            _SupplyItemsList.RemoveAt(i);
            break;
          }
        }
        LoadDataInSupplyItemsL(_SupplyItemsList);
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

    private void LoadAllDate() {
      StatusCBox.SelectedIndex = 0;
      _CategoryList = _CategoryProvider.GetAllCategory();
      CategoryCBox.DataSource = _CategoryList;
      CategoryCBox.ValueMember = "CategoryId";
      CategoryCBox.DisplayMember = "CategoryName";
      _IsCategoryLoad = true;

      _SupplierList = _SupplierProvider.GetAllSupplier();
      SupplierCBox.DataSource = _SupplierList;
      SupplierCBox.ValueMember = "SupplierId";
      SupplierCBox.DisplayMember = "SupplierName";
      _IsSupplierLoad = true;

      CategoryCBox_SelectedValueChanged(CategoryCBox, EventArgs.Empty);
    }

    private void LoadDataInSupplyItemsL(List<SupplyItems> AllSupplyItems) {
      ChangeNumber();
      ManualTotalTBox.Text = GetSumSupplyInvoices().ToString();

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

        DataGridViewColumn QuantityColumn = new DataGridViewTextBoxColumn();
        QuantityColumn.HeaderText = "Кількість";
        QuantityColumn.DataPropertyName = "Qty";
        QuantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        QuantityColumn.Width = 80;
        SupplyItemsGridView.Columns.Add(QuantityColumn);

        DataGridViewColumn UnitCostColumn = new DataGridViewTextBoxColumn();
        UnitCostColumn.HeaderText = "Ціна закупки";
        UnitCostColumn.DataPropertyName = "UnitCost";
        UnitCostColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        UnitCostColumn.Width = 120;
        SupplyItemsGridView.Columns.Add(UnitCostColumn);

        DataGridViewButtonColumn DeleteBtn = new DataGridViewButtonColumn();
        DeleteBtn.Text = "Видалити";
        DeleteBtn.UseColumnTextForButtonValue = true;
        DeleteBtn.ToolTipText = "Видалити";
        DeleteBtn.Width = NamesMy.SizeOptins.DeleteBtnSize;
        SupplyItemsGridView.Columns.Add(DeleteBtn);

        for (int i = 0; i < SupplyItemsGridView.Columns.Count; i++) {
          SupplyItemsGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ChangeNumber() {
      for (int i = 0; i < _SupplyItemsList.Count; i++) {
        _SupplyItemsList[i].Number = i + 1;
      }
    }

  
    private bool IsProductAdd(int ProductId) {
      for (int i = 0; i < _SupplyItemsList.Count; i++) {
        if (_SupplyItemsList[i].ProductId == ProductId) {
          return true;
        }
      }
      return false;
    }

    private double GetSumSupplyInvoices() {
      double allSum = 0;
      for (int i = 0; i < _SupplyItemsList.Count; i++) {
        allSum += _SupplyItemsList[i].Qty * _SupplyItemsList[i].UnitCost;
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
      if (_SupplyItemsList.Count <= 0) {
        MessageBox.Show("Необхідно додати хоча б одну позицію для замовлення", "Увага!");
        isCorrect = false;
      }
      return isCorrect;
    }


  }
}
