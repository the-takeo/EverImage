using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace EverImage
{
    /// <summary>
    /// Webページ情報を取得するための非表示ウィブブラウザクラス
    /// https://github.com/the-takeo/DownloadPictures から流用
    /// </summary>
    public class UnDisplayedBrowser : WebBrowser
    {
        bool isCompleted = false;

        TimeSpan timeout = new TimeSpan(0, 0, 10);

        public UnDisplayedBrowser()
        {
            this.ScriptErrorsSuppressed = true;
        }

        protected override void OnDocumentCompleted(WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url == this.Url)
                isCompleted = true;
        }

        protected override void OnNewWindow(CancelEventArgs e)
        {
            e.Cancel = true;
        }

        public bool NavigateAndWait(string url)
        {
            base.Navigate(url);

            isCompleted = false;
            DateTime start = DateTime.Now;

            while (isCompleted == false)
            {
                if (DateTime.Now - start > timeout)
                {
                    return false;
                }
                Application.DoEvents();
            }
            return true;
        }
    }

    /// <summary>
    /// Webから画像情報を取得するクラス
    /// https://github.com/the-takeo/DownloadPictures から流用
    /// </summary>
    public class GetImages
    {
        string[] invalidPathStrings = new string[9] { @"\", @"/", @"?", @":", @"|", @"*", @"<", @">", @"""" };
        List<string> picExtensions = new List<string>() { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
        List<string> filter_ = new List<string>();

        public GetImages(List<string> filter = null)
        {
            if (filter != null)
                filter_ = filter;
        }

        /// <summary>
        /// 指定したURLのWebページに表示されている画像アドレスを取得し、
        /// リストにして返す。
        /// </summary>
        /// <param name="url">Webページのアドレス</param>
        public List<string> GetPictures(string url)
        {
            List<string> pictureAdresses = new List<string>();

            UnDisplayedBrowser udb = new UnDisplayedBrowser();
            udb.NavigateAndWait(url);

            HtmlDocument doc = udb.Document;


            //Webページに表示されている画像の取得
            foreach (HtmlElement picElement in doc.GetElementsByTagName("IMG"))
            {
                string picUrl = picElement.GetAttribute("src");

                if (picExtensions.Contains(Path.GetExtension(picUrl)) == false)
                    continue;

                //フィルター式が設定されている場合、除外する
                if (filter_ != null)
                {
                    bool isFiltered = false;

                    foreach (var item in filter_)
                    {
                        if (picUrl.Contains(item))
                        {
                            isFiltered = true;
                            break;
                        }
                    }

                    if (isFiltered)
                        continue;
                }

                if (pictureAdresses.Contains(picUrl) == false)
                {
                    pictureAdresses.Add(picUrl);
                }
            }

            //サムネイル画像をリンク先画像に差し替え
            foreach (HtmlElement linkElement in doc.GetElementsByTagName("A"))
            {
                string picUrl = linkElement.GetAttribute("href");
                if (picExtensions.Contains(Path.GetExtension(picUrl)) == false)
                    continue;

                foreach (HtmlElement picElement in linkElement.GetElementsByTagName("IMG"))
                {
                    if (pictureAdresses.Contains(picElement.GetAttribute("src")))
                    {
                        pictureAdresses.Remove(picElement.GetAttribute("src"));
                        pictureAdresses.Add(picUrl);
                    }
                }
            }

            return pictureAdresses;
        }
    }
}
