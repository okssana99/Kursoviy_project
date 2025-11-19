namespace ConfectioneryDepartmentApp.Forms.Dictionary {
  partial class CustomerForm {
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.CreatedAtDTP = new System.Windows.Forms.DateTimePicker();
      this.EmailValiadtionLbl = new System.Windows.Forms.Label();
      this.EmailTBox = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.PhoneValiadtionLbl = new System.Windows.Forms.Label();
      this.PhoneTBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.ExitBtn = new System.Windows.Forms.Button();
      this.ClearBtn = new System.Windows.Forms.Button();
      this.AddBtn = new System.Windows.Forms.Button();
      this.AddPanel = new System.Windows.Forms.Panel();
      this.AddGBox = new System.Windows.Forms.GroupBox();
      this.DiscountPctUpDwn = new System.Windows.Forms.NumericUpDown();
      this.label3 = new System.Windows.Forms.Label();
      this.BasePriceValiadtionLbl = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.FullNameValiadtionLbl = new System.Windows.Forms.Label();
      this.FullNameTBox = new System.Windows.Forms.TextBox();
      this.СomputerLbl = new System.Windows.Forms.Label();
      this.CustomerGridView = new System.Windows.Forms.DataGridView();
      this.AddPanel.SuspendLayout();
      this.AddGBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DiscountPctUpDwn)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.CustomerGridView)).BeginInit();
      this.SuspendLayout();
      // 
      // CreatedAtDTP
      // 
      this.CreatedAtDTP.Enabled = false;
      this.CreatedAtDTP.Location = new System.Drawing.Point(217, 70);
      this.CreatedAtDTP.Name = "CreatedAtDTP";
      this.CreatedAtDTP.Size = new System.Drawing.Size(167, 22);
      this.CreatedAtDTP.TabIndex = 3;
      // 
      // EmailValiadtionLbl
      // 
      this.EmailValiadtionLbl.AutoSize = true;
      this.EmailValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.EmailValiadtionLbl.Location = new System.Drawing.Point(152, 101);
      this.EmailValiadtionLbl.Name = "EmailValiadtionLbl";
      this.EmailValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.EmailValiadtionLbl.TabIndex = 131;
      this.EmailValiadtionLbl.Text = "*";
      // 
      // EmailTBox
      // 
      this.EmailTBox.BackColor = System.Drawing.SystemColors.Info;
      this.EmailTBox.Location = new System.Drawing.Point(170, 98);
      this.EmailTBox.MaxLength = 254;
      this.EmailTBox.Name = "EmailTBox";
      this.EmailTBox.Size = new System.Drawing.Size(214, 22);
      this.EmailTBox.TabIndex = 4;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label5.Location = new System.Drawing.Point(5, 101);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(141, 16);
      this.label5.TabIndex = 129;
      this.label5.Text = "Електронна адреса:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label7.Location = new System.Drawing.Point(86, 72);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(113, 16);
      this.label7.TabIndex = 126;
      this.label7.Text = "Дата реєстрації:";
      // 
      // PhoneValiadtionLbl
      // 
      this.PhoneValiadtionLbl.AutoSize = true;
      this.PhoneValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.PhoneValiadtionLbl.Location = new System.Drawing.Point(135, 45);
      this.PhoneValiadtionLbl.Name = "PhoneValiadtionLbl";
      this.PhoneValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.PhoneValiadtionLbl.TabIndex = 125;
      this.PhoneValiadtionLbl.Text = "*";
      // 
      // PhoneTBox
      // 
      this.PhoneTBox.BackColor = System.Drawing.SystemColors.Info;
      this.PhoneTBox.Location = new System.Drawing.Point(153, 42);
      this.PhoneTBox.MaxLength = 254;
      this.PhoneTBox.Name = "PhoneTBox";
      this.PhoneTBox.Size = new System.Drawing.Size(231, 22);
      this.PhoneTBox.TabIndex = 2;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(6, 45);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(122, 16);
      this.label2.TabIndex = 123;
      this.label2.Text = "Номер телефону:";
      // 
      // ExitBtn
      // 
      this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExitBtn.Location = new System.Drawing.Point(303, 157);
      this.ExitBtn.Name = "ExitBtn";
      this.ExitBtn.Size = new System.Drawing.Size(81, 25);
      this.ExitBtn.TabIndex = 23;
      this.ExitBtn.Text = "Вихід";
      this.ExitBtn.UseVisualStyleBackColor = false;
      this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
      // 
      // ClearBtn
      // 
      this.ClearBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.ClearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ClearBtn.Location = new System.Drawing.Point(201, 157);
      this.ClearBtn.Name = "ClearBtn";
      this.ClearBtn.Size = new System.Drawing.Size(81, 25);
      this.ClearBtn.TabIndex = 22;
      this.ClearBtn.Text = "Очистити";
      this.ClearBtn.UseVisualStyleBackColor = false;
      this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
      // 
      // AddBtn
      // 
      this.AddBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.AddBtn.Location = new System.Drawing.Point(99, 157);
      this.AddBtn.Name = "AddBtn";
      this.AddBtn.Size = new System.Drawing.Size(81, 25);
      this.AddBtn.TabIndex = 21;
      this.AddBtn.Text = "Додати";
      this.AddBtn.UseVisualStyleBackColor = false;
      this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
      // 
      // AddPanel
      // 
      this.AddPanel.Controls.Add(this.AddGBox);
      this.AddPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.AddPanel.Location = new System.Drawing.Point(0, 0);
      this.AddPanel.Name = "AddPanel";
      this.AddPanel.Size = new System.Drawing.Size(415, 197);
      this.AddPanel.TabIndex = 0;
      // 
      // AddGBox
      // 
      this.AddGBox.Controls.Add(this.DiscountPctUpDwn);
      this.AddGBox.Controls.Add(this.label3);
      this.AddGBox.Controls.Add(this.BasePriceValiadtionLbl);
      this.AddGBox.Controls.Add(this.label1);
      this.AddGBox.Controls.Add(this.CreatedAtDTP);
      this.AddGBox.Controls.Add(this.EmailValiadtionLbl);
      this.AddGBox.Controls.Add(this.EmailTBox);
      this.AddGBox.Controls.Add(this.label5);
      this.AddGBox.Controls.Add(this.label7);
      this.AddGBox.Controls.Add(this.PhoneValiadtionLbl);
      this.AddGBox.Controls.Add(this.PhoneTBox);
      this.AddGBox.Controls.Add(this.label2);
      this.AddGBox.Controls.Add(this.ExitBtn);
      this.AddGBox.Controls.Add(this.ClearBtn);
      this.AddGBox.Controls.Add(this.AddBtn);
      this.AddGBox.Controls.Add(this.FullNameValiadtionLbl);
      this.AddGBox.Controls.Add(this.FullNameTBox);
      this.AddGBox.Controls.Add(this.СomputerLbl);
      this.AddGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.AddGBox.Location = new System.Drawing.Point(12, -2);
      this.AddGBox.Name = "AddGBox";
      this.AddGBox.Size = new System.Drawing.Size(393, 196);
      this.AddGBox.TabIndex = 0;
      this.AddGBox.TabStop = false;
      // 
      // DiscountPctUpDwn
      // 
      this.DiscountPctUpDwn.BackColor = System.Drawing.SystemColors.Info;
      this.DiscountPctUpDwn.Location = new System.Drawing.Point(170, 126);
      this.DiscountPctUpDwn.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
      this.DiscountPctUpDwn.Name = "DiscountPctUpDwn";
      this.DiscountPctUpDwn.Size = new System.Drawing.Size(53, 22);
      this.DiscountPctUpDwn.TabIndex = 5;
      this.DiscountPctUpDwn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(229, 129);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(27, 16);
      this.label3.TabIndex = 135;
      this.label3.Text = "(%)";
      // 
      // BasePriceValiadtionLbl
      // 
      this.BasePriceValiadtionLbl.AutoSize = true;
      this.BasePriceValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.BasePriceValiadtionLbl.Location = new System.Drawing.Point(152, 129);
      this.BasePriceValiadtionLbl.Name = "BasePriceValiadtionLbl";
      this.BasePriceValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.BasePriceValiadtionLbl.TabIndex = 134;
      this.BasePriceValiadtionLbl.Text = "*";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(40, 129);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(106, 16);
      this.label1.TabIndex = 133;
      this.label1.Text = "Розмір знижки:";
      // 
      // FullNameValiadtionLbl
      // 
      this.FullNameValiadtionLbl.AutoSize = true;
      this.FullNameValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.FullNameValiadtionLbl.Location = new System.Drawing.Point(97, 17);
      this.FullNameValiadtionLbl.Name = "FullNameValiadtionLbl";
      this.FullNameValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.FullNameValiadtionLbl.TabIndex = 23;
      this.FullNameValiadtionLbl.Text = "*";
      // 
      // FullNameTBox
      // 
      this.FullNameTBox.BackColor = System.Drawing.SystemColors.Info;
      this.FullNameTBox.Location = new System.Drawing.Point(115, 14);
      this.FullNameTBox.MaxLength = 254;
      this.FullNameTBox.Name = "FullNameTBox";
      this.FullNameTBox.Size = new System.Drawing.Size(269, 22);
      this.FullNameTBox.TabIndex = 1;
      // 
      // СomputerLbl
      // 
      this.СomputerLbl.AutoSize = true;
      this.СomputerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.СomputerLbl.Location = new System.Drawing.Point(6, 18);
      this.СomputerLbl.Name = "СomputerLbl";
      this.СomputerLbl.Size = new System.Drawing.Size(77, 16);
      this.СomputerLbl.TabIndex = 0;
      this.СomputerLbl.Text = "Повне ім’я:";
      // 
      // CustomerGridView
      // 
      this.CustomerGridView.AllowUserToAddRows = false;
      this.CustomerGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.CustomerGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.CustomerGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.CustomerGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.CustomerGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.CustomerGridView.GridColor = System.Drawing.SystemColors.Control;
      this.CustomerGridView.Location = new System.Drawing.Point(415, 0);
      this.CustomerGridView.MultiSelect = false;
      this.CustomerGridView.Name = "CustomerGridView";
      this.CustomerGridView.ReadOnly = true;
      this.CustomerGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.CustomerGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.CustomerGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.CustomerGridView.Size = new System.Drawing.Size(548, 197);
      this.CustomerGridView.TabIndex = 129;
      this.CustomerGridView.TabStop = false;
      this.CustomerGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CustomerGridView_CellClick);
      // 
      // CustomerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(963, 197);
      this.Controls.Add(this.CustomerGridView);
      this.Controls.Add(this.AddPanel);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CustomerForm";
      this.ShowIcon = false;
      this.Text = "Клієнти";
      this.AddPanel.ResumeLayout(false);
      this.AddGBox.ResumeLayout(false);
      this.AddGBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.DiscountPctUpDwn)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.CustomerGridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DateTimePicker CreatedAtDTP;
    private System.Windows.Forms.Label EmailValiadtionLbl;
    private System.Windows.Forms.TextBox EmailTBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label PhoneValiadtionLbl;
    private System.Windows.Forms.TextBox PhoneTBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Button ClearBtn;
    private System.Windows.Forms.Button AddBtn;
    private System.Windows.Forms.Panel AddPanel;
    private System.Windows.Forms.GroupBox AddGBox;
    private System.Windows.Forms.Label FullNameValiadtionLbl;
    private System.Windows.Forms.TextBox FullNameTBox;
    private System.Windows.Forms.Label СomputerLbl;
    private System.Windows.Forms.DataGridView CustomerGridView;
    private System.Windows.Forms.Label BasePriceValiadtionLbl;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.NumericUpDown DiscountPctUpDwn;
  }
}