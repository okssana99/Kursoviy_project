using ConfectioneryDepartmentApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryDepartmentApp.Providers {
  internal class ProductProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    // Додавання нового виробу
    public void InsertProduct(string Sku, string ProductName, int CategoryId, double BasePrice, double SellingPrice, int PrepTimeMin,
      byte[] PhotoData, string Unit, int Quantity, string Notes) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "INSERT INTO products (sku, product_name, category_id, base_price, selling_price, prep_time_min, photo_data, unit, quantity, notes) " +
                     "VALUES (@Sku, @ProductName, @CategoryId, @BasePrice, @SellingPrice, @PrepTimeMin, @PhotoData, @Unit, @Quantity, @Notes)";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@Sku", Sku);
      cmd.Parameters.AddWithValue("@ProductName", ProductName);
      cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
      cmd.Parameters.AddWithValue("@BasePrice", BasePrice);
      cmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);
      cmd.Parameters.AddWithValue("@PrepTimeMin", PrepTimeMin);
      cmd.Parameters.AddWithValue("@PhotoData", (object)PhotoData ?? DBNull.Value);
      cmd.Parameters.AddWithValue("@Unit", Unit);
      cmd.Parameters.AddWithValue("@Quantity", Quantity);
      cmd.Parameters.AddWithValue("@Notes", Notes);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }


    // Отримання повного списку виробів
    public List<Product> GetAllProducts() {
      int i = 0;
      List<Product> ProductList = new List<Product>();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT * FROM products";
      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        Product selectedProduct = new Product();

        selectedProduct.Number = ++i;  // Порядковий номер
        selectedProduct.ProductId = Convert.ToInt32(reader["product_id"]);
        selectedProduct.Sku = reader["sku"].ToString();
        selectedProduct.ProductName = reader["product_name"].ToString();
        selectedProduct.CategoryId = Convert.ToInt32(reader["category_id"]);
        selectedProduct.BasePrice = Convert.ToDouble(reader["base_price"]);
        selectedProduct.SellingPrice = Convert.ToDouble(reader["selling_price"]);
        selectedProduct.PrepTimeMin = Convert.ToInt32(reader["prep_time_min"]);
        selectedProduct.Unit = reader["unit"].ToString();
        selectedProduct.Quantity = Convert.ToInt32(reader["quantity"]);
        // Фото може бути відсутнім
        if (reader["photo_data"] != DBNull.Value)
          selectedProduct.PhotoData = (byte[])reader["photo_data"];

        selectedProduct.Notes = reader["notes"].ToString();

        ProductList.Add(selectedProduct);
      }

      reader.Close();
      connection.Close();

      // Якщо даних немає – додаємо службовий запис
      if (ProductList.Count == 0) {
        Product noProduct = new Product();
        noProduct.ProductId = 0;
        noProduct.Message = NamesMy.NoDataNames.NoDataInProducts;
        ProductList.Add(noProduct);
      }

      return ProductList;
    }


    // Отримання всіх продуктів за ідентифікатором категорії
    public List<Product> GetAllProductsByCategoryId(int CategoryId) {
      int i = 0;
      List<Product> ProductList = new List<Product>();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT product_id, product_name, base_price, selling_price, quantity FROM products WHERE category_id = @CategoryId";
      MySqlCommand command = new MySqlCommand(query, connection);
      command.Parameters.AddWithValue("@CategoryId", CategoryId);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        Product selectedProduct = new Product();

        selectedProduct.Number = ++i;  // Порядковий номер
        selectedProduct.ProductId = Convert.ToInt32(reader["product_id"]);
        selectedProduct.ProductName = reader["product_name"].ToString();
        selectedProduct.BasePrice = Convert.ToDouble(reader["base_price"]);
        selectedProduct.SellingPrice = Convert.ToDouble(reader["selling_price"]);
        selectedProduct.Quantity = Convert.ToInt32(reader["quantity"]);
        ProductList.Add(selectedProduct);
      }

      reader.Close();
      connection.Close();

      return ProductList;
    }


    // === Отримання вибраного виробу за його ідентифікатором ===
    public Product SelectedProductById(int ProductId) {
      Product selectedProduct = new Product();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT * FROM products WHERE product_id = " + ProductId.ToString();
      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        selectedProduct.ProductId = Convert.ToInt32(reader["product_id"]);       // Ідентифікатор виробу
        selectedProduct.Sku = reader["sku"].ToString();                          // Внутрішній артикул
        selectedProduct.ProductName = reader["product_name"].ToString();         // Назва виробу
        selectedProduct.CategoryId = Convert.ToInt32(reader["category_id"]);     // Категорія
        selectedProduct.BasePrice = Convert.ToDouble(reader["base_price"]);      // Ціна бази
        selectedProduct.SellingPrice = Convert.ToDouble(reader["selling_price"]); // Ціна продажу
        selectedProduct.PrepTimeMin = Convert.ToInt32(reader["prep_time_min"]);  // Час виготовлення
        selectedProduct.Unit = reader["unit"].ToString();
        // Фото може бути відсутнім
        if (reader["photo_data"] != DBNull.Value)
          selectedProduct.PhotoData = (byte[])reader["photo_data"];
        selectedProduct.Quantity = Convert.ToInt32(reader["quantity"]);
        selectedProduct.Notes = reader["notes"].ToString();                      // Примітки
      }

      reader.Close();
      connection.Close();
      return selectedProduct;
    }


    // === Оновлення даних про виріб ===
    public void UpdateProduct(string Sku, string ProductName, int CategoryId, double BasePrice, double SellingPrice, int PrepTimeMin, byte[] PhotoData, string Unit, int Quantity, string Notes,  int ProductId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "UPDATE products SET sku = @Sku, product_name = @ProductName, category_id = @CategoryId, " +
                     "base_price = @BasePrice, selling_price=@SellingPrice, prep_time_min = @PrepTimeMin, photo_data = @PhotoData, unit=@Unit, quantity = @Quantity, notes = @Notes " +
                     "WHERE product_id = @ProductId";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@Sku", Sku);
      cmd.Parameters.AddWithValue("@ProductName", ProductName);
      cmd.Parameters.AddWithValue("@CategoryId", CategoryId);
      cmd.Parameters.AddWithValue("@BasePrice", BasePrice);
      cmd.Parameters.AddWithValue("@SellingPrice", SellingPrice);
      cmd.Parameters.AddWithValue("@PrepTimeMin", PrepTimeMin);
      cmd.Parameters.AddWithValue("@PhotoData", (object)PhotoData ?? DBNull.Value);
      cmd.Parameters.AddWithValue("@Unit", Unit);
      cmd.Parameters.AddWithValue("@Quantity", Quantity);
      cmd.Parameters.AddWithValue("@Notes", Notes);
      cmd.Parameters.AddWithValue("@ProductId", ProductId);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }






    // ================== Provider: підрахунок використання товару ==================
    // К-ть позицій замовлень, де використано цей товар
    public int CountProductUsageInOrderItems(int productId) {
      using (var cn = new MySqlConnection(_ConnString))
      using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM order_items WHERE product_id = @id", cn)) {
        cmd.Parameters.AddWithValue("@id", productId);
        cn.Open();
        return Convert.ToInt32(cmd.ExecuteScalar());
      }
    }

    // ================== Provider: транзакційне «ручне» каскадне видалення ==================
    // 1) Видалити всі позиції замовлень з цим продуктом
    // 2) Видалити сам продукт
    public void DeleteProductWithOrderItems(int productId) {
      using (var cn = new MySqlConnection(_ConnString)) {
        cn.Open();
        using (var tx = cn.BeginTransaction()) {

          // 1) Видаляємо позиції замовлень, що посилаються на продукт
          var delItems = new MySqlCommand(
            "DELETE FROM order_items WHERE product_id = @id", cn, tx);
          delItems.Parameters.AddWithValue("@id", productId);
          delItems.ExecuteNonQuery();

          // 2) Видаляємо сам продукт
          var delProd = new MySqlCommand(
            "DELETE FROM products WHERE product_id = @id", cn, tx);
          delProd.Parameters.AddWithValue("@id", productId);
          delProd.ExecuteNonQuery();

          tx.Commit();
        }
      }
    }

    // ===================== ADD QUANTITY =====================
    // Збільшення кількості товару за вказаним ідентифікатором
    public void AddProductQuantity(int ProductId, int AmountToAdd) {
      if (AmountToAdd <= 0) return;  // Перевірка коректності

      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        string query = "UPDATE products SET quantity = quantity + @AmountToAdd WHERE product_id = @ProductId";
        using (MySqlCommand cmd = new MySqlCommand(query, connection)) {
          cmd.Parameters.AddWithValue("@AmountToAdd", AmountToAdd);
          cmd.Parameters.AddWithValue("@ProductId", ProductId);

          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }

    // ===================== SUBTRACT QUANTITY =====================
    // Зменшення кількості товару за вказаним ідентифікатором
    public void SubtractProductQuantity(int ProductId, int AmountToSubtract) {
      if (AmountToSubtract <= 0) return;  // Перевірка коректності

      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        string query = @"
      UPDATE products 
      SET quantity = CASE 
                       WHEN quantity >= @AmountToSubtract 
                       THEN quantity - @AmountToSubtract 
                       ELSE 0 
                     END 
      WHERE product_id = @ProductId";

        using (MySqlCommand cmd = new MySqlCommand(query, connection)) {
          cmd.Parameters.AddWithValue("@AmountToSubtract", AmountToSubtract);
          cmd.Parameters.AddWithValue("@ProductId", ProductId);

          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }


  }
}

