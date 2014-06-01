using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        string EvernoteToken = string.Empty; //本来はappConfigから取得する
        string consumerKey = string.Empty; //本来はここで記述
        string consumerSecret = string.Empty; //本来はここで記述

        public FormMain()
        {
            InitializeComponent();

            listView.LargeImageList = imageList;
            EvernoteToken = EverImage.Properties.Settings.Default.EvernoteToken;

            endProgress();
        }

        private void closeCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fillImagesToList()
        {
            beginProgress();
            WebClient wc = new WebClient();
            Stream stream;

            for (int i = 0; i < Adresses.Count; i++)
            {
                stream = wc.OpenRead(Adresses[i]);
                Image image = Image.FromStream(stream);
                Images.Add(image);

                imageList.Images.Add(image);
                listView.Items.Add(Path.GetFileName(Adresses[i]), i);
                stream.Close();
            }

            endProgress();
        }

        private void btnGetImages_Click(object sender, EventArgs e)
        {
            listView.Clear();
            imageList.Images.Clear();
            Images.Clear();

            Adresses = gi.GetPictures(tbUrl.Text);

            fillImagesToList();
        }

        private void btnEvernote_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Evernoteに画像を送信中です。";
            lblStatus.Visible = true;
            beginProgress();

            List<Image> sendImages = new List<Image>();

            foreach (ListViewItem item in listView.CheckedItems)
            {
                Evernote.SendToEvernote(Images[item.Index], EvernoteToken);
            }

            endProgress();
        }

        private void beginProgress()
        {
            btnGetImages.Enabled = false;
            btnEvernote.Enabled = false;
            tbUrl.Enabled = false;
        }

        private void endProgress()
        {
            btnGetImages.Enabled = true;
            btnEvernote.Enabled = true;
            tbUrl.Enabled = true;
            lblStatus.Visible = false;
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
    }
}
