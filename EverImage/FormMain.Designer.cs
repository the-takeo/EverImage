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
            this.closeCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUrl = new System.Windows.Forms.Label();
            this.gbTop = new System.Windows.Forms.GroupBox();
            this.btnGetImages = new System.Windows.Forms.Button();
            this.tbUrl = new System.Windows.Forms.TextBox();
            this.gbImages = new System.Windows.Forms.GroupBox();
            this.lblEvernoteTags = new System.Windows.Forms.Label();
            this.tbEvernoteTags = new System.Windows.Forms.TextBox();
            this.pbSendingEvernote = new System.Windows.Forms.ProgressBar();
            this.btnEvernote = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.bgSendToEvernote = new System.ComponentModel.BackgroundWorker();
            this.menuStrip.SuspendLayout();
            this.gbTop.SuspendLayout();
            this.gbImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileFToolStripMenuItem});
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
            // closeCToolStripMenuItem
            // 
            this.closeCToolStripMenuItem.Name = "closeCToolStripMenuItem";
            this.closeCToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.closeCToolStripMenuItem.Text = "Close(&C)";
            this.closeCToolStripMenuItem.Click += new System.EventHandler(this.closeCToolStripMenuItem_Click);
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
            this.tbUrl.Location = new System.Drawing.Point(39, 12);
            this.tbUrl.Name = "tbUrl";
            this.tbUrl.Size = new System.Drawing.Size(315, 19);
            this.tbUrl.TabIndex = 2;
            // 
            // gbImages
            // 
            this.gbImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImages.Controls.Add(this.lblEvernoteTags);
            this.gbImages.Controls.Add(this.tbEvernoteTags);
            this.gbImages.Controls.Add(this.pbSendingEvernote);
            this.gbImages.Controls.Add(this.btnEvernote);
            this.gbImages.Controls.Add(this.lblStatus);
            this.gbImages.Controls.Add(this.listView);
            this.gbImages.Location = new System.Drawing.Point(12, 103);
            this.gbImages.Name = "gbImages";
            this.gbImages.Size = new System.Drawing.Size(360, 366);
            this.gbImages.TabIndex = 4;
            this.gbImages.TabStop = false;
            // 
            // lblEvernoteTags
            // 
            this.lblEvernoteTags.AutoSize = true;
            this.lblEvernoteTags.Location = new System.Drawing.Point(6, 285);
            this.lblEvernoteTags.Name = "lblEvernoteTags";
            this.lblEvernoteTags.Size = new System.Drawing.Size(230, 12);
            this.lblEvernoteTags.TabIndex = 10;
            this.lblEvernoteTags.Text = "タグ(複数付ける場合はカンマで区切ってください)";
            // 
            // tbEvernoteTags
            // 
            this.tbEvernoteTags.Location = new System.Drawing.Point(8, 300);
            this.tbEvernoteTags.Name = "tbEvernoteTags";
            this.tbEvernoteTags.Size = new System.Drawing.Size(346, 19);
            this.tbEvernoteTags.TabIndex = 9;
            // 
            // pbSendingEvernote
            // 
            this.pbSendingEvernote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbSendingEvernote.Location = new System.Drawing.Point(8, 337);
            this.pbSendingEvernote.Name = "pbSendingEvernote";
            this.pbSendingEvernote.Size = new System.Drawing.Size(249, 23);
            this.pbSendingEvernote.TabIndex = 8;
            // 
            // btnEvernote
            // 
            this.btnEvernote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEvernote.Location = new System.Drawing.Point(263, 337);
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
            this.lblStatus.Location = new System.Drawing.Point(6, 322);
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
            this.listView.Size = new System.Drawing.Size(346, 264);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 481);
            this.Controls.Add(this.gbImages);
            this.Controls.Add(this.gbTop);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.ShowIcon = false;
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
    }
}

