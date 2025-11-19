namespace ConfectioneryDepartmentApp.Forms.Report {
  partial class SoldProductsInfoForm {
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
      this.SearchBtn = new System.Windows.Forms.Button();
      this.ReportTBox = new System.Windows.Forms.TextBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.EndDTP = new System.Windows.Forms.DateTimePicker();
      this.LastNameLbl = new System.Windows.Forms.Label();
      this.StartDTP = new System.Windows.Forms.DateTimePicker();
      this.ExportingBtn = new System.Windows.Forms.Button();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // SearchBtn
      // 
      this.SearchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.SearchBtn.Location = new System.Drawing.Point(364, 44);
      this.SearchBtn.Name = "SearchBtn";
      this.SearchBtn.Size = new System.Drawing.Size(109, 27);
      this.SearchBtn.TabIndex = 102;
      this.SearchBtn.Text = "Формувати";
      this.SearchBtn.UseVisualStyleBackColor = false;
      this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
      // 
      // ReportTBox
      // 
      this.ReportTBox.BackColor = System.Drawing.SystemColors.Info;
      this.ReportTBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ReportTBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.ReportTBox.Location = new System.Drawing.Point(0, 86);
      this.ReportTBox.Multiline = true;
      this.ReportTBox.Name = "ReportTBox";
      this.ReportTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.ReportTBox.Size = new System.Drawing.Size(800, 364);
      this.ReportTBox.TabIndex = 110;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.ExportingBtn);
      this.groupBox2.Controls.Add(this.label1);
      this.groupBox2.Controls.Add(this.EndDTP);
      this.groupBox2.Controls.Add(this.LastNameLbl);
      this.groupBox2.Controls.Add(this.StartDTP);
      this.groupBox2.Controls.Add(this.SearchBtn);
      this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
      this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.groupBox2.Location = new System.Drawing.Point(0, 0);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(800, 86);
      this.groupBox2.TabIndex = 109;
      this.groupBox2.TabStop = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(12, 50);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(106, 16);
      this.label1.TabIndex = 119;
      this.label1.Text = "Кінець періоду:";
      // 
      // EndDTP
      // 
      this.EndDTP.Location = new System.Drawing.Point(157, 45);
      this.EndDTP.Name = "EndDTP";
      this.EndDTP.Size = new System.Drawing.Size(191, 22);
      this.EndDTP.TabIndex = 118;
      // 
      // LastNameLbl
      // 
      this.LastNameLbl.AutoSize = true;
      this.LastNameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.LastNameLbl.Location = new System.Drawing.Point(12, 17);
      this.LastNameLbl.Name = "LastNameLbl";
      this.LastNameLbl.Size = new System.Drawing.Size(120, 16);
      this.LastNameLbl.TabIndex = 117;
      this.LastNameLbl.Text = "Початок періоду:";
      // 
      // StartDTP
      // 
      this.StartDTP.Location = new System.Drawing.Point(157, 12);
      this.StartDTP.Name = "StartDTP";
      this.StartDTP.Size = new System.Drawing.Size(191, 22);
      this.StartDTP.TabIndex = 116;
      // 
      // ExportingBtn
      // 
      this.ExportingBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.ExportingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.ExportingBtn.Location = new System.Drawing.Point(480, 45);
      this.ExportingBtn.Margin = new System.Windows.Forms.Padding(4);
      this.ExportingBtn.Name = "ExportingBtn";
      this.ExportingBtn.Size = new System.Drawing.Size(117, 27);
      this.ExportingBtn.TabIndex = 146;
      this.ExportingBtn.Text = "Експортувати";
      this.ExportingBtn.UseVisualStyleBackColor = false;
      this.ExportingBtn.Click += new System.EventHandler(this.ExportingBtn_Click);
      // 
      // SoldProductsInfoForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.ReportTBox);
      this.Controls.Add(this.groupBox2);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "SoldProductsInfoForm";
      this.ShowIcon = false;
      this.Text = "Звітність по продажу продукції";
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button SearchBtn;
    private System.Windows.Forms.TextBox ReportTBox;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DateTimePicker EndDTP;
    private System.Windows.Forms.Label LastNameLbl;
    private System.Windows.Forms.DateTimePicker StartDTP;
    private System.Windows.Forms.Button ExportingBtn;
  }
}