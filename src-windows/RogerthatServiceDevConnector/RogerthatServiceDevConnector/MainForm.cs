using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using System.Xml;

using jabber;
using jabber.client;

namespace RogerthatServiceDevConnector
{
    public partial class MainForm : Form
    {
        JabberClient jc;

        public MainForm()
        {
            InitializeComponent();

            //Change SSL checks so that all checks pass
            ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(grant);
   
        }

        private Boolean grant(Object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                logsListBox.Items.Clear();
                jc = new JabberClient();
                jc.OnReadText += new bedrock.TextHandler(jc_OnReadText);
                jc.OnWriteText += new bedrock.TextHandler(jc_OnWriteText);
                jc.OnError += new bedrock.ExceptionHandler(jc_OnError);
                jc.OnStreamError += new jabber.protocol.ProtocolHandler(jc_OnStreamError);
                jc.OnInvalidCertificate += new System.Net.Security.RemoteCertificateValidationCallback(jc_OnInvalidCertificate);
                jc.OnMessage += new MessageHandler(jc_OnMessage);

                JID j = new JID(accountTextbox.Text);
                jc.User = j.User;
                jc.Server = j.Server;
                jc.Resource = "RogerthatServiceCallbackForwarder";
                jc.Password = passwordTextbox.Text;
                jc.AutoPresence = true;

                jc.Connect();

                startButton.Enabled = false;
                stopButton.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "An error occurred while trying to set up an xmpp connection using the given credentials.\r\nError: " + ex.Message);
            }

        }

        void jc_OnMessage(object sender, jabber.protocol.client.Message msg)
        {
            try
            {
                    if (msg.From != "bot@callback.rogerth.at")
                {
                    logsListBox.BeginInvoke(new logDelegate(log), new object[] { "FROM ERROR: Ignored message from " + msg.From });
                    return;
                }
                XmlNodeList calls = msg.GetElementsByTagName("call", "mobicage:comm");
                foreach (XmlElement call in calls)
                {
                    String sik = call.GetAttribute("sik");
                    if (string.Empty == sik)
                    {
                        logsListBox.BeginInvoke(new logDelegate(log), new object[] { "SIK ERROR: Skipping call without sik!" });
                        continue;
                    }
                    String callBodyBase64 = call.InnerText;
                    String callBody = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(callBodyBase64));

                    var webRequest = WebRequest.Create(callbackUriTextbox.Text) as HttpWebRequest;
                    webRequest.ContentType = "application/json-rpc";
                    webRequest.Headers.Add("X-Nuntiuz-Service-Key", sik);
                    webRequest.Method = "POST";
                    StreamWriter sw = new StreamWriter(webRequest.GetRequestStream());
                    sw.Write(callBody);
                    sw.Close();
                    HttpWebResponse response = null;
                    try
                    {
                        response = webRequest.GetResponse() as HttpWebResponse;
                    }
                    catch (WebException we)
                    {
                        logsListBox.BeginInvoke(new logDelegate(log), new object[] { "ERROR: " + we.ToString() });
                        continue;
                    }

                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        String resultBody = reader.ReadToEnd();
                        XmlDocument doc = new XmlDocument();
                        jabber.protocol.client.Message reply = new jabber.protocol.client.Message(doc);
                        reply.From = msg.To;
                        reply.To = msg.From;
                        XmlElement element = doc.CreateElement("result", "mobicage:comm");
                        element.SetAttribute("sik", sik);
                        element.InnerText = Convert.ToBase64String(UnicodeEncoding.UTF8.GetBytes(resultBody));
                        reply.AddChild(element);
                        jc.Write(reply);
                    }

                }
            }
            catch (Exception e)
            {
                logsListBox.BeginInvoke(new logDelegate(log), new object[] { "ERROR: " + e.ToString() });
            }
        }

        bool jc_OnInvalidCertificate(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        void jc_OnStreamError(object sender, System.Xml.XmlElement rp)
        {
            logsListBox.BeginInvoke(new logDelegate(log), new object[] { "Stream ERROR: " + rp.OuterXml });
        }

        void jc_OnError(object sender, Exception ex)
        {
            logsListBox.BeginInvoke(new logDelegate(log), new object[] { "ERROR: " + ex.ToString() });
        }

        void jc_OnWriteText(object sender, string txt)
        {
            logsListBox.BeginInvoke(new logDelegate(log), new object[] { "SENT: " + txt });
        }

        void jc_OnReadText(object sender, string txt)
        {
            logsListBox.BeginInvoke(new logDelegate(log), new object[] { "RECV: " + txt });
        }
            
        delegate void logDelegate(String text); 
        void log(String text)
        {
            if (text != null)
            {
                logsListBox.Items.Add(text);
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            try
            {
                jc.Write("</stream:stream>");
            }
            catch { }
            jc = null;
            startButton.Enabled = true;
            stopButton.Enabled = false;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {   
        }
    }
}
