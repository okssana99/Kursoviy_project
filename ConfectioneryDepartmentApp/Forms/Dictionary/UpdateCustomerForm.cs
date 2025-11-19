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
  public partial class UpdateCustomerForm : Form {
    private int _CustomerId = 0;
    private Customer _selectedCustomer = new Customer();
    private CustomerProvider _CustomerProvider = new CustomerProvider();
    private Validations _Validation = new Validations();

    public UpdateCustomerForm(int CustomerId) {
      InitializeComponent();
      _CustomerId = CustomerId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _CustomerProvider.UpdateCustomer(FullNameTBox.Text, PhoneTBox.Text, EmailTBox.Text, Convert.ToDouble(DiscountPctUpDwn.Value), _CustomerId);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _CustomerProvider.DeleteCustomer(_CustomerId);
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _selectedCustomer = _CustomerProvider.SelectedCustomerById(_CustomerId);
      FullNameTBox.Text = _selectedCustomer.FullName;
      PhoneTBox.Text = _selectedCustomer.Phone;
      EmailTBox.Text = _selectedCustomer.Email;
      DiscountPctUpDwn.Value = Convert.ToInt32(_selectedCustomer.DiscountPct);
      CreatedAtDTP.Value = _selectedCustomer.CreatedAt;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_Validation.IsDataEntering(FullNameTBox.Text)) {
        FullNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        FullNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_Validation.IsDataEntering(PhoneTBox.Text)) {
        PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_Validation.IsValidEmail(EmailTBox.Text)) {
        EmailValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        EmailValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }

  }
}
