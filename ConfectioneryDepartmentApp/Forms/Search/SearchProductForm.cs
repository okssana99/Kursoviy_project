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

namespace ConfectioneryDepartmentApp.Forms.Search {
  public partial class SearchProductForm : Form {
    private Validations _validation = new Validations();

    private ProductProvider _ProductProvider = new ProductProvider();
    private List<Product> _ProductList = new List<Product>();

    private CategoryProvider _CategoryProvider = new CategoryProvider();
    private List<Category> _CategoryList = new List<Category>();

    // Кеш для швидкого отримання назви категорії за Id
    private Dictionary<int, string> _CategoryNameById = new Dictionary<int, string>();

    public SearchProductForm() {
      InitializeComponent();
      LoadAllDate();
    }

    private void LoadAllDate() {
      _CategoryList = _CategoryProvider.GetAllCategory();
      CategoryCBox.DataSource = _CategoryList;
      CategoryCBox.ValueMember = "CategoryId";
      CategoryCBox.DisplayMember = "CategoryName";

      _CategoryNameById = _CategoryList.ToDictionary(c => c.CategoryId, c => c.CategoryName);

      _ProductList = _ProductProvider.GetAllProducts();
      DisplayProductsInTextBox(_ProductList, RaportTBox);
    }

    // Пошук за вибраною категорією (значення з ComboBox)
    private void CategoryBtn_Click(object sender, EventArgs e) {
      if (CategoryCBox.SelectedValue == null) {
        DisplayProductsInTextBox(_ProductList, RaportTBox);
        return;
      }
      int categoryId = Convert.ToInt32(CategoryCBox.SelectedValue);
      var results = SearchProductsByCategoryId(categoryId);
      DisplayProductsInTextBox(results, RaportTBox);
    }

    // Пошук за частиною назви продукту
    private void ProductNameBtn_Click(object sender, EventArgs e) {
      var results = SearchProductsByName(ProductNameTBox.Text);
      DisplayProductsInTextBox(results, RaportTBox);
    }

    // Пошук за SKU
    private void SkuBtn_Click(object sender, EventArgs e) {
      var results = SearchProductsBySku(SkuTBox.Text);
      DisplayProductsInTextBox(results, RaportTBox);
    }

    // Узагальнений пошук (якщо захочете повісити на окрему кнопку «Пошук»)
    private void SearchAllFiltersBtn_Click(object sender, EventArgs e) {
      int? categoryId = CategoryCBox.SelectedValue != null ? Convert.ToInt32(CategoryCBox.SelectedValue) : (int?)null;
      string name = ProductNameTBox.Text;
      string sku = SkuTBox.Text;

      var results = SearchProducts(categoryId, name, sku);
      DisplayProductsInTextBox(results, RaportTBox);
    }

    // ---------- Методи пошуку ----------

    public List<Product> SearchProductsByCategoryId(int categoryId) {
      return _ProductList
        .Where(p => p.CategoryId == categoryId)
        .OrderBy(p => p.ProductName)
        .ToList();
    }

    public List<Product> SearchProductsByName(string productName) {
      return string.IsNullOrWhiteSpace(productName)
        ? _ProductList.ToList()
        : _ProductList
            .Where(p => (p.ProductName ?? string.Empty)
                        .ToLower()
                        .Contains(productName.Trim().ToLower()))
            .OrderBy(p => p.ProductName)
            .ToList();
    }

    public List<Product> SearchProductsBySku(string sku) {
      return string.IsNullOrWhiteSpace(sku)
        ? _ProductList.ToList()
        : _ProductList
            .Where(p => (p.Sku ?? string.Empty)
                        .ToLower()
                        .Contains(sku.Trim().ToLower()))
            .OrderBy(p => p.Sku)
            .ToList();
    }

    public List<Product> SearchProducts(int? categoryId, string productName, string sku) {
      var q = _ProductList.AsEnumerable();

      if (categoryId.HasValue)
        q = q.Where(p => p.CategoryId == categoryId.Value);

      if (!string.IsNullOrWhiteSpace(productName)) {
        string name = productName.Trim().ToLower();
        q = q.Where(p => (p.ProductName ?? string.Empty).ToLower().Contains(name));
      }

      if (!string.IsNullOrWhiteSpace(sku)) {
        string s = sku.Trim().ToLower();
        q = q.Where(p => (p.Sku ?? string.Empty).ToLower().Contains(s));
      }

      return q.OrderBy(p => p.ProductName).ToList();
    }

    // ---------- Відображення результатів ----------

    public void DisplayProductsInTextBox(List<Product> products, TextBox textBox) {
      textBox.Clear();

      if (products == null || products.Count == 0) {
        textBox.AppendText("Дані не знайдено.\r\n");
        return;
      }

      // Заголовок
      string header = string.Format("{0,3}|{1,-12}|{2,-34}|{3,-20}|{4,-6}|{5,10}|{6,10}\r\n",
                                    "№", "SKU", "Назва", "Категорія", "Од.", "Ціна", "Час,хв");
      textBox.AppendText(header);
      textBox.AppendText(new string('-', header.Length) + "\r\n");

      int i = 0;
      foreach (var p in products) {
        string catName = _CategoryNameById.TryGetValue(p.CategoryId, out var cn) ? cn : "-";
        string line = string.Format("{0,3}|{1,-12}|{2,-34}|{3,-20}|{4,-6}|{5,10:F2}|{6,10}\r\n",
                                    ++i,
                                    Truncate(p.Sku, 12),
                                    Truncate(p.ProductName, 34),
                                    Truncate(catName, 20),
                                    Truncate(p.Unit, 6),
                                    p.BasePrice,
                                    p.PrepTimeMin);
        textBox.AppendText(line);
      }
    }

    public static string Truncate(string value, int maxLen) {
      if (string.IsNullOrEmpty(value)) return "";
      return value.Length <= maxLen ? value : value.Substring(0, maxLen);
    }
  }
}

