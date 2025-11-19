using ConfectioneryDepartmentApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryDepartmentApp.Providers {
  internal class OrderProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    // ===================== INSERT =====================
    // Додавання нового замовлення
    public void InsertOrder(int CustomerId, string Status, DateTime? DueDt, string Notes, double? ManualTotal) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "INSERT INTO orders (customer_id, status, due_dt, notes, manual_total) " +
                     "VALUES (@CustomerId, @Status, @DueDt, @Notes, @ManualTotal)";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@CustomerId", CustomerId);                       // FK → customers.customer_id
      cmd.Parameters.AddWithValue("@Status", Status);                               // Статус замовлення
      cmd.Parameters.AddWithValue("@DueDt", DueDt.HasValue ? (object)DueDt.Value : DBNull.Value);  // Термін готовності
      cmd.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(Notes) ? (object)DBNull.Value : Notes); // Примітки
      cmd.Parameters.AddWithValue("@ManualTotal", (object)ManualTotal ?? DBNull.Value); // Ручна сума (може бути NULL)

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    // Додавання нового замовлення та повернення його ідентифікатора
    public int InsertOrderAndGetId(int CustomerId, string Status, DateTime? DueDt, string Notes, double? ManualTotal) {
      int newOrderId = 0;
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "INSERT INTO orders (customer_id, status, due_dt, notes, manual_total) " +
                     "VALUES (@CustomerId, @Status, @DueDt, @Notes, @ManualTotal); " +
                     "SELECT LAST_INSERT_ID();";  // Отримання ідентифікатора доданого запису

      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
      cmd.Parameters.AddWithValue("@Status", Status);
      cmd.Parameters.AddWithValue("@DueDt", DueDt.HasValue ? (object)DueDt.Value : DBNull.Value);
      cmd.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(Notes) ? (object)DBNull.Value : Notes);
      cmd.Parameters.AddWithValue("@ManualTotal", (object)ManualTotal ?? DBNull.Value);

      connection.Open();
      object result = cmd.ExecuteScalar();  // Виконання запиту та зчитування ID
      if (result != null)
        newOrderId = Convert.ToInt32(result);
      connection.Close();

      return newOrderId;
    }


    // ===================== SELECT ALL =====================
    // Отримання повного списку замовлень
    public List<Order> GetAllOrders() {
      int i = 0;
      List<Order> OrderList = new List<Order>();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT * FROM orders";
      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        Order o = new Order();

        o.Number = ++i;                                      // Порядковий номер
        o.OrderId = Convert.ToInt32(reader["order_id"]);      // Ідентифікатор замовлення
        o.CustomerId = Convert.ToInt32(reader["customer_id"]);   // Ідентифікатор клієнта
        o.Status = reader["status"].ToString();              // Статус
        o.OrderDt = Convert.ToDateTime(reader["order_dt"]);   // Дата створення

        // Термін готовності може бути NULL
        o.DueDt = reader["due_dt"] == DBNull.Value ? (DateTime?)null
                                                        : Convert.ToDateTime(reader["due_dt"]);

        // Примітки можуть бути NULL
        o.Notes = reader["notes"] == DBNull.Value ? string.Empty
                                                       : reader["notes"].ToString();

        // Ручна сума може бути NULL
        o.ManualTotal = reader["manual_total"] == DBNull.Value ? 0.0
                                                               : Convert.ToDouble(reader["manual_total"]);
        OrderList.Add(o);
      }

      reader.Close();
      connection.Close();

      // Якщо даних немає — службовий запис для UI
      if (OrderList.Count == 0) {
        Order noOrder = new Order();
        noOrder.OrderId = 0;
        noOrder.Message = NamesMy.NoDataNames.NoDataInOrders;
        OrderList.Add(noOrder);
      }

      return OrderList;
    }


    public List<Order> GetOrdersByStatus() {
      int i = 0;
      List<Order> OrderList = new List<Order>();

      // SQL-запит для вибірки замовлень із статусами "нове" або "в роботі" і додаванням FullName з таблиці customers
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = @"
    SELECT o.order_id, o.customer_id, o.status, o.order_dt, o.due_dt, o.notes, o.manual_total, c.full_name
    FROM orders o
    JOIN customers c ON o.customer_id = c.customer_id
    WHERE o.status IN ('нове', 'в роботі')";

      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        Order o = new Order();
        o.Number = ++i;                                          // Порядковий номер
        o.OrderId = Convert.ToInt32(reader["order_id"]);          // Ідентифікатор замовлення
        o.CustomerId = Convert.ToInt32(reader["customer_id"]);    // Ідентифікатор клієнта
        o.Status = reader["status"].ToString();                   // Статус
        o.OrderDt = Convert.ToDateTime(reader["order_dt"]);       // Дата створення

        // Термін готовності може бути NULL
        o.DueDt = reader["due_dt"] == DBNull.Value ? (DateTime?)null
                                                    : Convert.ToDateTime(reader["due_dt"]);

        // Примітки можуть бути NULL
        o.Notes = reader["notes"] == DBNull.Value ? string.Empty
                                                   : reader["notes"].ToString();

        // Ручна сума може бути NULL
        o.ManualTotal = reader["manual_total"] == DBNull.Value ? 0.0
                                                               : Convert.ToDouble(reader["manual_total"]);

        // Додаємо FullName клієнта
        o.FullName = reader["full_name"].ToString();  // FullName з таблиці customers

        OrderList.Add(o);
      }

      reader.Close();
      connection.Close();

      // Якщо даних немає — службовий запис для UI
      if (OrderList.Count == 0) {
        Order noOrder = new Order();
        noOrder.OrderId = 0;
        noOrder.Message = NamesMy.NoDataNames.NoDataInOrders;
        OrderList.Add(noOrder);
      }

      return OrderList;
    }

    public List<Order> GetFinishOrders() {
      int i = 0;
      List<Order> OrderList = new List<Order>();

      // SQL-запит для вибірки замовлень із статусами "нове" або "в роботі" і додаванням FullName з таблиці customers
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = @"
    SELECT o.order_id, o.customer_id, o.status, o.order_dt, o.due_dt, o.notes, o.manual_total, c.full_name
    FROM orders o
    JOIN customers c ON o.customer_id = c.customer_id
    WHERE o.status IN ('видано')";

      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        Order o = new Order();
        o.Number = ++i;                                          // Порядковий номер
        o.OrderId = Convert.ToInt32(reader["order_id"]);          // Ідентифікатор замовлення
        o.CustomerId = Convert.ToInt32(reader["customer_id"]);    // Ідентифікатор клієнта
        o.Status = reader["status"].ToString();                   // Статус
        o.OrderDt = Convert.ToDateTime(reader["order_dt"]);       // Дата створення

        // Термін готовності може бути NULL
        o.DueDt = reader["due_dt"] == DBNull.Value ? (DateTime?)null
                                                    : Convert.ToDateTime(reader["due_dt"]);

        // Примітки можуть бути NULL
        o.Notes = reader["notes"] == DBNull.Value ? string.Empty
                                                   : reader["notes"].ToString();

        // Ручна сума може бути NULL
        o.ManualTotal = reader["manual_total"] == DBNull.Value ? 0.0
                                                               : Convert.ToDouble(reader["manual_total"]);

        // Додаємо FullName клієнта
        o.FullName = reader["full_name"].ToString();  // FullName з таблиці customers

        OrderList.Add(o);
      }

      reader.Close();
      connection.Close();

      // Якщо даних немає — службовий запис для UI
      if (OrderList.Count == 0) {
        Order noOrder = new Order();
        noOrder.OrderId = 0;
        noOrder.Message = NamesMy.NoDataNames.NoDataInOrders;
        OrderList.Add(noOrder);
      }

      return OrderList;
    }


    // ===================== SELECT BY ID =====================
    // Отримання вибраного замовлення за його ідентифікатором
    public Order SelectedOrderById(int OrderId) {
      Order selectedOrder = new Order();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT * FROM orders WHERE order_id = " + OrderId.ToString();
      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        selectedOrder.OrderId = Convert.ToInt32(reader["order_id"]);
        selectedOrder.CustomerId = Convert.ToInt32(reader["customer_id"]);
        selectedOrder.Status = reader["status"].ToString();
        selectedOrder.OrderDt = Convert.ToDateTime(reader["order_dt"]);

        selectedOrder.DueDt = reader["due_dt"] == DBNull.Value ? (DateTime?)null
                                                                    : Convert.ToDateTime(reader["due_dt"]);
        selectedOrder.Notes = reader["notes"] == DBNull.Value ? string.Empty
                                                                   : reader["notes"].ToString();
        selectedOrder.ManualTotal = reader["manual_total"] == DBNull.Value ? 0.0
                                                                           : Convert.ToDouble(reader["manual_total"]);
      }

      reader.Close();
      connection.Close();
      return selectedOrder;
    }

    // ===================== UPDATE =====================
    // Оновлення даних про замовлення
    public void UpdateOrder(int CustomerId, string Status, DateTime? DueDt, string Notes, double? ManualTotal, int OrderId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "UPDATE orders SET customer_id = @CustomerId, status = @Status, due_dt = @DueDt, " +
                     "notes = @Notes, manual_total = @ManualTotal WHERE order_id = @OrderId";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
      cmd.Parameters.AddWithValue("@Status", Status);
      cmd.Parameters.AddWithValue("@DueDt", DueDt.HasValue ? (object)DueDt.Value : DBNull.Value);
      cmd.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(Notes) ? (object)DBNull.Value : Notes);
      cmd.Parameters.AddWithValue("@ManualTotal", (object)ManualTotal ?? DBNull.Value);
      cmd.Parameters.AddWithValue("@OrderId", OrderId);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    // ===================== DELETE =====================
    // Видалення замовлення за ідентифікатором
    public void DeleteOrder(int OrderId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "DELETE FROM orders WHERE order_id = @OrderId";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("@OrderId", OrderId);
      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    public void UpdateOrderStatusToDelivered(int OrderId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "UPDATE orders SET status = 'видано' WHERE order_id = @OrderId";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("@OrderId", OrderId);
      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }


    /// <summary>
    /// Перевіряє наявність усіх позицій замовлення та, якщо достатньо,
    /// списує кількість з products.quantity і оновлює статус замовлення на "видано".
    /// Усе виконується в одній транзакції (ACID).
    /// </summary>
    public bool TryIssueOrderAndDeductStock(int orderId, List<OrderItem> items, out string message) {
      message = string.Empty;

      if (items == null || items.Count == 0) {
        message = "У замовленні немає позицій.";
        return false;
      }

      using (var cn = new MySqlConnection(_ConnString)) {
        cn.Open();

        // REPEATABLE READ достатньо; за потреби можна підняти до SERIALIZABLE
        using (var tx = cn.BeginTransaction(System.Data.IsolationLevel.ReadCommitted)) {
          try {
            // 1) Перевірка наявності з блокуванням рядків
            var shortages = new List<string>();

            foreach (var it in items) {
              using (var sel = new MySqlCommand(@"
                SELECT product_name, quantity 
                FROM products 
                WHERE product_id = @pid
                FOR UPDATE;", cn, tx)) // Блокуємо рядок до кінця транзакції
              {
                sel.Parameters.AddWithValue("@pid", it.ProductId);

                using (var rd = sel.ExecuteReader()) {
                  if (!rd.Read()) {
                    shortages.Add($"ID={it.ProductId}: товар не знайдено");
                  } else {
                    string pname = rd.GetString("product_name");
                    // quantity в БД INT або DECIMAL — читаємо як decimal для точності
                    decimal stock = Convert.ToDecimal(rd["quantity"]);
                    decimal need = Convert.ToDecimal(it.Qty);

                    if (stock < need) {
                      shortages.Add($"{pname}: потрібно {need}, доступно {stock}");
                    }
                  }
                }
              }
            }

            if (shortages.Count > 0) {
              // Є нестачі — відкочуємо транзакцію і повертаємо повідомлення
              tx.Rollback();
              var sb = new StringBuilder();
              sb.AppendLine("Недостатньо товарів для видачі:");
              foreach (var s in shortages) sb.AppendLine(" • " + s);
              message = sb.ToString();
              return false;
            }

            // 2) Списання залишків
            foreach (var it in items) {
              using (var upd = new MySqlCommand(@"
                UPDATE products
                SET quantity = quantity - @qty
                WHERE product_id = @pid;", cn, tx)) {
                upd.Parameters.AddWithValue("@qty", Convert.ToDecimal(it.Qty));
                upd.Parameters.AddWithValue("@pid", it.ProductId);
                upd.ExecuteNonQuery();
              }
            }

            // 3) Зміна статусу замовлення на "видано"
            using (var updOrder = new MySqlCommand(@"
              UPDATE orders SET status = 'видано'
              WHERE order_id = @oid;", cn, tx)) {
              updOrder.Parameters.AddWithValue("@oid", orderId);
              updOrder.ExecuteNonQuery();
            }

            tx.Commit();
            message = "Замовлення видано, товари списано.";
            return true;
          } catch (Exception ex) {
            try { tx.Rollback(); } catch { /* ignore */ }
            message = "Помилка під час видачі замовлення: " + ex.Message;
            return false;
          }
        }
      }
    }


  }
}

public class Order {
  private int _Number;             // Порядковий номер запису для відображення у таблицях
  private int _OrderId;            // Унікальний ідентифікатор замовлення (order_id)
  private int _CustomerId;         // Ідентифікатор клієнта (FK → customers.customer_id)
  private string _FullName;        // Повне ім'я клієнта (для відображення в UI)
  private string _Status;          // Поточний статус замовлення (status)
  private DateTime _OrderDt;       // Дата створення замовлення (order_dt)
  private DateTime? _DueDt;        // Термін готовності або видачі (due_dt, може бути NULL)
  private string _Notes;           // Додаткові примітки до замовлення (notes)
  private double _ManualTotal;     // Вартість, зафіксована вручну (manual_total)
  private string _Message;         // Службове повідомлення для відображення в UI

  // Конструктор за замовчуванням
  public Order() {
    _Number = 0;
    _OrderId = 0;
    _CustomerId = 0;
    _FullName = string.Empty;
    _Status = string.Empty;
    _OrderDt = DateTime.Now;
    _DueDt = null;
    _Notes = string.Empty;
    _ManualTotal = 0.0;
    _Message = string.Empty;
  }

  // Порядковий номер
  public int Number {
    get { return _Number; }
    set { _Number = value; }
  }

  // Ідентифікатор замовлення
  public int OrderId {
    get { return _OrderId; }
    set { _OrderId = value; }
  }

  // Ідентифікатор клієнта
  public int CustomerId {
    get { return _CustomerId; }
    set { _CustomerId = value; }
  }
  public string FullName {
    get { return _FullName; }
    set { _FullName = value; }
  }
  // Статус замовлення
  public string Status {
    get { return _Status; }
    set { _Status = value; }
  }

  // Дата створення замовлення
  public DateTime OrderDt {
    get { return _OrderDt; }
    set { _OrderDt = value; }
  }

  // Термін готовності/видачі
  public DateTime? DueDt {
    get { return _DueDt; }
    set { _DueDt = value; }
  }

  // Примітки
  public string Notes {
    get { return _Notes; }
    set { _Notes = value; }
  }

  // Ручна загальна вартість
  public double ManualTotal {
    get { return _ManualTotal; }
    set { _ManualTotal = value; }
  }

  // Службове повідомлення
  public string Message {
    get { return _Message; }
    set { _Message = value; }
  }
}
