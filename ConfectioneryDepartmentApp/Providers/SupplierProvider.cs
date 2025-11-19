using ConfectioneryDepartmentApp.AppCode;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfectioneryDepartmentApp.Providers {
  internal class SupplierProvider {
    private string _ConnString = System.Configuration.ConfigurationSettings.AppSettings["CONNECTSQL"];

    public void InsertSupplier(string SupplierName, string Address, string Email, string Phone) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "INSERT INTO suppliers (SupplierName, Address, Email, Phone) VALUES(@SupplierName, @Address, @Email, @Phone)";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("@SupplierName", SupplierName);
      cmd.Parameters.AddWithValue("@Address", Address);
      cmd.Parameters.AddWithValue("@Email", Email);
      cmd.Parameters.AddWithValue("@Phone", Phone);
      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    public List<Supplier> GetAllSupplier() {
      int i = 0;
      List<Supplier> supplierList = new List<Supplier>();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT * FROM suppliers";
      MySqlCommand command = new MySqlCommand(query, connection);
      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();
      while (reader.Read()) {
        Supplier supplier = new Supplier() {
          Number = ++i,
          SupplierId = Convert.ToInt32(reader["SupplierId"]),
          SupplierName = reader["SupplierName"].ToString(),
          Address = reader["Address"].ToString(),
          Email = reader["Email"].ToString(),
          Phone = reader["Phone"].ToString()
        };
        supplierList.Add(supplier);
      }
      reader.Close();
      connection.Close();

      if (supplierList.Count == 0) {
        Supplier noSupplier = new Supplier();
        noSupplier.SupplierId = 0;
        noSupplier.Message = NamesMy.NoDataNames.NoDataInSupplier;
        supplierList.Add(noSupplier);
      }

      return supplierList;
    }

    public Supplier SelectedSupplierBySupplierId(int SupplierId) {
      Supplier selectedSupplier = new Supplier();
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "SELECT * FROM suppliers WHERE SupplierId = @SupplierId";
      MySqlCommand command = new MySqlCommand(query, connection);
      command.Parameters.AddWithValue("@SupplierId", SupplierId);
      connection.Open();
      MySqlDataReader reader = command.ExecuteReader();
      if (reader.Read()) {
        selectedSupplier.SupplierId = Convert.ToInt32(reader["SupplierId"]);
        selectedSupplier.SupplierName = reader["SupplierName"].ToString();
        selectedSupplier.Address = reader["Address"].ToString();
        selectedSupplier.Email = reader["Email"].ToString();
        selectedSupplier.Phone = reader["Phone"].ToString();
      }
      reader.Close();
      connection.Close();
      return selectedSupplier;
    }


    public void UpdateSupplier(string SupplierName, string Address, string Email, string Phone, int SupplierId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "UPDATE suppliers SET SupplierName = @SupplierName, Address = @Address, Email = @Email, Phone=@Phone WHERE SupplierId = @SupplierId";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("@SupplierName", SupplierName);
      cmd.Parameters.AddWithValue("@Address", Address);
      cmd.Parameters.AddWithValue("@Email", Email);
      cmd.Parameters.AddWithValue("@Phone", Phone);
      cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

    public void DeleteSupplier(int SupplierId) {
      MySqlConnection connection = new MySqlConnection(_ConnString);
      string query = "DELETE FROM suppliers WHERE SupplierId = @SupplierId";
      MySqlCommand cmd = new MySqlCommand(query, connection);
      cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
      connection.Open();
      cmd.ExecuteNonQuery();
      connection.Close();
    }

  }
}


public class Supplier {
  // Унікальний ідентифікатор постачальника
  private int _SupplierId;
  // Назва постачальника
  private string _SupplierName;
  // Адреса постачальника
  private string _Address;
  // Електронна пошта постачальника
  private string _Email;
  // Номер постачальника для внутрішнього використання
  private string _Phone;
  private int _Number;
  // Додаткове повідомлення або коментар
  private string _Message;

  public Supplier() {
    _SupplierId = 0;
    _SupplierName = String.Empty;
    _Address = String.Empty;
    _Email = String.Empty;
    _Phone = String.Empty;
    _Number = 0;
    _Message = String.Empty;
  }

  public int SupplierId {
    set { _SupplierId = value; }
    get { return _SupplierId; }
  }

  public string SupplierName {
    set { _SupplierName = value; }
    get { return _SupplierName; }
  }

  public string Address {
    set { _Address = value; }
    get { return _Address; }
  }

  public string Email {
    set { _Email = value; }
    get { return _Email; }
  }
  public string Phone {
    set { _Phone = value; }
    get { return _Phone; }
  }

  public int Number {
    set { _Number = value; }
    get { return _Number; }
  }

  public string Message {
    set { _Message = value; }
    get { return _Message; }
  }
}
