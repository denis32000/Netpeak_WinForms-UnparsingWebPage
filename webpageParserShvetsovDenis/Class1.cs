using System;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace webpageParserShvetsovDenis
{
    public partial class MainForm : Form
    {
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

            if (!itemExistsInDatabase)
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
    }
}
