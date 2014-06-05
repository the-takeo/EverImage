using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Thrift.Protocol;
using Thrift.Transport;
using Evernote.EDAM.Type;
using Evernote.EDAM.UserStore;
using Evernote.EDAM.NoteStore;
using System.Drawing;

namespace EverImage
{
    /// <summary>
    /// Evernote操作関連のクラス
    /// </summary>
    class Evernote
    {
        static public string GetEvernoteUserName(string EvernoteToken)
        {
            string authToken = EvernoteToken;
            String evernoteHost = "sandbox.evernote.com";

            Uri userStoreUrl = new Uri("https://" + evernoteHost + "/edam/user");
            TTransport userStoreTransport = new THttpClient(userStoreUrl);
            TProtocol userStoreProtocol = new TBinaryProtocol(userStoreTransport);
            UserStore.Client userStore = new UserStore.Client(userStoreProtocol);

            return userStore.getUser(authToken).Username;
        }

        /// <summary>
        /// Evernoteに画像を送信する
        /// </summary>
        /// <param name="sendImage">送信する画像</param>
        /// <param name="EvernoteToken">Evernoteトークン</param>
        static public void SendToEvernote(Image sendImage, string EvernoteToken)
        {
            string authToken = EvernoteToken;
            String evernoteHost = "sandbox.evernote.com";

            Uri userStoreUrl = new Uri("https://" + evernoteHost + "/edam/user");
            TTransport userStoreTransport = new THttpClient(userStoreUrl);
            TProtocol userStoreProtocol = new TBinaryProtocol(userStoreTransport);
            UserStore.Client userStore = new UserStore.Client(userStoreProtocol);
            String noteStoreUrl = userStore.getNoteStoreUrl(authToken);

            TTransport noteStoreTransport = new THttpClient(new Uri(noteStoreUrl));
            TProtocol noteStoreProtocol = new TBinaryProtocol(noteStoreTransport);
            NoteStore.Client noteStore = new NoteStore.Client(noteStoreProtocol);

            //List<Notebook> notebooks = noteStore.listNotebooks(authToken);

            Note note = new Note();
            note.Title = DateTime.Now.ToShortDateString();

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

            note.Resources = new List<Resource>();
            note.Resources.Add(resource);

            string hashHex = BitConverter.ToString(hash).Replace("-", "").ToLower();

            note.Content = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<!DOCTYPE en-note SYSTEM \"http://xml.evernote.com/pub/enml2.dtd\">" +
                "<en-note>" +
                "<en-media type=\"image/png\" hash=\"" + hashHex + "\"/>" +
                "</en-note>";

            Note createdNote = noteStore.createNote(authToken, note);
        }
    }
}
