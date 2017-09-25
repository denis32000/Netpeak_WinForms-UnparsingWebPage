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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonLinkRequest
            // 
            this.buttonLinkRequest.Location = new System.Drawing.Point(469, 75);
            this.buttonLinkRequest.Name = "buttonLinkRequest";
            this.buttonLinkRequest.Size = new System.Drawing.Size(109, 23);
            this.buttonLinkRequest.TabIndex = 0;
            this.buttonLinkRequest.Text = "Проверить адрес";
            this.buttonLinkRequest.UseVisualStyleBackColor = true;
            this.buttonLinkRequest.Click += new System.EventHandler(this.buttonLinkRequest_Click);
            // 
            // textBoxWebAdress
            // 
            this.textBoxWebAdress.Location = new System.Drawing.Point(22, 49);
            this.textBoxWebAdress.Name = "textBoxWebAdress";
            this.textBoxWebAdress.Size = new System.Drawing.Size(556, 20);
            this.textBoxWebAdress.TabIndex = 1;
            this.textBoxWebAdress.TextChanged += new System.EventHandler(this.textBoxWebAdress_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(22, 141);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(556, 317);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 487);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBoxWebAdress);
            this.Controls.Add(this.buttonLinkRequest);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLinkRequest;
        private System.Windows.Forms.TextBox textBoxWebAdress;
        private System.Windows.Forms.TextBox textBox2;
    }
}

