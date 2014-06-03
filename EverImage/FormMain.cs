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

        string EvernoteToken = string.Empty; //本来はappConfigから取得する
        string consumerKey = string.Empty; //本来はここで記述
        string consumerSecret = string.Empty; //本来はここで記述

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            listView.LargeImageList = imageList;
            EvernoteToken = EverImage.Properties.Settings.Default.EvernoteToken;
            statusToolStripMenuItem.Enabled = false;

            this.MinimumSize = new System.Drawing.Size(400, 500);

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
            listView.Enabled = true;
        }

        private void loginLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EvernoteOA oauth = new EvernoteOA(EvernoteOA.HostService.Sandbox);
            if (oauth.doAuth(consumerKey, consumerSecret))
            {
                EverImage.Properties.Settings.Default.EvernoteToken = oauth.OAuthToken;
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
        }

        private void settingSToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EvernoteToken) == false)
            {
                statusToolStripMenuItem.Text
                    = Evernote.GetEvernoteUserName(EvernoteToken) + "としてEvernoteにログインしています。";
                loginLToolStripMenuItem.Enabled = false;
                logoutOToolStripMenuItem.Enabled = true;
            }
            else
            {
                statusToolStripMenuItem.Text = "Evernoteにログインしていません。";
                loginLToolStripMenuItem.Enabled = true;
                logoutOToolStripMenuItem.Enabled = false;
            }
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

                imageList.Images.Add(image);
                listView.Items.Add(Path.GetFileName(Adresses[i]), i);
                listView.Items[i].Checked = true;
                stream.Close();
            }
        }

        private void btnGetImages_Click(object sender, EventArgs e)
        {
            beginProgress();
            lblStatus.Text = "Webページから画像を取得中です。";

            listView.Clear();
            imageList.Images.Clear();
            Images.Clear();

            Adresses = gi.GetPictures(tbUrl.Text);

            fillImagesToList();

            listView.Enabled = true;

            lblStatus.Text = "画像の取得が完了しました。";
            endProgress();
        }

        private void btnEvernote_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Evernoteに画像を送信中です。";
            beginProgress();
            pbSendingEvernote.Enabled = true;

            foreach (ListViewItem item in listView.CheckedItems)
            {
                SendImagesIndex.Add(item.Index, item.Text);
            }

            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = 1;

            foreach (int index in SendImagesIndex.Keys)
            {
                try
                {
                    Evernote.SendToEvernote(Images[index], EvernoteToken);
                }
                catch
                {
                    ErrorImageUrls.Add(SendImagesIndex[index]);
                }

                backgroundWorker.ReportProgress(count);
                count++;
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text
                = listView.CheckedItems.Count.ToString() + "画像中"
                + e.ProgressPercentage.ToString() + "画像の送信が完了しました。";

            pbSendingEvernote.Value = 100 * e.ProgressPercentage / SendImagesIndex.Count;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = "送信が完了しました。";

            if (ErrorImageUrls.Count != 0)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var errorImageUrl in ErrorImageUrls)
                {
                    sb.Append(errorImageUrl);
                    sb.Append(",");
                }
                sb.Remove(sb.Length - 1, 1);
                sb.Append("の送信に失敗しました。");

                MessageBox.Show(sb.ToString());

                ErrorImageUrls.Clear();
            }

            SendImagesIndex.Clear();

            pbSendingEvernote.Value = 0;
            pbSendingEvernote.Enabled = false;
            endProgress();
        }
    }
}
