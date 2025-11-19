using ConfectioneryDepartmentApp.AppCode;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ConfectioneryDepartmentApp.Forms.Report {
  public partial class SoldProductsInfoForm : Form {
    RaportBLL _RaportBLL = new RaportBLL();
    List<ProductSaleInfo> _ProductSaleInfoList = new List<ProductSaleInfo>();

    public SoldProductsInfoForm() {
      InitializeComponent();
    }

    private void SearchBtn_Click(object sender, EventArgs e) {
      DateTime start = new DateTime(StartDTP.Value.Year, StartDTP.Value.Month, StartDTP.Value.Day, 0, 0, 0);
      DateTime end = new DateTime(EndDTP.Value.Year, EndDTP.Value.Month, EndDTP.Value.Day, 23, 59, 59);

      _ProductSaleInfoList = _RaportBLL.GetSoldProductsInfo(start, end);
      GetRaport(_ProductSaleInfoList);
    }

    public void GetRaport(List<ProductSaleInfo> ProductSaleInfoList) {
      int num = 0;
      double allPrice = 0;
      if (ProductSaleInfoList.Count > 0) {
        ReportTBox.Text = "Звіт за вибраний перід з " + StartDTP.Value.ToShortDateString() + " до " + EndDTP.Value.ToShortDateString() + ":\r\n";
        ReportTBox.Text += "--------------------------------------------------------------------------------\r\n";

        ReportTBox.Text += String.Format("{0,3}|{1, -40}|{2, -8}|{3, -12}|{4, -12}|\r\n", "№", "Продукція", "К-сть", "Ціна", "Сума");
        for (int i = 0; i < ProductSaleInfoList.Count(); i++) {
          string raportString = String.Format("{0,3}|{1, -40}|{2, 8}|{3, 12}|{4, 12}|\r\n",
          ++num,
          ProductSaleInfoList[i].ProductName,
          ProductSaleInfoList[i].QuantitySold,
          ProductSaleInfoList[i].SalePrice,
          ProductSaleInfoList[i].TotalSale);
          ReportTBox.Text += raportString;
          allPrice += ProductSaleInfoList[i].TotalSale;
        }
        ReportTBox.Text += "--------------------------------------------------------------------------------\r\n";
        ReportTBox.Text += String.Format("{0,66} {1, 12}\r\n", "Загальна сума: ", allPrice);
      } else {
        ReportTBox.Text = "За вибраний період даних не знайдено!";
      }
    }

    private void ExportingBtn_Click(object sender, EventArgs e) {
      if (ReportTBox.Text != "") {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
        saveFileDialog.FilterIndex = 2;
        saveFileDialog.RestoreDirectory = true;

        if (saveFileDialog.ShowDialog() == DialogResult.OK) {
          PdfDocument document = new PdfDocument();
          document.Info.Title = "Generated PDF";

          PdfPage page = document.AddPage();
          XGraphics gfx = XGraphics.FromPdfPage(page);
          var font = new XFont("Courier New", 9, XFontStyle.Regular);


          XTextFormatter tf = new XTextFormatter(gfx);
          XRect rect = new XRect(0, 0, page.Width, page.Height);
          gfx.DrawRectangle(XBrushes.White, rect);

          tf.DrawString(ReportTBox.Text, font, XBrushes.Black, rect, XStringFormats.TopLeft);

          document.Save(saveFileDialog.FileName);
          document.Close();
          MessageBox.Show("Експорт звіту в PDF файл успішно завершено.", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
      } else {
        MessageBox.Show("Спочатку створіть звіт", "Увага!");
      }
    }
  }
}
