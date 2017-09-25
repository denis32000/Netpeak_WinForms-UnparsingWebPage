using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace webpageParserShvetsovDenis
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        
        private async void MainForm_Load(object sender, EventArgs e)
        {
            // Do i need async or make thread from the beggining
            
            //HtmlNode specificNode = doc.DocumentNode`("nodeId");
            //HtmlNodeCollection nodesMatchingXPath = doc.DocumentNode.SelectNodes("x/path/nodes");
            //doc.

            //textBox2.Text = data;
            //string result = data.Substring("id=\"metadata\" class=\"meta\">", "</div>", 0);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonLinkRequest_Click(object sender, EventArgs e)
        {
            //string webAdress = textBoxWebAdress.Text;
            //
            //if (String.IsNullOrEmpty(webAdress))
            //{
            //    //TODO: error message
            //    return;
            //}

            string webAddress = "https://netpeaksoftware.com/"; // http://kapon.com.ua/beginning.php

            var req = WebRequest.Create(webAddress) as HttpWebRequest;
            if (req == null)
            {
                MessageBox.Show("Unable to create web request from this link.");
                return;
            }

            var timer = new Stopwatch();
            timer.Start();
            var serverResponse = req.GetResponse() as HttpWebResponse;
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;

            if (serverResponse?.StatusCode != HttpStatusCode.OK)
            {
                MessageBox.Show($"Server responded with result {serverResponse?.StatusCode}!\n{serverResponse?.StatusDescription}");
                return;
            }

            var responseStream = serverResponse.GetResponseStream();
            if (responseStream == null)
            {
                MessageBox.Show("Unable to receive data stream from this resource.");
                return;
            }
            serverResponse.Close();

            var streamReader = new StreamReader(responseStream);
            string data = streamReader.ReadToEnd();
            streamReader.Close();

            var doc = new HtmlDocument();
            doc.LoadHtml(data);

            var pageTitle =
                doc.DocumentNode.SelectSingleNode("//title")?.InnerText;

            var pageDescription =
                doc.DocumentNode.SelectNodes("//meta")
                .FirstOrDefault(n => n.GetAttributeValue("name", "") == "description")?
                .GetAttributeValue("content", null);

            var h1Headers =
                doc.DocumentNode.SelectNodes("//h1").Select(n => n.InnerText);

            var images =
                doc.DocumentNode.SelectNodes("//img").Select(n => n.Attributes["src"].Value);

            var links =
                doc.DocumentNode.SelectNodes("//a")
                .Where(l => l.HasAttributes && l.Attributes["href"] != null)
                .Select(l => l.Attributes["href"].Value);

            // TODO: check if link starts with '/' -> add webAddress to the start of link

            var responseModel = new ResponseModel
            {
                Link = webAddress,
                Title = pageTitle,
                Description = pageDescription,
                ResponseCode = (int)serverResponse.StatusCode,
                ResponseTime = timeTaken,
                AhrefLinks = links.ToList(),
                HeadersH1 = h1Headers.ToList(),
                Images = images.ToList()
            };
        }

        private void textBoxWebAdress_TextChanged(object sender, EventArgs e)
        {
            // TODO: validation
        }
    }
}
