namespace EverImage
{
    partial class FormMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noteBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingSToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusfolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionInfomationVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUrl = new System.Windows.Forms.Label();
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.btnGetImages = new System.Windows.Forms.Button();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.gbImages = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.cbSendinOneNote = new System.Windows.Forms.CheckBox();
            this.lblEvernoteTags = new System.Windows.Forms.Label();
            this.tbEvernoteTags = new System.Windows.Forms.TextBox();
            this.pbSendingEvernote = new System.Windows.Forms.ProgressBar();
            this.btnEvernote = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.bgSendToEvernote = new System.ComponentModel.BackgroundWorker();
            this.bgDownload = new System.ComponentModel.BackgroundWorker();
            this.lblfilter = new System.Windows.Forms.Label();
            this.tbFilter = new System.Windows.Forms.TextBox();
            this.menuStrip.SuspendLayout();
            this.gbTop.SuspendLayout();
            this.gbImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem,
            this.infoIToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(384, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileFToolStripMenuItem
            // 
            this.fileFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingSToolStripMenuItem,
            this.folderToolStripMenuItem,
            this.closeCToolStripMenuItem});
            this.fileFToolStripMenuItem.Name = "fileFToolStripMenuItem";
            this.fileFToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.fileFToolStripMenuItem.Text = "File(&F)";
            // 
            // settingSToolStripMenuItem
            // 
            this.settingSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginLToolStripMenuItem,
            this.statusToolStripMenuItem,
            this.logoutOToolStripMenuItem,
            this.noteBookToolStripMenuItem});
            this.settingSToolStripMenuItem.Name = "settingSToolStripMenuItem";
            this.settingSToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.settingSToolStripMenuItem.Text = "Evernote(&S)";
            this.settingSToolStripMenuItem.MouseEnter += new System.EventHandler(this.settingSToolStripMenuItem_MouseEnter);
            // 
            // loginLToolStripMenuItem
            // 
            this.loginLToolStripMenuItem.Name = "loginLToolStripMenuItem";
            this.loginLToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.loginLToolStripMenuItem.Text = "Login(&L)";
            this.loginLToolStripMenuItem.Click += new System.EventHandler(this.loginLToolStripMenuItem_Click);
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.statusToolStripMenuItem.Text = "Status";
            // 
            // logoutOToolStripMenuItem
            // 
            this.logoutOToolStripMenuItem.Name = "logoutOToolStripMenuItem";
            this.logoutOToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.logoutOToolStripMenuItem.Text = "Logout(&O)";
            this.logoutOToolStripMenuItem.Click += new System.EventHandler(this.logoutOToolStripMenuItem_Click);
            // 
            // noteBookToolStripMenuItem
            // 
            this.noteBookToolStripMenuItem.Name = "noteBookToolStripMenuItem";
            this.noteBookToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.noteBookToolStripMenuItem.Text = "NoteBook";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingSToolStripMenuItem1,
            this.statusfolderToolStripMenuItem});
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.folderToolStripMenuItem.Text = "Folder(&F)";
            this.folderToolStripMenuItem.MouseEnter += new System.EventHandler(this.folderToolStripMenuItem_MouseEnter);
            // 
            // settingSToolStripMenuItem1
            // 
            this.settingSToolStripMenuItem1.Name = "settingSToolStripMenuItem1";
            this.settingSToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.settingSToolStripMenuItem1.Text = "Setting(&S)";
            this.settingSToolStripMenuItem1.Click += new System.EventHandler(this.settingSToolStripMenuItem1_Click);
            // 
            // statusfolderToolStripMenuItem
            // 
            this.statusfolderToolStripMenuItem.Name = "statusfolderToolStripMenuItem";
            this.statusfolderToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.statusfolderToolStripMenuItem.Text = "statusfolder";
            // 
            // closeCToolStripMenuItem
            // 
            this.closeCToolStripMenuItem.Name = "closeCToolStripMenuItem";
            this.closeCToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.closeCToolStripMenuItem.Text = "Close(&C)";
            this.closeCToolStripMenuItem.Click += new System.EventHandler(this.closeCToolStripMenuItem_Click);
            // 
            // infoIToolStripMenuItem
            // 
            this.infoIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.versionInfomationVToolStripMenuItem});
            this.infoIToolStripMenuItem.Name = "infoIToolStripMenuItem";
            this.infoIToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.infoIToolStripMenuItem.Text = "Info(&I)";
            // 
            // versionInfomationVToolStripMenuItem
            // 
            this.versionInfomationVToolStripMenuItem.Name = "versionInfomationVToolStripMenuItem";
            this.versionInfomationVToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.versionInfomationVToolStripMenuItem.Text = "Version(&V)";
            this.versionInfomationVToolStripMenuItem.Click += new System.EventHandler(this.versionInfomationVToolStripMenuItem_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(6, 15);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(27, 12);
            this.lblUrl.TabIndex = 1;
            this.lblUrl.Text = "URL";
            // 
            // gbTop
            // 
            this.gbTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTop.Controls.Add(this.lblfilter);
            this.gbTop.Controls.Add(this.tbFilter);
            this.gbTop.Controls.Add(this.btnGetImages);
            this.gbTop.Controls.Add(this.tbUrl);
            this.gbTop.Controls.Add(this.lblUrl);
            this.gbTop.Location = new System.Drawing.Point(12, 27);
            this.gbTop.Name = "gbTop";
            this.gbTop.Size = new System.Drawing.Size(360, 70);
            this.gbTop.TabIndex = 2;
            this.gbTop.TabStop = false;
            // 
            // btnGetImages
            // 
            this.btnGetImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetImages.Location = new System.Drawing.Point(198, 37);
            this.btnGetImages.Name = "btnGetImages";
            this.btnGetImages.Size = new System.Drawing.Size(156, 23);
            this.btnGetImages.TabIndex = 3;
            this.btnGetImages.Text = "指定したURL上の画像を取得";
            this.btnGetImages.UseVisualStyleBackColor = true;
            this.btnGetImages.Click += new System.EventHandler(this.btnGetImages_Click);
            // 
            // tbUrl
            // 
            this.tbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbUrl.Location = new System.Drawing.Point(44, 12);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(310, 19);
            this.tbUrl.TabIndex = 2;
            // 
            // gbImages
            // 
            this.gbImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImages.Controls.Add(this.btnDownload);
            this.gbImages.Controls.Add(this.cbSendinOneNote);
            this.gbImages.Controls.Add(this.lblEvernoteTags);
            this.gbImages.Controls.Add(this.tbEvernoteTags);
            this.gbImages.Controls.Add(this.pbSendingEvernote);
            this.gbImages.Controls.Add(this.btnEvernote);
            this.gbImages.Controls.Add(this.lblStatus);
            this.gbImages.Controls.Add(this.listView);
            this.gbImages.Location = new System.Drawing.Point(12, 103);
            this.gbImages.Name = "gbImages";
            this.gbImages.Size = new System.Drawing.Size(360, 486);
            this.gbImages.TabIndex = 4;
            this.gbImages.TabStop = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(168, 457);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(89, 23);
            this.btnDownload.TabIndex = 12;
            this.btnDownload.Text = "ダウンロードする";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // cbSendinOneNote
            // 
            this.cbSendinOneNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSendinOneNote.AutoSize = true;
            this.cbSendinOneNote.Location = new System.Drawing.Point(6, 394);
            this.cbSendinOneNote.Name = "cbSendinOneNote";
            this.cbSendinOneNote.Size = new System.Drawing.Size(168, 16);
            this.cbSendinOneNote.TabIndex = 11;
            this.cbSendinOneNote.Text = "1ノートブックにまとめて送信する";
            this.cbSendinOneNote.UseVisualStyleBackColor = true;
            // 
            // lblEvernoteTags
            // 
            this.lblEvernoteTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEvernoteTags.AutoSize = true;
            this.lblEvernoteTags.Location = new System.Drawing.Point(6, 354);
            this.lblEvernoteTags.Name = "lblEvernoteTags";
            this.lblEvernoteTags.Size = new System.Drawing.Size(230, 12);
            this.lblEvernoteTags.TabIndex = 10;
            this.lblEvernoteTags.Text = "タグ(複数付ける場合はカンマで区切ってください)";
            // 
            // tbEvernoteTags
            // 
            this.tbEvernoteTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEvernoteTags.Location = new System.Drawing.Point(8, 369);
            this.tbEvernoteTags.Name = "tbEvernoteTags";
            this.tbEvernoteTags.Size = new System.Drawing.Size(346, 19);
            this.tbEvernoteTags.TabIndex = 9;
            // 
            // pbSendingEvernote
            // 
            this.pbSendingEvernote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSendingEvernote.Location = new System.Drawing.Point(8, 428);
            this.pbSendingEvernote.Name = "pbSendingEvernote";
            this.pbSendingEvernote.Size = new System.Drawing.Size(346, 23);
            this.pbSendingEvernote.TabIndex = 8;
            // 
            // btnEvernote
            // 
            this.btnEvernote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEvernote.Location = new System.Drawing.Point(263, 457);
            this.btnEvernote.Name = "btnEvernote";
            this.btnEvernote.Size = new System.Drawing.Size(91, 23);
            this.btnEvernote.TabIndex = 7;
            this.btnEvernote.Text = "Evernoteに送信";
            this.btnEvernote.UseVisualStyleBackColor = true;
            this.btnEvernote.Click += new System.EventHandler(this.btnEvernote_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 413);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 12);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status";
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.CheckBoxes = true;
            this.listView.Location = new System.Drawing.Point(8, 18);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(346, 333);
            this.listView.TabIndex = 1;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // bgSendToEvernote
            // 
            this.bgSendToEvernote.WorkerReportsProgress = true;
            this.bgSendToEvernote.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgSendToEvernote_DoWork);
            this.bgSendToEvernote.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgSendToEvernote_ProgressChanged);
            this.bgSendToEvernote.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgSendToEvernote_RunWorkerCompleted);
            // 
            // bgDownload
            // 
            this.bgDownload.WorkerReportsProgress = true;
            this.bgDownload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgDownload_DoWork);
            this.bgDownload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgDownload_ProgressChanged);
            this.bgDownload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgDownload_RunWorkerCompleted);
            // 
            // lblfilter
            // 
            this.lblfilter.AutoSize = true;
            this.lblfilter.Location = new System.Drawing.Point(6, 42);
            this.lblfilter.Name = "lblfilter";
            this.lblfilter.Size = new System.Drawing.Size(32, 12);
            this.lblfilter.TabIndex = 5;
            this.lblfilter.Text = "Filter";
            // 
            // tbFilter
            // 
            this.tbFilter.Location = new System.Drawing.Point(44, 39);
            this.tbFilter.Name = "tbFilter";
            this.tbFilter.Size = new System.Drawing.Size(148, 19);
            this.tbFilter.TabIndex = 6;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 601);
            this.Controls.Add(this.gbImages);
            this.Controls.Add(this.gbTop);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.Text = "EverImage";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.gbTop.ResumeLayout(false);
            this.gbTop.PerformLayout();
            this.gbImages.ResumeLayout(false);
            this.gbImages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginLToolStripMenuItem;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.GroupBox gbTop;
        private System.Windows.Forms.Button btnGetImages;
        private System.Windows.Forms.TextBox tbUrl;
        private System.Windows.Forms.GroupBox gbImages;
        private System.Windows.Forms.Button btnEvernote;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgSendToEvernote;
        private System.Windows.Forms.ToolStripMenuItem logoutOToolStripMenuItem;
        private System.Windows.Forms.ProgressBar pbSendingEvernote;
        private System.Windows.Forms.ToolStripMenuItem noteBookToolStripMenuItem;
        private System.Windows.Forms.Label lblEvernoteTags;
        private System.Windows.Forms.TextBox tbEvernoteTags;
        private System.Windows.Forms.CheckBox cbSendinOneNote;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingSToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem statusfolderToolStripMenuItem;
        private System.Windows.Forms.Button btnDownload;
        private System.ComponentModel.BackgroundWorker bgDownload;
        private System.Windows.Forms.ToolStripMenuItem infoIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem versionInfomationVToolStripMenuItem;
        private System.Windows.Forms.Label lblfilter;
        private System.Windows.Forms.TextBox tbFilter;
    }
}

