namespace RogerthatServiceDevConnector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.configurationTabPage = new System.Windows.Forms.TabPage();
            this.developmentConfigurationGroupBox = new System.Windows.Forms.GroupBox();
            this.callbackUriTextbox = new System.Windows.Forms.TextBox();
            this.uriLabel = new System.Windows.Forms.Label();
            this.xmppGroupBox = new System.Windows.Forms.GroupBox();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.accountTextbox = new System.Windows.Forms.TextBox();
            this.accountLabel = new System.Windows.Forms.Label();
            this.runningTabPage = new System.Windows.Forms.TabPage();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.logsListBox = new System.Windows.Forms.ListBox();
            this.tabControl.SuspendLayout();
            this.configurationTabPage.SuspendLayout();
            this.developmentConfigurationGroupBox.SuspendLayout();
            this.xmppGroupBox.SuspendLayout();
            this.runningTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.configurationTabPage);
            this.tabControl.Controls.Add(this.runningTabPage);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(774, 396);
            this.tabControl.TabIndex = 7;
            // 
            // configurationTabPage
            // 
            this.configurationTabPage.Controls.Add(this.developmentConfigurationGroupBox);
            this.configurationTabPage.Controls.Add(this.xmppGroupBox);
            this.configurationTabPage.Location = new System.Drawing.Point(4, 22);
            this.configurationTabPage.Name = "configurationTabPage";
            this.configurationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.configurationTabPage.Size = new System.Drawing.Size(766, 370);
            this.configurationTabPage.TabIndex = 0;
            this.configurationTabPage.Text = "Configuration";
            this.configurationTabPage.UseVisualStyleBackColor = true;
            // 
            // developmentConfigurationGroupBox
            // 
            this.developmentConfigurationGroupBox.Controls.Add(this.callbackUriTextbox);
            this.developmentConfigurationGroupBox.Controls.Add(this.uriLabel);
            this.developmentConfigurationGroupBox.Location = new System.Drawing.Point(6, 85);
            this.developmentConfigurationGroupBox.Name = "developmentConfigurationGroupBox";
            this.developmentConfigurationGroupBox.Size = new System.Drawing.Size(414, 70);
            this.developmentConfigurationGroupBox.TabIndex = 8;
            this.developmentConfigurationGroupBox.TabStop = false;
            this.developmentConfigurationGroupBox.Text = "Development setup configuration";
            // 
            // callbackUriTextbox
            // 
            this.callbackUriTextbox.Location = new System.Drawing.Point(9, 37);
            this.callbackUriTextbox.Name = "callbackUriTextbox";
            this.callbackUriTextbox.Size = new System.Drawing.Size(394, 20);
            this.callbackUriTextbox.TabIndex = 1;
            // 
            // uriLabel
            // 
            this.uriLabel.AutoSize = true;
            this.uriLabel.Location = new System.Drawing.Point(7, 20);
            this.uriLabel.Name = "uriLabel";
            this.uriLabel.Size = new System.Drawing.Size(406, 13);
            this.uriLabel.TabIndex = 0;
            this.uriLabel.Text = "Enter uri on which your development setup accepts the Rogerthat callback requests" +
                ":";
            // 
            // xmppGroupBox
            // 
            this.xmppGroupBox.Controls.Add(this.passwordTextbox);
            this.xmppGroupBox.Controls.Add(this.passwordLabel);
            this.xmppGroupBox.Controls.Add(this.accountTextbox);
            this.xmppGroupBox.Controls.Add(this.accountLabel);
            this.xmppGroupBox.Location = new System.Drawing.Point(6, 6);
            this.xmppGroupBox.Name = "xmppGroupBox";
            this.xmppGroupBox.Size = new System.Drawing.Size(414, 73);
            this.xmppGroupBox.TabIndex = 7;
            this.xmppGroupBox.TabStop = false;
            this.xmppGroupBox.Text = "Rogerthat service XMPP Callback configuration";
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(97, 42);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '•';
            this.passwordTextbox.Size = new System.Drawing.Size(306, 20);
            this.passwordTextbox.TabIndex = 8;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(6, 45);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(85, 13);
            this.passwordLabel.TabIndex = 7;
            this.passwordLabel.Text = "Xmpp password:";
            // 
            // accountTextbox
            // 
            this.accountTextbox.Location = new System.Drawing.Point(97, 16);
            this.accountTextbox.Name = "accountTextbox";
            this.accountTextbox.Size = new System.Drawing.Size(306, 20);
            this.accountTextbox.TabIndex = 6;
            // 
            // accountLabel
            // 
            this.accountLabel.AutoSize = true;
            this.accountLabel.Location = new System.Drawing.Point(12, 19);
            this.accountLabel.Name = "accountLabel";
            this.accountLabel.Size = new System.Drawing.Size(79, 13);
            this.accountLabel.TabIndex = 5;
            this.accountLabel.Text = "Xmpp account:";
            // 
            // runningTabPage
            // 
            this.runningTabPage.Controls.Add(this.logsListBox);
            this.runningTabPage.Controls.Add(this.stopButton);
            this.runningTabPage.Controls.Add(this.startButton);
            this.runningTabPage.Location = new System.Drawing.Point(4, 22);
            this.runningTabPage.Name = "runningTabPage";
            this.runningTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.runningTabPage.Size = new System.Drawing.Size(766, 370);
            this.runningTabPage.TabIndex = 1;
            this.runningTabPage.Text = "Running ...";
            this.runningTabPage.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(87, 6);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 1;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(6, 6);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // logsListBox
            // 
            this.logsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logsListBox.BackColor = System.Drawing.Color.Black;
            this.logsListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logsListBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logsListBox.ForeColor = System.Drawing.Color.GreenYellow;
            this.logsListBox.FormattingEnabled = true;
            this.logsListBox.HorizontalScrollbar = true;
            this.logsListBox.IntegralHeight = false;
            this.logsListBox.ItemHeight = 16;
            this.logsListBox.Location = new System.Drawing.Point(7, 36);
            this.logsListBox.Name = "logsListBox";
            this.logsListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.logsListBox.Size = new System.Drawing.Size(753, 329);
            this.logsListBox.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 419);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Rogerthat service dev connector";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.tabControl.ResumeLayout(false);
            this.configurationTabPage.ResumeLayout(false);
            this.developmentConfigurationGroupBox.ResumeLayout(false);
            this.developmentConfigurationGroupBox.PerformLayout();
            this.xmppGroupBox.ResumeLayout(false);
            this.xmppGroupBox.PerformLayout();
            this.runningTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage configurationTabPage;
        private System.Windows.Forms.GroupBox developmentConfigurationGroupBox;
        private System.Windows.Forms.TextBox callbackUriTextbox;
        private System.Windows.Forms.Label uriLabel;
        private System.Windows.Forms.GroupBox xmppGroupBox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox accountTextbox;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.TabPage runningTabPage;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.ListBox logsListBox;


    }
}

