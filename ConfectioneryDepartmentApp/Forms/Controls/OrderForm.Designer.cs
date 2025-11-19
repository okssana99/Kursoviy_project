namespace ConfectioneryDepartmentApp.Forms.Controls {
  partial class OrderForm {
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
      this.AddBtn = new System.Windows.Forms.Button();
      this.QuantityTBox = new System.Windows.Forms.TextBox();
      this.CategoryCBox = new System.Windows.Forms.ComboBox();
      this.СomputerLbl = new System.Windows.Forms.Label();
      this.PhotoPBox = new System.Windows.Forms.PictureBox();
      this.QuantityValiadtionLbl = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.QuantityLbl = new System.Windows.Forms.Label();
      this.BasePriceTBox = new System.Windows.Forms.TextBox();
      this.label7 = new System.Windows.Forms.Label();
      this.NotesTBox = new System.Windows.Forms.TextBox();
      this.AddGBox = new System.Windows.Forms.GroupBox();
      this.ManualTotalWithDiscountTBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label10 = new System.Windows.Forms.Label();
      this.DueDtDTP = new System.Windows.Forms.DateTimePicker();
      this.label9 = new System.Windows.Forms.Label();
      this.NotesOrderTBox = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.Status = new System.Windows.Forms.Label();
      this.StatusCBox = new System.Windows.Forms.ComboBox();
      this.label5 = new System.Windows.Forms.Label();
      this.CustomerValiadtionLbl = new System.Windows.Forms.Label();
      this.CustomerCBox = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.UnitLbl = new System.Windows.Forms.Label();
      this.ProductValiadtionLbl = new System.Windows.Forms.Label();
      this.ProductCBox = new System.Windows.Forms.ComboBox();
      this.label2 = new System.Windows.Forms.Label();
      this.CategoryValiadtionLbl = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.ManualTotalTBox = new System.Windows.Forms.TextBox();
      this.ProductsItemsGridView = new System.Windows.Forms.DataGridView();
      this.ExitBtn = new System.Windows.Forms.Button();
      this.OrderBtn = new System.Windows.Forms.Button();
      this.AddPanel = new System.Windows.Forms.Panel();
      ((System.ComponentModel.ISupportInitialize)(this.PhotoPBox)).BeginInit();
      this.groupBox1.SuspendLayout();
      this.AddGBox.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ProductsItemsGridView)).BeginInit();
      this.AddPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // AddBtn
      // 
      this.AddBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.AddBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.AddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.AddBtn.Location = new System.Drawing.Point(339, 65);
      this.AddBtn.Name = "AddBtn";
      this.AddBtn.Size = new System.Drawing.Size(89, 25);
      this.AddBtn.TabIndex = 102;
      this.AddBtn.Text = "Додати";
      this.AddBtn.UseVisualStyleBackColor = false;
      this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
      // 
      // QuantityTBox
      // 
      this.QuantityTBox.BackColor = System.Drawing.SystemColors.Info;
      this.QuantityTBox.Location = new System.Drawing.Point(109, 66);
      this.QuantityTBox.MaxLength = 8;
      this.QuantityTBox.Name = "QuantityTBox";
      this.QuantityTBox.Size = new System.Drawing.Size(73, 22);
      this.QuantityTBox.TabIndex = 108;
      this.QuantityTBox.Text = "0";
      this.QuantityTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // CategoryCBox
      // 
      this.CategoryCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CategoryCBox.FormattingEnabled = true;
      this.CategoryCBox.Location = new System.Drawing.Point(109, 12);
      this.CategoryCBox.Name = "CategoryCBox";
      this.CategoryCBox.Size = new System.Drawing.Size(319, 24);
      this.CategoryCBox.TabIndex = 95;
      this.CategoryCBox.SelectedValueChanged += new System.EventHandler(this.CategoryCBox_SelectedValueChanged);
      // 
      // СomputerLbl
      // 
      this.СomputerLbl.AutoSize = true;
      this.СomputerLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.СomputerLbl.Location = new System.Drawing.Point(263, 373);
      this.СomputerLbl.Name = "СomputerLbl";
      this.СomputerLbl.Size = new System.Drawing.Size(107, 16);
      this.СomputerLbl.TabIndex = 0;
      this.СomputerLbl.Text = "Загальна сума:";
      // 
      // PhotoPBox
      // 
      this.PhotoPBox.Location = new System.Drawing.Point(9, 31);
      this.PhotoPBox.Name = "PhotoPBox";
      this.PhotoPBox.Size = new System.Drawing.Size(242, 140);
      this.PhotoPBox.TabIndex = 111;
      this.PhotoPBox.TabStop = false;
      // 
      // QuantityValiadtionLbl
      // 
      this.QuantityValiadtionLbl.AutoSize = true;
      this.QuantityValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.QuantityValiadtionLbl.Location = new System.Drawing.Point(91, 69);
      this.QuantityValiadtionLbl.Name = "QuantityValiadtionLbl";
      this.QuantityValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.QuantityValiadtionLbl.TabIndex = 109;
      this.QuantityValiadtionLbl.Text = "*";
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.QuantityLbl);
      this.groupBox1.Controls.Add(this.PhotoPBox);
      this.groupBox1.Controls.Add(this.BasePriceTBox);
      this.groupBox1.Controls.Add(this.label7);
      this.groupBox1.Controls.Add(this.NotesTBox);
      this.groupBox1.Location = new System.Drawing.Point(6, 96);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(501, 209);
      this.groupBox1.TabIndex = 103;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Деталі обраного товару";
      // 
      // QuantityLbl
      // 
      this.QuantityLbl.AutoSize = true;
      this.QuantityLbl.BackColor = System.Drawing.SystemColors.Control;
      this.QuantityLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.QuantityLbl.ForeColor = System.Drawing.Color.Magenta;
      this.QuantityLbl.Location = new System.Drawing.Point(205, 182);
      this.QuantityLbl.Name = "QuantityLbl";
      this.QuantityLbl.Size = new System.Drawing.Size(15, 16);
      this.QuantityLbl.TabIndex = 112;
      this.QuantityLbl.Text = "()";
      // 
      // BasePriceTBox
      // 
      this.BasePriceTBox.BackColor = System.Drawing.SystemColors.Info;
      this.BasePriceTBox.Location = new System.Drawing.Point(49, 179);
      this.BasePriceTBox.MaxLength = 10;
      this.BasePriceTBox.Name = "BasePriceTBox";
      this.BasePriceTBox.ReadOnly = true;
      this.BasePriceTBox.Size = new System.Drawing.Size(150, 22);
      this.BasePriceTBox.TabIndex = 107;
      this.BasePriceTBox.Text = "0";
      this.BasePriceTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label7.Location = new System.Drawing.Point(8, 182);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(38, 16);
      this.label7.TabIndex = 110;
      this.label7.Text = "Ціна:";
      // 
      // NotesTBox
      // 
      this.NotesTBox.BackColor = System.Drawing.SystemColors.Info;
      this.NotesTBox.Location = new System.Drawing.Point(257, 31);
      this.NotesTBox.MaxLength = 1500;
      this.NotesTBox.Multiline = true;
      this.NotesTBox.Name = "NotesTBox";
      this.NotesTBox.ReadOnly = true;
      this.NotesTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.NotesTBox.Size = new System.Drawing.Size(242, 140);
      this.NotesTBox.TabIndex = 109;
      // 
      // AddGBox
      // 
      this.AddGBox.Controls.Add(this.ManualTotalWithDiscountTBox);
      this.AddGBox.Controls.Add(this.label1);
      this.AddGBox.Controls.Add(this.label10);
      this.AddGBox.Controls.Add(this.DueDtDTP);
      this.AddGBox.Controls.Add(this.label9);
      this.AddGBox.Controls.Add(this.NotesOrderTBox);
      this.AddGBox.Controls.Add(this.label6);
      this.AddGBox.Controls.Add(this.Status);
      this.AddGBox.Controls.Add(this.StatusCBox);
      this.AddGBox.Controls.Add(this.label5);
      this.AddGBox.Controls.Add(this.CustomerValiadtionLbl);
      this.AddGBox.Controls.Add(this.CustomerCBox);
      this.AddGBox.Controls.Add(this.label3);
      this.AddGBox.Controls.Add(this.UnitLbl);
      this.AddGBox.Controls.Add(this.QuantityValiadtionLbl);
      this.AddGBox.Controls.Add(this.groupBox1);
      this.AddGBox.Controls.Add(this.AddBtn);
      this.AddGBox.Controls.Add(this.QuantityTBox);
      this.AddGBox.Controls.Add(this.ProductValiadtionLbl);
      this.AddGBox.Controls.Add(this.ProductCBox);
      this.AddGBox.Controls.Add(this.label2);
      this.AddGBox.Controls.Add(this.CategoryValiadtionLbl);
      this.AddGBox.Controls.Add(this.CategoryCBox);
      this.AddGBox.Controls.Add(this.label4);
      this.AddGBox.Controls.Add(this.ManualTotalTBox);
      this.AddGBox.Controls.Add(this.СomputerLbl);
      this.AddGBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.AddGBox.Location = new System.Drawing.Point(12, 5);
      this.AddGBox.Name = "AddGBox";
      this.AddGBox.Size = new System.Drawing.Size(516, 516);
      this.AddGBox.TabIndex = 0;
      this.AddGBox.TabStop = false;
      // 
      // ManualTotalWithDiscountTBox
      // 
      this.ManualTotalWithDiscountTBox.BackColor = System.Drawing.SystemColors.Info;
      this.ManualTotalWithDiscountTBox.Location = new System.Drawing.Point(376, 395);
      this.ManualTotalWithDiscountTBox.MaxLength = 10;
      this.ManualTotalWithDiscountTBox.Name = "ManualTotalWithDiscountTBox";
      this.ManualTotalWithDiscountTBox.ReadOnly = true;
      this.ManualTotalWithDiscountTBox.Size = new System.Drawing.Size(129, 22);
      this.ManualTotalWithDiscountTBox.TabIndex = 112;
      this.ManualTotalWithDiscountTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(287, 398);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(83, 16);
      this.label1.TabIndex = 113;
      this.label1.Text = "Зі знижкою:";
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.ForeColor = System.Drawing.Color.Red;
      this.label10.Location = new System.Drawing.Point(145, 312);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(12, 16);
      this.label10.TabIndex = 132;
      this.label10.Text = "*";
      // 
      // DueDtDTP
      // 
      this.DueDtDTP.Location = new System.Drawing.Point(163, 309);
      this.DueDtDTP.Name = "DueDtDTP";
      this.DueDtDTP.Size = new System.Drawing.Size(167, 22);
      this.DueDtDTP.TabIndex = 129;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label9.Location = new System.Drawing.Point(10, 311);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(128, 16);
      this.label9.TabIndex = 130;
      this.label9.Text = "Термін готовності:";
      // 
      // NotesOrderTBox
      // 
      this.NotesOrderTBox.BackColor = System.Drawing.SystemColors.Info;
      this.NotesOrderTBox.Location = new System.Drawing.Point(10, 423);
      this.NotesOrderTBox.MaxLength = 1500;
      this.NotesOrderTBox.Multiline = true;
      this.NotesOrderTBox.Name = "NotesOrderTBox";
      this.NotesOrderTBox.ReadOnly = true;
      this.NotesOrderTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.NotesOrderTBox.Size = new System.Drawing.Size(495, 82);
      this.NotesOrderTBox.TabIndex = 118;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label6.Location = new System.Drawing.Point(10, 401);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(239, 16);
      this.label6.TabIndex = 117;
      this.label6.Text = "Додаткові примітки до замовлення:";
      // 
      // Status
      // 
      this.Status.AutoSize = true;
      this.Status.ForeColor = System.Drawing.Color.Red;
      this.Status.Location = new System.Drawing.Point(91, 370);
      this.Status.Name = "Status";
      this.Status.Size = new System.Drawing.Size(12, 16);
      this.Status.TabIndex = 116;
      this.Status.Text = "*";
      // 
      // StatusCBox
      // 
      this.StatusCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.StatusCBox.FormattingEnabled = true;
      this.StatusCBox.Items.AddRange(new object[] {
            "нове",
            "в роботі"});
      this.StatusCBox.Location = new System.Drawing.Point(109, 367);
      this.StatusCBox.Name = "StatusCBox";
      this.StatusCBox.Size = new System.Drawing.Size(145, 24);
      this.StatusCBox.TabIndex = 114;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label5.Location = new System.Drawing.Point(7, 372);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(56, 16);
      this.label5.TabIndex = 115;
      this.label5.Text = "Статус:";
      // 
      // CustomerValiadtionLbl
      // 
      this.CustomerValiadtionLbl.AutoSize = true;
      this.CustomerValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.CustomerValiadtionLbl.Location = new System.Drawing.Point(91, 340);
      this.CustomerValiadtionLbl.Name = "CustomerValiadtionLbl";
      this.CustomerValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.CustomerValiadtionLbl.TabIndex = 113;
      this.CustomerValiadtionLbl.Text = "*";
      // 
      // CustomerCBox
      // 
      this.CustomerCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.CustomerCBox.FormattingEnabled = true;
      this.CustomerCBox.Location = new System.Drawing.Point(109, 337);
      this.CustomerCBox.Name = "CustomerCBox";
      this.CustomerCBox.Size = new System.Drawing.Size(396, 24);
      this.CustomerCBox.TabIndex = 111;
      this.CustomerCBox.SelectedValueChanged += new System.EventHandler(this.CustomerCBox_SelectedValueChanged);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label3.Location = new System.Drawing.Point(7, 342);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(52, 16);
      this.label3.TabIndex = 112;
      this.label3.Text = "Клієнт:";
      // 
      // UnitLbl
      // 
      this.UnitLbl.AutoSize = true;
      this.UnitLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.UnitLbl.Location = new System.Drawing.Point(188, 70);
      this.UnitLbl.Name = "UnitLbl";
      this.UnitLbl.Size = new System.Drawing.Size(76, 16);
      this.UnitLbl.TabIndex = 110;
      this.UnitLbl.Text = "(Од. вим.:  )";
      // 
      // ProductValiadtionLbl
      // 
      this.ProductValiadtionLbl.AutoSize = true;
      this.ProductValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.ProductValiadtionLbl.Location = new System.Drawing.Point(91, 42);
      this.ProductValiadtionLbl.Name = "ProductValiadtionLbl";
      this.ProductValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.ProductValiadtionLbl.TabIndex = 100;
      this.ProductValiadtionLbl.Text = "*";
      // 
      // ProductCBox
      // 
      this.ProductCBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.ProductCBox.FormattingEnabled = true;
      this.ProductCBox.Location = new System.Drawing.Point(109, 39);
      this.ProductCBox.Name = "ProductCBox";
      this.ProductCBox.Size = new System.Drawing.Size(319, 24);
      this.ProductCBox.TabIndex = 98;
      this.ProductCBox.SelectedValueChanged += new System.EventHandler(this.ProductCBox_SelectedValueChanged);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(7, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(51, 16);
      this.label2.TabIndex = 99;
      this.label2.Text = "Товар:";
      // 
      // CategoryValiadtionLbl
      // 
      this.CategoryValiadtionLbl.AutoSize = true;
      this.CategoryValiadtionLbl.ForeColor = System.Drawing.Color.Red;
      this.CategoryValiadtionLbl.Location = new System.Drawing.Point(91, 15);
      this.CategoryValiadtionLbl.Name = "CategoryValiadtionLbl";
      this.CategoryValiadtionLbl.Size = new System.Drawing.Size(12, 16);
      this.CategoryValiadtionLbl.TabIndex = 97;
      this.CategoryValiadtionLbl.Text = "*";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label4.Location = new System.Drawing.Point(7, 15);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(73, 16);
      this.label4.TabIndex = 96;
      this.label4.Text = "Категорія:";
      // 
      // ManualTotalTBox
      // 
      this.ManualTotalTBox.BackColor = System.Drawing.SystemColors.Info;
      this.ManualTotalTBox.Location = new System.Drawing.Point(376, 370);
      this.ManualTotalTBox.MaxLength = 250;
      this.ManualTotalTBox.Name = "ManualTotalTBox";
      this.ManualTotalTBox.ReadOnly = true;
      this.ManualTotalTBox.Size = new System.Drawing.Size(129, 22);
      this.ManualTotalTBox.TabIndex = 1;
      this.ManualTotalTBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // ProductsItemsGridView
      // 
      this.ProductsItemsGridView.AllowUserToAddRows = false;
      this.ProductsItemsGridView.AllowUserToDeleteRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
      this.ProductsItemsGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.ProductsItemsGridView.BackgroundColor = System.Drawing.SystemColors.Control;
      this.ProductsItemsGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.ProductsItemsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ProductsItemsGridView.GridColor = System.Drawing.SystemColors.Control;
      this.ProductsItemsGridView.Location = new System.Drawing.Point(543, 0);
      this.ProductsItemsGridView.MultiSelect = false;
      this.ProductsItemsGridView.Name = "ProductsItemsGridView";
      this.ProductsItemsGridView.ReadOnly = true;
      this.ProductsItemsGridView.RowHeadersWidth = 20;
      dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ProductsItemsGridView.RowsDefaultCellStyle = dataGridViewCellStyle2;
      this.ProductsItemsGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.ProductsItemsGridView.Size = new System.Drawing.Size(474, 559);
      this.ProductsItemsGridView.TabIndex = 138;
      this.ProductsItemsGridView.TabStop = false;
      this.ProductsItemsGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProductsItemsGridView_CellClick);
      // 
      // ExitBtn
      // 
      this.ExitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ExitBtn.Location = new System.Drawing.Point(436, 527);
      this.ExitBtn.Name = "ExitBtn";
      this.ExitBtn.Size = new System.Drawing.Size(81, 25);
      this.ExitBtn.TabIndex = 5;
      this.ExitBtn.Text = "Вихід";
      this.ExitBtn.UseVisualStyleBackColor = false;
      this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
      // 
      // OrderBtn
      // 
      this.OrderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.OrderBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.OrderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.OrderBtn.Location = new System.Drawing.Point(326, 527);
      this.OrderBtn.Name = "OrderBtn";
      this.OrderBtn.Size = new System.Drawing.Size(89, 25);
      this.OrderBtn.TabIndex = 3;
      this.OrderBtn.Text = "Замовити";
      this.OrderBtn.UseVisualStyleBackColor = false;
      this.OrderBtn.Click += new System.EventHandler(this.OrderBtn_Click);
      // 
      // AddPanel
      // 
      this.AddPanel.Controls.Add(this.AddGBox);
      this.AddPanel.Controls.Add(this.ExitBtn);
      this.AddPanel.Controls.Add(this.OrderBtn);
      this.AddPanel.Dock = System.Windows.Forms.DockStyle.Left;
      this.AddPanel.Location = new System.Drawing.Point(0, 0);
      this.AddPanel.Name = "AddPanel";
      this.AddPanel.Size = new System.Drawing.Size(543, 559);
      this.AddPanel.TabIndex = 137;
      // 
      // OrderForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1017, 559);
      this.Controls.Add(this.ProductsItemsGridView);
      this.Controls.Add(this.AddPanel);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "OrderForm";
      this.ShowIcon = false;
      this.Text = "Формування замовлення на продаж";
      ((System.ComponentModel.ISupportInitialize)(this.PhotoPBox)).EndInit();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.AddGBox.ResumeLayout(false);
      this.AddGBox.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.ProductsItemsGridView)).EndInit();
      this.AddPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button AddBtn;
    private System.Windows.Forms.TextBox QuantityTBox;
    private System.Windows.Forms.ComboBox CategoryCBox;
    private System.Windows.Forms.Label СomputerLbl;
    private System.Windows.Forms.PictureBox PhotoPBox;
    private System.Windows.Forms.Label QuantityValiadtionLbl;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox BasePriceTBox;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.TextBox NotesTBox;
    private System.Windows.Forms.GroupBox AddGBox;
    private System.Windows.Forms.Label ProductValiadtionLbl;
    private System.Windows.Forms.ComboBox ProductCBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label CategoryValiadtionLbl;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox ManualTotalTBox;
    private System.Windows.Forms.DataGridView ProductsItemsGridView;
    private System.Windows.Forms.Button ExitBtn;
    private System.Windows.Forms.Button OrderBtn;
    private System.Windows.Forms.Panel AddPanel;
    private System.Windows.Forms.Label UnitLbl;
    private System.Windows.Forms.Label CustomerValiadtionLbl;
    private System.Windows.Forms.ComboBox CustomerCBox;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label Status;
    private System.Windows.Forms.ComboBox StatusCBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox NotesOrderTBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.DateTimePicker DueDtDTP;
    private System.Windows.Forms.Label label9;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox ManualTotalWithDiscountTBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label QuantityLbl;
  }
}