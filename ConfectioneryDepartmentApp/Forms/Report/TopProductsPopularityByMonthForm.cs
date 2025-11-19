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
  public partial class TopProductsPopularityByMonthForm : Form {
    private readonly RaportBLL _RaportBLL = new RaportBLL();
    private List<ProductPopularityReport> _Report = new List<ProductPopularityReport>();
    public TopProductsPopularityByMonthForm() {
      InitializeComponent();
      // За весь час
      _Report = _RaportBLL.GetTopProductsPopularity(10);
      DisplayProductPopularity(_Report);
    }

    public void DisplayProductPopularity(List<ProductPopularityReport> list) {
      RaportTBox.Clear();

      if (list == null || list.Count == 0) {
        RaportTBox.Text = "Дані про популярність товарів відсутні.\r\n";
        return;
      }

      RaportTBox.Text = "Популярність товарів: кількість продажів та дохід\r\n";
      RaportTBox.Text += "-----------------------------------------------------------------------------------------------------------|\r\n";
      RaportTBox.Text += string.Format("{0,-3}|{1,-35}|{2,-22}|{3,14}|{4,16}|{5,12}|\r\n",
                                       "№", "Товар", "Категорія", "К-сть, од.", "Дохід, грн", "Частка, %");
      RaportTBox.Text += "-----------------------------------------------------------------------------------------------------------|\r\n";

      int i = 1;
      foreach (var r in list) {
        string line = string.Format("{0,-3}|{1,-35}|{2,-22}|{3,14:F2}|{4,16:F2}|{5,12:F2}|\r\n",
                                    i, r.ProductName, r.CategoryName, r.QtySold, r.RevenueTotal, r.RevenueSharePct);
        RaportTBox.Text += line;
        i++;
      }

      RaportTBox.Text += "============================================================================================================\r\n";
    }

  }
}
