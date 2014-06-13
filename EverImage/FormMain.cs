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

        string EvernoteToken = EverImage.Properties.Settings.Default.EvernoteToken;
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
            EvernoteToken = EverImage.Properties.Settings.Default.EvernoteToken;
            statusToolStripMenuItem.Enabled = false;

            tbUrl.Text = EverImage.Properties.Settings.Default.CurrentUrl;
            tbEvernoteTags.Text = EverImage.Properties.Settings.Default.EvernoteTags;
            
            this.MinimumSize = new System.Drawing.Size(400, 520);

            endProgress();
        }

        /// <summary>
        /// 処理実行前に主要コントロールを操作不可にする
        /// </summary>
        private void beginProgress()
        {
            btnGetImages.Enabled = false;
            btnEvernote.Enabled = false;
            tbUrl.Enabled = false;
            tbEvernoteTags.Enabled = false;
            listView.Enabled = false;
        }

        /// <summary>
        /// 処理終了後に主要コントロールを操作可能にする
        /// </summary>
        private void endProgress()
        {
            btnGetImages.Enabled = true;
            btnEvernote.Enabled = true;
            tbUrl.Enabled = true;
            tbEvernoteTags.Enabled = true;
            listView.Enabled = true;
        }

        private void loginLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvernoteOA oauth = new EvernoteOA(EvernoteOA.HostService.Sandbox);
            if (oauth.doAuth(consumerKey, consumerSecret))
            {
                EverImage.Properties.Settings.Default.EvernoteToken = oauth.OAuthToken;
                EverImage.Properties.Settings.Default.Save();
                EvernoteToken = oauth.OAuthToken;
            }
        }

        private void closeCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void logoutOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvernoteToken = string.Empty;
            EverImage.Properties.Settings.Default.EvernoteToken = string.Empty;
            EverImage.Properties.Settings.Default.Save();
        }

        private void settingSToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EvernoteToken) == false)
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
                        noteStrip.Checked = (evernotebooks[i] == EverImage.Properties.Settings.Default.EvernoteBookName);
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

        private void btnEvernote_Click(object sender, EventArgs e)
        {
            lblStatus.Text = ResEverImage.SendingToEvernote;
            beginProgress();
            pbSendingEvernote.Enabled = true;

            EverImage.Properties.Settings.Default.EvernoteTags = tbEvernoteTags.Text;
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

            foreach (int index in SendImagesIndex.Keys)
            {
                try
                {
                    Evernote.SendToEvernote(Images[index], EvernoteToken,
                        EverImage.Properties.Settings.Default.EvernoteBookName, evernoteTags);
                }
                catch
                {
                    ErrorImageUrls.Add(SendImagesIndex[index]);
                }

                bgSendToEvernote.ReportProgress(count);
                count++;
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
    }
}