public class Product {
  private int _Number;             // Порядковий номер запису (для відображення у звітах/таблицях)
  private int _ProductId;          // Унікальний ідентифікатор виробу (product_id)
  private string _Sku;             // Внутрішній артикул (sku)
  private string _ProductName;     // Назва виробу (product_name)
  private int _CategoryId;         // Посилання на категорію (category_id, FK → category.category_id)
  private double _BasePrice;      // Базова ціна (base_price)
  private double _SellingPrice;    // Ціна продажу (selling_price)
  private int _PrepTimeMin;        // Орієнтовний час виготовлення у хвилинах (prep_time_min)
  private byte[] _PhotoData;       // Фото виробу у двійковому форматі (photo_data, LONGBLOB)
  private string _Unit;            // Одиниця виміру: 'шт' або 'кг'
  private int _Quantity;           // Кількість (для замовлення)
  private string _Notes;           // Додаткові примітки (notes)
  private string _Message;         // Повідомлення/коментар службового характеру

  // Конструктор за замовчуванням
  public Product() {
    _Number = 0;
    _ProductId = 0;
    _Sku = string.Empty;
    _ProductName = string.Empty;
    _CategoryId = 0;
    _BasePrice = 0;
    _SellingPrice = 0;
    _PrepTimeMin = 0;
    _PhotoData = null;            // Відсутність фото
    _Unit = string.Empty;
    _Quantity = 0;
    _Notes = string.Empty;
    _Message = string.Empty;
  }

