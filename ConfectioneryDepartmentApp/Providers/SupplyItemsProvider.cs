using ConfectioneryDepartmentApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryDepartmentApp.Providers {
  internal class SupplyItemsProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    // ===================== INSERT BATCH =====================
    // Пакетне додавання позицій накладної (у транзакції)
    public void InsertBatchSupplyItems(List<SupplyItems> items) {
      if (items == null || items.Count == 0) return;

      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        connection.Open();
        using (var tx = connection.BeginTransaction()) {
          string query = @"
          INSERT INTO supply_items (supply_id, product_id, qty, unit_cost)
          VALUES (@SupplyId, @ProductId, @Qty, @UnitCost)";

          using (MySqlCommand cmd = new MySqlCommand(query, connection, tx)) {
            cmd.Parameters.Add("@SupplyId", MySqlDbType.Int32);
            cmd.Parameters.Add("@ProductId", MySqlDbType.Int32);
            cmd.Parameters.Add("@Qty", MySqlDbType.Double);
            cmd.Parameters.Add("@UnitCost", MySqlDbType.Double);

            foreach (var it in items) {
              cmd.Parameters["@SupplyId"].Value = it.SupplyId;
              cmd.Parameters["@ProductId"].Value = it.ProductId;
              cmd.Parameters["@Qty"].Value = it.Qty;
              cmd.Parameters["@UnitCost"].Value = it.UnitCost;
              cmd.ExecuteNonQuery();
            }
          }

          tx.Commit();
        }
      }
    }

    // ===================== SELECT BY SUPPLY =====================
    // Отримання всіх позицій накладної з назвою продукту
    public List<SupplyItems> GetAllSupplyItemsBySupplyId(int SupplyId) {
      int i = 0;
      List<SupplyItems> ItemList = new List<SupplyItems>();

      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        string query = @"
        SELECT si.supply_item_id, si.supply_id, si.product_id, si.qty, si.unit_cost, si.line_total,
               p.product_name
        FROM supply_items si
        JOIN products p ON p.product_id = si.product_id
        WHERE si.supply_id = @SupplyId";

        using (MySqlCommand command = new MySqlCommand(query, connection)) {
          command.Parameters.AddWithValue("@SupplyId", SupplyId);

          connection.Open();
          using (MySqlDataReader reader = command.ExecuteReader()) {
            while (reader.Read()) {
              SupplyItems it = new SupplyItems();
              it.Number = ++i;                                     // Порядковий номер (для UI)
              it.SupplyId = Convert.ToInt32(reader["supply_id"]);    // Ідентифікатор накладної
              it.ProductId = Convert.ToInt32(reader["product_id"]);   // Ідентифікатор продукту
              it.Qty = Convert.ToDouble(reader["qty"]);         // Кількість
              it.UnitCost = Convert.ToDouble(reader["unit_cost"]);   // Закупівельна ціна
              it.LineTotal = Convert.ToDouble(reader["line_total"]);  // Сума рядка
              it.ProductName = reader["product_name"].ToString();       // Назва продукту
              ItemList.Add(it);
            }
          }
        }
      }

      // Якщо даних немає — службовий запис для UI
      if (ItemList.Count == 0) {
        SupplyItems noItem = new SupplyItems();
        noItem.SupplyId = SupplyId;
        noItem.Message = NamesMy.NoDataNames.NoDataInSupplyItems;
        ItemList.Add(noItem);
      }

      return ItemList;
    }

    // ===================== DELETE BY SUPPLY =====================
    // Видалення всіх позицій за ідентифікатором накладної
    public void DeleteSupplyItemsBySupplyId(int SupplyId) {
      using (MySqlConnection connection = new MySqlConnection(_ConnString)) {
        string query = "DELETE FROM supply_items WHERE supply_id = @SupplyId";
        using (MySqlCommand cmd = new MySqlCommand(query, connection)) {
          cmd.Parameters.AddWithValue("@SupplyId", SupplyId);
          connection.Open();
          cmd.ExecuteNonQuery();
        }
      }
    }


  }
}


public class SupplyItems {
  private int _Number;          // Порядковий номер запису для відображення у звітах/таблицях (не зберігається в БД)
  private int _SupplyId;        // Ідентифікатор накладної (PK, FK → supply_invoices.supply_id)
  private int _ProductId;       // Ідентифікатор товару (FK → products.product_id)
  private string _ProductName;  // Назва товару для відображення у звітах
  private double _Qty;          // Кількість отриманого товару
  private double _UnitCost;     // Закупівельна ціна одиниці товару на момент постачання
  private double _LineTotal;    // Загальна сума рядка (qty * unit_cost), обчислюється в БД (GENERATED ALWAYS)
  private string _Message;      // Службове повідомлення для UI (наприклад, "Дані відсутні")

  // Конструктор за замовчуванням
  public SupplyItems() {
    _Number = 0;
    _SupplyId = 0;
    _ProductId = 0;
    _ProductName = string.Empty;
    _Qty = 0.0;
    _UnitCost = 0.0;
    _LineTotal = 0.0;   // Значення встановлюється після зчитування з БД
    _Message = string.Empty;
  }

  // Порядковий номер (для UI)
  public int Number {
    get { return _Number; }
    set { _Number = value; }
  }

  // Ідентифікатор накладної (PK)
  public int SupplyId {
    get { return _SupplyId; }
    set { _SupplyId = value; }
  }

  // Ідентифікатор товару (FK)
  public int ProductId {
    get { return _ProductId; }
    set { _ProductId = value; }
  }

  // Назва товару
  public string ProductName {
    get { return _ProductName; }
    set { _ProductName = value; }
  }

  // Кількість товару
  public double Qty {
    get { return _Qty; }
    set { _Qty = value; }
  }

  // Закупівельна ціна одиниці
  public double UnitCost {
    get { return _UnitCost; }
    set { _UnitCost = value; }
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
