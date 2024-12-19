namespace SmartHome
{
    partial class HouseForm
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traceOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tempHumidityIsFahrenheitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSep = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDateTimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSep1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripCommLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSep2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripPortLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSep3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.humiditylabel = new System.Windows.Forms.Label();
            this.serialLumiPort = new System.IO.Ports.SerialPort(this.components);
            this.lumiComboBox = new System.Windows.Forms.ComboBox();
            this.lumiPortLabel = new System.Windows.Forms.Label();
            this.lumiStartButton = new System.Windows.Forms.Button();
            this.monitorTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.tempLabel = new System.Windows.Forms.Label();
            this.humLabel = new System.Windows.Forms.Label();
            this.lumiLightsButton = new System.Windows.Forms.Button();
            this.frontDoorButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lightPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // temperatureLabel
            // 
            this.temperatureLabel.AutoSize = true;
            this.temperatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.temperatureLabel.Location = new System.Drawing.Point(200, 52);
            this.temperatureLabel.Name = "temperatureLabel";
            this.temperatureLabel.Size = new System.Drawing.Size(78, 13);
            this.temperatureLabel.TabIndex = 1;
            this.temperatureLabel.Text = "Temperature";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.traceOffToolStripMenuItem,
            this.tempHumidityIsFahrenheitToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // traceOffToolStripMenuItem
            // 
            this.traceOffToolStripMenuItem.Name = "traceOffToolStripMenuItem";
            this.traceOffToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.traceOffToolStripMenuItem.Text = "Trace is OFF";
            this.traceOffToolStripMenuItem.Click += new System.EventHandler(this.traceOffToolStripMenuItem_Click);
            // 
            // tempHumidityIsFahrenheitToolStripMenuItem
            // 
            this.tempHumidityIsFahrenheitToolStripMenuItem.Name = "tempHumidityIsFahrenheitToolStripMenuItem";
            this.tempHumidityIsFahrenheitToolStripMenuItem.Size = new System.Drawing.Size(228, 22);
            this.tempHumidityIsFahrenheitToolStripMenuItem.Text = "Temp-Humidity is Fahrenheit";
            this.tempHumidityIsFahrenheitToolStripMenuItem.Click += new System.EventHandler(this.tempHumidityIsFahrenheitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelStatus,
            this.toolStripSep,
            this.toolStripDateTimeLabel,
            this.toolStripSep1,
            this.toolStripCommLabel,
            this.toolStripSep2,
            this.toolStripPortLabel,
            this.toolStripSep3});
            this.statusStrip1.Location = new System.Drawing.Point(0, 571);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(778, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelStatus
            // 
            this.toolStripStatusLabelStatus.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabelStatus.Name = "toolStripStatusLabelStatus";
            this.toolStripStatusLabelStatus.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabelStatus.Text = "STATUS";
            // 
            // toolStripSep
            // 
            this.toolStripSep.Name = "toolStripSep";
            this.toolStripSep.Size = new System.Drawing.Size(16, 17);
            this.toolStripSep.Text = " | ";
            // 
            // toolStripDateTimeLabel
            // 
            this.toolStripDateTimeLabel.Name = "toolStripDateTimeLabel";
            this.toolStripDateTimeLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripSep1
            // 
            this.toolStripSep1.Name = "toolStripSep1";
            this.toolStripSep1.Size = new System.Drawing.Size(16, 17);
            this.toolStripSep1.Text = " | ";
            // 
            // toolStripCommLabel
            // 
            this.toolStripCommLabel.Name = "toolStripCommLabel";
            this.toolStripCommLabel.Size = new System.Drawing.Size(69, 17);
            this.toolStripCommLabel.Text = "Comm Port";
            // 
            // toolStripSep2
            // 
            this.toolStripSep2.Name = "toolStripSep2";
            this.toolStripSep2.Size = new System.Drawing.Size(16, 17);
            this.toolStripSep2.Text = " | ";
            // 
            // toolStripPortLabel
            // 
            this.toolStripPortLabel.ForeColor = System.Drawing.Color.Red;
            this.toolStripPortLabel.Name = "toolStripPortLabel";
            this.toolStripPortLabel.Size = new System.Drawing.Size(88, 17);
            this.toolStripPortLabel.Text = "Not Connected";
            // 
            // toolStripSep3
            // 
            this.toolStripSep3.Name = "toolStripSep3";
            this.toolStripSep3.Size = new System.Drawing.Size(16, 17);
            this.toolStripSep3.Text = " | ";
            // 
            // humiditylabel
            // 
            this.humiditylabel.AutoSize = true;
            this.humiditylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humiditylabel.Location = new System.Drawing.Point(660, 52);
            this.humiditylabel.Name = "humiditylabel";
            this.humiditylabel.Size = new System.Drawing.Size(55, 13);
            this.humiditylabel.TabIndex = 4;
            this.humiditylabel.Text = "Humidity";
            // 
            // lumiComboBox
            // 
            this.lumiComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lumiComboBox.FormattingEnabled = true;
            this.lumiComboBox.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.lumiComboBox.Location = new System.Drawing.Point(37, 81);
            this.lumiComboBox.Name = "lumiComboBox";
            this.lumiComboBox.Size = new System.Drawing.Size(75, 21);
            this.lumiComboBox.TabIndex = 5;
            this.lumiComboBox.Text = "COMM";
            // 
            // lumiPortLabel
            // 
            this.lumiPortLabel.AutoSize = true;
            this.lumiPortLabel.BackColor = System.Drawing.Color.LightSalmon;
            this.lumiPortLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lumiPortLabel.Location = new System.Drawing.Point(37, 52);
            this.lumiPortLabel.Name = "lumiPortLabel";
            this.lumiPortLabel.Size = new System.Drawing.Size(74, 15);
            this.lumiPortLabel.TabIndex = 6;
            this.lumiPortLabel.Text = " LUMI PORT ";
            // 
            // lumiStartButton
            // 
            this.lumiStartButton.Location = new System.Drawing.Point(37, 274);
            this.lumiStartButton.Name = "lumiStartButton";
            this.lumiStartButton.Size = new System.Drawing.Size(75, 23);
            this.lumiStartButton.TabIndex = 7;
            this.lumiStartButton.Text = "START";
            this.lumiStartButton.UseVisualStyleBackColor = true;
            this.lumiStartButton.Click += new System.EventHandler(this.lumiStartButton_Click);
            // 
            // monitorTextBox
            // 
            this.monitorTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.monitorTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monitorTextBox.Location = new System.Drawing.Point(37, 315);
            this.monitorTextBox.Multiline = true;
            this.monitorTextBox.Name = "monitorTextBox";
            this.monitorTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.monitorTextBox.Size = new System.Drawing.Size(712, 241);
            this.monitorTextBox.TabIndex = 8;
            this.monitorTextBox.WordWrap = false;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // tempLabel
            // 
            this.tempLabel.AutoSize = true;
            this.tempLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tempLabel.ForeColor = System.Drawing.Color.Red;
            this.tempLabel.Location = new System.Drawing.Point(216, 105);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(0, 13);
            this.tempLabel.TabIndex = 0;
            this.tempLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // humLabel
            // 
            this.humLabel.AutoSize = true;
            this.humLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.humLabel.ForeColor = System.Drawing.Color.Red;
            this.humLabel.Location = new System.Drawing.Point(668, 105);
            this.humLabel.Name = "humLabel";
            this.humLabel.Size = new System.Drawing.Size(0, 13);
            this.humLabel.TabIndex = 9;
            this.humLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lumiLightsButton
            // 
            this.lumiLightsButton.Location = new System.Drawing.Point(397, 52);
            this.lumiLightsButton.Name = "lumiLightsButton";
            this.lumiLightsButton.Size = new System.Drawing.Size(96, 23);
            this.lumiLightsButton.TabIndex = 10;
            this.lumiLightsButton.Text = "STREET LIGHT";
            this.lumiLightsButton.UseVisualStyleBackColor = true;
            this.lumiLightsButton.Click += new System.EventHandler(this.lumiLightsButton_Click);
            // 
            // frontDoorButton
            // 
            this.frontDoorButton.Location = new System.Drawing.Point(191, 170);
            this.frontDoorButton.Name = "frontDoorButton";
            this.frontDoorButton.Size = new System.Drawing.Size(96, 23);
            this.frontDoorButton.TabIndex = 13;
            this.frontDoorButton.Text = "FRONT DOOR";
            this.frontDoorButton.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SmartHome.Properties.Resources.FRONT_DOOR_CLOSED;
            this.pictureBox1.Location = new System.Drawing.Point(219, 199);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 58);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lightPictureBox
            // 
            this.lightPictureBox.Image = global::SmartHome.Properties.Resources.LIGHTBULB_OFF1;
            this.lightPictureBox.Location = new System.Drawing.Point(413, 81);
            this.lightPictureBox.Name = "lightPictureBox";
            this.lightPictureBox.Size = new System.Drawing.Size(68, 79);
            this.lightPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.lightPictureBox.TabIndex = 11;
            this.lightPictureBox.TabStop = false;
            // 
            // HouseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(778, 593);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.frontDoorButton);
            this.Controls.Add(this.lightPictureBox);
            this.Controls.Add(this.lumiLightsButton);
            this.Controls.Add(this.humLabel);
            this.Controls.Add(this.monitorTextBox);
            this.Controls.Add(this.lumiStartButton);
            this.Controls.Add(this.lumiPortLabel);
            this.Controls.Add(this.lumiComboBox);
            this.Controls.Add(this.humiditylabel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.temperatureLabel);
            this.Controls.Add(this.tempLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "HouseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Smart Home";
            this.Load += new System.EventHandler(this.HouseForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        protected internal System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSep;
        protected internal System.Windows.Forms.Label humiditylabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripDateTimeLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSep1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripCommLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSep2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripPortLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripSep3;
        private System.IO.Ports.SerialPort serialLumiPort;
        private System.Windows.Forms.ComboBox lumiComboBox;
        private System.Windows.Forms.Label lumiPortLabel;
        private System.Windows.Forms.Button lumiStartButton;
        private System.Windows.Forms.TextBox monitorTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traceOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tempHumidityIsFahrenheitToolStripMenuItem;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Label humLabel;
        private System.Windows.Forms.Button lumiLightsButton;
        private System.Windows.Forms.PictureBox lightPictureBox;
        private System.Windows.Forms.Button frontDoorButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

