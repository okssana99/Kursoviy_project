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
  public partial class UpdateSupplierForm : Form {
    private int _SupplierId = 0;
    private Supplier _selectedSupplier = new Supplier();
    private SupplierProvider _SupplierProvider = new SupplierProvider();
    private Validations _validation = new Validations();


    public UpdateSupplierForm(int SupplierId) {
      InitializeComponent();
      _SupplierId = SupplierId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _SupplierProvider.UpdateSupplier(SupplierNameTBox.Text, AddressTBox.Text, EmailTBox.Text, PhoneTBox.Text, _SupplierId);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цей елемент?", "Видалити", MessageBoxButtons.YesNo) == DialogResult.Yes) {
        _SupplierProvider.DeleteSupplier(_SupplierId);
        this.Close();
      }
    }

    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _selectedSupplier = _SupplierProvider.SelectedSupplierBySupplierId(_SupplierId);
      SupplierNameTBox.Text = _selectedSupplier.SupplierName;
      AddressTBox.Text = _selectedSupplier.Address;
      PhoneTBox.Text = _selectedSupplier.Phone;
      EmailTBox.Text = _selectedSupplier.Email;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_validation.IsDataEntering(SupplierNameTBox.Text)) {
        SupplierNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        SupplierNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsValidEmail(EmailTBox.Text)) {
        EmailValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        EmailValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      if (_validation.IsDataEntering(PhoneTBox.Text)) {
        PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        PhoneValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }
  }
}