  // Порядковий номер
  public int Number {
    get { return _Number; }
    set { _Number = value; }
  }

  // Ідентифікатор виробу
  public int ProductId {
    get { return _ProductId; }
    set { _ProductId = value; }
  }

  // Внутрішній артикул
  public string Sku {
    get { return _Sku; }
    set { _Sku = value; }
  }

  // Назва виробу
  public string ProductName {
    get { return _ProductName; }
    set { _ProductName = value; }
  }

  // Ідентифікатор категорії (FK)
  public int CategoryId {
    get { return _CategoryId; }
    set { _CategoryId = value; }
  }

  // Базова ціна
  public double BasePrice {
    get { return _BasePrice; }
    set { _BasePrice = value; }
  }
  // Ціна продажу
  public double SellingPrice {
    get { return _SellingPrice; }
    set { _SellingPrice = value; }
  }

  // Час підготовки (хв)
  public int PrepTimeMin {
    get { return _PrepTimeMin; }
    set { _PrepTimeMin = value; }
  }

  // Фото у вигляді масиву байтів
  public byte[] PhotoData {
    get { return _PhotoData; }
    set { _PhotoData = value; }
  }

  public string Unit {
    get { return _Unit; }
    set { _Unit = value; }
  }
  // Кількість (для замовлення)
  public int Quantity {
    get { return _Quantity; }
    set { _Quantity = value; }
  }

  // Примітки
  public string Notes {
    get { return _Notes; }
    set { _Notes = value; }
  }

  // Службове повідомлення
  public string Message {
    get { return _Message; }
    set { _Message = value; }
  }
}
