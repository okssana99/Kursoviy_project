namespace ConfectioneryDepartmentApp.Forms.Report {
  partial class CategoryRevenueReportLastMonthForm {
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
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.LastNameLbl = new System.Windows.Forms.Label();
      this.SelectMonthDTP = new System.Windows.Forms.DateTimePicker();
      this.SearchBtn = new System.Windows.Forms.Button();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // RaportTBox
      // 
      this.RaportTBox.BackColor = System.Drawing.SystemColors.Info;
      this.RaportTBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RaportTBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.RaportTBox.Location = new System.Drawing.Point(0, 46);
      this.RaportTBox.Multiline = true;
      this.RaportTBox.Name = "RaportTBox";
      this.RaportTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.RaportTBox.Size = new System.Drawing.Size(800, 404);
      this.RaportTBox.TabIndex = 110;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.LastNameLbl);
      this.groupBox2.Controls.Add(this.SelectMonthDTP);
      this.groupBox2.Controls.Add(this.SearchBtn);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox2.Location = new System.Drawing.Point(0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(800, 46);
      this.groupBox2.TabIndex = 109;
      this.groupBox2.TabStop = false;
      // 
      // LastNameLbl
      // 
      this.LastNameLbl.AutoSize = true;
      this.LastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LastNameLbl.Location = new System.Drawing.Point(10, 17);
      this.LastNameLbl.Name = "LastNameLbl";
      this.LastNameLbl.Size = new System.Drawing.Size(53, 16);
      this.LastNameLbl.TabIndex = 117;
      this.LastNameLbl.Text = "Місяць:";
      // 
      // SelectMonthDTP
      // 
      this.SelectMonthDTP.Location = new System.Drawing.Point(65, 13);
      this.SelectMonthDTP.Name = "SelectMonthDTP";
      this.SelectMonthDTP.Size = new System.Drawing.Size(171, 22);
      this.SelectMonthDTP.TabIndex = 116;
      // 
      // SearchBtn
      // 
      this.SearchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SearchBtn.Location = new System.Drawing.Point(242, 11);
      this.SearchBtn.Name = "SearchBtn";
      this.SearchBtn.Size = new System.Drawing.Size(109, 25);
      this.SearchBtn.TabIndex = 102;
      this.SearchBtn.Text = "Формувати";
      this.SearchBtn.UseVisualStyleBackColor = false;
      this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
      // 
      // CategoryRevenueReportLastMonthForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.RaportTBox);
      this.Controls.Add(this.groupBox2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "CategoryRevenueReportLastMonthForm";
      this.ShowIcon = false;
      this.Text = "Аналіз найприбутковіших категорій за місяць";
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox RaportTBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label LastNameLbl;
    private System.Windows.Forms.DateTimePicker SelectMonthDTP;
    private System.Windows.Forms.Button SearchBtn;
  }
}