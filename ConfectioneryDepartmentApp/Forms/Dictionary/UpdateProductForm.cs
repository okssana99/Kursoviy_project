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

namespace ConfectioneryDepartmentApp.Forms.Dictionary {
  public partial class UpdateProductForm : Form {
    private int _ProductId = 0;
    private Validations _validation = new Validations();
    private CategoryProvider _CategoryProvider = new CategoryProvider();
    private List<Category> _CategoryList = new List<Category>();
    private string _filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
    private byte[] _imagePhoto;

    ProductProvider _ProductProvider = new ProductProvider();
    Product _selectedProduct = new Product();


    public UpdateProductForm(int ProductId) {
      InitializeComponent();
      _ProductId = ProductId;
      LoadAllDate();

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

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _ProductProvider.UpdateProduct(SkuTBox.Text, ProductNameTBox.Text, Convert.ToInt32(CategoryCBox.SelectedValue), Convert.ToDouble(BasePriceTBox.Text),
         Convert.ToDouble(SellingPriceTBox.Text), Convert.ToInt32(PrepTimeMinTBox.Text), _imagePhoto, UnitTBox.Text, Convert.ToInt32(QuantityTBox.Text), NotesTBox.Text, _ProductId);
        this.Close();
      }
    }

    // ================== UI: кнопка Видалити (однакова логіка, як для категорії) ==================
    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей товар?", "Видалити",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;

      // Перевіряємо, чи товар використовується у замовленнях
      int cnt = _ProductProvider.CountProductUsageInOrderItems(_ProductId);
      if (cnt > 0) {
        // Повідомляємо і не видаляємо (аналогічна політика до категорій)
        MessageBox.Show(
          $"Неможливо видалити: продукція використовується у {cnt} позиціях замовлень.\n" +
          $"Перепризначте або видаліть відповідні позиції, після чого повторіть спробу.",
          "Відмова", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      // Якщо не використовується — звичайне видалення товару
      _ProductProvider.DeleteProductWithOrderItems(_ProductId);
      MessageBox.Show("Товар видалено.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
      this.Close();
    }


    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _CategoryList = _CategoryProvider.GetAllCategory();
      CategoryCBox.DataSource = _CategoryList;
      CategoryCBox.ValueMember = "CategoryId";
      CategoryCBox.DisplayMember = "CategoryName";


      _selectedProduct = _ProductProvider.SelectedProductById(_ProductId);
      ProductNameTBox.Text = _selectedProduct.ProductName;
      CategoryCBox.SelectedValue = _selectedProduct.CategoryId;
      SkuTBox.Text = _selectedProduct.Sku;
      BasePriceTBox.Text = _selectedProduct.BasePrice.ToString();
      PrepTimeMinTBox.Text = _selectedProduct.PrepTimeMin.ToString();
      UnitTBox.Text = _selectedProduct.Unit;
      NotesTBox.Text = _selectedProduct.Notes;
      QuantityTBox.Text = _selectedProduct.Quantity.ToString();

      PhotoPBox.SizeMode = PictureBoxSizeMode.StretchImage;
      PhotoPBox.Image = ByteToImage(_selectedProduct.PhotoData);
      _imagePhoto = _selectedProduct.PhotoData;
    }

    public Bitmap ByteToImage(byte[] blob) {
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
      if (_validation.IsDataConvertToDouble(SellingPriceTBox.Text)) {
        SellingPriceValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        SellingPriceValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
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
