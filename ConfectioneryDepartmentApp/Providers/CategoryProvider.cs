using ConfectioneryDepartmentApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryDepartmentApp.Providers {
  internal class CategoryProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    // Додавання нового запису категорії
    public void InsertCategory(string CategoryName, string Description) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "INSERT INTO category (category_name, description) VALUES(@CategoryName, @Description)";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      // Передача параметрів запиту
      cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
      cmd.Parameters.AddWithValue("@Description", Description);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    // Отримання всіх категорій із таблиці
    public List<Category> GetAllCategory() {
      int i = 0;
      List<Category> CategoryList = new List<Category>();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT * FROM category";
      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        Category selectedCategory = new Category();

        selectedCategory.Number = ++i; // Порядковий номер
        selectedCategory.CategoryId = Convert.ToInt32(reader["category_id"]);
        selectedCategory.CategoryName = reader["category_name"].ToString();
        selectedCategory.Description = reader["description"].ToString();

        CategoryList.Add(selectedCategory);
      }

      reader.Close();
      connection.Close();

      // Якщо категорій не знайдено — створити службовий запис
      if (CategoryList.Count == 0) {
        Category noCategory = new Category();
        noCategory.CategoryId = 0;
        noCategory.Message = NamesMy.NoDataNames.NoDataInCategory;
        CategoryList.Add(noCategory);
      }
      return CategoryList;
    }

    // Отримання вибраної категорії за її ідентифікатором
    public Category SelectedCategoryById(int CategoryId) {
      Category selectedCategory = new Category();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT * FROM category WHERE category_id = " + CategoryId.ToString();
      MySqlCommand command = new MySqlCommand(query, connection);
      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        selectedCategory.CategoryId = Convert.ToInt32(reader["category_id"]);        // Ідентифікатор категорії
        selectedCategory.CategoryName = reader["category_name"].ToString();          // Назва категорії
        selectedCategory.Description = reader["description"].ToString();             // Опис категорії
      }

      reader.Close();
      connection.Close();
      return selectedCategory;
    }


    // Оновлення даних про категорію
    public void UpdateCategory(string CategoryName, string Description, int CategoryId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "UPDATE category SET category_name = @CategoryName, description = @Description " +
                     "WHERE category_id = @CategoryId";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@CategoryName", CategoryName);
      cmd.Parameters.AddWithValue("@Description", Description);
      cmd.Parameters.AddWithValue("@CategoryId", CategoryId);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }


    // Видалення категорії за ідентифікатором
    public void DeleteCategory(int CategoryId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "DELETE FROM category WHERE category_id = @CategoryId";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@CategoryId", CategoryId);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    public int CountProductsInCategory(int categoryId) {
      using (var cn = new MySqlConnection(_ConnString))
      using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM products WHERE category_id=@id", cn)) {
        cmd.Parameters.AddWithValue("@id", categoryId);
        cn.Open();
        return Convert.ToInt32(cmd.ExecuteScalar());
      }
    }

  }
}

public class Category {
  private int _Number;             // Порядковий номер запису
  private int _CategoryId;         // Унікальний ідентифікатор категорії
  private string _CategoryName;    // Назва категорії виробів
  private string _Description;     // Опис категорії
  private string _Message;         // Повідомлення або коментар користувача

  // Конструктор за замовчуванням
  public Category() {
    _Number = 0;
    _CategoryId = 0;
    _CategoryName = String.Empty;
    _Description = String.Empty;
    _Message = String.Empty;
  }

  // Властивість для порядкового номера
  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }

  // Властивість для ідентифікатора категорії
  public int CategoryId {
    set { _CategoryId = value; }
    get { return _CategoryId; }
  }

  // Властивість для назви категорії
  public string CategoryName {
    set { _CategoryName = value; }
    get { return _CategoryName; }
  }

  // Властивість для опису категорії
  public string Description {
    set { _Description = value; }
    get { return _Description; }
  }

  // Властивість для повідомлення або коментаря
  public string Message {
    set { _Message = value; }
    get { return _Message; }
  }
}
