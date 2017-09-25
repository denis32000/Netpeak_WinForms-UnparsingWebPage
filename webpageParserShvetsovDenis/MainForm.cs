using System;
using System.ComponentModel;
using System.Data;
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
            string webAddress = "https://netpeaksoftware.com/"; // http://kapon.com.ua/beginning.php
            
            var req = WebRequest.Create(webAddress) as HttpWebRequest;
            if (req == null)
            {
                MessageBox.Show("Unable to create web request from this link.");
                return;
            }

            var serverResponse = req.GetResponse() as HttpWebResponse;
            if(serverResponse?.StatusCode != HttpStatusCode.OK)
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

            //WebClient webClient = new WebClient();
            //string page = webClient.DownloadString(webAddress);
            var doc = new HtmlDocument();
            doc.LoadHtml(data);

            HtmlNode specificNode = doc.DocumentNode`("nodeId");
            HtmlNodeCollection nodesMatchingXPath = doc.DocumentNode.SelectNodes("x/path/nodes");

            textBox2.Text = data;
            //string result = data.Substring("id=\"metadata\" class=\"meta\">", "</div>", 0);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
