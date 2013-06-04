/*  Program:     guessing game
    Author:      paola socorro
    Class:	     cisp41
    Date:	     june 03, 2013
    Description: a simple number guessing game. Player has 3 chances to guess the number right. When wrong, program will show if the guess
 * was too high or too low. At the end of a lost game, it displays the right number. Shows number of games won and lost at the end.

    I certify that the code below is my own work.
	
	Exception(s): N/A

*/


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GuessingGame
{
    public partial class guessingGameForm : Form
    {
       
        public guessingGameForm()
        {
            InitializeComponent();
        }

        //Variables:

        int playerGuess;
        int compGuess;
        int[] pGuesses;
        int min =0;
        int max=10;
        bool newGame;
        int gameNum;
        int pAttemps=3;
        int gamesWon;
        int gamesLost;
        string playerName;

       

        private void guessingGameForm_Load(object sender, EventArgs e)
        {
            
            generateGuess();
            newGame = true;
            newGameButton.Enabled = false;
            gameNum++;
            infoRichText.Text = "New Game Started. Good Luck you have 3 chances.";
        }

        private void playButton_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(guessText.Text))
            {
                MessageBox.Show("Please guess a number");
            }
            else
            {
                
                playerGuess = int.Parse(guessText.Text);
                checkGuess();
            }
            if (newGame == false)
            {
                playButton.Enabled = false;
            }

            
        }

        private void generateGuess()
        {
            Random rnd = new Random();
            compGuess = rnd.Next(min, max);
            infoRichText.Text = compGuess.ToString();            
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            generateGuess();
            newGame = true;
            newGameButton.Enabled = false;
            gameNum++;
            infoRichText.Text = null;
            playButton.Enabled = true;
            infoRichText.Text = "New Game Started. Good Luck you have 3 chances.";
            guessText.Focus();
            guessText.Text = null;
            pAttemps = 3;
        }

        private void checkGuess()
        {
            if (playerGuess == compGuess)
            {
                infoRichText.Text = null;
                guessText.Focus();
                guessText.Text = null;
                infoRichText.Text = "Congratulations you win. Play one more time?";
                playButton.Enabled = false;
                newGameButton.Enabled = true;
                gamesWon++;
            }
            else
            {
                
                infoRichText.Text = null;
                guessText.Focus();
                guessText.Text = null;
                pAttemps--;                               
                lowHighCheck();

            }
            if (pAttemps == 0)
            {
                newGame = false;
                newGameButton.Enabled = true;
                gamesLost++;
                infoRichText.Text = "Sorry you lost. No more plays left in this game." + "\n" + "The number was: " + compGuess.ToString();
                guessText.Focus();

            }
        }

        private void lowHighCheck()
        {
            if (playerGuess > compGuess)
            {
                infoRichText.Text = "Sorry. "+ playerGuess.ToString()+" is too high" + "\n" + "You have " + pAttemps.ToString() + " more plays left.";
            }
            if (playerGuess < compGuess)
            {
                infoRichText.Text = "Sorry. " + playerGuess.ToString() + " is too low" + "\n" + "You have " + pAttemps.ToString() + " more plays left.";
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guessingGameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Games Won: " + gamesWon.ToString() + "\n" + "Games Lost: " + gamesLost.ToString()+ "\n" + "Play Again Soon!");
        }


    }
}
