using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        List<string> listOfWords = new List<string>();
        int counter = 0;
        string line, chosenWord, chosenWordUppercase, guess;
        char[] guessToChar = new char[1];
        int timer = 0;
        int numWrongGusses, numCorrectGusses;
        StringBuilder displayToPlayer;
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            HangmanPicture.Image = Hangman.Properties.Resources.Hangman_Drawing__1_;
            LoadWords();
        }

        void LoadWords()
        {
            //B:\OneDrive\School\12th Grade\Computer Programing\Hangman\Hangman\Resources\ListOfWords.txt
            System.IO.StreamReader file =
    new System.IO.StreamReader(@"B:\OneDrive\School\12th Grade\Computer Programing\Hangman\Hangman\Resources\ListOfWords.txt");
            while((line = file.ReadLine()) != null)
            {
                listOfWords.Add(line);
            }
            file.Close();
            StartGame();
        }

        

        void StartGame()
        {
            GameTimer.Start();
            chosenWord = listOfWords[rnd.Next(0, listOfWords.Count())];
            wordLbl.Text = chosenWord;
            displayToPlayer = new StringBuilder(chosenWord.Length);
            for(int i = 0; i < chosenWord.Length; i++)
            {
                displayToPlayer.Append("_ ");
            }
            chosenWordUppercase = chosenWord.ToUpper();
            WordUnknown.Text = displayToPlayer.ToString();
            
        }

        private void guessbtn_Click(object sender, EventArgs e)
        {
            guess = letterGuesstxtbox.Text.ToUpper();
            guessToChar = guess.ToCharArray(0, 1);
            if(chosenWordUppercase.Contains(guess))
            {
                for(int i = 0; i < chosenWord.Length; i++)
                {
                    if(chosenWordUppercase[i] == guessToChar[0])
                    {
                        displayToPlayer[i] = chosenWord[i];
                    }
                    
                }
            }
            letterGuesstxtbox.Text = null;
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timer++;
            Timelbl.Text = timer.ToString("00:00");
        }
    }
}
