using ConfectioneryDepartmentApp.AppCode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfectioneryDepartmentApp.Forms.Report {
  public partial class CategoryRevenueReportLastMonthForm : Form {
    private readonly RaportBLL _RaportBLL = new RaportBLL();
    private List<CategoryRevenueReport> _ReportList = new List<CategoryRevenueReport>();
    public CategoryRevenueReportLastMonthForm() {
      InitializeComponent();
      SelectMonthDTP.Format = DateTimePickerFormat.Custom;
      SelectMonthDTP.CustomFormat = "MMMM yyyy";  // Наприклад: "Листопад 2025"
    }

    private void SearchBtn_Click(object sender, EventArgs e) {
      DateTime selectedMonth = SelectMonthDTP.Value;

      _ReportList = _RaportBLL.GetCategoryRevenueReportByMonth(selectedMonth);
      DisplayCategoryRevenueReport(_ReportList);
    }

    public void DisplayCategoryRevenueReport(List<CategoryRevenueReport> list) {
      RaportTBox.Clear();

      if (list == null || list.Count == 0) {
        RaportTBox.Text = "Немає даних для відображення звіту про доходи категорій за останній місяць.\r\n";
        return;
      }

      RaportTBox.Text = "Звіт: Найприбутковіші категорії за останній місяць\r\n";
      RaportTBox.Text += "-------------------------------------------------------------------------------------|\r\n";
      RaportTBox.Text += string.Format("{0, -3}|{1, -30}|{2, 15}|{3, 18}|{4, 15}|\r\n",
                                       "№", "Категорія", "Дохід, грн", "К-сть замовлень", "Середня ціна");
      RaportTBox.Text += "-------------------------------------------------------------------------------------|\r\n";

      int i = 1;
      foreach (var r in list) {
        string line = string.Format("{0, -3}|{1, -30}|{2, 15:F2}|{3, 18}|{4, 15:F2}|\r\n",
                                    i, r.CategoryName, r.TotalRevenue, r.OrdersCount, r.AvgUnitPrice);
        RaportTBox.Text += line;
        i++;
      }

      RaportTBox.Text += "======================================================================================\r\n";
    }


  }
}

