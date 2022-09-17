
namespace InsanKaynaklariBilgiSistem
{
    partial class havuzKayit
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
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.btn_ekle = new DevExpress.XtraEditors.SimpleButton();
            this.btn_aktar = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btn_rapor = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_yenile = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView1
            // 
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(-2, 25);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1230, 724);
            this.gridControl1.TabIndex = 344;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // btn_ekle
            // 
            this.btn_ekle.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.addfile_16x1610;
            this.btn_ekle.Location = new System.Drawing.Point(14, 2);
            this.btn_ekle.Name = "btn_ekle";
            this.btn_ekle.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_ekle.Size = new System.Drawing.Size(25, 23);
            this.btn_ekle.TabIndex = 362;
            this.btn_ekle.Click += new System.EventHandler(this.btn_ekle_Click);
            // 
            // btn_aktar
            // 
            this.btn_aktar.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.exporttoxlsx_16x16;
            this.btn_aktar.Location = new System.Drawing.Point(45, 2);
            this.btn_aktar.Name = "btn_aktar";
            this.btn_aktar.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_aktar.Size = new System.Drawing.Size(35, 23);
            this.btn_aktar.TabIndex = 362;
            this.btn_aktar.Click += new System.EventHandler(this.btn_aktar_Click);
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(45, 294);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(796, 230);
            this.gridControl2.TabIndex = 363;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            this.gridControl2.Visible = false;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // btn_rapor
            // 
            this.btn_rapor.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.boreport_16x16;
            this.btn_rapor.Location = new System.Drawing.Point(311, 2);
            this.btn_rapor.Name = "btn_rapor";
            this.btn_rapor.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_rapor.Size = new System.Drawing.Size(35, 23);
            this.btn_rapor.TabIndex = 362;
            this.btn_rapor.Click += new System.EventHandler(this.btn_rapor_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(240, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 364;
            this.label1.Text = "Tüm Kayıtlar";
            // 
            // btn_yenile
            // 
            this.btn_yenile.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.updatefield_16x161;
            this.btn_yenile.Location = new System.Drawing.Point(400, 2);
            this.btn_yenile.Name = "btn_yenile";
            this.btn_yenile.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_yenile.Size = new System.Drawing.Size(72, 23);
            this.btn_yenile.TabIndex = 362;
            this.btn_yenile.Text = "Yenile";
            this.btn_yenile.Click += new System.EventHandler(this.btn_yenile_Click);
            // 
            // havuzKayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 749);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_yenile);
            this.Controls.Add(this.btn_rapor);
            this.Controls.Add(this.btn_aktar);
            this.Controls.Add(this.btn_ekle);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.gridControl1);
            this.Name = "havuzKayit";
            this.Text = "HAVUZ KAYIT";
            this.Load += new System.EventHandler(this.havuzKayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btn_aktar;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.SimpleButton btn_rapor;
        private System.Windows.Forms.Label label1;
        public DevExpress.XtraEditors.SimpleButton btn_ekle;
        public DevExpress.XtraGrid.GridControl gridControl1;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btn_yenile;
    }
}