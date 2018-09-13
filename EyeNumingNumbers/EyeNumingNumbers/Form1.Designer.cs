namespace EyeNumingNumbers
{
    partial class Form1
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
            this.numList = new System.Windows.Forms.ListBox();
            this.valueFinderTxtBox = new System.Windows.Forms.TextBox();
            this.tileAmountLbl = new System.Windows.Forms.Label();
            this.mousePosTxt = new System.Windows.Forms.Label();
            this.buttonClickedTxt = new System.Windows.Forms.Label();
            this.mainGamePanel = new System.Windows.Forms.Panel();
            this.endGamePanel = new System.Windows.Forms.Panel();
            this.quitButton = new System.Windows.Forms.Button();
            this.tryAgainBtn = new System.Windows.Forms.Button();
            this.ScoreLbl = new System.Windows.Forms.Label();
            this.timerTxtBox = new System.Windows.Forms.TextBox();
            this.debugPanel = new System.Windows.Forms.Panel();
            this.numberLeftText = new System.Windows.Forms.Label();
            this.CurrentNumberTxt = new System.Windows.Forms.Label();
            this.titleScreenPnl = new System.Windows.Forms.Panel();
            this.debugModeBtn = new System.Windows.Forms.Button();
            this.quitBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.titleLbl = new System.Windows.Forms.Label();
            this.gameTime = new System.Windows.Forms.Timer(this.components);
            this.mainGamePanel.SuspendLayout();
            this.endGamePanel.SuspendLayout();
            this.debugPanel.SuspendLayout();
            this.titleScreenPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // numList
            // 
            this.numList.FormattingEnabled = true;
            this.numList.ItemHeight = 25;
            this.numList.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.numList.Location = new System.Drawing.Point(8, 35);
            this.numList.Margin = new System.Windows.Forms.Padding(4);
            this.numList.Name = "numList";
            this.numList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.numList.Size = new System.Drawing.Size(149, 504);
            this.numList.TabIndex = 0;
            this.numList.UseTabStops = false;
            // 
            // valueFinderTxtBox
            // 
            this.valueFinderTxtBox.Location = new System.Drawing.Point(138, 19);
            this.valueFinderTxtBox.Margin = new System.Windows.Forms.Padding(4);
            this.valueFinderTxtBox.Name = "valueFinderTxtBox";
            this.valueFinderTxtBox.Size = new System.Drawing.Size(42, 31);
            this.valueFinderTxtBox.TabIndex = 1;
            this.valueFinderTxtBox.TextChanged += new System.EventHandler(this.valueFinderTxtBox_TextChanged);
            // 
            // tileAmountLbl
            // 
            this.tileAmountLbl.AutoSize = true;
            this.tileAmountLbl.Location = new System.Drawing.Point(4, 22);
            this.tileAmountLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tileAmountLbl.Name = "tileAmountLbl";
            this.tileAmountLbl.Size = new System.Drawing.Size(126, 25);
            this.tileAmountLbl.TabIndex = 2;
            this.tileAmountLbl.Text = "Tile Amount";
            this.tileAmountLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mousePosTxt
            // 
            this.mousePosTxt.AutoSize = true;
            this.mousePosTxt.Location = new System.Drawing.Point(4, 250);
            this.mousePosTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mousePosTxt.Name = "mousePosTxt";
            this.mousePosTxt.Size = new System.Drawing.Size(120, 25);
            this.mousePosTxt.TabIndex = 3;
            this.mousePosTxt.Text = "Mouse Pos";
            this.mousePosTxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonClickedTxt
            // 
            this.buttonClickedTxt.AutoSize = true;
            this.buttonClickedTxt.Location = new System.Drawing.Point(4, 189);
            this.buttonClickedTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.buttonClickedTxt.Name = "buttonClickedTxt";
            this.buttonClickedTxt.Size = new System.Drawing.Size(92, 25);
            this.buttonClickedTxt.TabIndex = 4;
            this.buttonClickedTxt.Text = "Button #";
            this.buttonClickedTxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // mainGamePanel
            // 
            this.mainGamePanel.Controls.Add(this.endGamePanel);
            this.mainGamePanel.Controls.Add(this.ScoreLbl);
            this.mainGamePanel.Controls.Add(this.timerTxtBox);
            this.mainGamePanel.Controls.Add(this.debugPanel);
            this.mainGamePanel.Controls.Add(this.numList);
            this.mainGamePanel.Location = new System.Drawing.Point(14, 12);
            this.mainGamePanel.Name = "mainGamePanel";
            this.mainGamePanel.Size = new System.Drawing.Size(1670, 900);
            this.mainGamePanel.TabIndex = 5;
            // 
            // endGamePanel
            // 
            this.endGamePanel.Controls.Add(this.quitButton);
            this.endGamePanel.Controls.Add(this.tryAgainBtn);
            this.endGamePanel.Location = new System.Drawing.Point(533, 828);
            this.endGamePanel.Name = "endGamePanel";
            this.endGamePanel.Size = new System.Drawing.Size(605, 69);
            this.endGamePanel.TabIndex = 10;
            this.endGamePanel.Visible = false;
            // 
            // quitButton
            // 
            this.quitButton.BackColor = System.Drawing.Color.Transparent;
            this.quitButton.Font = new System.Drawing.Font("Moire ExtraBold", 10F);
            this.quitButton.Location = new System.Drawing.Point(406, 14);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(185, 47);
            this.quitButton.TabIndex = 9;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // tryAgainBtn
            // 
            this.tryAgainBtn.BackColor = System.Drawing.Color.Transparent;
            this.tryAgainBtn.Font = new System.Drawing.Font("Moire ExtraBold", 8F);
            this.tryAgainBtn.Location = new System.Drawing.Point(22, 14);
            this.tryAgainBtn.Name = "tryAgainBtn";
            this.tryAgainBtn.Size = new System.Drawing.Size(185, 47);
            this.tryAgainBtn.TabIndex = 8;
            this.tryAgainBtn.Text = "Try Again?";
            this.tryAgainBtn.UseVisualStyleBackColor = false;
            this.tryAgainBtn.Click += new System.EventHandler(this.tryAgainBtn_Click);
            // 
            // ScoreLbl
            // 
            this.ScoreLbl.AutoSize = true;
            this.ScoreLbl.Font = new System.Drawing.Font("Moire ExtraBold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScoreLbl.Location = new System.Drawing.Point(1403, 10);
            this.ScoreLbl.Name = "ScoreLbl";
            this.ScoreLbl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ScoreLbl.Size = new System.Drawing.Size(213, 33);
            this.ScoreLbl.TabIndex = 7;
            this.ScoreLbl.Text = "Score: 0/210";
            this.ScoreLbl.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timerTxtBox
            // 
            this.timerTxtBox.Font = new System.Drawing.Font("Moire ExtraBold", 10F);
            this.timerTxtBox.Location = new System.Drawing.Point(731, 7);
            this.timerTxtBox.Name = "timerTxtBox";
            this.timerTxtBox.ReadOnly = true;
            this.timerTxtBox.Size = new System.Drawing.Size(208, 40);
            this.timerTxtBox.TabIndex = 6;
            this.timerTxtBox.Text = "5:00";
            this.timerTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // debugPanel
            // 
            this.debugPanel.Controls.Add(this.numberLeftText);
            this.debugPanel.Controls.Add(this.CurrentNumberTxt);
            this.debugPanel.Controls.Add(this.buttonClickedTxt);
            this.debugPanel.Controls.Add(this.mousePosTxt);
            this.debugPanel.Controls.Add(this.tileAmountLbl);
            this.debugPanel.Controls.Add(this.valueFinderTxtBox);
            this.debugPanel.Location = new System.Drawing.Point(8, 583);
            this.debugPanel.Name = "debugPanel";
            this.debugPanel.Size = new System.Drawing.Size(195, 290);
            this.debugPanel.TabIndex = 5;
            // 
            // numberLeftText
            // 
            this.numberLeftText.AutoSize = true;
            this.numberLeftText.Location = new System.Drawing.Point(4, 76);
            this.numberLeftText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.numberLeftText.Name = "numberLeftText";
            this.numberLeftText.Size = new System.Drawing.Size(119, 25);
            this.numberLeftText.TabIndex = 6;
            this.numberLeftText.Text = "number left";
            this.numberLeftText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CurrentNumberTxt
            // 
            this.CurrentNumberTxt.AutoSize = true;
            this.CurrentNumberTxt.Location = new System.Drawing.Point(4, 133);
            this.CurrentNumberTxt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.CurrentNumberTxt.Name = "CurrentNumberTxt";
            this.CurrentNumberTxt.Size = new System.Drawing.Size(164, 25);
            this.CurrentNumberTxt.TabIndex = 5;
            this.CurrentNumberTxt.Text = "Current Number";
            this.CurrentNumberTxt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // titleScreenPnl
            // 
            this.titleScreenPnl.Controls.Add(this.debugModeBtn);
            this.titleScreenPnl.Controls.Add(this.quitBtn);
            this.titleScreenPnl.Controls.Add(this.playBtn);
            this.titleScreenPnl.Controls.Add(this.titleLbl);
            this.titleScreenPnl.Location = new System.Drawing.Point(354, 45);
            this.titleScreenPnl.Name = "titleScreenPnl";
            this.titleScreenPnl.Size = new System.Drawing.Size(990, 840);
            this.titleScreenPnl.TabIndex = 6;
            // 
            // debugModeBtn
            // 
            this.debugModeBtn.Font = new System.Drawing.Font("Moire ExtraBold", 20F);
            this.debugModeBtn.Location = new System.Drawing.Point(211, 613);
            this.debugModeBtn.Name = "debugModeBtn";
            this.debugModeBtn.Size = new System.Drawing.Size(569, 194);
            this.debugModeBtn.TabIndex = 3;
            this.debugModeBtn.Text = "Debug";
            this.debugModeBtn.UseVisualStyleBackColor = true;
            this.debugModeBtn.Visible = false;
            this.debugModeBtn.Click += new System.EventHandler(this.debugModeBtn_Click);
            // 
            // quitBtn
            // 
            this.quitBtn.Font = new System.Drawing.Font("Moire ExtraBold", 20F);
            this.quitBtn.Location = new System.Drawing.Point(211, 392);
            this.quitBtn.Name = "quitBtn";
            this.quitBtn.Size = new System.Drawing.Size(569, 194);
            this.quitBtn.TabIndex = 2;
            this.quitBtn.Text = "Quit";
            this.quitBtn.UseVisualStyleBackColor = true;
            this.quitBtn.Click += new System.EventHandler(this.quitBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Font = new System.Drawing.Font("Moire ExtraBold", 20F);
            this.playBtn.Location = new System.Drawing.Point(211, 171);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(569, 194);
            this.playBtn.TabIndex = 1;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // titleLbl
            // 
            this.titleLbl.AutoSize = true;
            this.titleLbl.Font = new System.Drawing.Font("Moire ExtraBold", 20F);
            this.titleLbl.Location = new System.Drawing.Point(151, 54);
            this.titleLbl.Name = "titleLbl";
            this.titleLbl.Size = new System.Drawing.Size(726, 66);
            this.titleLbl.TabIndex = 0;
            this.titleLbl.Text = "Eye Numbing Numbers";
            // 
            // gameTime
            // 
            this.gameTime.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1698, 928);
            this.Controls.Add(this.mainGamePanel);
            this.Controls.Add(this.titleScreenPnl);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Eye Numbing Numbers";
            this.mainGamePanel.ResumeLayout(false);
            this.mainGamePanel.PerformLayout();
            this.endGamePanel.ResumeLayout(false);
            this.debugPanel.ResumeLayout(false);
            this.debugPanel.PerformLayout();
            this.titleScreenPnl.ResumeLayout(false);
            this.titleScreenPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox numList;
        private System.Windows.Forms.TextBox valueFinderTxtBox;
        private System.Windows.Forms.Label tileAmountLbl;
        private System.Windows.Forms.Label mousePosTxt;
        private System.Windows.Forms.Label buttonClickedTxt;
        private System.Windows.Forms.Panel mainGamePanel;
        private System.Windows.Forms.Panel titleScreenPnl;
        private System.Windows.Forms.Button quitBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Label titleLbl;
        private System.Windows.Forms.Button debugModeBtn;
        private System.Windows.Forms.Panel debugPanel;
        private System.Windows.Forms.Label CurrentNumberTxt;
        private System.Windows.Forms.Label numberLeftText;
        private System.Windows.Forms.TextBox timerTxtBox;
        private System.Windows.Forms.Timer gameTime;
        private System.Windows.Forms.Label ScoreLbl;
        private System.Windows.Forms.Button tryAgainBtn;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Panel endGamePanel;
    }
}

