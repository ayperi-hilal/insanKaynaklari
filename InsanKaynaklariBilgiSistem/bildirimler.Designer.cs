
namespace InsanKaynaklariBilgiSistem
{
    partial class bildirimler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_rapor = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1-Bu Hafta Doğum Günü Olanlar",
            "2-Bugün Doğun Günü Olanlar",
            "3-Bugün Bir Merasimi Olanlar",
            "4-Bu Hafta Bir Merasimi Olanlar",
            "5-Bugün Borç Ödemesi Olanlar",
            "6-Bu Hafta Ödemesi Olanlar",
            "7-Bu Ay Ödemesi Olanlar",
            "8-Borç Ödemesi Gecikenler",
            "9-Ağır İş Sertifikası Süresi Bugün Dolanlar",
            "10-Ağır İş Sertifikası Süresi Bu Hafta Dolacaklar",
            "11-Ağır İş Sertifikası Süresi Bu Ay Dolacaklar",
            "12-Ağır İş Sertifikası Süresi Dolanlar",
            "13-Sertifikası Süresi Bu Hafta Dolacaklar",
            "14-Sertifikası Süresi Bu Ay Dolacaklar",
            "15-Sertifikası Süresi Dolanlar",
            "16-Bugün Aile ile İlgili Merasimler",
            "17-Yaklaşan Aile ile İlgili Merasimler"});
            this.comboBox1.Location = new System.Drawing.Point(913, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(204, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(677, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bildirimlerini Görmek İstediğiniz Grubu seçiniz";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(-1, 61);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1127, 389);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            // 
            // btn_rapor
            // 
            this.btn_rapor.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.report_32x323;
            this.btn_rapor.Location = new System.Drawing.Point(482, 4);
            this.btn_rapor.Name = "btn_rapor";
            this.btn_rapor.Size = new System.Drawing.Size(140, 40);
            this.btn_rapor.TabIndex = 442;
            this.btn_rapor.Text = "EKRANI\r\nYAZDIR";
            this.btn_rapor.Click += new System.EventHandler(this.btn_rapor_Click);
            // 
            // bildirimler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1126, 450);
            this.Controls.Add(this.btn_rapor);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Name = "bildirimler";
            this.Text = "BİLDİRİMLER";
            this.Load += new System.EventHandler(this.bildirimler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btn_rapor;
    }
}