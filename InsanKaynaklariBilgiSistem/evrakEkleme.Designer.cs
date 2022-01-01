
namespace InsanKaynaklariBilgiSistem
{
    partial class evrakEkleme
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
            this.components = new System.ComponentModel.Container();
            this.btn_kimlik = new DevExpress.XtraEditors.SimpleButton();
            this.btn_akciger = new DevExpress.XtraEditors.SimpleButton();
            this.btn_tetanoz = new DevExpress.XtraEditors.SimpleButton();
            this.btn_odyogram = new DevExpress.XtraEditors.SimpleButton();
            this.btn_muayene = new DevExpress.XtraEditors.SimpleButton();
            this.btn_kan = new DevExpress.XtraEditors.SimpleButton();
            this.btn_diploma = new DevExpress.XtraEditors.SimpleButton();
            this.btn_dil = new DevExpress.XtraEditors.SimpleButton();
            this.btn_myb = new DevExpress.XtraEditors.SimpleButton();
            this.btn_isg = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sgk = new DevExpress.XtraEditors.SimpleButton();
            this.btn_sabika = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ikametgah = new DevExpress.XtraEditors.SimpleButton();
            this.btn_hepaitit = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btn_myb2 = new DevExpress.XtraEditors.SimpleButton();
            this.lbl_kisi = new System.Windows.Forms.Label();
            this.xtraSaveFileDialog1 = new DevExpress.XtraEditors.XtraSaveFileDialog(this.components);
            this.xtraOpenFileDialog1 = new DevExpress.XtraEditors.XtraOpenFileDialog(this.components);
            this.btn_tamamlandi = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Popup_Menu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.popup_btn_EvrakKaldir = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.listBox1 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Popup_Menu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_kimlik
            // 
            this.btn_kimlik.Location = new System.Drawing.Point(45, 33);
            this.btn_kimlik.Name = "btn_kimlik";
            this.barManager1.SetPopupContextMenu(this.btn_kimlik, this.btn_Popup_Menu);
            this.btn_kimlik.Size = new System.Drawing.Size(157, 23);
            this.btn_kimlik.TabIndex = 0;
            this.btn_kimlik.Text = "Kimlik Fotokopisi";
            this.btn_kimlik.Click += new System.EventHandler(this.btn_kimlik_Click);
            // 
            // btn_akciger
            // 
            this.btn_akciger.Location = new System.Drawing.Point(45, 81);
            this.btn_akciger.Name = "btn_akciger";
            this.barManager1.SetPopupContextMenu(this.btn_akciger, this.btn_Popup_Menu);
            this.btn_akciger.Size = new System.Drawing.Size(157, 23);
            this.btn_akciger.TabIndex = 1;
            this.btn_akciger.Text = "Akciğer Grafiği";
            this.btn_akciger.Click += new System.EventHandler(this.btn_akciger_Click);
            // 
            // btn_tetanoz
            // 
            this.btn_tetanoz.Location = new System.Drawing.Point(45, 137);
            this.btn_tetanoz.Name = "btn_tetanoz";
            this.barManager1.SetPopupContextMenu(this.btn_tetanoz, this.btn_Popup_Menu);
            this.btn_tetanoz.Size = new System.Drawing.Size(157, 23);
            this.btn_tetanoz.TabIndex = 2;
            this.btn_tetanoz.Text = "Tetanoz Aşısı";
            this.btn_tetanoz.Click += new System.EventHandler(this.btn_tetanoz_Click);
            // 
            // btn_odyogram
            // 
            this.btn_odyogram.Location = new System.Drawing.Point(45, 293);
            this.btn_odyogram.Name = "btn_odyogram";
            this.barManager1.SetPopupContextMenu(this.btn_odyogram, this.btn_Popup_Menu);
            this.btn_odyogram.Size = new System.Drawing.Size(157, 23);
            this.btn_odyogram.TabIndex = 5;
            this.btn_odyogram.Text = "ODYOGRAM";
            this.btn_odyogram.Click += new System.EventHandler(this.btn_odyogram_Click);
            // 
            // btn_muayene
            // 
            this.btn_muayene.Location = new System.Drawing.Point(45, 237);
            this.btn_muayene.Name = "btn_muayene";
            this.barManager1.SetPopupContextMenu(this.btn_muayene, this.btn_Popup_Menu);
            this.btn_muayene.Size = new System.Drawing.Size(157, 23);
            this.btn_muayene.TabIndex = 4;
            this.btn_muayene.Text = "Muayene";
            this.btn_muayene.Click += new System.EventHandler(this.btn_muayene_Click);
            // 
            // btn_kan
            // 
            this.btn_kan.Location = new System.Drawing.Point(45, 189);
            this.btn_kan.Name = "btn_kan";
            this.barManager1.SetPopupContextMenu(this.btn_kan, this.btn_Popup_Menu);
            this.btn_kan.Size = new System.Drawing.Size(157, 23);
            this.btn_kan.TabIndex = 3;
            this.btn_kan.Text = "Kan Tahlili";
            this.btn_kan.Click += new System.EventHandler(this.btn_kan_Click);
            // 
            // btn_diploma
            // 
            this.btn_diploma.Location = new System.Drawing.Point(344, 33);
            this.btn_diploma.Name = "btn_diploma";
            this.barManager1.SetPopupContextMenu(this.btn_diploma, this.btn_Popup_Menu);
            this.btn_diploma.Size = new System.Drawing.Size(157, 23);
            this.btn_diploma.TabIndex = 8;
            this.btn_diploma.Text = "Diploma";
            this.btn_diploma.Click += new System.EventHandler(this.btn_diploma_Click);
            // 
            // btn_dil
            // 
            this.btn_dil.Location = new System.Drawing.Point(585, 137);
            this.btn_dil.Name = "btn_dil";
            this.barManager1.SetPopupContextMenu(this.btn_dil, this.btn_Popup_Menu);
            this.btn_dil.Size = new System.Drawing.Size(157, 23);
            this.btn_dil.TabIndex = 7;
            this.btn_dil.Text = "Dil Bilgisi";
            this.btn_dil.Click += new System.EventHandler(this.btn_dil_Click);
            // 
            // btn_myb
            // 
            this.btn_myb.Location = new System.Drawing.Point(585, 33);
            this.btn_myb.Name = "btn_myb";
            this.barManager1.SetPopupContextMenu(this.btn_myb, this.btn_Popup_Menu);
            this.btn_myb.Size = new System.Drawing.Size(157, 23);
            this.btn_myb.TabIndex = 6;
            this.btn_myb.Text = "Mesleki Yeterlilik Belgesi-1";
            this.btn_myb.Click += new System.EventHandler(this.btn_myb_Click);
            // 
            // btn_isg
            // 
            this.btn_isg.Location = new System.Drawing.Point(344, 237);
            this.btn_isg.Name = "btn_isg";
            this.barManager1.SetPopupContextMenu(this.btn_isg, this.btn_Popup_Menu);
            this.btn_isg.Size = new System.Drawing.Size(157, 23);
            this.btn_isg.TabIndex = 12;
            this.btn_isg.Text = "İSG";
            this.btn_isg.Click += new System.EventHandler(this.btn_isg_Click);
            // 
            // btn_sgk
            // 
            this.btn_sgk.Location = new System.Drawing.Point(344, 189);
            this.btn_sgk.Name = "btn_sgk";
            this.barManager1.SetPopupContextMenu(this.btn_sgk, this.btn_Popup_Menu);
            this.btn_sgk.Size = new System.Drawing.Size(157, 23);
            this.btn_sgk.TabIndex = 11;
            this.btn_sgk.Text = "SGK Bildiriri";
            this.btn_sgk.Click += new System.EventHandler(this.btn_sgk_Click);
            // 
            // btn_sabika
            // 
            this.btn_sabika.Location = new System.Drawing.Point(344, 137);
            this.btn_sabika.Name = "btn_sabika";
            this.barManager1.SetPopupContextMenu(this.btn_sabika, this.btn_Popup_Menu);
            this.btn_sabika.Size = new System.Drawing.Size(157, 23);
            this.btn_sabika.TabIndex = 10;
            this.btn_sabika.Text = "Sabıka";
            this.btn_sabika.Click += new System.EventHandler(this.btn_sabika_Click);
            // 
            // btn_ikametgah
            // 
            this.btn_ikametgah.Location = new System.Drawing.Point(344, 81);
            this.btn_ikametgah.Name = "btn_ikametgah";
            this.barManager1.SetPopupContextMenu(this.btn_ikametgah, this.btn_Popup_Menu);
            this.btn_ikametgah.Size = new System.Drawing.Size(157, 23);
            this.btn_ikametgah.TabIndex = 9;
            this.btn_ikametgah.Text = "İkametgah";
            this.btn_ikametgah.Click += new System.EventHandler(this.btn_ikametgah_Click);
            // 
            // btn_hepaitit
            // 
            this.btn_hepaitit.Location = new System.Drawing.Point(45, 346);
            this.btn_hepaitit.Name = "btn_hepaitit";
            this.barManager1.SetPopupContextMenu(this.btn_hepaitit, this.btn_Popup_Menu);
            this.btn_hepaitit.Size = new System.Drawing.Size(157, 23);
            this.btn_hepaitit.TabIndex = 13;
            this.btn_hepaitit.Text = "Hepatit";
            this.btn_hepaitit.Click += new System.EventHandler(this.btn_hepaitit_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(585, 189);
            this.simpleButton2.Name = "simpleButton2";
            this.barManager1.SetPopupContextMenu(this.simpleButton2, this.btn_Popup_Menu);
            this.simpleButton2.Size = new System.Drawing.Size(157, 23);
            this.simpleButton2.TabIndex = 14;
            this.simpleButton2.Text = "DİĞER EVRAKLAR";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btn_myb2
            // 
            this.btn_myb2.Location = new System.Drawing.Point(585, 81);
            this.btn_myb2.Name = "btn_myb2";
            this.barManager1.SetPopupContextMenu(this.btn_myb2, this.btn_Popup_Menu);
            this.btn_myb2.Size = new System.Drawing.Size(157, 23);
            this.btn_myb2.TabIndex = 6;
            this.btn_myb2.Text = "Mesleki Yeterlilik Belgesi-2";
            this.btn_myb2.Click += new System.EventHandler(this.btn_myb2_Click);
            // 
            // lbl_kisi
            // 
            this.lbl_kisi.AutoSize = true;
            this.lbl_kisi.Location = new System.Drawing.Point(29, 9);
            this.lbl_kisi.Name = "lbl_kisi";
            this.lbl_kisi.Size = new System.Drawing.Size(35, 13);
            this.lbl_kisi.TabIndex = 17;
            this.lbl_kisi.Text = "label1";
            // 
            // xtraSaveFileDialog1
            // 
            this.xtraSaveFileDialog1.FileName = "xtraSaveFileDialog1";
            // 
            // xtraOpenFileDialog1
            // 
            this.xtraOpenFileDialog1.FileName = "xtraOpenFileDialog1";
            // 
            // btn_tamamlandi
            // 
            this.btn_tamamlandi.ImageOptions.Image = global::InsanKaynaklariBilgiSistem.Properties.Resources.apply_32x321;
            this.btn_tamamlandi.Location = new System.Drawing.Point(679, 372);
            this.btn_tamamlandi.Name = "btn_tamamlandi";
            this.btn_tamamlandi.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_tamamlandi.Size = new System.Drawing.Size(119, 79);
            this.btn_tamamlandi.TabIndex = 16;
            this.btn_tamamlandi.Text = "TAMAMLANDI";
            this.btn_tamamlandi.Click += new System.EventHandler(this.btn_tamamlandi_Click);
            // 
            // btn_Popup_Menu
            // 
            this.btn_Popup_Menu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.popup_btn_EvrakKaldir)});
            this.btn_Popup_Menu.Manager = this.barManager1;
            this.btn_Popup_Menu.Name = "btn_Popup_Menu";
            // 
            // popup_btn_EvrakKaldir
            // 
            this.popup_btn_EvrakKaldir.Caption = "Evrağı Kaldır";
            this.popup_btn_EvrakKaldir.Id = 0;
            this.popup_btn_EvrakKaldir.Name = "popup_btn_EvrakKaldir";
            this.popup_btn_EvrakKaldir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.popup_btn_EvrakKaldir_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.popup_btn_EvrakKaldir});
            this.barManager1.MaxItemId = 1;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(978, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 450);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(978, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 450);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(978, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 450);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(772, 33);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(194, 316);
            this.listBox1.TabIndex = 22;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // evrakEkleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.lbl_kisi);
            this.Controls.Add(this.btn_tamamlandi);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.btn_hepaitit);
            this.Controls.Add(this.btn_isg);
            this.Controls.Add(this.btn_sgk);
            this.Controls.Add(this.btn_sabika);
            this.Controls.Add(this.btn_ikametgah);
            this.Controls.Add(this.btn_diploma);
            this.Controls.Add(this.btn_dil);
            this.Controls.Add(this.btn_myb2);
            this.Controls.Add(this.btn_myb);
            this.Controls.Add(this.btn_odyogram);
            this.Controls.Add(this.btn_muayene);
            this.Controls.Add(this.btn_kan);
            this.Controls.Add(this.btn_tetanoz);
            this.Controls.Add(this.btn_akciger);
            this.Controls.Add(this.btn_kimlik);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "evrakEkleme";
            this.Text = "EVRAK YÜKLEME";
            this.Load += new System.EventHandler(this.evrakEkleme_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Popup_Menu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_kimlik;
        private DevExpress.XtraEditors.SimpleButton btn_akciger;
        private DevExpress.XtraEditors.SimpleButton btn_tetanoz;
        private DevExpress.XtraEditors.SimpleButton btn_odyogram;
        private DevExpress.XtraEditors.SimpleButton btn_muayene;
        private DevExpress.XtraEditors.SimpleButton btn_kan;
        private DevExpress.XtraEditors.SimpleButton btn_diploma;
        private DevExpress.XtraEditors.SimpleButton btn_dil;
        private DevExpress.XtraEditors.SimpleButton btn_myb;
        private DevExpress.XtraEditors.SimpleButton btn_isg;
        private DevExpress.XtraEditors.SimpleButton btn_sgk;
        private DevExpress.XtraEditors.SimpleButton btn_sabika;
        private DevExpress.XtraEditors.SimpleButton btn_ikametgah;
        private DevExpress.XtraEditors.SimpleButton btn_hepaitit;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btn_tamamlandi;
        private DevExpress.XtraEditors.SimpleButton btn_myb2;
        private System.Windows.Forms.Label lbl_kisi;
        private DevExpress.XtraEditors.XtraSaveFileDialog xtraSaveFileDialog1;
        private DevExpress.XtraEditors.XtraOpenFileDialog xtraOpenFileDialog1;
        private DevExpress.XtraBars.PopupMenu btn_Popup_Menu;
        private DevExpress.XtraBars.BarButtonItem popup_btn_EvrakKaldir;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private System.Windows.Forms.ListBox listBox1;
    }
}