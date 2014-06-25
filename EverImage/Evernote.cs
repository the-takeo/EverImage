using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Thrift.Protocol;
using Thrift.Transport;
using Evernote.EDAM.Type;
using Evernote.EDAM.UserStore;
using Evernote.EDAM.NoteStore;
using System.Drawing;
using System.Text;

namespace EverImage
{
    /// <summary>
    /// Evernote操作関連のクラス
    /// </summary>
    class Evernote
    {
        static String evernoteHost = "www.evernote.com";

        /// <summary>
        /// Evernoteのユーザー名を取得する
        /// </summary>
        /// <param name="EvernoteToken">Evernoteトークン</param>
        /// <returns>ユーザー名</returns>
        static public string GetEvernoteUserName(string EvernoteToken)
        {
            string authToken = EvernoteToken;

            Uri userStoreUrl = new Uri("https://" + evernoteHost + "/edam/user");
            TTransport userStoreTransport = new THttpClient(userStoreUrl);
            TProtocol userStoreProtocol = new TBinaryProtocol(userStoreTransport);
            UserStore.Client userStore = new UserStore.Client(userStoreProtocol);

            return userStore.getUser(authToken).Username;
        }

        /// <summary>
        /// Evernoteのノートブック情報を取得する
        /// </summary>
        /// <param name="EvernoteToken">Evernoteトークン</param>
        /// <returns>ノートブック名とノートブックGuidのDictionary</returns>
        static public Dictionary<string, string> GetEvetnoteNotebook(string EvernoteToken)
        {
            string authToken = EvernoteToken;

            Uri userStoreUrl = new Uri("https://" + evernoteHost + "/edam/user");
            TTransport userStoreTransport = new THttpClient(userStoreUrl);
            TProtocol userStoreProtocol = new TBinaryProtocol(userStoreTransport);
            UserStore.Client userStore = new UserStore.Client(userStoreProtocol);

            String noteStoreUrl = userStore.getNoteStoreUrl(authToken);

            TTransport noteStoreTransport = new THttpClient(new Uri(noteStoreUrl));
            TProtocol noteStoreProtocol = new TBinaryProtocol(noteStoreTransport);
            NoteStore.Client noteStore = new NoteStore.Client(noteStoreProtocol);

            List<Notebook> notebooks = noteStore.listNotebooks(authToken);

            Dictionary<string, string> notebookNames = new Dictionary<string, string>();

            foreach (var note in notebooks)
            {
                notebookNames.Add(note.Name, note.Guid);
            }

            return notebookNames;
        }


        /// <summary>
        /// Evernoteに画像を送信する
        /// </summary>
        /// <param name="sendImage">送信する画像</param>
        /// <param name="EvernoteToken">Evernoteトークン</param>
        static public void SendToEvernote(List<Image> sendImages, string EvernoteToken,
            string evernoteNotebookName, List<string> evernoteTags, string sourceUrl)
        {
            string authToken = EvernoteToken;

            Uri userStoreUrl = new Uri("https://" + evernoteHost + "/edam/user");
            TTransport userStoreTransport = new THttpClient(userStoreUrl);
            TProtocol userStoreProtocol = new TBinaryProtocol(userStoreTransport);
            UserStore.Client userStore = new UserStore.Client(userStoreProtocol);
            String noteStoreUrl = userStore.getNoteStoreUrl(authToken);

            TTransport noteStoreTransport = new THttpClient(new Uri(noteStoreUrl));
            TProtocol noteStoreProtocol = new TBinaryProtocol(noteStoreTransport);
            NoteStore.Client noteStore = new NoteStore.Client(noteStoreProtocol);

            Note note = new Note();
            note.Title = DateTime.Now.ToShortDateString();

            foreach (var notebook in Evernote.GetEvetnoteNotebook(EvernoteToken))
            {
                if (notebook.Key == evernoteNotebookName)
                {
                    note.NotebookGuid = notebook.Value;
                    break;
                }
            }

            note.TagNames = evernoteTags;

            NoteAttributes attributes = new NoteAttributes();
            attributes.SourceURL = sourceUrl;
            note.Attributes = attributes;

            StringBuilder content = new StringBuilder();
            content.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            content.Append("<!DOCTYPE en-note SYSTEM \"http://xml.evernote.com/pub/enml2.dtd\">");
            content.Append("<en-note>");

            note.Resources = new List<Resource>();

            foreach (var sendImage in sendImages)
            {
                ImageConverter converter = new ImageConverter();
                byte[] image = (byte[])converter.ConvertTo(sendImage, typeof(byte[]));
                byte[] hash = new MD5CryptoServiceProvider().ComputeHash(image);

                Data data = new Data();
                data.Size = image.Length;
                data.BodyHash = hash;
                data.Body = image;

                Resource resource = new Resource();
                resource.Mime = "image/png";
                resource.Data = data;


                note.Resources.Add(resource);

                string hashHex = BitConverter.ToString(hash).Replace("-", "").ToLower();

                content.Append("<span>");
                content.Append("<en-media type=\"image/png\" hash=\"");
                content.Append(hashHex);
                content.Append("\"/>");
                content.Append("</span>");
                content.Append("<br/>");
            }

            content.Append("</en-note>");

            note.Content = content.ToString();

            Note createdNote = noteStore.createNote(authToken, note);
        }
    }
}
