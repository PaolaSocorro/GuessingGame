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
    public partial class splashScreen : Form
    {
        public string playerName;

        public splashScreen()
        {
            InitializeComponent();
        }

        

        private void goButton_Click(object sender, EventArgs e)
        {
            

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
