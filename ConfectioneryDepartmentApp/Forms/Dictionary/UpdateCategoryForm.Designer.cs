namespace ConfectioneryDepartmentApp.Forms.Dictionary {
  partial class UpdateCategoryForm {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.AddGBox = new System.Windows.Forms.GroupBox();
      this.CategoryNameValiadtionLbl = new System.Windows.Forms.Label();
      this.DescriptionTBox = new System.Windows.Forms.TextBox();
      this.CategoryNameTBox = new System.Windows.Forms.TextBox();
      this.DescriptionLbl = new System.Windows.Forms.Label();
      this.СomputerLbl = new System.Windows.Forms.Label();
      this.ExitBtn = new System.Windows.Forms.Button();
      this.DeleteBtn = new System.Windows.Forms.Button();
      this.SaveBtn = new System.Windows.Forms.Button();
      this.AddGBox.SuspendLayout();
      this.SuspendLayout();
      // 
      // AddGBox
      // 
      this.AddGBox.Controls.Add(this.ExitBtn);
      this.AddGBox.Controls.Add(this.DeleteBtn);
      this.AddGBox.Controls.Add(this.SaveBtn);
      this.AddGBox.Controls.Add(this.CategoryNameValiadtionLbl);
      this.AddGBox.Controls.Add(this.DescriptionTBox);
      this.AddGBox.Controls.Add(this.CategoryNameTBox);
      this.AddGBox.Controls.Add(this.DescriptionLbl);
      this.AddGBox.Controls.Add(this.СomputerLbl);
      this.AddGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.AddGBox.Location = new System.Drawing.Point(9, 2);
      this.AddGBox.Name = "AddGBox";
      this.AddGBox.Size = new System.Drawing.Size(335, 287);
      this.AddGBox.TabIndex = 1;
      this.AddGBox.TabStop = false;
      // 
      // CategoryNameValiadtionLbl
      // 
      this.CategoryNameValiadtionLbl.AutoSize = true;
      this.CategoryNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.CategoryNameValiadtionLbl.Location = new System.Drawing.Point(64, 16);
      this.CategoryNameValiadtionLbl.Name = "CategoryNameValiadtionLbl";
      this.CategoryNameValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.CategoryNameValiadtionLbl.TabIndex = 23;
      this.CategoryNameValiadtionLbl.Text = "*";
      // 
      // DescriptionTBox
      // 
      this.DescriptionTBox.BackColor = System.Drawing.SystemColors.Info;
      this.DescriptionTBox.Location = new System.Drawing.Point(9, 90);
      this.DescriptionTBox.MaxLength = 1500;
      this.DescriptionTBox.Multiline = true;
      this.DescriptionTBox.Name = "DescriptionTBox";
      this.DescriptionTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.DescriptionTBox.Size = new System.Drawing.Size(319, 156);
      this.DescriptionTBox.TabIndex = 2;
      // 
      // CategoryNameTBox
      // 
      this.CategoryNameTBox.BackColor = System.Drawing.SystemColors.Info;
      this.CategoryNameTBox.Location = new System.Drawing.Point(6, 35);
      this.CategoryNameTBox.MaxLength = 250;
      this.CategoryNameTBox.Name = "CategoryNameTBox";
      this.CategoryNameTBox.Size = new System.Drawing.Size(323, 22);
      this.CategoryNameTBox.TabIndex = 1;
      // 
      // DescriptionLbl
      // 
      this.DescriptionLbl.AutoSize = true;
      this.DescriptionLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.DescriptionLbl.Location = new System.Drawing.Point(6, 71);
      this.DescriptionLbl.Name = "DescriptionLbl";
      this.DescriptionLbl.Size = new System.Drawing.Size(43, 16);
      this.DescriptionLbl.TabIndex = 1;
      this.DescriptionLbl.Text = "Опис:";
      // 
      // СomputerLbl
      // 
      this.СomputerLbl.AutoSize = true;
      this.СomputerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.СomputerLbl.Location = new System.Drawing.Point(6, 16);
      this.СomputerLbl.Name = "СomputerLbl";
      this.СomputerLbl.Size = new System.Drawing.Size(52, 16);
      this.СomputerLbl.TabIndex = 0;
      this.СomputerLbl.Text = "Назва:";
      // 
      // ExitBtn
      // 
      this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExitBtn.ForeColor = System.Drawing.Color.Black;
      this.ExitBtn.Location = new System.Drawing.Point(237, 252);
      this.ExitBtn.Name = "ExitBtn";
      this.ExitBtn.Size = new System.Drawing.Size(91, 25);
      this.ExitBtn.TabIndex = 29;
      this.ExitBtn.Text = "Вихід";
      this.ExitBtn.UseVisualStyleBackColor = false;
      this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
      // 
      // DeleteBtn
      // 
      this.DeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.DeleteBtn.ForeColor = System.Drawing.Color.Black;
      this.DeleteBtn.Location = new System.Drawing.Point(129, 252);
      this.DeleteBtn.Name = "DeleteBtn";
      this.DeleteBtn.Size = new System.Drawing.Size(91, 25);
      this.DeleteBtn.TabIndex = 28;
      this.DeleteBtn.Text = "Видалити";
      this.DeleteBtn.UseVisualStyleBackColor = false;
      this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
      // 
      // SaveBtn
      // 
      this.SaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SaveBtn.ForeColor = System.Drawing.Color.Black;
      this.SaveBtn.Location = new System.Drawing.Point(27, 252);
      this.SaveBtn.Name = "SaveBtn";
      this.SaveBtn.Size = new System.Drawing.Size(91, 25);
      this.SaveBtn.TabIndex = 27;
      this.SaveBtn.Text = "Зберегти";
      this.SaveBtn.UseVisualStyleBackColor = false;
      this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
      // 
      // UpdateCategoryForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(353, 295);
      this.Controls.Add(this.AddGBox);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "UpdateCategoryForm";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Редагувати";
      this.AddGBox.ResumeLayout(false);
      this.AddGBox.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox AddGBox;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Button DeleteBtn;
    private System.Windows.Forms.Button SaveBtn;
    private System.Windows.Forms.Label CategoryNameValiadtionLbl;
    private System.Windows.Forms.TextBox DescriptionTBox;
    private System.Windows.Forms.TextBox CategoryNameTBox;
    private System.Windows.Forms.Label DescriptionLbl;
    private System.Windows.Forms.Label СomputerLbl;
  }
}