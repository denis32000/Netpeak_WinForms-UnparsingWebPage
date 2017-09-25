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
using System.Text.RegularExpressions;
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
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            // Do i need async or make thread from the beggining
        }
        
        private void buttonLinkRequest_Click(object sender, EventArgs e)
        {
            // http://kapon.com.ua/beginning.php
            string webAdress = textBoxWebAdress.Text; //"https://netpeaksoftware.com";
            //string pattern = @"*://*.*/";
            //Regex rgx = new Regex(pattern);
            if (String.IsNullOrEmpty(webAdress))
            {
                //TODO: error message
                return;
            }


            var req = WebRequest.Create(webAdress) as HttpWebRequest;
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

            var streamReader = new StreamReader(responseStream);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            serverResponse.Close();

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
                Link = webAdress,
                Title = pageTitle,
                Description = pageDescription,
                ResponseCode = (int)serverResponse.StatusCode,
                ResponseTime = timeTaken,
                AhrefLinks = links.ToList(),
                HeadersH1 = h1Headers.ToList(),
                Images = images.ToList()
            };

            ShowResponseModel(responseModel);
        }

        public void ShowResponseModel(ResponseModel responseModel)
        {
            int listElementsCounter = 0;
            StringBuilder sb = new StringBuilder();
            //Dictionary<string, string> rowsElements = new Dictionary<string, string>();
            sb.Append($"Web resource adress {responseModel.Link}");
            sb.Append($"\nTitle: {responseModel.Link}");
            sb.Append($"\nDescription: {responseModel.Link}");
            sb.Append($"\nResponse Code: {responseModel.Link}");
            sb.Append($"\nResponse Time: {responseModel.Link}");

            listElementsCounter = 0;
            sb.Append("Headers");
            foreach (var header in responseModel.HeadersH1)
            {
                listElementsCounter++;
                sb.Append($"\n\t{listElementsCounter}. {header}");
            }
            
            sb.Append("\nLinks:");
            listElementsCounter = 0;
            foreach (var link in responseModel.AhrefLinks)
            {
                listElementsCounter++;
                sb.Append($"\n\t{listElementsCounter}. {link}");
            }
            
            sb.Append("\nImages:");
            listElementsCounter = 0;
            foreach (var images in responseModel.Images)
            {
                listElementsCounter++;
                sb.Append($"\n\t{listElementsCounter}. {images}");
            }

            richTextBox1.Text = sb.ToString();
            //dataGridView1.Rows.Add(rowsElements); ///Columns.Add("Item")
            //listView1.Items.Add("test");
            //listView1.Items.Add("testfdfff");
            //label1.Text = sb.ToString();
            //dataGridView1. = sb.ToString();
        }

        private void textBoxWebAdress_TextChanged(object sender, EventArgs e)
        {
            // TODO: validation
        }
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
