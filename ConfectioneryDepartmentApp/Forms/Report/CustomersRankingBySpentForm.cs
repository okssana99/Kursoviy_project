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
  public partial class CustomersRankingBySpentForm : Form {
    private readonly RaportBLL _RaportBLL = new RaportBLL();
    private List<CustomerRankingReport> _Report = new List<CustomerRankingReport>();
    public CustomersRankingBySpentForm() {
      InitializeComponent();
      _Report = _RaportBLL.GetCustomersRankingBySpent(10);
      DisplayCustomerRanking(_Report);
    }

    public void DisplayCustomerRanking(List<CustomerRankingReport> list) {
      RaportTBox.Clear();

      if (list == null || list.Count == 0) {
        RaportTBox.Text = "Немає даних для відображення рейтингу клієнтів.\r\n";
        return;
      }

      RaportTBox.Text = "Рейтинг клієнтів за обсягом покупок (з урахуванням знижок)\r\n";
      RaportTBox.Text += "-----------------------------------------------------------------------------------------------------------|\r\n";
      RaportTBox.Text += string.Format("{0,-3}|{1,-35}|{2,10}|{3,18}|{4,18}|{5,18}|\r\n",
                                       "№", "Клієнт", "Замовл.", "Сума до знижки", "Сума після знижки", "Середній чек");
      RaportTBox.Text += "-----------------------------------------------------------------------------------------------------------|\r\n";

      int i = 1;
      foreach (var r in list) {
        string line = string.Format("{0,-3}|{1,-35}|{2,10}|{3,18:F2}|{4,18:F2}|{5,18:F2}|\r\n",
                                    i, r.CustomerName, r.OrdersCount,
                                    r.TotalBeforeDiscount, r.TotalAfterDiscount, r.AvgOrderAfterDiscount);
        RaportTBox.Text += line;
        i++;
      }
      RaportTBox.Text += "============================================================================================================\r\n";
    }

  }
}
