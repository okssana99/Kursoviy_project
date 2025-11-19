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
  public partial class SupplierForm : Form {
    private int _selectedRowIndex = 0;
    private Validations _validation = new Validations();
    private SupplierProvider _SupplierProvider = new SupplierProvider();
    private List<Supplier> _SupplierList = new List<Supplier>();

    public SupplierForm() {
      InitializeComponent();
      DataLoad();
    }

    private void AddBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _SupplierProvider.InsertSupplier(SupplierNameTBox.Text, AddressTBox.Text, EmailTBox.Text, PhoneTBox.Text);
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

    private void SupplierGridView_CellClick(object sender, DataGridViewCellEventArgs e) {
      if (e.RowIndex >= 0 && SupplierGridView[0, e.RowIndex].Value.ToString() != _SupplierList[0].Message) {
        _selectedRowIndex = e.RowIndex;
        UpdateSupplierForm updateSupplierForm = new UpdateSupplierForm(Convert.ToInt32(SupplierGridView[0, e.RowIndex].Value.ToString()));
        updateSupplierForm.ShowDialog();
        DataLoad();
      }
    }


    private void DataLoad() {
      int firstRowIndex = 0;
      if (SupplierGridView.FirstDisplayedScrollingRowIndex > 0) {
        firstRowIndex = SupplierGridView.FirstDisplayedScrollingRowIndex;
      }
      try {
        _SupplierList = _SupplierProvider.GetAllSupplier();
        LoadDataInSupplierGridView(_SupplierList);
        if (_selectedRowIndex == SupplierGridView.Rows.Count) {
          _selectedRowIndex = SupplierGridView.Rows.Count - 1;
        }
        if (_selectedRowIndex >= 0) {
          SupplierGridView.FirstDisplayedScrollingRowIndex = firstRowIndex;
          SupplierGridView.Rows[_selectedRowIndex].Selected = true;
        }
      } catch { }
    }

    private void LoadDataInSupplierGridView(List<Supplier> SupplierList) {
      SupplierGridView.DataSource = null;
      SupplierGridView.Columns.Clear();
      SupplierGridView.AutoGenerateColumns = false;
      SupplierGridView.RowHeadersVisible = false;

      SupplierGridView.DataSource = SupplierList;

      if (SupplierList.Count > 0) {
        if (SupplierList[0].Message == NamesMy.NoDataNames.NoDataInSupplier) {
          DataGridViewColumn messageColumn = new DataGridViewTextBoxColumn();
          messageColumn.DataPropertyName = "Message";
          messageColumn.Width = SupplierGridView.Width - NamesMy.SizeOptins.MinusSizePanel;
          SupplierGridView.Columns.Add(messageColumn);
        } else {
          DataGridViewColumn DetailIdColumn = new DataGridViewTextBoxColumn();
          DetailIdColumn.DataPropertyName = "SupplierId";
          SupplierGridView.Columns.Add(DetailIdColumn);
          SupplierGridView.Columns[0].Visible = false;

          DataGridViewColumn numberColumn = new DataGridViewTextBoxColumn();
          numberColumn.HeaderText = "№ ";
          numberColumn.DataPropertyName = "Number";
          numberColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          numberColumn.Width = NamesMy.SizeOptins.NumberSize;
          SupplierGridView.Columns.Add(numberColumn);

          DataGridViewColumn SupplierNameColumn = new DataGridViewTextBoxColumn();
          SupplierNameColumn.HeaderText = "Постачальник";
          SupplierNameColumn.DataPropertyName = "SupplierName";
          SupplierNameColumn.Width = 220;
          SupplierGridView.Columns.Add(SupplierNameColumn);

          DataGridViewColumn EmailColumn = new DataGridViewTextBoxColumn();
          EmailColumn.HeaderText = "Електронна пошта";
          EmailColumn.DataPropertyName = "Email";
          EmailColumn.Width = 220;
          SupplierGridView.Columns.Add(EmailColumn);

          DataGridViewColumn PhoneColumn = new DataGridViewTextBoxColumn();
          PhoneColumn.HeaderText = "№ телефону";
          PhoneColumn.DataPropertyName = "Phone";
          PhoneColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
          PhoneColumn.Width = 120;
          SupplierGridView.Columns.Add(PhoneColumn);
        }
        for (int i = 0; i < SupplierGridView.Columns.Count; i++) {
          SupplierGridView.Columns[i].HeaderCell.Style.BackColor = Color.LightGray;
        }
      }
    }

    private void ClearAllControls() {
      SupplierNameTBox.Text = String.Empty;
      PhoneTBox.Text = String.Empty;
      EmailTBox.Text = String.Empty;
      AddressTBox.Text = String.Empty;
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
