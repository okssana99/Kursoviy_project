using ConfectioneryDepartmentApp.Forms.Controls;
using ConfectioneryDepartmentApp.Forms.Dictionary;
using ConfectioneryDepartmentApp.Forms.Report;
using ConfectioneryDepartmentApp.Forms.Search;
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

namespace ConfectioneryDepartmentApp {
  public partial class ConfectioneryMDI : Form {
    GenDataConfact _GenDataConfact = new GenDataConfact();
    public ConfectioneryMDI() {
      InitializeComponent();
      //_GenDataConfact.InsertDefaultCategories();
      //_GenDataConfact.InsertDefaultProducts();
      //_GenDataConfact.InsertDefaultCustomers();
      //_GenDataConfact.InsertRandomOrdersLast2Months(30);
      //_GenDataConfact.SeedSuppliers();
    }

    public void CloseAllWindows() {
      Form[] childArray = this.MdiChildren;
      foreach (Form childForm in childArray) {
        childForm.Close();
      }
    }

    private void формуванняЗамовленняToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      OrderForm orderForm = new OrderForm();
      orderForm.MdiParent = this;
      orderForm.WindowState = FormWindowState.Maximized;
      orderForm.Show();
    }

    private void переглядЗамовленьToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      OrderInWorkForm orderInWorkForm = new OrderInWorkForm();
      orderInWorkForm.MdiParent = this;
      orderInWorkForm.WindowState = FormWindowState.Maximized;
      orderInWorkForm.Show();
    }

    private void завершеніЗамовленняToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      OrderFinishForm orderFinishForm = new OrderFinishForm();
      orderFinishForm.MdiParent = this;
      orderFinishForm.WindowState = FormWindowState.Maximized;
      orderFinishForm.Show();
    }

    private void вихідToolStripMenuItem_Click(object sender, EventArgs e) {
      this.Close();
    }


    private void категоріїКондитерськихВиробівToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      CategoryForm categoryForm = new CategoryForm();
      categoryForm.MdiParent = this;
      categoryForm.WindowState = FormWindowState.Maximized;
      categoryForm.Show();
    }

    private void продукціяToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      ProductForm productForm = new ProductForm();
      productForm.MdiParent = this;
      productForm.WindowState = FormWindowState.Maximized;
      productForm.Show();
    }

    private void клієнтиToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      CustomerForm customerForm = new CustomerForm();
      customerForm.MdiParent = this;
      customerForm.WindowState = FormWindowState.Maximized;
      customerForm.Show();
    }

    private void постачальникиToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      SupplierForm supplierForm = new SupplierForm();
      supplierForm.MdiParent = this;
      supplierForm.WindowState = FormWindowState.Maximized;
      supplierForm.Show();
    }

 
    private void аналізНайприбутковішихКатегорійЗаМісяцьToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      CategoryRevenueReportLastMonthForm categoryRevenueReportLastMonthForm = new CategoryRevenueReportLastMonthForm();
      categoryRevenueReportLastMonthForm.MdiParent = this;
      categoryRevenueReportLastMonthForm.WindowState = FormWindowState.Maximized;
      categoryRevenueReportLastMonthForm.Show();
    }

    private void рейтингКлієнтівЗаОбсягомПокупокІзУрахуваннямЗнижокToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      CustomersRankingBySpentForm customersRankingBySpentForm = new CustomersRankingBySpentForm();
      customersRankingBySpentForm.MdiParent = this;
      customersRankingBySpentForm.WindowState = FormWindowState.Maximized;
      customersRankingBySpentForm.Show();
    }

    private void популярністьТоварівЗаКількістюПродажівІОтриманимДоходомToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      TopProductsPopularityByMonthForm topProductsPopularityByMonthForm = new TopProductsPopularityByMonthForm();
      topProductsPopularityByMonthForm.MdiParent = this;
      topProductsPopularityByMonthForm.WindowState = FormWindowState.Maximized;
      topProductsPopularityByMonthForm.Show();
    }

    private void звітністьПоПродажуПродукціїToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      SoldProductsInfoForm soldProductsInfoForm = new SoldProductsInfoForm();
      soldProductsInfoForm.MdiParent = this;
      soldProductsInfoForm.WindowState = FormWindowState.Maximized;
      soldProductsInfoForm.Show();
    }

    private void товариToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      SearchProductForm searchProductForm = new SearchProductForm();
      searchProductForm.MdiParent = this;
      searchProductForm.WindowState = FormWindowState.Maximized;
      searchProductForm.Show();
    }

    private void клієнтиToolStripMenuItem1_Click(object sender, EventArgs e) {
      CloseAllWindows();
      SearchCustomerForm searchCustomerForm = new SearchCustomerForm();
      searchCustomerForm.MdiParent = this;
      searchCustomerForm.WindowState = FormWindowState.Maximized;
      searchCustomerForm.Show();
    }

    private void формуванняЗамовленняНаВиготовленняToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      SupplyInvoicesForm supplyInvoicesForm = new SupplyInvoicesForm();
      supplyInvoicesForm.MdiParent = this;
      supplyInvoicesForm.WindowState = FormWindowState.Maximized;
      supplyInvoicesForm.Show();
    }

    private void переглядНадходженняПродукціїToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      SupplyInvoicesInWorkForm supplyInvoicesInWorkForm = new SupplyInvoicesInWorkForm();
      supplyInvoicesInWorkForm.MdiParent = this;
      supplyInvoicesInWorkForm.WindowState = FormWindowState.Maximized;
      supplyInvoicesInWorkForm.Show();
    }

    private void завершеніНадходженняToolStripMenuItem_Click(object sender, EventArgs e) {
      CloseAllWindows();
      SupplyInvoicesFinishForm supplyInvoicesFinishForm = new SupplyInvoicesFinishForm();
      supplyInvoicesFinishForm.MdiParent = this;
      supplyInvoicesFinishForm.WindowState = FormWindowState.Maximized;
      supplyInvoicesFinishForm.Show();
    }
  }
}
