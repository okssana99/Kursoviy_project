namespace ConfectioneryDepartmentApp.Forms.Search {
  partial class SearchCustomerForm {
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
      this.RaportTBox = new System.Windows.Forms.TextBox();
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox4 = new System.Windows.Forms.GroupBox();
      this.CreatedAtBtn = new System.Windows.Forms.Button();
      this.SkuValiadtionLbl = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.FullNameBtn = new System.Windows.Forms.Button();
      this.FullNameValiadtionLbl = new System.Windows.Forms.Label();
      this.FullNameTBox = new System.Windows.Forms.TextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.PhoneTBox = new System.Windows.Forms.TextBox();
      this.PhoneBtn = new System.Windows.Forms.Button();
      this.PhoneValiadtionLbl = new System.Windows.Forms.Label();
      this.CreatedAtDTP = new System.Windows.Forms.DateTimePicker();
      this.panel1.SuspendLayout();
      this.groupBox4.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
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
      this.RaportTBox.TabIndex = 104;
      this.RaportTBox.TabStop = false;
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.SystemColors.Control;
      this.panel1.Controls.Add(this.groupBox2);
      this.panel1.Controls.Add(this.groupBox4);
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(800, 66);
      this.panel1.TabIndex = 103;
      // 
      // groupBox4
      // 
      this.groupBox4.Controls.Add(this.CreatedAtDTP);
      this.groupBox4.Controls.Add(this.CreatedAtBtn);
      this.groupBox4.Controls.Add(this.SkuValiadtionLbl);
      this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.groupBox4.Location = new System.Drawing.Point(490, 3);
      this.groupBox4.Name = "groupBox4";
      this.groupBox4.Size = new System.Drawing.Size(257, 54);
      this.groupBox4.TabIndex = 133;
      this.groupBox4.TabStop = false;
      this.groupBox4.Text = "Дата реєстрації:";
      // 
      // CreatedAtBtn
      // 
      this.CreatedAtBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.CreatedAtBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.CreatedAtBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.CreatedAtBtn.Location = new System.Drawing.Point(201, 15);
      this.CreatedAtBtn.Name = "CreatedAtBtn";
      this.CreatedAtBtn.Size = new System.Drawing.Size(43, 23);
      this.CreatedAtBtn.TabIndex = 1;
      this.CreatedAtBtn.Text = "ОК";
      this.CreatedAtBtn.UseVisualStyleBackColor = false;
      this.CreatedAtBtn.Click += new System.EventHandler(this.CreatedAtBtn_Click);
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
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.FullNameBtn);
      this.groupBox1.Controls.Add(this.FullNameValiadtionLbl);
      this.groupBox1.Controls.Add(this.FullNameTBox);
      this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.groupBox1.Location = new System.Drawing.Point(12, 3);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(233, 54);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Повне ім’я:";
      // 
      // FullNameBtn
      // 
      this.FullNameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.FullNameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.FullNameBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.FullNameBtn.Location = new System.Drawing.Point(178, 19);
      this.FullNameBtn.Name = "FullNameBtn";
      this.FullNameBtn.Size = new System.Drawing.Size(43, 23);
      this.FullNameBtn.TabIndex = 1;
      this.FullNameBtn.Text = "ОК";
      this.FullNameBtn.UseVisualStyleBackColor = false;
      this.FullNameBtn.Click += new System.EventHandler(this.FullNameBtn_Click);
      // 
      // FullNameValiadtionLbl
      // 
      this.FullNameValiadtionLbl.AutoSize = true;
      this.FullNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.FullNameValiadtionLbl.Location = new System.Drawing.Point(9, 24);
      this.FullNameValiadtionLbl.Name = "FullNameValiadtionLbl";
      this.FullNameValiadtionLbl.Size = new System.Drawing.Size(11, 13);
      this.FullNameValiadtionLbl.TabIndex = 26;
      this.FullNameValiadtionLbl.Text = "*";
      // 
      // FullNameTBox
      // 
      this.FullNameTBox.BackColor = System.Drawing.Color.Ivory;
      this.FullNameTBox.Location = new System.Drawing.Point(32, 21);
      this.FullNameTBox.MaxLength = 200;
      this.FullNameTBox.Name = "FullNameTBox";
      this.FullNameTBox.Size = new System.Drawing.Size(140, 20);
      this.FullNameTBox.TabIndex = 25;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.PhoneTBox);
      this.groupBox2.Controls.Add(this.PhoneBtn);
      this.groupBox2.Controls.Add(this.PhoneValiadtionLbl);
      this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.groupBox2.Location = new System.Drawing.Point(251, 3);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(233, 54);
      this.groupBox2.TabIndex = 134;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "№ телефону:";
      // 
      // PhoneTBox
      // 
      this.PhoneTBox.BackColor = System.Drawing.Color.Ivory;
      this.PhoneTBox.Location = new System.Drawing.Point(32, 21);
      this.PhoneTBox.MaxLength = 200;
      this.PhoneTBox.Name = "PhoneTBox";
      this.PhoneTBox.Size = new System.Drawing.Size(140, 20);
      this.PhoneTBox.TabIndex = 27;
      // 
      // PhoneBtn
      // 
      this.PhoneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.PhoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.PhoneBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
      this.PhoneBtn.Location = new System.Drawing.Point(178, 19);
      this.PhoneBtn.Name = "PhoneBtn";
      this.PhoneBtn.Size = new System.Drawing.Size(43, 23);
      this.PhoneBtn.TabIndex = 1;
      this.PhoneBtn.Text = "ОК";
      this.PhoneBtn.UseVisualStyleBackColor = false;
      this.PhoneBtn.Click += new System.EventHandler(this.PhoneBtn_Click);
      // 
      // PhoneValiadtionLbl
      // 
      this.PhoneValiadtionLbl.AutoSize = true;
      this.PhoneValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.PhoneValiadtionLbl.Location = new System.Drawing.Point(14, 24);
      this.PhoneValiadtionLbl.Name = "PhoneValiadtionLbl";
      this.PhoneValiadtionLbl.Size = new System.Drawing.Size(11, 13);
      this.PhoneValiadtionLbl.TabIndex = 26;
      this.PhoneValiadtionLbl.Text = "*";
      // 
      // CreatedAtDTP
      // 
      this.CreatedAtDTP.Location = new System.Drawing.Point(28, 17);
      this.CreatedAtDTP.Name = "CreatedAtDTP";
      this.CreatedAtDTP.Size = new System.Drawing.Size(167, 20);
      this.CreatedAtDTP.TabIndex = 27;
      // 
      // SearchCustomerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.RaportTBox);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SearchCustomerForm";
      this.ShowIcon = false;
      this.Text = "Клієнтів";
      this.panel1.ResumeLayout(false);
      this.groupBox4.ResumeLayout(false);
      this.groupBox4.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox RaportTBox;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.GroupBox groupBox4;
    private System.Windows.Forms.Button CreatedAtBtn;
    private System.Windows.Forms.Label SkuValiadtionLbl;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Button FullNameBtn;
    private System.Windows.Forms.Label FullNameValiadtionLbl;
    private System.Windows.Forms.TextBox FullNameTBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.TextBox PhoneTBox;
    private System.Windows.Forms.Button PhoneBtn;
    private System.Windows.Forms.Label PhoneValiadtionLbl;
    private System.Windows.Forms.DateTimePicker CreatedAtDTP;
  }
}