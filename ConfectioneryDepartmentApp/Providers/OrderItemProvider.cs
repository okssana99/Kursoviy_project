using ConfectioneryDepartmentApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryDepartmentApp.Providers {
  internal class OrderItemProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    // ===================== INSERT BATCH =====================
    // Пакетне додавання позицій замовлення (у транзакції)
    public void InsertBatchOrderItems(List<OrderItem> items) {
      if (items == null || items.Count == 0) return;
      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        connection.Open();
        using (var tx = connection.BeginTransaction()) {
          string query = @"
        INSERT INTO order_items (order_id, product_id, qty, unit_price) 
        VALUES (@OrderId, @ProductId, @Qty, @UnitPrice)";

          using (MySqlCommand cmd = new MySqlCommand(query, connection, tx)) {
            cmd.Parameters.Add("@OrderId", MySqlDbType.Int32);
            cmd.Parameters.Add("@ProductId", MySqlDbType.Int32);
            cmd.Parameters.Add("@Qty", MySqlDbType.Double);
            cmd.Parameters.Add("@UnitPrice", MySqlDbType.Double);

            foreach (var it in items) {
              cmd.Parameters["@OrderId"].Value = it.OrderId;
              cmd.Parameters["@ProductId"].Value = it.ProductId;
              cmd.Parameters["@Qty"].Value = it.Qty;
              cmd.Parameters["@UnitPrice"].Value = it.UnitPrice;
              cmd.ExecuteNonQuery();
            }
          }
          tx.Commit();
        }
      }
    }


    // ===================== SELECT BY ORDER =====================
    // Отримання всіх позицій замовлення з назвою продукту
    public List<OrderItem> GetAllOrderItemsByOrderId(int OrderId) {
      int i = 0;
      List<OrderItem> ItemList = new List<OrderItem>();

      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        string query =
          "SELECT oi.order_items_id, oi.order_id, oi.product_id, oi.qty, oi.unit_price, oi.line_total, p.product_name " +
          "FROM order_items oi " +
          "JOIN products p ON p.product_id = oi.product_id " +
          "WHERE oi.order_id = @OrderId";

        using (MySqlCommand command = new MySqlCommand(query, connection)) {
          command.Parameters.AddWithValue("@OrderId", OrderId);

          connection.Open();
          using (MySqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) {
              OrderItem it = new OrderItem();
              it.Number = ++i;                                // Порядковий номер (для UI)
              it.OrderId = Convert.ToInt32(reader["order_id"]);  // Ідентифікатор замовлення
              it.ProductId = Convert.ToInt32(reader["product_id"]); // Ідентифікатор продукту
              it.Qty = Convert.ToDouble(reader["qty"]);            // Кількість
              it.UnitPrice = Convert.ToDouble(reader["unit_price"]); // Ціна
              it.LineTotal = Convert.ToDouble(reader["line_total"]); // Сума рядка

              // Назва продукту
              it.ProductName = reader["product_name"].ToString();

              ItemList.Add(it);
            }
          }
        }
      }

      // Якщо даних немає — службовий запис для UI
      if (ItemList.Count == 0) {
        OrderItem noItem = new OrderItem();
        noItem.OrderId = OrderId;
        noItem.Message = NamesMy.NoDataNames.NoDataInOrderItems;
        ItemList.Add(noItem);
      }

      return ItemList;
    }

    // ===================== DELETE BY ORDER =====================
    // Видалення всіх позицій за ідентифікатором замовлення
    public void DeleteOrderItemsByOrderId(int OrderId) {
      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        string query = "DELETE FROM order_items WHERE order_id = @OrderId";
        using (MySqlCommand cmd = new MySqlCommand(query, connection)) {
          cmd.Parameters.AddWithValue("@OrderId", OrderId);
          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }


  }
}

public class OrderItem {
  private int _Number;        // Порядковий номер запису для відображення у звітах/таблицях (не зберігається в БД)
  private int _OrderId;       // Ідентифікатор замовлення (PK, FK → orders.order_id)
  private int _ProductId;     // Ідентифікатор виробу (FK → products.product_id)
  private string _ProductName;
  private double _Qty;        // Кількість (шт або кг; одиниця не зберігається в цій версії таблиці)
  private double _UnitPrice;  // Ціна за одиницю на момент замовлення
  private double _LineTotal;  // Сума рядка (qty * unit_price), обчислюється на рівні БД (GENERATED ALWAYS)
  private string _Message;    // Службове повідомлення (наприклад, "Дані відсутні")

  // Конструктор за замовчуванням
  public OrderItem() {
    _Number = 0;
    _OrderId = 0;
    _ProductId = 0;
    _ProductName = string.Empty;
    _Qty = 0.0;
    _UnitPrice = 0.0;
    _LineTotal = 0.0;   // Значення встановлюється після зчитування з БД
    _Message = string.Empty;
  }

  // Порядковий номер (для UI)
  public int Number {
    get { return _Number; }
    set { _Number = value; }
  }

  // Ідентифікатор замовлення (PK)
  public int OrderId {
    get { return _OrderId; }
    set { _OrderId = value; }
  }

  // Ідентифікатор продукту (FK)
  public int ProductId {
    get { return _ProductId; }
    set { _ProductId = value; }
  }
  public string ProductName {
    get { return _ProductName; }
    set { _ProductName = value; }
  }
  // Кількість
  public double Qty {
    get { return _Qty; }
    set { _Qty = value; }
  }

  // Ціна за одиницю
  public double UnitPrice {
    get { return _UnitPrice; }
    set { _UnitPrice = value; }
  }

  // Сума рядка (обчислювана в БД)
  public double LineTotal {
    get { return _LineTotal; }
    set { _LineTotal = value; }
  }

  // Службове повідомлення
  public string Message {
    get { return _Message; }
    set { _Message = value; }
  }
}
