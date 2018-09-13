using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeNumingNumbers
{
    public partial class Form1 : Form
    {
        //Button Maker
        List<Button> numberButtons = new List<Button>();
        int number = 20, tileHighlighted, tempVal, currentNumber = 1;
        int[] numberArray = new int[21];
        List<int> numberAmount = new List<int>();
        int[] numberAmountLeft = new int[21];
        int buttonsAmount;
        Point boardLocation = new Point(70,40);
        Point boardLocationNew;
        Random rnd = new Random();
        bool loadingComplete = false, gameOver = false;
        bool debugMode = false;
        Point mousePoint;

        //Timer Function
        int timeLeft, timeEscalated, timeAmount, m, s;


        public Form1()
        {
            InitializeComponent();

            boardLocationNew = boardLocation;
            
            TitleScreen();
            //MainGame();

            
        }

        private void tryAgainBtn_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void TitleScreen()
        {

            titleScreenPnl.Visible = true;
            mainGamePanel.Visible = false;
            //titleScreenPnl.Location = new Point(0, 0);
            if(debugMode == true)
            {
                debugModeBtn.Visible = true;
            }
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            MainGame();
            titleScreenPnl.Visible = false;
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void debugModeBtn_Click(object sender, EventArgs e)
        {
            switch (debugMode)
            {
                case true:
                    debugModeBtn.BackColor = Color.Red;
                    debugModeBtn.Text = "Debug Off";
                    debugMode = false;
                    break;
                case false:
                    debugModeBtn.BackColor = Color.Green;
                    debugModeBtn.Text = "Debug On";
                    debugMode = true;
                    break;
            }
            
        }

        void MainGame()
        {
            
            mainGamePanel.Visible = true;
            if (!loadingComplete)
            {
                
                for (int i = 1; i < 20; i++)
                {
                    for (int j = 1; j <= number; j++)
                    {
                        numberAmount.Add(number);
                        numberAmountLeft[number]++;
                        numberArray[number]++;
                        if (j == number)
                        {
                            j = 0;
                            number--;
                        }
                    }

                }

                for (int i = 0; i < 210; i++)
                {
                    if(debugMode)
                    {
                        mainGamePanel.Location = new Point(12, 12);
                        numList.Visible = true;
                        debugPanel.Visible = true;
                    }

                    if(!debugMode)
                    {
                        numList.Visible = false;
                        debugPanel.Visible = false;
                        Point boardLocation = new Point(25, 25);
                    }

                    numberButtons.Add(new Button());
                    numberButtons[i].Name = "numButton" + i;

                    //Random number, increase the amount in number list, if the number being added exeeds the list's limit, generate new random number
                    tempVal = rnd.Next(0, numberAmount.Count());


                    if (boardLocationNew.X > 735)
                    {
                        boardLocationNew.Y += 35;
                        boardLocationNew.X = boardLocation.X;
                    }

                    boardLocationNew.X += 35;
                    numberButtons[i].Location = boardLocationNew;
                    numberButtons[i].Size = new Size(35, 35);
                    numberButtons[i].Font = new Font("Moire ExtraBold", 8);
                    numberButtons[i].BackColor = Color.Transparent;
                    numberButtons[i].Text = (numberAmount[tempVal]).ToString();
                    numberAmount.RemoveAt(tempVal);

                    if (i > 1 && i < 21)
                    {
                        numList.Items.Add((i + " | " + numberArray[i]).ToString());
                    }
                    
                    mainGamePanel.Controls.Add(numberButtons[i]);
                    numberButtons[i].MouseClick += numberButtonClicked;

                }
                timeLeft = 5 * 60;
                gameTime.Tick += gameTimeTick;
                gameTime.Start();
                
                gameOver = false;
                loadingComplete = true;
            }
            
        }

        private void gameTimeTick(object sender, EventArgs e)
        {
            if(timeLeft > 0)
            {
                timeLeft--;
                //timerTxtBox.Text = ((timeLeft % 60) >= 10 ? (timeLeft % 60).ToString("0") + (timeLeft % 60));
                timerTxtBox.Text = (timeLeft / 60).ToString("0") + ":"  + (timeLeft % 60).ToString("00");
                
                //timerTxtBox.Text = timeLeft.ToString("0:00");
            }

            if(timeLeft == 0 || gameOver == true)
            {
                gameTime.Stop();
                for (int i = 0; i < numberButtons.Count(); i++)
                {
                    numberButtons[i].BackColor = Color.Red;
                    numberButtons[i].Enabled = false;
                }
                timerTxtBox.Text = "Game Over";
                gameOver = true;
                endGamePanel.Visible = true;
            }

            if(numberAmountLeft[20]==0)
            {
                gameTime.Stop();
                timerTxtBox.Text = "You Won!!";
                endGamePanel.Visible = true;
                tryAgainBtn.Text = "Play Again?";
            }

            
        }

        private void numberButtonClicked(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            //button.BackColor = Color.Green;
            //
            buttonClickedTxt.Text = button.Name;

            #region LegalMoveChecker
            
            if(int.Parse(button.Text) == numberArray[currentNumber])
            {
                button.BackColor = Color.Lime;
                button.Enabled = false;
                buttonsAmount++;
                numberAmountLeft[currentNumber]--;
                if(numberAmountLeft[currentNumber] ==0 && currentNumber!=20)
                {
                    currentNumber++;
                }
                ScoreLbl.Text = "Score: " + buttonsAmount.ToString() + "/210";
                CurrentNumberTxt.Text = currentNumber.ToString();
                numberLeftText.Text = numberAmountLeft[currentNumber].ToString();
                
            }

            else
            {
                gameOver = true;
                for(int i = 0; i < numberButtons.Count(); i++)
                {
                    numberButtons[i].BackColor = Color.LightCoral;
                    numberButtons[i].Enabled = false;
                }
            }

            #endregion



            mousePosTxt.Text = "X: " + MousePosition.X + " Y: " + MousePosition.Y;
        }

        
        

        private void valueFinderTxtBox_TextChanged(object sender, EventArgs e)
        {
            tileHighlighted = 0;
            
            for (int i = 0; i < 210; i++)
            {
                if (numberButtons[i].Text == valueFinderTxtBox.Text && numberButtons[i].Enabled == true)
                {

                    numberButtons[i].BackColor = Color.Purple;
                    tileHighlighted++;
                }
                else if(numberButtons[i].Enabled == true)
                {
                    numberButtons[i].BackColor = Color.Transparent;
                }
                
            }
            if(valueFinderTxtBox.Text == null)
            {
                tileAmountLbl.Text = "Tile Amount";
            }
            tileAmountLbl.Text = tileHighlighted.ToString();
        }






    }
}
