
namespace InsanKaynaklariBilgiSistem
{
    partial class performansDurum
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.SecondaryAxisY secondaryAxisY1 = new DevExpress.XtraCharts.SecondaryAxisY();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.StackedLineSeriesView stackedLineSeriesView1 = new DevExpress.XtraCharts.StackedLineSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(performansDurum));
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.cb_yil_sec = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_listele = new DevExpress.XtraEditors.SimpleButton();
            this.cbx_calisan_grubu = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_gorevii = new System.Windows.Forms.Label();
            this.lbl_gorevyeri = new System.Windows.Forms.Label();
            this.lbl_gorevi = new System.Windows.Forms.Label();
            this.lbl_gorev_yeri = new System.Windows.Forms.Label();
            this.txt_pdks = new System.Windows.Forms.TextBox();
            this.lbl_pdks = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ara = new DevExpress.XtraEditors.SimpleButton();
            this.mtxt_tc_no = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            secondaryAxisY1.Alignment = DevExpress.XtraCharts.AxisAlignment.Near;
            secondaryAxisY1.AxisID = 0;
            secondaryAxisY1.GridLines.Visible = true;
            secondaryAxisY1.Name = "Secondary AxisY 1";
            secondaryAxisY1.VisibleInPanesSerializable = "-1";
            xyDiagram1.SecondaryAxesY.AddRange(new DevExpress.XtraCharts.SecondaryAxisY[] {
            secondaryAxisY1});
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(537, 4);
            this.chartControl1.Name = "chartControl1";
            series1.Name = "Series 1";
            series1.SeriesPointsSortingKey = DevExpress.XtraCharts.SeriesPointKey.Value_1;
            series1.ToolTipSeriesPattern = "{S}={S}";
            series2.Name = "Series 2";
            series2.ToolTipSeriesPattern = "{S}={S}";
            series2.View = stackedLineSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartControl1.SeriesTemplate.SeriesPointsSortingKey = DevExpress.XtraCharts.SeriesPointKey.Value_1;
            this.chartControl1.Size = new System.Drawing.Size(527, 215);
            this.chartControl1.TabIndex = 3;
            // 
            // cb_yil_sec
            // 
            this.cb_yil_sec.FormattingEnabled = true;
            this.cb_yil_sec.Location = new System.Drawing.Point(70, 198);
            this.cb_yil_sec.Name = "cb_yil_sec";
            this.cb_yil_sec.Size = new System.Drawing.Size(70, 21);
            this.cb_yil_sec.TabIndex = 381;
            this.cb_yil_sec.Text = "2022";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 380;
            this.label6.Text = "YIL";
            // 
            // btn_listele
            // 
            this.btn_listele.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_listele.ImageOptions.Image")));
            this.btn_listele.Location = new System.Drawing.Point(169, 198);
            this.btn_listele.Name = "btn_listele";
            this.btn_listele.Size = new System.Drawing.Size(75, 23);
            this.btn_listele.TabIndex = 379;
            this.btn_listele.Text = "LİSTELE";
            this.btn_listele.Click += new System.EventHandler(this.btn_listele_Click);
            // 
            // cbx_calisan_grubu
            // 
            this.cbx_calisan_grubu.FormattingEnabled = true;
            this.cbx_calisan_grubu.Location = new System.Drawing.Point(240, 52);
            this.cbx_calisan_grubu.Name = "cbx_calisan_grubu";
            this.cbx_calisan_grubu.Size = new System.Drawing.Size(121, 21);
            this.cbx_calisan_grubu.TabIndex = 411;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(356, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 410;
            this.label10.Text = "ORTALAMA";
            // 
            // lbl_gorevii
            // 
            this.lbl_gorevii.AutoSize = true;
            this.lbl_gorevii.Location = new System.Drawing.Point(106, 133);
            this.lbl_gorevii.Name = "lbl_gorevii";
            this.lbl_gorevii.Size = new System.Drawing.Size(16, 13);
            this.lbl_gorevii.TabIndex = 408;
            this.lbl_gorevii.Text = "...";
            // 
            // lbl_gorevyeri
            // 
            this.lbl_gorevyeri.AutoSize = true;
            this.lbl_gorevyeri.Location = new System.Drawing.Point(106, 108);
            this.lbl_gorevyeri.Name = "lbl_gorevyeri";
            this.lbl_gorevyeri.Size = new System.Drawing.Size(16, 13);
            this.lbl_gorevyeri.TabIndex = 409;
            this.lbl_gorevyeri.Text = "...";
            // 
            // lbl_gorevi
            // 
            this.lbl_gorevi.AutoSize = true;
            this.lbl_gorevi.Location = new System.Drawing.Point(25, 133);
            this.lbl_gorevi.Name = "lbl_gorevi";
            this.lbl_gorevi.Size = new System.Drawing.Size(48, 13);
            this.lbl_gorevi.TabIndex = 406;
            this.lbl_gorevi.Text = "GÖREVİ";
            // 
            // lbl_gorev_yeri
            // 
            this.lbl_gorev_yeri.AutoSize = true;
            this.lbl_gorev_yeri.Location = new System.Drawing.Point(25, 108);
            this.lbl_gorev_yeri.Name = "lbl_gorev_yeri";
            this.lbl_gorev_yeri.Size = new System.Drawing.Size(73, 13);
            this.lbl_gorev_yeri.TabIndex = 407;
            this.lbl_gorev_yeri.Text = "GÖREV YERİ";
            // 
            // txt_pdks
            // 
            this.txt_pdks.Location = new System.Drawing.Point(109, 29);
            this.txt_pdks.Name = "txt_pdks";
            this.txt_pdks.Size = new System.Drawing.Size(64, 20);
            this.txt_pdks.TabIndex = 405;
            // 
            // lbl_pdks
            // 
            this.lbl_pdks.AutoSize = true;
            this.lbl_pdks.Location = new System.Drawing.Point(25, 36);
            this.lbl_pdks.Name = "lbl_pdks";
            this.lbl_pdks.Size = new System.Drawing.Size(36, 13);
            this.lbl_pdks.TabIndex = 404;
            this.lbl_pdks.Text = "PDKS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 403;
            this.label5.Text = "...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 402;
            this.label4.Text = "SOYADI";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(106, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 13);
            this.label3.TabIndex = 401;
            this.label3.Text = "...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(25, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 400;
            this.label2.Text = "AD";
            // 
            // btn_ara
            // 
            this.btn_ara.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ara.ImageOptions.Image")));
            this.btn_ara.Location = new System.Drawing.Point(240, 4);
            this.btn_ara.Name = "btn_ara";
            this.btn_ara.Size = new System.Drawing.Size(75, 23);
            this.btn_ara.TabIndex = 399;
            this.btn_ara.Text = "ARA";
            this.btn_ara.Click += new System.EventHandler(this.btn_ara_Click);
            // 
            // mtxt_tc_no
            // 
            this.mtxt_tc_no.Location = new System.Drawing.Point(109, 6);
            this.mtxt_tc_no.Name = "mtxt_tc_no";
            this.mtxt_tc_no.Size = new System.Drawing.Size(100, 20);
            this.mtxt_tc_no.TabIndex = 398;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 397;
            this.label1.Text = "TC NO";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(537, 225);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(527, 355);
            this.gridControl1.TabIndex = 412;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // performansDurum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 581);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.cbx_calisan_grubu);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbl_gorevii);
            this.Controls.Add(this.lbl_gorevyeri);
            this.Controls.Add(this.lbl_gorevi);
            this.Controls.Add(this.lbl_gorev_yeri);
            this.Controls.Add(this.txt_pdks);
            this.Controls.Add(this.lbl_pdks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ara);
            this.Controls.Add(this.mtxt_tc_no);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_yil_sec);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_listele);
            this.Controls.Add(this.chartControl1);
            this.Name = "performansDurum";
            this.Text = "PERFORMANS";
            this.Load += new System.EventHandler(this.performansDurum_Load);
            ((System.ComponentModel.ISupportInitialize)(secondaryAxisY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(stackedLineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.ComboBox cb_yil_sec;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.SimpleButton btn_listele;
        private System.Windows.Forms.ComboBox cbx_calisan_grubu;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_gorevii;
        private System.Windows.Forms.Label lbl_gorevyeri;
        private System.Windows.Forms.Label lbl_gorevi;
        private System.Windows.Forms.Label lbl_gorev_yeri;
        private System.Windows.Forms.TextBox txt_pdks;
        private System.Windows.Forms.Label lbl_pdks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btn_ara;
        private System.Windows.Forms.MaskedTextBox mtxt_tc_no;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}