/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2014 the-takeo
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Threading;
using System.Text;

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
    /// </summary>
    public class GetImages
    {
        string[] invalidPathStrings = new string[9] { @"\", @"/", @"?", @":", @"|", @"*", @"<", @">", @"""" };
        List<string> imgExtensions = new List<string>() { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };
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
        public List<string> DoGetImages(string url)
        {
            List<string> imageAdresses = new List<string>();

            UnDisplayedBrowser udb = new UnDisplayedBrowser();
            udb.NavigateAndWait(url);

            HtmlDocument doc = udb.Document;

            //Webページに表示されている画像の取得
            foreach (HtmlElement imgElement in doc.GetElementsByTagName("IMG"))
            {
                string imgUrl = imgElement.GetAttribute("src");

                if (imgExtensions.Contains(Path.GetExtension(imgUrl)) == false)
                    continue;

                //フィルター式が設定されている場合、除外する
                if (filter_ != null)
                {
                    bool isFiltered = false;

                    foreach (var item in filter_)
                    {
                        if (imgUrl.Contains(item))
                        {
                            isFiltered = true;
                            break;
                        }
                    }

                    if (isFiltered)
                        continue;
                }

                if (imageAdresses.Contains(imgUrl) == false)
                {
                    imageAdresses.Add(imgUrl);
                }
            }

            //サムネイル画像をリンク先画像に差し替え
            foreach (HtmlElement linkElement in doc.GetElementsByTagName("A"))
            {
                string imgUrl = linkElement.GetAttribute("href");
                if (imgExtensions.Contains(Path.GetExtension(imgUrl)) == false)
                    continue;

                foreach (HtmlElement imgElement in linkElement.GetElementsByTagName("IMG"))
                {
                    if (imageAdresses.Contains(imgElement.GetAttribute("src")))
                    {
                        imageAdresses.Remove(imgElement.GetAttribute("src"));
                        imageAdresses.Add(imgUrl);
                    }
                }
            }

            return imageAdresses;
        }

        /// <summary>
        /// 渡されたアドレスリストを元に画像のダウンロードを開始する
        /// </summary>
        /// <param name="imageAdresses">ダウンロード対象画像アドレス</param>
        /// <param name="folder">ダウンロード先ディレクトリ</param>
        public void StartDownload(string imageAdresse, string folder)
        {
            if (folder.EndsWith(@"\") == false)
                folder = folder + @"\";

            WebClient wc = new WebClient();

            string downloadingfileName = imageAdresse;

            //禁則文字の置換
            foreach (var InvalidPathChar in Path.GetInvalidPathChars())
            {
                if (imageAdresse.Contains(InvalidPathChar.ToString()))
                    downloadingfileName = downloadingfileName.Replace(InvalidPathChar, '_');
            }

            downloadingfileName = Path.GetFileName(downloadingfileName);

            //禁則文字の置換
            foreach (var InvalidPathString in invalidPathStrings)
            {
                if (imageAdresse.Contains(InvalidPathString))
                    downloadingfileName = downloadingfileName.Replace(InvalidPathString, "_");
            }

            wc.DownloadFile(new Uri(imageAdresse), folder + downloadingfileName);
        }
    }
}
