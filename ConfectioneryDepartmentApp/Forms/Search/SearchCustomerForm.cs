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
  public partial class SearchCustomerForm : Form {
    private Validations _validation = new Validations();
    private CustomerProvider _CustomerProvider = new CustomerProvider();
    private List<Customer> _CustomerList = new List<Customer>();

    public SearchCustomerForm() {
      InitializeComponent();
      LoadAllData();
    }

    private void LoadAllData() {
      _CustomerList = _CustomerProvider.GetAllCustomers();
      DisplayCustomersInTextBox(_CustomerList, RaportTBox);
    }

    // --- Обробники кнопок ---

    // Пошук за частиною ПІБ (FullNameTBox)
    private void FullNameBtn_Click(object sender, EventArgs e) {
      var results = SearchCustomersByFullName(FullNameTBox.Text);
      DisplayCustomersInTextBox(results, RaportTBox);
    }

    // Пошук за телефоном (PhoneTBox)
    private void PhoneBtn_Click(object sender, EventArgs e) {
      var results = SearchCustomersByPhone(PhoneTBox.Text);
      DisplayCustomersInTextBox(results, RaportTBox);
    }

    // Пошук за діапазоном дат створення (StartDTP, EndDTP)
    private void CreatedAtBtn_Click(object sender, EventArgs e) {
      // Отримати обрану дату
      DateTime selectedDate = CreatedAtDTP.Value.Date;

      // Визначити межі доби (0:00 – 23:59)
      DateTime start = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 0, 0, 0);
      DateTime end = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, 23, 59, 59);

      // Пошук клієнтів, створених саме цього дня
      var results = _CustomerList
          .Where(c => c.CreatedAt >= start && c.CreatedAt <= end)
          .OrderBy(c => c.FullName)
          .ToList();

      // Вивід результатів у RaportTBox
      DisplayCustomersInTextBox(results, RaportTBox);
    }


    // --- Методи пошуку ---

    public List<Customer> SearchCustomersByFullName(string fullName) {
      return string.IsNullOrWhiteSpace(fullName)
        ? _CustomerList.ToList()
        : _CustomerList
            .Where(c => (c.FullName ?? string.Empty)
                         .ToLower()
                         .Contains(fullName.Trim().ToLower()))
            .OrderBy(c => c.FullName)
            .ToList();
    }

    public List<Customer> SearchCustomersByPhone(string phone) {
      return string.IsNullOrWhiteSpace(phone)
        ? _CustomerList.ToList()
        : _CustomerList
            .Where(c => (c.Phone ?? string.Empty)
                         .ToLower()
                         .Contains(phone.Trim().ToLower()))
            .OrderBy(c => c.Phone)
            .ToList();
    }

    public List<Customer> SearchCustomersByCreatedAt(DateTime start, DateTime end) {
      return _CustomerList
        .Where(c => c.CreatedAt >= start && c.CreatedAt <= end)
        .OrderBy(c => c.CreatedAt)
        .ToList();
    }

    public List<Customer> SearchCustomers(string fullName, string phone, DateTime? start, DateTime? end) {
      var q = _CustomerList.AsEnumerable();

      if (!string.IsNullOrWhiteSpace(fullName)) {
        string f = fullName.Trim().ToLower();
        q = q.Where(c => (c.FullName ?? string.Empty).ToLower().Contains(f));
      }

      if (!string.IsNullOrWhiteSpace(phone)) {
        string p = phone.Trim().ToLower();
        q = q.Where(c => (c.Phone ?? string.Empty).ToLower().Contains(p));
      }

      if (start.HasValue && end.HasValue) {
        q = q.Where(c => c.CreatedAt >= start.Value && c.CreatedAt <= end.Value);
      }

      return q
        .OrderBy(c => c.FullName)
        .ThenBy(c => c.CreatedAt)
        .ToList();
    }

    // --- Відображення результатів ---

    public void DisplayCustomersInTextBox(List<Customer> customers, TextBox textBox) {
      textBox.Clear();

      if (customers == null || customers.Count == 0) {
        textBox.AppendText("Дані не знайдено.\r\n");
        return;
      }

      // Заголовок
      string header = string.Format("{0,3}|{1,-30}|{2,-14}|{3,-28}|{4,8}|{5,20}\r\n",
                                    "№", "ПІБ", "Телефон", "Email", "Знижка", "Створено");
      textBox.AppendText(header);
      textBox.AppendText(new string('-', header.Length) + "\r\n");

      int i = 0;
      foreach (var c in customers) {
        string line = string.Format("{0,3}|{1,-30}|{2,-14}|{3,-28}|{4,8:F2}|{5,20}\r\n",
                                    ++i,
                                    Truncate(c.FullName, 30),
                                    Truncate(c.Phone, 14),
                                    Truncate(c.Email, 28),
                                    c.DiscountPct,
                                    c.CreatedAt.ToString("yyyy-MM-dd HH:mm"));
        textBox.AppendText(line);
      }
    }

    public static string Truncate(string value, int maxLen) {
      if (string.IsNullOrEmpty(value)) return "";
      return value.Length <= maxLen ? value : value.Substring(0, maxLen);
    }

  }
}

