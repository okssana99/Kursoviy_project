namespace ConfectioneryDepartmentApp.Forms.Search {
  partial class SearchProductForm {
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
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.SkuTBox = new System.Windows.Forms.TextBox();
      this.SkuBtn = new System.Windows.Forms.Button();
      this.SkuValiadtionLbl = new System.Windows.Forms.Label();
      this.groupBox3 = new System.Windows.Forms.GroupBox();
      this.CategoryBtn = new System.Windows.Forms.Button();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.ProductNameBtn = new System.Windows.Forms.Button();
      this.ProductNameValiadtionLbl = new System.Windows.Forms.Label();
      this.ProductNameTBox = new System.Windows.Forms.TextBox();
      this.RaportTBox = new System.Windows.Forms.TextBox();
      this.CategoryValiadtionLbl = new System.Windows.Forms.Label();
      this.CategoryCBox = new System.Windows.Forms.ComboBox();
      this.panel1.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox3.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.Control;
      this.panel1.Controls.Add(this.groupBox4);
      this.panel1.Controls.Add(this.groupBox3);
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(800, 66);
      this.panel1.TabIndex = 101;
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.SkuTBox);
      this.groupBox4.Controls.Add(this.SkuBtn);
      this.groupBox4.Controls.Add(this.SkuValiadtionLbl);
      this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.groupBox4.Location = new System.Drawing.Point(541, 6);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(233, 54);
      this.groupBox4.TabIndex = 133;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Артикул:";
      // 
      // SkuTBox
      // 
      this.SkuTBox.BackColor = System.Drawing.Color.Ivory;
      this.SkuTBox.Location = new System.Drawing.Point(32, 21);
      this.SkuTBox.MaxLength = 200;
      this.SkuTBox.Name = "SkuTBox";
      this.SkuTBox.Size = new System.Drawing.Size(140, 20);
      this.SkuTBox.TabIndex = 27;
      // 
      // SkuBtn
      // 
      this.SkuBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.SkuBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SkuBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.SkuBtn.Location = new System.Drawing.Point(178, 19);
      this.SkuBtn.Name = "SkuBtn";
      this.SkuBtn.Size = new System.Drawing.Size(43, 23);
      this.SkuBtn.TabIndex = 1;
      this.SkuBtn.Text = "ОК";
      this.SkuBtn.UseVisualStyleBackColor = false;
      this.SkuBtn.Click += new System.EventHandler(this.SkuBtn_Click);
      // 
      // SkuValiadtionLbl
      // 
      this.SkuValiadtionLbl.AutoSize = true;
      this.SkuValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.SkuValiadtionLbl.Location = new System.Drawing.Point(9, 24);
      this.SkuValiadtionLbl.Name = "SkuValiadtionLbl";
      this.SkuValiadtionLbl.Size = new System.Drawing.Size(11, 13);
      this.SkuValiadtionLbl.TabIndex = 26;
      this.SkuValiadtionLbl.Text = "*";
      // 
      // groupBox3
      // 
      this.groupBox3.Controls.Add(this.CategoryValiadtionLbl);
      this.groupBox3.Controls.Add(this.CategoryBtn);
      this.groupBox3.Controls.Add(this.CategoryCBox);
      this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.groupBox3.Location = new System.Drawing.Point(3, 6);
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.Size = new System.Drawing.Size(292, 54);
      this.groupBox3.TabIndex = 2;
      this.groupBox3.TabStop = false;
      this.groupBox3.Text = "Категорія:";
      // 
      // CategoryBtn
      // 
      this.CategoryBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.CategoryBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.CategoryBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.CategoryBtn.Location = new System.Drawing.Point(240, 16);
      this.CategoryBtn.Name = "CategoryBtn";
      this.CategoryBtn.Size = new System.Drawing.Size(43, 23);
      this.CategoryBtn.TabIndex = 1;
      this.CategoryBtn.Text = "ОК";
      this.CategoryBtn.UseVisualStyleBackColor = false;
      this.CategoryBtn.Click += new System.EventHandler(this.CategoryBtn_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.ProductNameBtn);
      this.groupBox1.Controls.Add(this.ProductNameValiadtionLbl);
      this.groupBox1.Controls.Add(this.ProductNameTBox);
      this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.groupBox1.Location = new System.Drawing.Point(302, 6);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(233, 54);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Назва:";
      // 
      // ProductNameBtn
      // 
      this.ProductNameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.ProductNameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ProductNameBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.ProductNameBtn.Location = new System.Drawing.Point(178, 19);
      this.ProductNameBtn.Name = "ProductNameBtn";
      this.ProductNameBtn.Size = new System.Drawing.Size(43, 23);
      this.ProductNameBtn.TabIndex = 1;
      this.ProductNameBtn.Text = "ОК";
      this.ProductNameBtn.UseVisualStyleBackColor = false;
      this.ProductNameBtn.Click += new System.EventHandler(this.ProductNameBtn_Click);
      // 
      // ProductNameValiadtionLbl
      // 
      this.ProductNameValiadtionLbl.AutoSize = true;
      this.ProductNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.ProductNameValiadtionLbl.Location = new System.Drawing.Point(9, 24);
      this.ProductNameValiadtionLbl.Name = "ProductNameValiadtionLbl";
      this.ProductNameValiadtionLbl.Size = new System.Drawing.Size(11, 13);
      this.ProductNameValiadtionLbl.TabIndex = 26;
      this.ProductNameValiadtionLbl.Text = "*";
      // 
      // ProductNameTBox
      // 
      this.ProductNameTBox.BackColor = System.Drawing.Color.Ivory;
      this.ProductNameTBox.Location = new System.Drawing.Point(32, 21);
      this.ProductNameTBox.MaxLength = 200;
      this.ProductNameTBox.Name = "ProductNameTBox";
      this.ProductNameTBox.Size = new System.Drawing.Size(140, 20);
      this.ProductNameTBox.TabIndex = 25;
      // 
      // RaportTBox
      // 
      this.RaportTBox.BackColor = System.Drawing.SystemColors.Control;
      this.RaportTBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RaportTBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.RaportTBox.Location = new System.Drawing.Point(0, 66);
      this.RaportTBox.MaxLength = 350000;
      this.RaportTBox.Multiline = true;
      this.RaportTBox.Name = "RaportTBox";
      this.RaportTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.RaportTBox.Size = new System.Drawing.Size(800, 384);
      this.RaportTBox.TabIndex = 102;
      this.RaportTBox.TabStop = false;
      // 
      // CategoryValiadtionLbl
      // 
      this.CategoryValiadtionLbl.AutoSize = true;
      this.CategoryValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.CategoryValiadtionLbl.Location = new System.Drawing.Point(10, 22);
      this.CategoryValiadtionLbl.Name = "CategoryValiadtionLbl";
      this.CategoryValiadtionLbl.Size = new System.Drawing.Size(11, 13);
      this.CategoryValiadtionLbl.TabIndex = 135;
      this.CategoryValiadtionLbl.Text = "*";
      // 
      // CategoryCBox
      // 
      this.CategoryCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CategoryCBox.FormattingEnabled = true;
      this.CategoryCBox.Location = new System.Drawing.Point(28, 18);
      this.CategoryCBox.Name = "CategoryCBox";
      this.CategoryCBox.Size = new System.Drawing.Size(206, 21);
      this.CategoryCBox.TabIndex = 134;
      // 
      // SearchProductForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.RaportTBox);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchProductForm";
      this.ShowIcon = false;
      this.Text = "Товарів";
      this.panel1.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      this.groupBox3.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.TextBox SkuTBox;
    private System.Windows.Forms.Button SkuBtn;
    private System.Windows.Forms.Label SkuValiadtionLbl;
    private System.Windows.Forms.GroupBox groupBox3;
    private System.Windows.Forms.Button CategoryBtn;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button ProductNameBtn;
    private System.Windows.Forms.Label ProductNameValiadtionLbl;
    private System.Windows.Forms.TextBox ProductNameTBox;
    private System.Windows.Forms.TextBox RaportTBox;
    private System.Windows.Forms.Label CategoryValiadtionLbl;
    private System.Windows.Forms.ComboBox CategoryCBox;
  }
}