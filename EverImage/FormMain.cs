using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using EvernoteOAuth;

namespace EverImage
{
    public partial class FormMain : Form
    {
        GetImages gi = new GetImages();
        List<string> Adresses;
        List<Image> Images = new List<Image>();
        Dictionary<int, string> SendImagesIndex = new Dictionary<int, string>();

        List<string> ErrorImageUrls = new List<string>();

        string consumerKey = ConsumerKeys.consumerKey; //公開不可
        string consumerSecret = ConsumerKeys.consumerSecret; //公開不可

        const int listWidth = 100;
        const int listHeight = 80;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            imageList.ImageSize = new Size(listWidth, listHeight);
            listView.LargeImageList = imageList;
            statusToolStripMenuItem.Enabled = false;
            statusfolderToolStripMenuItem.Enabled = false;

            tbUrl.Text = EverImage.Properties.Settings.Default.CurrentUrl;
            tbEvernoteTags.Text = EverImage.Properties.Settings.Default.EvernoteTags;
            cbSendinOneNote.Checked = EverImage.Properties.Settings.Default.SendOneNote;

            this.MinimumSize = new System.Drawing.Size(400, 640);

            endProgress();

            reflesh();
        }

        /// <summary>
        /// Evernoteにログイン中か
        /// </summary>
        private bool isAvailableEvernote
        {
            get { return string.IsNullOrEmpty(EvernoteToken) == false && imageList.Images.Count != 0; }
        }

        /// <summary>
        /// Downloadが可能か
        /// </summary>
        private bool isAvailableDownload
        {
            get { return string.IsNullOrEmpty(FolderDirectory) == false && imageList.Images.Count != 0; }
        }

        /// <summary>
        /// Download先Folderアドレス
        /// </summary>
        private string FolderDirectory
        {
            get { return EverImage.Properties.Settings.Default.Folder; }
        }

        /// <summary>
        /// ログイン中のEvernoteToken
        /// </summary>
        private string EvernoteToken
        {
            get { return EverImage.Properties.Settings.Default.EvernoteToken; }
        }

        /// <summary>
        /// Evernoteの送信先に指定しているNotebookの名前
        /// </summary>
        private string EvernoteNotebookName
        {
            get { return EverImage.Properties.Settings.Default.EvernoteBookName; }
        }

        /// <summary>
        /// 処理実行前に主要コントロールを操作不可にする
        /// </summary>
        private void beginProgress()
        {
            btnGetImages.Enabled = false;
            btnEvernote.Enabled = false;
            btnDownload.Enabled = false;
            tbUrl.Enabled = false;
            tbEvernoteTags.Enabled = false;
            listView.Enabled = false;
            cbSendinOneNote.Enabled = false;
        }

        /// <summary>
        /// 処理終了後に主要コントロールを操作可能にする
        /// </summary>
        private void endProgress()
        {
            btnGetImages.Enabled = true;
            btnEvernote.Enabled = true;
            btnDownload.Enabled = true;
            tbUrl.Enabled = true;
            tbEvernoteTags.Enabled = true;
            listView.Enabled = true;
            cbSendinOneNote.Enabled = true;
        }

        /// <summary>
        /// データの保持状況に基づき、各コントロールの状態を設定する
        /// </summary>
        private void reflesh()
        {
            tbEvernoteTags.Enabled = isAvailableEvernote;
            cbSendinOneNote.Enabled = isAvailableEvernote;
            btnEvernote.Enabled = isAvailableEvernote;

            btnDownload.Enabled = isAvailableDownload;
        }

        /// <summary>
        /// 取得した画像をリストに追加する
        /// </summary>
        private void fillImagesToList()
        {
            WebClient wc = new WebClient();
            Stream stream;

            for (int i = 0; i < Adresses.Count; i++)
            {
                stream = wc.OpenRead(Adresses[i]);
                Image image = Image.FromStream(stream);
                Images.Add(image);

                Image thumbnail = createThumbnail(image, listWidth, listHeight);

                imageList.Images.Add(thumbnail);
                listView.Items.Add(Path.GetFileName(Adresses[i]), i);
                listView.Items[i].Checked = true;
                stream.Close();
            }
        }

