using ConfectioneryDepartmentApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryDepartmentApp.Providers {
  internal class SupplyInvoicesProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    // ===================== INSERT =====================
    // Додавання нової накладної на постачання
    public void InsertSupply(int SupplierId, string Status, DateTime? DueDt, string Notes, double? ManualTotal) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "INSERT INTO supply_invoices (supplier_id, status, due_dt, notes, manual_total) " +
                     "VALUES (@SupplierId, @Status, @DueDt, @Notes, @ManualTotal)";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@SupplierId", SupplierId);   // FK → suppliers.SupplierId
      cmd.Parameters.AddWithValue("@Status", Status);           // Статус постачання
      cmd.Parameters.AddWithValue("@DueDt", DueDt.HasValue ? (object)DueDt.Value : DBNull.Value);
      cmd.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(Notes) ? (object)DBNull.Value : Notes);
      cmd.Parameters.AddWithValue("@ManualTotal", (object)ManualTotal ?? DBNull.Value);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    // Додавання накладної з поверненням її ідентифікатора
    public int InsertSupplyAndGetId(int SupplierId, string Status, DateTime? DueDt, string Notes, double? ManualTotal) {
      int newSupplyId = 0;
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "INSERT INTO supply_invoices (supplier_id, status, due_dt, notes, manual_total) " +
                     "VALUES (@SupplierId, @Status, @DueDt, @Notes, @ManualTotal); " +
                     "SELECT LAST_INSERT_ID();";

      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
      cmd.Parameters.AddWithValue("@Status", Status);
      cmd.Parameters.AddWithValue("@DueDt", DueDt.HasValue ? (object)DueDt.Value : DBNull.Value);
      cmd.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(Notes) ? (object)DBNull.Value : Notes);
      cmd.Parameters.AddWithValue("@ManualTotal", (object)ManualTotal ?? DBNull.Value);

      connection.Open();
      object result = cmd.ExecuteScalar();
      if (result != null)
        newSupplyId = Convert.ToInt32(result);
      connection.Close();

      return newSupplyId;
    }

    // ===================== SELECT ALL =====================
    // Отримання повного списку накладних
    public List<SupplyInvoices> GetAllSupplies() {
      int i = 0;
      List<SupplyInvoices> SupplyList = new List<SupplyInvoices>();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = @"SELECT s.supply_id, s.supplier_id, sp.SupplierName, s.status, 
                            s.supply_dt, s.due_dt, s.notes, s.manual_total
                     FROM supply_invoices s
                     JOIN suppliers sp ON s.supplier_id = sp.SupplierId
                     ORDER BY s.supply_dt DESC";
      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        SupplyInvoices si = new SupplyInvoices();

        si.Number = ++i;
        si.SupplyId = Convert.ToInt32(reader["supply_id"]);
        si.SupplierId = Convert.ToInt32(reader["supplier_id"]);
        si.SupplierName = reader["SupplierName"].ToString();
        si.Status = reader["status"].ToString();
        si.SupplyDt = Convert.ToDateTime(reader["supply_dt"]);

        si.DueDt = reader["due_dt"] == DBNull.Value ? (DateTime?)null
                                                    : Convert.ToDateTime(reader["due_dt"]);

        si.Notes = reader["notes"] == DBNull.Value ? string.Empty
                                                   : reader["notes"].ToString();

        si.ManualTotal = reader["manual_total"] == DBNull.Value ? 0.0
                                                                : Convert.ToDouble(reader["manual_total"]);

        SupplyList.Add(si);
      }

      reader.Close();
      connection.Close();

      // Якщо даних немає — службовий запис для UI
      if (SupplyList.Count == 0) {
        SupplyInvoices noSupply = new SupplyInvoices();
        noSupply.SupplyId = 0;
        noSupply.Message = NamesMy.NoDataNames.NoDataInSupplyInvoices;
        SupplyList.Add(noSupply);
      }

      return SupplyList;
    }

    // ===================== SELECT: "нове" | "в роботі" =====================
    // Отримання накладних постачання зі статусами "нове" або "в роботі"
    // + підтягується SupplierName з таблиці suppliers
    public List<SupplyInvoices> GetSuppliesByStatus() {
      int i = 0;
      List<SupplyInvoices> SupplyList = new List<SupplyInvoices>();

      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = @"
    SELECT s.supply_id, s.supplier_id, s.status, s.supply_dt, s.due_dt, s.notes, s.manual_total,
           sp.SupplierName
    FROM supply_invoices s
    JOIN suppliers sp ON s.supplier_id = sp.SupplierId
    WHERE s.status IN ('нове', 'в роботі')";

      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        SupplyInvoices si = new SupplyInvoices();

        si.Number = ++i;                                      // Порядковий номер
        si.SupplyId = Convert.ToInt32(reader["supply_id"]);     // Ідентифікатор накладної
        si.SupplierId = Convert.ToInt32(reader["supplier_id"]);   // Ідентифікатор постачальника
        si.Status = reader["status"].ToString();              // Статус
        si.SupplyDt = Convert.ToDateTime(reader["supply_dt"]);  // Дата створення

        // Термін може бути NULL
        si.DueDt = reader["due_dt"] == DBNull.Value ? (DateTime?)null
                                                          : Convert.ToDateTime(reader["due_dt"]);

        // Примітки можуть бути NULL
        si.Notes = reader["notes"] == DBNull.Value ? string.Empty
                                                         : reader["notes"].ToString();

        // Ручна сума може бути NULL
        si.ManualTotal = reader["manual_total"] == DBNull.Value ? 0.0
                                                                : Convert.ToDouble(reader["manual_total"]);

        // Назва постачальника для UI
        si.SupplierName = reader["SupplierName"].ToString();

        SupplyList.Add(si);
      }

      reader.Close();
      connection.Close();

      // Якщо даних немає — службовий запис для UI
      if (SupplyList.Count == 0) {
        SupplyInvoices noSupply = new SupplyInvoices();
        noSupply.SupplyId = 0;
        noSupply.Message = NamesMy.NoDataNames.NoDataInSupplyInvoices;
        SupplyList.Add(noSupply);
      }

      return SupplyList;
    }

    // ===================== SELECT: "отримано" =====================
    // Отримання накладних постачання зі статусом "отримано"
    // + підтягується SupplierName з таблиці suppliers
    public List<SupplyInvoices> GetFinishedSupplies() {
      int i = 0;
      List<SupplyInvoices> SupplyList = new List<SupplyInvoices>();

      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = @"
    SELECT s.supply_id, s.supplier_id, s.status, s.supply_dt, s.due_dt, s.notes, s.manual_total,
           sp.SupplierName
    FROM supply_invoices s
    JOIN suppliers sp ON s.supplier_id = sp.SupplierId
    WHERE s.status IN ('отримано')";

      MySqlCommand command = new MySqlCommand(query, connection);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      while (reader.Read()) {
        SupplyInvoices si = new SupplyInvoices();

        si.Number = ++i;
        si.SupplyId = Convert.ToInt32(reader["supply_id"]);
        si.SupplierId = Convert.ToInt32(reader["supplier_id"]);
        si.Status = reader["status"].ToString();
        si.SupplyDt = Convert.ToDateTime(reader["supply_dt"]);

        si.DueDt = reader["due_dt"] == DBNull.Value ? (DateTime?)null
                                                          : Convert.ToDateTime(reader["due_dt"]);

        si.Notes = reader["notes"] == DBNull.Value ? string.Empty
                                                         : reader["notes"].ToString();

        si.ManualTotal = reader["manual_total"] == DBNull.Value ? 0.0
                                                                : Convert.ToDouble(reader["manual_total"]);

        si.SupplierName = reader["SupplierName"].ToString();

        SupplyList.Add(si);
      }

      reader.Close();
      connection.Close();

      if (SupplyList.Count == 0) {
        SupplyInvoices noSupply = new SupplyInvoices();
        noSupply.SupplyId = 0;
        noSupply.Message = NamesMy.NoDataNames.NoDataInSupplyInvoices;
        SupplyList.Add(noSupply);
      }

      return SupplyList;
    }

    // ===================== SELECT BY ID =====================
    // Отримання вибраної накладної постачання за її ідентифікатором
    public SupplyInvoices SelectedSupplyById(int SupplyId) {
      SupplyInvoices selected = new SupplyInvoices();

      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = @"SELECT s.supply_id, s.supplier_id, s.status, s.supply_dt, s.due_dt, s.notes, s.manual_total,
                          sp.SupplierName
                   FROM supply_invoices s
                   JOIN suppliers sp ON s.supplier_id = sp.SupplierId
                   WHERE s.supply_id = @id";

      MySqlCommand command = new MySqlCommand(query, connection);
      command.Parameters.AddWithValue("@id", SupplyId);

      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();

      if (reader.Read()) {
        selected.SupplyId = Convert.ToInt32(reader["supply_id"]);
        selected.SupplierId = Convert.ToInt32(reader["supplier_id"]);
        selected.Status = reader["status"].ToString();
        selected.SupplyDt = Convert.ToDateTime(reader["supply_dt"]);
        selected.DueDt = reader["due_dt"] == DBNull.Value ? (DateTime?)null
                                                                 : Convert.ToDateTime(reader["due_dt"]);
        selected.Notes = reader["notes"] == DBNull.Value ? string.Empty
                                                                : reader["notes"].ToString();
        selected.ManualTotal = reader["manual_total"] == DBNull.Value ? 0.0
                                                                       : Convert.ToDouble(reader["manual_total"]);
        selected.SupplierName = reader["SupplierName"].ToString();
      }

      reader.Close();
      connection.Close();

      return selected;
    }

    // ===================== UPDATE =====================
    // Оновлення даних про накладну постачання
    public void UpdateSupply(int SupplierId, string Status, DateTime? DueDt, string Notes, double? ManualTotal, int SupplyId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "UPDATE supply_invoices SET supplier_id = @SupplierId, status = @Status, due_dt = @DueDt, " +
                     "notes = @Notes, manual_total = @ManualTotal WHERE supply_id = @SupplyId";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
      cmd.Parameters.AddWithValue("@Status", Status);
      cmd.Parameters.AddWithValue("@DueDt", DueDt.HasValue ? (object)DueDt.Value : DBNull.Value);
      cmd.Parameters.AddWithValue("@Notes", string.IsNullOrWhiteSpace(Notes) ? (object)DBNull.Value : Notes);
      cmd.Parameters.AddWithValue("@ManualTotal", (object)ManualTotal ?? DBNull.Value);
      cmd.Parameters.AddWithValue("@SupplyId", SupplyId);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    // ===================== DELETE =====================
    // Видалення накладної постачання за ідентифікатором
    public void DeleteSupply(int SupplyId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "DELETE FROM supply_invoices WHERE supply_id = @SupplyId";
      MySqlCommand cmd = new MySqlCommand(query, connection);

      cmd.Parameters.AddWithValue("@SupplyId", SupplyId);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    // ===================== UPDATE STATUS =====================
    // Оновлення статусу накладної постачання на "отримано"
    public void UpdateSupplyStatusToReceived(int SupplyId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "UPDATE supply_invoices SET status = 'отримано' WHERE supply_id = @SupplyId";

      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("@SupplyId", SupplyId);

      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }


    /// <summary>
    /// Приймає накладну: додає кількість товарів з supply_items у products.quantity
    /// та оновлює статус накладної на "отримано". Все – в одній транзакції.
    /// </summary>
    public bool TryReceiveSupplyAndAddStock(int supplyId, out string message) {
      message = string.Empty;

      using (var cn = new MySqlConnection(_ConnString)) {
        cn.Open();
        using (var tx = cn.BeginTransaction()) {
          try {
            // 0) Захист від повторної обробки
            using (var chk = new MySqlCommand(
              "SELECT status FROM supply_invoices WHERE supply_id=@id FOR UPDATE;",
              cn, tx)) {
              chk.Parameters.AddWithValue("@id", supplyId);
              var statusObj = chk.ExecuteScalar();
              if (statusObj == null) {
                tx.Rollback();
                message = "Накладну не знайдено.";
                return false;
              }
              var status = Convert.ToString(statusObj) ?? string.Empty;
              if (status.Equals("отримано", StringComparison.OrdinalIgnoreCase)) {
                tx.Rollback();
                message = "Накладну вже отримано раніше.";
                return false;
              }
            }

            // 1) Оновити залишки за один прохід (JOIN + агрегування позицій)
            //    Збільшуємо products.quantity на суму qty з усіх позицій накладної.
            using (var upd = new MySqlCommand(@"
            UPDATE products p
            JOIN (
              SELECT si.product_id, SUM(si.qty) AS sum_qty
              FROM supply_items si
              WHERE si.supply_id = @sid
              GROUP BY si.product_id
            ) t ON t.product_id = p.product_id
            SET p.quantity = p.quantity + t.sum_qty;", cn, tx)) {
              upd.Parameters.AddWithValue("@sid", supplyId);
              int affected = upd.ExecuteNonQuery();
              if (affected <= 0) {
                tx.Rollback();
                message = "У накладній немає позицій або не вдалося оновити залишки.";
                return false;
              }
            }

            // 2) Оновити статус накладної
            using (var st = new MySqlCommand(
              "UPDATE supply_invoices SET status='отримано' WHERE supply_id=@sid;", cn, tx)) {
              st.Parameters.AddWithValue("@sid", supplyId);
              st.ExecuteNonQuery();
            }

            tx.Commit();
            message = "Отримання продукції підтверджено та залишки оновлено.";
            return true;
          } catch (Exception ex) {
            try { tx.Rollback(); } catch { /* ignore */ }
            message = "Помилка під час приймання накладної: " + ex.Message;
            return false;
          }
        }
      }
    }


  }
}

public class SupplyInvoices {
  private int _Number;             // Порядковий номер запису для відображення у таблицях
  private int _SupplyId;           // Унікальний ідентифікатор накладної (supply_id)
  private int _SupplierId;         // Ідентифікатор постачальника (FK → suppliers.SupplierId)
  private string _SupplierName;    // Назва постачальника (для відображення в UI)
  private string _Status;          // Поточний статус накладної (status)
  private DateTime _SupplyDt;      // Дата створення або реєстрації накладної (supply_dt)
  private DateTime? _DueDt;        // Очікувана дата поставки або оплати (due_dt, може бути NULL)
  private string _Notes;           // Додаткові примітки до постачання (notes)
  private double _ManualTotal;     // Підсумкова сума накладної, зафіксована вручну (manual_total)
  private string _Message;         // Службове повідомлення для відображення в UI

  // Конструктор за замовчуванням
  public SupplyInvoices() {
    _Number = 0;
    _SupplyId = 0;
    _SupplierId = 0;
    _SupplierName = string.Empty;
    _Status = string.Empty;
    _SupplyDt = DateTime.Now;
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

  // Ідентифікатор накладної
  public int SupplyId {
    get { return _SupplyId; }
    set { _SupplyId = value; }
  }

  // Ідентифікатор постачальника
  public int SupplierId {
    get { return _SupplierId; }
    set { _SupplierId = value; }
  }

  // Назва постачальника
  public string SupplierName {
    get { return _SupplierName; }
    set { _SupplierName = value; }
  }

  // Статус накладної
  public string Status {
    get { return _Status; }
    set { _Status = value; }
  }

  // Дата створення накладної
  public DateTime SupplyDt {
    get { return _SupplyDt; }
    set { _SupplyDt = value; }
  }

  // Очікувана дата поставки/оплати
  public DateTime? DueDt {
    get { return _DueDt; }
    set { _DueDt = value; }
  }

  // Примітки
  public string Notes {
    get { return _Notes; }
    set { _Notes = value; }
  }

  // Підсумкова сума вручну
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
