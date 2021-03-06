﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using webpageParserShvetsovDenis.Models;

namespace webpageParserShvetsovDenis
{
    /// <summary>
    /// Main form of application
    /// </summary>
    public partial class MainForm : Form
    {
        private List<Thread> _runningThreads; // threads stack

        // Used for backcalls from additional threads
        public delegate void ResponseModelDelegate(ResponseModel rm);
        public ResponseModelDelegate saveDataDelegate;
        public ResponseModelDelegate showOutputDelegate;
        
        public MainForm()
        {
            InitializeComponent();
            saveDataDelegate = new ResponseModelDelegate(SaveResponseModel);
            showOutputDelegate = new ResponseModelDelegate(ShowResponseModel);
        }
        
        /// <summary>
        /// Loads main form and opens connection with Data Base
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            _runningThreads = new List<Thread>();

            try
            {
                var dbInstance = DbConnectionManager.Instance;
                dbInstance.ResponseModels.Load();

                if (dbInstance.ResponseModels.Any())
                    comboBox1.Items.AddRange(dbInstance.ResponseModels.Select(rm => rm.Link).ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured while connecting to Data Base!\n{ex.Message}\n{ex.InnerException?.Message}", "Error",  
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Button click to Request data from web resource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLinkRequest_Click(object sender, EventArgs e)
        {
            string webAdress = textBoxWebAdress.Text; 

            //TODO: regex for URL format
            if (String.IsNullOrEmpty(webAdress))
            {
                MessageBox.Show("Link field can't be empty.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var req = WebRequest.Create(webAdress) as HttpWebRequest;

                if (req == null)
                {
                    MessageBox.Show("Unable to create web request from this link.", "Help", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var timer = new Stopwatch();
                timer.Start();
                var serverResponse = req.GetResponse() as HttpWebResponse;
                timer.Stop();
                TimeSpan timeTaken = timer.Elapsed;

                if (serverResponse?.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show($"Server responded with result {serverResponse?.StatusCode}!\n{serverResponse?.StatusDescription}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                var responseStream = serverResponse.GetResponseStream();
                if (responseStream == null)
                {
                    MessageBox.Show("Unable to receive data stream from this resource.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    // Uncomment this to see how the threading works!
                    //Thread.Sleep(5000);

                    Invoke(showOutputDelegate, responseModel);
                    Invoke(saveDataDelegate, responseModel);
                }));
                anotherThread.Start();
                _runningThreads.Add(anotherThread);

                richTextBox1.Text = "Request was sent! Wait for results..";
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error has occured!\n{exception.Message}\n{exception.InnerException?.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button click to Load data from DataBase
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDatabaseRequest_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Choose item from the list first!", "Help",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                ResponseModel responseModel =
                    DbConnectionManager.Instance.ResponseModels.FirstOrDefault(rm => rm.Link.Equals(comboBox1.Text));
                if (responseModel == null)
                {
                    MessageBox.Show("Such address wasn't found in DB!", "Help",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ShowResponseModel(responseModel);
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Error getting data from DB!\n{exception.Message}\n{exception.InnerException?.Message}", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Button click to finish last thread in the threads stack
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonStopRequestThread_Click(object sender, EventArgs e)
        {
            if (_runningThreads.Count == 0)
            {
                MessageBox.Show("There are no other threads currently running!", "Help", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (_runningThreads.Count == 1)
            {
                richTextBox1.Text = "Web request was cancelled.\nResource data will be showed here..";
            }

            var lastThread = _runningThreads.Last();
            var threadState = lastThread.ThreadState;
            lastThread.Abort();
            _runningThreads.Remove(lastThread);

            MessageBox.Show($"Last thread with status {Enum.GetName(typeof(System.Threading.ThreadState), threadState)} was aborted!", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
