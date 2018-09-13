namespace Hangman
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
            this.HangmanTitle = new System.Windows.Forms.Label();
            this.HangmanPicture = new System.Windows.Forms.PictureBox();
            this.WordUnknown = new System.Windows.Forms.Label();
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.Timelbl = new System.Windows.Forms.Label();
            this.letterGuesstxtbox = new System.Windows.Forms.TextBox();
            this.guessbtn = new System.Windows.Forms.Button();
            this.debugPanel = new System.Windows.Forms.Panel();
            this.wordLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HangmanPicture)).BeginInit();
            this.debugPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HangmanTitle
            // 
            this.HangmanTitle.AutoSize = true;
            this.HangmanTitle.Font = new System.Drawing.Font("MV Boli", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HangmanTitle.Location = new System.Drawing.Point(301, 31);
            this.HangmanTitle.Name = "HangmanTitle";
            this.HangmanTitle.Size = new System.Drawing.Size(187, 52);
            this.HangmanTitle.TabIndex = 0;
            this.HangmanTitle.Text = "Hangman";
            // 
            // HangmanPicture
            // 
            this.HangmanPicture.Image = global::Hangman.Properties.Resources.Hangman_Drawing__1_;
            this.HangmanPicture.Location = new System.Drawing.Point(247, 122);
            this.HangmanPicture.Name = "HangmanPicture";
            this.HangmanPicture.Size = new System.Drawing.Size(294, 302);
            this.HangmanPicture.TabIndex = 1;
            this.HangmanPicture.TabStop = false;
            // 
            // WordUnknown
            // 
            this.WordUnknown.AutoSize = true;
            this.WordUnknown.Font = new System.Drawing.Font("MV Boli", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordUnknown.Location = new System.Drawing.Point(217, 444);
            this.WordUnknown.Name = "WordUnknown";
            this.WordUnknown.Size = new System.Drawing.Size(354, 52);
            this.WordUnknown.TabIndex = 2;
            this.WordUnknown.Text = "_ _ _ _ _ _ _ _ _";
            this.WordUnknown.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 1000;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // Timelbl
            // 
            this.Timelbl.AutoSize = true;
            this.Timelbl.Font = new System.Drawing.Font("MV Boli", 10F);
            this.Timelbl.Location = new System.Drawing.Point(547, 122);
            this.Timelbl.Name = "Timelbl";
            this.Timelbl.Size = new System.Drawing.Size(57, 26);
            this.Timelbl.TabIndex = 3;
            this.Timelbl.Text = "Time";
            // 
            // letterGuesstxtbox
            // 
            this.letterGuesstxtbox.Font = new System.Drawing.Font("MV Boli", 20F);
            this.letterGuesstxtbox.Location = new System.Drawing.Point(344, 519);
            this.letterGuesstxtbox.MaxLength = 1;
            this.letterGuesstxtbox.Name = "letterGuesstxtbox";
            this.letterGuesstxtbox.Size = new System.Drawing.Size(100, 72);
            this.letterGuesstxtbox.TabIndex = 4;
            // 
            // guessbtn
            // 
            this.guessbtn.Font = new System.Drawing.Font("MV Boli", 20F);
            this.guessbtn.Location = new System.Drawing.Point(324, 614);
            this.guessbtn.Name = "guessbtn";
            this.guessbtn.Size = new System.Drawing.Size(140, 55);
            this.guessbtn.TabIndex = 5;
            this.guessbtn.Text = "Guess";
            this.guessbtn.UseVisualStyleBackColor = true;
            this.guessbtn.Click += new System.EventHandler(this.guessbtn_Click);
            // 
            // debugPanel
            // 
            this.debugPanel.Controls.Add(this.wordLbl);
            this.debugPanel.Location = new System.Drawing.Point(573, 257);
            this.debugPanel.Name = "debugPanel";
            this.debugPanel.Size = new System.Drawing.Size(137, 166);
            this.debugPanel.TabIndex = 6;
            // 
            // wordLbl
            // 
            this.wordLbl.AutoSize = true;
            this.wordLbl.Font = new System.Drawing.Font("MV Boli", 8F);
            this.wordLbl.Location = new System.Drawing.Point(34, 71);
            this.wordLbl.Name = "wordLbl";
            this.wordLbl.Size = new System.Drawing.Size(60, 21);
            this.wordLbl.TabIndex = 7;
            this.wordLbl.Text = "[word]";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 682);
            this.Controls.Add(this.debugPanel);
            this.Controls.Add(this.guessbtn);
            this.Controls.Add(this.letterGuesstxtbox);
            this.Controls.Add(this.Timelbl);
            this.Controls.Add(this.WordUnknown);
            this.Controls.Add(this.HangmanPicture);
            this.Controls.Add(this.HangmanTitle);
            this.Name = "Form1";
            this.Text = "Hangman by Ido Tanne";
            ((System.ComponentModel.ISupportInitialize)(this.HangmanPicture)).EndInit();
            this.debugPanel.ResumeLayout(false);
            this.debugPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HangmanTitle;
        private System.Windows.Forms.PictureBox HangmanPicture;
        private System.Windows.Forms.Label WordUnknown;
        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.Label Timelbl;
        private System.Windows.Forms.TextBox letterGuesstxtbox;
        private System.Windows.Forms.Button guessbtn;
        private System.Windows.Forms.Panel debugPanel;
        private System.Windows.Forms.Label wordLbl;
    }
}

