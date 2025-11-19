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
  public partial class UpdateCategoryForm : Form {
    private int _CategoryId = 0;
    private Category _selectedCategory = new Category();
    private CategoryProvider _CategoryProvider = new CategoryProvider();
    private Validations _Validation = new Validations();

    public UpdateCategoryForm(int CategoryId) {
      InitializeComponent();
      _CategoryId = CategoryId;
      LoadAllDate();
    }

    private void SaveBtn_Click(object sender, EventArgs e) {
      if (IsDataEnteringCorrect()) {
        _CategoryProvider.UpdateCategory(CategoryNameTBox.Text, DescriptionTBox.Text, _CategoryId);
        this.Close();
      }
    }

    private void DeleteBtn_Click(object sender, EventArgs e) {
      if (MessageBox.Show("Ви дійсно хочете видалити цю категорію?", "Видалити", MessageBoxButtons.YesNo) != DialogResult.Yes)
        return;

      int cnt = _CategoryProvider.CountProductsInCategory(_CategoryId);
      if (cnt > 0) {
        MessageBox.Show($"Неможливо видалити: до категорії прив’язано {cnt} продукція(ї).\n" +
                        $"Перепризначте продукцію або видаліть її.", "Відмова", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }

      _CategoryProvider.DeleteCategory(_CategoryId);
      this.Close();
    }


    private void ExitBtn_Click(object sender, EventArgs e) {
      this.Close();
    }

    private void LoadAllDate() {
      _selectedCategory = _CategoryProvider.SelectedCategoryById(_CategoryId);
      CategoryNameTBox.Text = _selectedCategory.CategoryName;
      DescriptionTBox.Text = _selectedCategory.Description;
    }

    private bool IsDataEnteringCorrect() {
      bool isCorrect = true;
      if (_Validation.IsDataEntering(CategoryNameTBox.Text)) {
        CategoryNameValiadtionLbl.Text = NamesMy.ProgramButtons.RequiredValidation;
      } else {
        CategoryNameValiadtionLbl.Text = NamesMy.ProgramButtons.ErrorValidation;
        isCorrect = false;
      }
      return isCorrect;
    }
  }
}
