namespace ConfectioneryDepartmentApp.Forms.Controls {
  partial class OrderFinishForm {
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      this.OrderItemGridView = new System.Windows.Forms.DataGridView();
      this.panel1 = new System.Windows.Forms.Panel();
      this.OrderGridView = new System.Windows.Forms.DataGridView();
      this.panel2 = new System.Windows.Forms.Panel();
      this.TotalPurchasesLbl = new System.Windows.Forms.Label();
      this.TotalPriceValiadtionLbl = new System.Windows.Forms.Label();
      this.TotalPriceTBox = new System.Windows.Forms.TextBox();
      this.СomputerLbl = new System.Windows.Forms.Label();
      this.DeleteBtn = new System.Windows.Forms.Button();
      this.NotesTBox = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.OrderItemGridView)).BeginInit();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.OrderGridView)).BeginInit();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // OrderItemGridView
      // 
      this.OrderItemGridView.AllowUserToAddRows = false;
      this.OrderItemGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.OrderItemGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
      this.OrderItemGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.OrderItemGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.OrderItemGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OrderItemGridView.GridColor = System.Drawing.SystemColors.Control;
      this.OrderItemGridView.Location = new System.Drawing.Point(477, 0);
      this.OrderItemGridView.MultiSelect = false;
      this.OrderItemGridView.Name = "OrderItemGridView";
      this.OrderItemGridView.ReadOnly = true;
      this.OrderItemGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.OrderItemGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
      this.OrderItemGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.OrderItemGridView.Size = new System.Drawing.Size(323, 450);
      this.OrderItemGridView.TabIndex = 138;
      this.OrderItemGridView.TabStop = false;
      this.OrderItemGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OrderItemGridView_DataError);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.OrderGridView);
      this.panel1.Controls.Add(this.panel2);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(477, 450);
      this.panel1.TabIndex = 137;
      // 
      // OrderGridView
      // 
      this.OrderGridView.AllowUserToAddRows = false;
      this.OrderGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.OrderGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
      this.OrderGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.OrderGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.OrderGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.OrderGridView.GridColor = System.Drawing.SystemColors.Control;
      this.OrderGridView.Location = new System.Drawing.Point(0, 0);
      this.OrderGridView.MultiSelect = false;
      this.OrderGridView.Name = "OrderGridView";
      this.OrderGridView.ReadOnly = true;
      this.OrderGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.OrderGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
      this.OrderGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.OrderGridView.Size = new System.Drawing.Size(477, 220);
      this.OrderGridView.TabIndex = 132;
      this.OrderGridView.TabStop = false;
      this.OrderGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OrderGridView_CellClick);
      this.OrderGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OrderGridView_DataError);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.TotalPurchasesLbl);
      this.panel2.Controls.Add(this.TotalPriceValiadtionLbl);
      this.panel2.Controls.Add(this.TotalPriceTBox);
      this.panel2.Controls.Add(this.СomputerLbl);
      this.panel2.Controls.Add(this.DeleteBtn);
      this.panel2.Controls.Add(this.NotesTBox);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panel2.Location = new System.Drawing.Point(0, 220);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(477, 230);
      this.panel2.TabIndex = 136;
      // 
      // TotalPurchasesLbl
      // 
      this.TotalPurchasesLbl.AutoSize = true;
      this.TotalPurchasesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.TotalPurchasesLbl.Location = new System.Drawing.Point(6, 43);
      this.TotalPurchasesLbl.Name = "TotalPurchasesLbl";
      this.TotalPurchasesLbl.Size = new System.Drawing.Size(199, 16);
      this.TotalPurchasesLbl.TabIndex = 102;
      this.TotalPurchasesLbl.Text = "Сума всіх закупівель клієнта:";
      // 
      // TotalPriceValiadtionLbl
      // 
      this.TotalPriceValiadtionLbl.AutoSize = true;
      this.TotalPriceValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.TotalPriceValiadtionLbl.Location = new System.Drawing.Point(182, 14);
      this.TotalPriceValiadtionLbl.Name = "TotalPriceValiadtionLbl";
      this.TotalPriceValiadtionLbl.Size = new System.Drawing.Size(11, 13);
      this.TotalPriceValiadtionLbl.TabIndex = 101;
      this.TotalPriceValiadtionLbl.Text = "*";
      // 
      // TotalPriceTBox
      // 
      this.TotalPriceTBox.BackColor = System.Drawing.SystemColors.Info;
      this.TotalPriceTBox.Location = new System.Drawing.Point(199, 11);
      this.TotalPriceTBox.MaxLength = 250;
      this.TotalPriceTBox.Name = "TotalPriceTBox";
      this.TotalPriceTBox.ReadOnly = true;
      this.TotalPriceTBox.Size = new System.Drawing.Size(155, 20);
      this.TotalPriceTBox.TabIndex = 10;
      this.TotalPriceTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // СomputerLbl
      // 
      this.СomputerLbl.AutoSize = true;
      this.СomputerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.СomputerLbl.Location = new System.Drawing.Point(49, 12);
      this.СomputerLbl.Name = "СomputerLbl";
      this.СomputerLbl.Size = new System.Drawing.Size(127, 16);
      this.СomputerLbl.TabIndex = 9;
      this.СomputerLbl.Text = "Сума замовлення:";
      // 
      // DeleteBtn
      // 
      this.DeleteBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.DeleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.DeleteBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.DeleteBtn.Location = new System.Drawing.Point(362, 8);
      this.DeleteBtn.Name = "DeleteBtn";
      this.DeleteBtn.Size = new System.Drawing.Size(109, 25);
      this.DeleteBtn.TabIndex = 8;
      this.DeleteBtn.Text = "Видалити";
      this.DeleteBtn.UseVisualStyleBackColor = false;
      this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
      // 
      // NotesTBox
      // 
      this.NotesTBox.BackColor = System.Drawing.SystemColors.Info;
      this.NotesTBox.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.NotesTBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.NotesTBox.Location = new System.Drawing.Point(0, 69);
      this.NotesTBox.MaxLength = 1500;
      this.NotesTBox.Multiline = true;
      this.NotesTBox.Name = "NotesTBox";
      this.NotesTBox.ReadOnly = true;
      this.NotesTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.NotesTBox.Size = new System.Drawing.Size(477, 161);
      this.NotesTBox.TabIndex = 7;
      // 
      // OrderFinishForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.OrderItemGridView);
      this.Controls.Add(this.panel1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "OrderFinishForm";
      this.ShowIcon = false;
      this.Text = "Завершені замовлення";
      ((System.ComponentModel.ISupportInitialize)(this.OrderItemGridView)).EndInit();
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.OrderGridView)).EndInit();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.DataGridView OrderItemGridView;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.DataGridView OrderGridView;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Label TotalPurchasesLbl;
    private System.Windows.Forms.Label TotalPriceValiadtionLbl;
    private System.Windows.Forms.TextBox TotalPriceTBox;
    private System.Windows.Forms.Label СomputerLbl;
    private System.Windows.Forms.Button DeleteBtn;
    private System.Windows.Forms.TextBox NotesTBox;
  }
}