namespace webpageParserShvetsovDenis
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLinkRequest = new System.Windows.Forms.Button();
            this.textBoxWebAdress = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelForMainLink = new System.Windows.Forms.Label();
            this.buttonStopRequest = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelDatabaseLine = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLinkRequest
            // 
            this.buttonLinkRequest.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonLinkRequest.Location = new System.Drawing.Point(401, 23);
            this.buttonLinkRequest.Name = "buttonLinkRequest";
            this.buttonLinkRequest.Size = new System.Drawing.Size(117, 23);
            this.buttonLinkRequest.TabIndex = 0;
            this.buttonLinkRequest.Text = "Send request";
            this.buttonLinkRequest.UseVisualStyleBackColor = false;
            this.buttonLinkRequest.Click += new System.EventHandler(this.buttonLinkRequest_Click);
            // 
            // textBoxWebAdress
            // 
            this.textBoxWebAdress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxWebAdress.Location = new System.Drawing.Point(3, 23);
            this.textBoxWebAdress.Name = "textBoxWebAdress";
            this.textBoxWebAdress.Size = new System.Drawing.Size(392, 20);
            this.textBoxWebAdress.TabIndex = 1;
            this.textBoxWebAdress.Text = "https://netpeaksoftware.com/";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 153);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(650, 418);
            this.richTextBox1.TabIndex = 6;
            this.richTextBox1.Text = "Resource data will be showed here..";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(656, 574);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.40888F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.60184F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.14242F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxWebAdress, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelForMainLink, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonLinkRequest, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonStopRequest, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(650, 54);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // labelForMainLink
            // 
            this.labelForMainLink.AutoSize = true;
            this.labelForMainLink.Location = new System.Drawing.Point(3, 0);
            this.labelForMainLink.Name = "labelForMainLink";
            this.labelForMainLink.Size = new System.Drawing.Size(170, 13);
            this.labelForMainLink.TabIndex = 2;
            this.labelForMainLink.Text = "Resource address to get data from";
            // 
            // buttonStopRequest
            // 
            this.buttonStopRequest.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonStopRequest.Location = new System.Drawing.Point(528, 23);
            this.buttonStopRequest.Name = "buttonStopRequest";
            this.buttonStopRequest.Size = new System.Drawing.Size(115, 23);
            this.buttonStopRequest.TabIndex = 3;
            this.buttonStopRequest.Text = "Cancel request";
            this.buttonStopRequest.UseVisualStyleBackColor = false;
            this.buttonStopRequest.Click += new System.EventHandler(this.buttonStopRequestThread_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.55989F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.44011F));
            this.tableLayoutPanel3.Controls.Add(this.labelDatabaseLine, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBox1, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.checkBox1, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.button1, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 63);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(650, 84);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // labelDatabaseLine
            // 
            this.labelDatabaseLine.AutoSize = true;
            this.labelDatabaseLine.Location = new System.Drawing.Point(3, 0);
            this.labelDatabaseLine.Name = "labelDatabaseLine";
            this.labelDatabaseLine.Size = new System.Drawing.Size(96, 13);
            this.labelDatabaseLine.TabIndex = 10;
            this.labelDatabaseLine.Text = "Load data from DB";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(3, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(394, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(403, 63);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(182, 17);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "Show full address of internal links";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Load data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonDatabaseRequest_Click);
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel1, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(682, 600);
            this.tableLayoutPanel5.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 600);
            this.Controls.Add(this.tableLayoutPanel5);
            this.MinimumSize = new System.Drawing.Size(500, 450);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonLinkRequest;
        private System.Windows.Forms.TextBox textBoxWebAdress;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelForMainLink;
        private System.Windows.Forms.Label labelDatabaseLine;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonStopRequest;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
    }
}

