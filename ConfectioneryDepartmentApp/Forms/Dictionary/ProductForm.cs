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

namespace ConfectioneryDepartmentApp.Forms.Dictionary {
  public partial class ProductForm : Form {
    private int _selectedRowIndex = 0;
    private Validations _validation = new Validations();
    private string _filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
    private byte[] _imagePhoto;

    private CategoryProvider _CategoryProvider = new CategoryProvider();
    private List<Category> _CategoryList = new List<Category>();
    private ProductProvider _ProductProvider = new ProductProvider();
    private List<Product> _ProductList = new List<Product>();

    public ProductForm() {
      InitializeComponent();
      LoadAllDate();
      DataLoad();
    }

    private void LoadPhotoBtn_Click(object sender, EventArgs e) {
      OpenFileDialog openFileDialog1 = new OpenFileDialog();
      openFileDialog1.Filter = _filter;
      if (openFileDialog1.ShowDialog() == DialogResult.OK) {
        PhotoPBox.SizeMode = PictureBoxSizeMode.StretchImage;
        PhotoPBox.Image = new Bitmap(openFileDialog1.FileName);
        PhotoNameLbl.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
        _imagePhoto = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
      }
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _ProductProvider.InsertProduct(SkuTBox.Text, ProductNameTBox.Text, Convert.ToInt32(CategoryCBox.SelectedValue), Convert.ToDouble(BasePriceTBox.Text),
        Convert.ToDouble(SellingPriceTBox.Text), Convert.ToInt32(PrepTimeMinTBox.Text), _imagePhoto, UnitTBox.Text, Convert.ToInt32(QuantityTBox.Text), NotesTBox.Text);
        DataLoad();
        ClearAllControls();
      }
    }

    private void ClearBtn_Click(object sender, EventArgs e) {
      ClearAllControls();
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void ProductGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && ProductGridView[0, e.RowIndex].Value.ToString() != _ProductList[0].Message) {
        _selectedRowIndex = e.RowIndex;
        UpdateProductForm updateCategoriesForm =
          new UpdateProductForm(Convert.ToInt32(ProductGridView[0, e.RowIndex].Value.ToString()));
        updateCategoriesForm.ShowDialog();
        DataLoad();
      }
    }

    private void LoadAllDate() {
      _CategoryList = _CategoryProvider.GetAllCategory();
      CategoryCBox.DataSource = _CategoryList;
      CategoryCBox.ValueMember = "CategoryId";
      CategoryCBox.DisplayMember = "CategoryName";
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (ProductGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = ProductGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _ProductList = _ProductProvider.GetAllProducts();
        LoadDataInDoctorGridView(_ProductList);
        if (_selectedRowIndex == ProductGridView.Rows.Count) {
          _selectedRowIndex = ProductGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          ProductGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          ProductGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInDoctorGridView(List<Product> ProductList) {
      ProductGridView.DataSource = null;
      ProductGridView.Columns.Clear();
      ProductGridView.AutoGenerateColumns = false;
      ProductGridView.RowHeadersVisible = false;
      ProductGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
      ProductGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

      ProductGridView.DataSource = ProductList;

      if (ProductList.Count > 0) {
        if (ProductList[0].Message == NamesMy.NoDataNames.NoDataInProducts) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = ProductGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          ProductGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn ProductIdColumn = new DataGridViewTextBoxColumn();
          ProductIdColumn.DataPropertyName = "ProductId";
          ProductGridView.Columns.Add(ProductIdColumn);
          ProductGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          ProductGridView.Columns.Add(numberColumn);

          DataGridViewColumn ProductNameColumn = new DataGridViewTextBoxColumn();
          ProductNameColumn.HeaderText = "Назва";
          ProductNameColumn.DataPropertyName = "ProductName";
          ProductNameColumn.Width = 250;
          ProductGridView.Columns.Add(ProductNameColumn);

          DataGridViewColumn BasePriceColumn = new DataGridViewTextBoxColumn();
          BasePriceColumn.HeaderText = "Ціна купівля";
          BasePriceColumn.DataPropertyName = "BasePrice";
          BasePriceColumn.Width = 120;
          BasePriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          ProductGridView.Columns.Add(BasePriceColumn);

          DataGridViewColumn SellingPriceColumn = new DataGridViewTextBoxColumn();
          SellingPriceColumn.HeaderText = "Ціна продажу";
          SellingPriceColumn.DataPropertyName = "SellingPrice";
          SellingPriceColumn.Width = 120;
          SellingPriceColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          ProductGridView.Columns.Add(SellingPriceColumn);

          DataGridViewColumn QuantityColumn = new DataGridViewTextBoxColumn();
          QuantityColumn.HeaderText = "Кількість";
          QuantityColumn.DataPropertyName = "Quantity";
          QuantityColumn.Width = 120;
          QuantityColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          ProductGridView.Columns.Add(QuantityColumn);

          DataGridViewColumn UploadDateColumn = new DataGridViewTextBoxColumn();
          UploadDateColumn.HeaderText = "Час виготовлення";
          UploadDateColumn.DataPropertyName = "PrepTimeMin";
          UploadDateColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          UploadDateColumn.Width = 140;
          ProductGridView.Columns.Add(UploadDateColumn);

        }
        for (int i = 0; i < ProductGridView.Columns.Count; i++) {
          ProductGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ClearAllControls() {
      ProductNameTBox.Text = String.Empty;
      SkuTBox.Text = String.Empty;
      BasePriceTBox.Text = "0";
      PrepTimeMinTBox.Text = "0";
      NotesTBox.Text = String.Empty;
      PhotoNameLbl.Text = String.Empty;
      _imagePhoto = null;
      PhotoPBox.Image = null;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(ProductNameTBox.Text)) {
        ProductNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        ProductNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (Convert.ToInt32(CategoryCBox.SelectedValue) > 0) {
        CategoryValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        CategoryValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(SkuTBox.Text)) {
        SkuValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        SkuValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToDouble(BasePriceTBox.Text)) {
        BasePriceValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        BasePriceValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(PrepTimeMinTBox.Text)) {
        PrepTimeMinValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PrepTimeMinValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(UnitTBox.Text)) {
        UnitValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        UnitValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataConvertToInt(QuantityTBox.Text)) {
        QuantityValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        QuantityValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (PhotoPBox.Image != null) {
        PhotoValidationLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PhotoValidationLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }


  }
}
