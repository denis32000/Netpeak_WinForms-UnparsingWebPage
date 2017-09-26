using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace webpageParserShvetsovDenis
{
    public partial class MainForm : Form
    {
        public delegate void ResponseModelDelegate(ResponseModel rm);
        public ResponseModelDelegate saveDataDelegate;
        public ResponseModelDelegate showOutputDelegate;

        public MainForm()
        {
            InitializeComponent();
            saveDataDelegate = new ResponseModelDelegate(SaveResponseModel);
            showOutputDelegate = new ResponseModelDelegate(ShowResponseModel);
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var dbInstance = DbConnectionManager.Instance;
                dbInstance.ResponseModels.Load();

                if (dbInstance.ResponseModels.Any())
                    comboBox1.Items.AddRange(dbInstance.ResponseModels.Select(rm => rm.Link).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data base error has occured!\n{ex.Message}\n{ex.InnerException?.Message}");
            }
        }
        
        private void buttonLinkRequest_Click(object sender, EventArgs e)
        {
            string webAdress = textBoxWebAdress.Text; 

            //TODO: regex for URL format
            if (String.IsNullOrEmpty(webAdress))
            {
                MessageBox.Show("Link field can't be empty.");
                return;
            }

            try
            {
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

                ResponseModel responseModel = new ResponseModel
                {
                    Link = webAdress,
                    ResponseCode = (int)serverResponse.StatusCode,
                    ResponseTime = timeTaken.ToString()
                };

                // Treading
                Thread t = Thread.CurrentThread;
                var anotherThread = (new Thread(delegate () {
                    ParsePageNodes(data, responseModel);
                    Invoke(showOutputDelegate, responseModel);
                    Invoke(saveDataDelegate, responseModel);
                }));
                anotherThread.Start();

                richTextBox1.Text = "Request was sent! Wait for results..";
                //ParsePageNodes(data, responseModel);
                //ShowResponseModel(responseModel);
                //SaveResponseModel(responseModel);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error has occured!\n{exception.Message}\n{exception.InnerException?.Message}");
            }
        }

        private static void ParsePageNodes(string data, ResponseModel responseModel)
        {
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

            responseModel.Title = pageTitle;
            responseModel.Description = pageDescription;
            responseModel.AhrefLinks = links.ToList();
            responseModel.HeadersH1 = h1Headers.ToList();
            responseModel.Images = images.ToList();
        }

        private void buttonDatabaseRequest_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Choose item from the list first!");
                return;
            }

            ResponseModel responseModel =
                DbConnectionManager.Instance.ResponseModels.FirstOrDefault(rm => rm.Link.Equals(comboBox1.Text));

            if (responseModel == null)
            {
                MessageBox.Show("Such address wasn't found in DB!");
                return;
            }

            ShowResponseModel(responseModel);
        }

        public async void SaveResponseModel(ResponseModel responseModel)
        {
            var dbInstance = DbConnectionManager.Instance;
            bool itemExistsInDatabase = false;
            var existingItem = await dbInstance.ResponseModels.FirstOrDefaultAsync(rm => rm.Link.Equals(responseModel.Link));

            if (existingItem == null)
                existingItem = dbInstance.ResponseModels.Create();
            else
                itemExistsInDatabase = true;

            existingItem.Link = responseModel.Link;
            existingItem.Title = responseModel.Title;
            existingItem.Description = responseModel.Description;
            existingItem.ResponseCode = responseModel.ResponseCode;
            existingItem.ResponseTime = responseModel.ResponseTime;

            if(!itemExistsInDatabase)
                dbInstance.ResponseModels.Add(existingItem);

            int result = await dbInstance.SaveChangesAsync();

            if (result == 0)
                MessageBox.Show("Unable to save data to Database.");

            if (dbInstance.ResponseModels.Any())
            {
                comboBox1.Items.Clear();
                comboBox1.Items.AddRange(dbInstance.ResponseModels.Select(rm => rm.Link).ToArray());
            }
        }

        public void ShowResponseModel(ResponseModel responseModel)
        {
            int listElementsCounter = 0;
            StringBuilder sb = new StringBuilder();

            if (String.IsNullOrEmpty(responseModel.Title))
                responseModel.Title = @"ERROR (Empty Title)";
            
            if (String.IsNullOrEmpty(responseModel.Description))
                responseModel.Description = "ERROR (Empty Description)";
            
            sb.Append($"Web resource adress {responseModel.Link}");
            sb.Append($"\nTitle: {responseModel.Title}");
            sb.Append($"\nDescription: {responseModel.Description}");
            sb.Append($"\nResponse Code: {responseModel.ResponseCode}");
            sb.Append($"\nResponse Time: {responseModel.ResponseTime}");

            listElementsCounter = 0;
            sb.Append("\nH1 Headers");
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
        }

        private void textBoxWebAdress_TextChanged(object sender, EventArgs e)
        {
            // TODO: validation
        }

        private void buttonStopRequestThread_Click(object sender, EventArgs e)
        {

        }
    }
}
