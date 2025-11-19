using ConfectioneryDepartmentApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryDepartmentApp.Providers {
  internal class CustomerProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    // Додавання нового клієнта
    public void InsertCustomer(string FullName, string Phone, string Email, double DiscountPct) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "INSERT INTO customers (full_name, phone, email, discount_pct) " +
                     "VALUES (@FullName, @Phone, @Email, @DiscountPct)";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@FullName", FullName);                    // Повне ім'я
      cmd.Parameters.AddWithValue("@Phone", Phone);                          // Телефон (UNIQUE)
      cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(Email) // Email може бути NULL
                                            ? (object)DBNull.Value : Email);
      cmd.Parameters.AddWithValue("@DiscountPct", DiscountPct);              // Знижка (%)

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    // Отримання повного списку клієнтів
    public List<Customer> GetAllCustomers() {
      int i = 0;
      List<Customer> CustomerList = new List<Customer>();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT * FROM customers";
      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        Customer c = new Customer();

        c.Number = ++i;                                         // Порядковий номер
        c.CustomerId = Convert.ToInt32(reader["customer_id"]);      // Ідентифікатор
        c.FullName = reader["full_name"].ToString();              // ПІБ
        c.Phone = reader["phone"].ToString();                  // Телефон
        c.Email = reader["email"] == DBNull.Value ? string.Empty
                                                        : reader["email"].ToString(); // Email (може бути NULL)
        c.DiscountPct = Convert.ToDouble(reader["discount_pct"]);    // Знижка, %
        c.CreatedAt = Convert.ToDateTime(reader["created_at"]);    // Дата створення

        CustomerList.Add(c);
      }

      reader.Close();
      connection.Close();

      // Якщо даних немає — службовий запис для UI
      if (CustomerList.Count == 0) {
        Customer noCustomer = new Customer();
        noCustomer.CustomerId = 0;
        noCustomer.Message = NamesMy.NoDataNames.NoDataInCustomers;
        CustomerList.Add(noCustomer);
      }

      return CustomerList;
    }

    // Отримання вибраного клієнта за його ідентифікатором
    public Customer SelectedCustomerById(int CustomerId) {
      Customer selectedCustomer = new Customer();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT * FROM customers WHERE customer_id = " + CustomerId.ToString();
      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        selectedCustomer.CustomerId = Convert.ToInt32(reader["customer_id"]);
        selectedCustomer.FullName = reader["full_name"].ToString();
        selectedCustomer.Phone = reader["phone"].ToString();
        selectedCustomer.Email = reader["email"] == DBNull.Value ? string.Empty
                                                                       : reader["email"].ToString();
        selectedCustomer.DiscountPct = Convert.ToDouble(reader["discount_pct"]);
        selectedCustomer.CreatedAt = Convert.ToDateTime(reader["created_at"]);
      }

      reader.Close();
      connection.Close();
      return selectedCustomer;
    }

    // Оновлення даних про клієнта
    public void UpdateCustomer(string FullName, string Phone, string Email, double DiscountPct, int CustomerId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "UPDATE customers SET full_name = @FullName, phone = @Phone, email = @Email, " +
                     "discount_pct = @DiscountPct WHERE customer_id = @CustomerId";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@FullName", FullName);
      cmd.Parameters.AddWithValue("@Phone", Phone);
      cmd.Parameters.AddWithValue("@Email", string.IsNullOrWhiteSpace(Email) ? (object)DBNull.Value : Email);
      cmd.Parameters.AddWithValue("@DiscountPct", DiscountPct);
      cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    // Видалення клієнта за ідентифікатором
    public void DeleteCustomer(int CustomerId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "DELETE FROM customers WHERE customer_id = @CustomerId";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@CustomerId", CustomerId);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }


  }
}

public class Customer {
  private int _Number;             // Порядковий номер запису (для відображення у таблицях)
  private int _CustomerId;         // Унікальний ідентифікатор клієнта (customer_id)
  private string _FullName;        // Повне ім’я клієнта (full_name)
  private string _Phone;           // Номер телефону (phone)
  private string _Email;           // Електронна адреса (email)
  private double _DiscountPct;     // Розмір знижки у відсотках (discount_pct)
  private DateTime _CreatedAt;     // Дата та час реєстрації клієнта (created_at)
  private string _Message;         // Повідомлення або службовий коментар

  // Конструктор за замовчуванням
  public Customer() {
    _Number = 0;
    _CustomerId = 0;
    _FullName = string.Empty;
    _Phone = string.Empty;
    _Email = string.Empty;
    _DiscountPct = 0.0;
    _CreatedAt = DateTime.Now;
    _Message = string.Empty;
  }

  // Порядковий номер
  public int Number {
    get { return _Number; }
    set { _Number = value; }
  }

  // Ідентифікатор клієнта
  public int CustomerId {
    get { return _CustomerId; }
    set { _CustomerId = value; }
  }

  // Повне ім’я клієнта
  public string FullName {
    get { return _FullName; }
    set { _FullName = value; }
  }

  // Номер телефону
  public string Phone {
    get { return _Phone; }
    set { _Phone = value; }
  }

  // Електронна адреса
  public string Email {
    get { return _Email; }
    set { _Email = value; }
  }

  // Знижка клієнта у відсотках
  public double DiscountPct {
    get { return _DiscountPct; }
    set { _DiscountPct = value; }
  }

  // Дата створення (реєстрації)
  public DateTime CreatedAt {
    get { return _CreatedAt; }
    set { _CreatedAt = value; }
  }

  // Службове повідомлення
  public string Message {
    get { return _Message; }
    set { _Message = value; }
  }
}
