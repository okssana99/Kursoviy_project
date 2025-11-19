namespace ConfectioneryDepartmentApp.Forms.Report {
  partial class TopProductsPopularityByMonthForm {
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
      this.SuspendLayout();
      // 
      // RaportTBox
      // 
      this.RaportTBox.BackColor = System.Drawing.SystemColors.Info;
      this.RaportTBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.RaportTBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.RaportTBox.Location = new System.Drawing.Point(0, 0);
      this.RaportTBox.Multiline = true;
      this.RaportTBox.Name = "RaportTBox";
      this.RaportTBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.RaportTBox.Size = new System.Drawing.Size(800, 450);
      this.RaportTBox.TabIndex = 112;
      this.RaportTBox.TabStop = false;
      // 
      // TopProductsPopularityByMonthForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Controls.Add(this.RaportTBox);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "TopProductsPopularityByMonthForm";
      this.ShowIcon = false;
      this.Text = "Популярність товарів за кількістю продаж і отриманим доходом";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox RaportTBox;
  }
}