        /// <summary>
        /// イメージのサムネイルを作成する
        /// </summary>
        /// <param name="image">イメージ</param>
        /// <param name="width">幅</param>
        /// <param name="height">高さ</param>
        /// <returns>サムネイルイメージ</returns>
        private Image createThumbnail(Image image, int width, int height)
        {
            Bitmap thumbnail = new Bitmap(width, height);

            Graphics graphics = Graphics.FromImage(thumbnail);
            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, width, height);

            float fw = (float)width / (float)image.Width;
            float fh = (float)height / (float)image.Height;

            float scale = Math.Min(fw, fh);
            fw = image.Width * scale;
            fh = image.Height * scale;

            graphics.DrawImage(image, (width - fw) / 2, (height - fh) / 2, fw, fh);
            graphics.Dispose();

            return thumbnail;
        }

        private void closeCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loginLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvernoteOA oauth = new EvernoteOA(EvernoteOA.HostService.Sandbox);
            if (oauth.doAuth(consumerKey, consumerSecret))
            {
                EverImage.Properties.Settings.Default.EvernoteToken = oauth.OAuthToken;
                EverImage.Properties.Settings.Default.Save();

                reflesh();
            }
        }

        private void logoutOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EverImage.Properties.Settings.Default.EvernoteToken = string.Empty;
            EverImage.Properties.Settings.Default.Save();

            reflesh();
        }

        /// <summary>
        /// セッティングメニュー展開前に実行。
        /// Evernoteのユーザー名とノート情報を通信して取得する。
        /// 毎回通信しているので、やや時間がかかる。
        /// </summary>
        private void settingSToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (isAvailableEvernote)
            {
                try
                {
                    settingSToolStripMenuItem.Text = ResEverImage.GettingEvernoteInfo;

                    statusToolStripMenuItem.Text
                       = string.Format(ResEverImage.LoginToEvernote, Evernote.GetEvernoteUserName(EvernoteToken));

                    noteBookToolStripMenuItem.DropDownItems.Clear();

                    List<string> evernotebooks = new List<string>(Evernote.GetEvetnoteNotebook(EvernoteToken).Keys);

                    for (int i = evernotebooks.Count - 1; i >= 0; i--)
                    {
                        ToolStripMenuItem noteStrip = new ToolStripMenuItem(evernotebooks[i]);
                        noteStrip.Click += noteStrip_Click;
                        noteBookToolStripMenuItem.DropDownItems.Add(noteStrip);
                        noteStrip.Checked = (evernotebooks[i] == EvernoteNotebookName);
                    }

                    noteBookToolStripMenuItem.Enabled = true;
                }
                catch
                {
                    statusToolStripMenuItem.Text = ResEverImage.FailedGettingEvernoteUserName;
                }
                loginLToolStripMenuItem.Enabled = false;
                logoutOToolStripMenuItem.Enabled = true;

                settingSToolStripMenuItem.Text = ResEverImage.EndGettingEvernoteInfo;
            }
            else
            {
                statusToolStripMenuItem.Text = ResEverImage.LogoutFromEvernote;
                loginLToolStripMenuItem.Enabled = true;
                logoutOToolStripMenuItem.Enabled = false;
                noteBookToolStripMenuItem.Enabled = false;
            }
        }

        void noteStrip_Click(object sender, EventArgs e)
        {
            EverImage.Properties.Settings.Default.EvernoteBookName = sender.ToString();
            EverImage.Properties.Settings.Default.Save();
        }


        private void settingSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = ResEverImage.SelectFolderTitle;
            fbd.RootFolder = Environment.SpecialFolder.Desktop;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                EverImage.Properties.Settings.Default.Folder = fbd.SelectedPath;
                EverImage.Properties.Settings.Default.Save();
            }

            reflesh();
        }

        private void folderToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FolderDirectory))
                statusfolderToolStripMenuItem.Text = ResEverImage.SelectedNoFolder;
            else
                statusfolderToolStripMenuItem.Text = FolderDirectory;
        }
        
        private void btnGetImages_Click(object sender, EventArgs e)
        {
            beginProgress();
            lblStatus.Text = ResEverImage.GettingImagesFromWeb;

            EverImage.Properties.Settings.Default.CurrentUrl = tbUrl.Text;
            EverImage.Properties.Settings.Default.Save();

            listView.Clear();
            imageList.Images.Clear();
            Images.Clear();

            Adresses = gi.GetPictures(tbUrl.Text);

            fillImagesToList();

            listView.Enabled = true;

            lblStatus.Text = ResEverImage.CompletedGettingImages;
            endProgress();
        }

        #region SendEvernote

        private void btnEvernote_Click(object sender, EventArgs e)
        {
            lblStatus.Text = ResEverImage.SendingToEvernote;
            beginProgress();
            pbSendingEvernote.Enabled = true;

            EverImage.Properties.Settings.Default.EvernoteTags = tbEvernoteTags.Text;
            EverImage.Properties.Settings.Default.SendOneNote = cbSendinOneNote.Checked;
            EverImage.Properties.Settings.Default.Save();

            foreach (ListViewItem item in listView.CheckedItems)
            {
                SendImagesIndex.Add(item.Index, item.Text);
            }

            bgSendToEvernote.RunWorkerAsync();
        }

        private void bgSendToEvernote_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 1;

            List<string> evernoteTags = new List<string>(tbEvernoteTags.Text.Split(','));

            if (cbSendinOneNote.Checked == true)
            {
                List<Image> sendImages = new List<Image>();

                foreach (var index in SendImagesIndex.Keys)
                {
                    sendImages.Add(Images[index]);
                }

                try
                {
                    Evernote.SendToEvernote(sendImages, EvernoteToken,
                        EvernoteNotebookName, evernoteTags);
                }
                catch (Exception ex)
                {
                    foreach (var index in SendImagesIndex.Keys)
                    {
                        ErrorImageUrls.Add(SendImagesIndex[index]);
                    }
                }
            }

            else
            {
                foreach (int index in SendImagesIndex.Keys)
                {
                    try
                    {
                        Evernote.SendToEvernote(new List<Image>() { Images[index] }, EvernoteToken,
                            EvernoteNotebookName, evernoteTags);
                    }
                    catch
                    {
                        ErrorImageUrls.Add(SendImagesIndex[index]);
                    }

                    bgSendToEvernote.ReportProgress(count);
                    count++;
                }
            }
        }

        private void bgSendToEvernote_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text
                = string.Format(ResEverImage.ProgressOfSending,
                listView.CheckedItems.Count.ToString(),
                e.ProgressPercentage.ToString());

            pbSendingEvernote.Value = 100 * e.ProgressPercentage / SendImagesIndex.Count;
        }

        private void bgSendToEvernote_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = ResEverImage.CompletedSending;

            if (ErrorImageUrls.Count != 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var errorImageUrl in ErrorImageUrls)
                {
                    sb.Append(errorImageUrl);
                    sb.Append(",");
                }
                sb.Remove(sb.Length - 1, 1);

                MessageBox.Show(string.Format(ResEverImage.SendingError, sb.ToString()));

                ErrorImageUrls.Clear();
            }

            SendImagesIndex.Clear();

            pbSendingEvernote.Value = 0;
            pbSendingEvernote.Enabled = false;
            endProgress();
        }

        #endregion

        #region Download

        private void btnDownload_Click(object sender, EventArgs e)
        {
            beginProgress();

            foreach (ListViewItem item in listView.CheckedItems)
            {
                SendImagesIndex.Add(item.Index, item.Text);
            }

            bgDownload.RunWorkerAsync();
        }

        private void bgDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 1;

            foreach (int index in SendImagesIndex.Keys)
            {
                try
                {
                    gi.StartDownload(Adresses[index], FolderDirectory);
                }
                catch
                {
                    ErrorImageUrls.Add(SendImagesIndex[index]);
                }

                bgDownload.ReportProgress(count);
                count++;
            }
        }

        private void bgDownload_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text
                = string.Format(ResEverImage.ProgressOfDownloading,
                listView.CheckedItems.Count.ToString(),
                e.ProgressPercentage.ToString());

            pbSendingEvernote.Value = 100 * e.ProgressPercentage / SendImagesIndex.Count;
        }

        private void bgDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = ResEverImage.CompletedDownloading;

            if (ErrorImageUrls.Count != 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var errorImageUrl in ErrorImageUrls)
                {
                    sb.Append(errorImageUrl);
                    sb.Append(",");
                }
                sb.Remove(sb.Length - 1, 1);

                MessageBox.Show(string.Format(ResEverImage.DownloadingError, sb.ToString()));

                ErrorImageUrls.Clear();
            }

            SendImagesIndex.Clear();

            pbSendingEvernote.Value = 0;
            pbSendingEvernote.Enabled = false;
            endProgress();
        }

        #endregion

        private void versionInfomationVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
    }
}
