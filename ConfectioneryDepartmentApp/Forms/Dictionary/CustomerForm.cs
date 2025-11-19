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

namespace ConfectioneryDepartmentApp.Forms.Dictionary {
  public partial class CustomerForm : Form {
    private int _selectedRowIndex = 0;
    private Validations  _validation = new Validations();
    private CustomerProvider _CustomerProvider = new CustomerProvider();
    private List<Customer> _CustomerList = new List<Customer>();

    public CustomerForm() {
      InitializeComponent();
      DataLoad();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _CustomerProvider.InsertCustomer(FullNameTBox.Text, PhoneTBox.Text, EmailTBox.Text, Convert.ToDouble(DiscountPctUpDwn.Value));
        DataLoad();
        ClearAllControls();
      }
    }

    private void ClearBtn_Click(object sender, EventArgs e) {
      ClearAllControls();
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void CustomerGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && CustomerGridView[0, e.RowIndex].Value.ToString() != _CustomerList[0].Message) {
        _selectedRowIndex = e.RowIndex;
        UpdateCustomerForm updateCustomerForm = new UpdateCustomerForm(Convert.ToInt32(CustomerGridView[0, e.RowIndex].Value.ToString()));
        updateCustomerForm.ShowDialog();
        DataLoad();
      }
    }

    private void DataLoad() {
      int firstRowIndex = 0;
      if (CustomerGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = CustomerGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _CustomerList = _CustomerProvider.GetAllCustomers();
        LoadDataInCustomerGridView(_CustomerList);
        if (_selectedRowIndex == CustomerGridView.Rows.Count) {
          _selectedRowIndex = CustomerGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          CustomerGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          CustomerGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInCustomerGridView(List<Customer> CustomerList) {
      CustomerGridView.DataSource = null;
      CustomerGridView.Columns.Clear();
      CustomerGridView.AutoGenerateColumns = false;
      CustomerGridView.RowHeadersVisible = false;

      CustomerGridView.DataSource = CustomerList;

      if (CustomerList.Count > 0) {
        if (CustomerList[0].Message == NamesMy.NoDataNames.NoDataInCustomers) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = CustomerGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          CustomerGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn CustomerIdColumn = new DataGridViewTextBoxColumn();
          CustomerIdColumn.DataPropertyName = "CustomerId";
          CustomerGridView.Columns.Add(CustomerIdColumn);
          CustomerGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          CustomerGridView.Columns.Add(numberColumn);

          DataGridViewColumn FullNameColumn = new DataGridViewTextBoxColumn();
          FullNameColumn.HeaderText = "Клієнт";
          FullNameColumn.DataPropertyName = "FullName";
          FullNameColumn.Width = NamesMy.SizeOptins.NameSize;
          CustomerGridView.Columns.Add(FullNameColumn);

          DataGridViewColumn PhoneColumn = new DataGridViewTextBoxColumn();
          PhoneColumn.HeaderText = "№ телефону";
          PhoneColumn.DataPropertyName = "Phone";
          PhoneColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          PhoneColumn.Width = 150;
          CustomerGridView.Columns.Add(PhoneColumn);

          DataGridViewColumn EmailColumn = new DataGridViewTextBoxColumn();
          EmailColumn.HeaderText = "Email";
          EmailColumn.DataPropertyName = "Email";
          EmailColumn.Width = 200;
          CustomerGridView.Columns.Add(EmailColumn);
          
          DataGridViewColumn DiscountPctColumn = new DataGridViewTextBoxColumn();
          DiscountPctColumn.HeaderText = "Знижка (%)";
          DiscountPctColumn.DataPropertyName = "DiscountPct";
          DiscountPctColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          DiscountPctColumn.Width = 80;
          CustomerGridView.Columns.Add(DiscountPctColumn);

          DataGridViewColumn CreatedAtColumn = new DataGridViewTextBoxColumn();
          CreatedAtColumn.HeaderText = "Реєстрація";
          CreatedAtColumn.DataPropertyName = "CreatedAt";
          CreatedAtColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          CreatedAtColumn.Width = 140;
          CustomerGridView.Columns.Add(CreatedAtColumn);
        }
        for (int i = 0; i < CustomerGridView.Columns.Count; i++) {
          CustomerGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ClearAllControls() {
      FullNameTBox.Text = String.Empty;
      PhoneTBox.Text = String.Empty;
      CreatedAtDTP.Value = DateTime.Now;
      EmailTBox.Text = String.Empty;
      DiscountPctUpDwn.Value = 0;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(FullNameTBox.Text)) {
        FullNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        FullNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(PhoneTBox.Text)) {
        PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsValidEmail(EmailTBox.Text)) {
        EmailValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        EmailValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }


  }
}
