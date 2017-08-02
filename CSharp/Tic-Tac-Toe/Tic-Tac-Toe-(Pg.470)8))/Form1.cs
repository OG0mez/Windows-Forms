/*
 * Name: 'Tic-Tac-Toe'
 * Purpose: Simulates a tic-tac-toe game. Generates a random number between 0 and 1. 0 represents 'O' and 1 represents 'X'. Determine the winner, or if its a tie. 
 *          Uses an integer two-dimensional array to display the X's and O's on the gameboard. Checks rows, columns, and diagonals for a match.
 *          Player 1 is O, Player 2 is X.
 * Programmer: Hunter Johnson
 * Date: 10/2/16
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe._470_8__
{
    public partial class Form1 : Form
    {
        // create new random variable
        Random rand = new Random();

        // named constants for ROWS and COLS
        const int ROWS = 3;
        const int COLS = 3;

        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // close the form
            this.Close();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            // letters array to hold the integer 0 or 1. 0 represents 'O' and 1 represents 'X'
            int[,] letters = new int[ROWS, COLS];

            // call showGameBoard method to show the X's and O's in the labels
            showGameBoard(ref letters);

            // call determineWinner method
            determineWinner(letters);
        }

        //****************************************************************************************************************************
        // method showGameBoard - Randomly sets each element in the array to either 0, or 1: 0 represents 'O' and 1 represents 'X'.  *
        //                        Displays 'O' or 'X' inside the labels depending on the number given.                               *
        //                        Player 1 is 'O' and Player 2 is 'X'.                                                               *
        //**************************************************************************************************************************** 
        private void showGameBoard(ref int[,] letters)
        {
            // iterate through rows
            for (int row = 0; row < ROWS; row++)
            {
                // iterate through columns
                for (int col = 0; col < COLS; col++)
                {
                    // set each element in the Int Array to either 0 or 1
                    letters[row, col] = rand.Next(2);
                }
            }

            // use conditional operators to display X's and O's depending on the random value given
            label1.Text = (letters[0, 0] == 0) ? "O" : "X";
            label2.Text = (letters[0, 1] == 0) ? "O" : "X";
            label3.Text = (letters[0, 2] == 0) ? "O" : "X";
            label4.Text = (letters[1, 0] == 0) ? "O" : "X";
            label5.Text = (letters[1, 1] == 0) ? "O" : "X";
            label6.Text = (letters[1, 2] == 0) ? "O" : "X";
            label7.Text = (letters[2, 0] == 0) ? "O" : "X";
            label8.Text = (letters[2, 1] == 0) ? "O" : "X";
            label9.Text = (letters[2, 2] == 0) ? "O" : "X";
        }

        //******************************************************************************************************************
        // method check_row - Passes r to check the row we are checking. if row==0, row 1. If row ==1, row 2. Else, row 3. *
        //                    P stands for player, for which player we're checking the row.                                *
        //                    So if r==0, p==1, we are checking if player 1 can win in row 1. Possible if 0, 0, 0          *
        //******************************************************************************************************************
        private bool check_row(int[,] l, int r, int p)
        {
            // if p==1, check the whole row to see if it contains 0,0,0
            if (p == 1)
            {
                if (l[r, 0] == l[r, 1] && l[r, 1] == l[r, 2] && l[r, 0] == 0)
                    return true;
            }
            // if p==2, check to see if row r contains 1, 1, 1
            else if (p == 2)
            {
                if (l[r, 0] == l[r, 1] && l[r, 1] == l[r, 2] && l[r, 0] == 1)
                    return true;
            }
            return false;
        }

        //****************************************************************************************************************************
        // method check_column - passes c to check the column we are checking. If c==0, column1. If c==1, column 2. Else, column 3.  *
        //                       P stands for player, for which player we're checking the column.                                    *
        //                       So if c==0, p==1, we're checking if player 1 can win in column 1. Possible if 0, 0, 0               *
        //****************************************************************************************************************************       
        private bool check_column(int[,] l, int c, int p)
        {
            // if p==1, check to see if column c contains 0, 0, 0
            if (p == 1)
            {
                if (l[0, c] == l[1, c] && l[1, c] == l[2, c] && l[0, c] == 0)
                    return true;
            }
            // if p==2, check to see if column c contains 1, 1, 1
            else if (p == 2)
            {
                if (l[0, c] == l[1, c] && l[1, c] == l[2, c] && l[0, c] == 1)
                    return true;
            }
            return false;
        }

        //****************************************************************************************************************************
        // method determineWinner - Has an array named letters getting passed to it.                                                 *                                             
        //                          Determines the winner in column, row, and diagonal. Whether X wins or O wins.                    *
        //****************************************************************************************************************************  
        private void determineWinner(int[,] letters)
        {
            // iterate through rows and check if there are wins
            for (int i = 0; i < ROWS; i++)
            {
                // call check_row to determine if the row contains 0,0,0 for player 1
                if (check_row(letters, i, 1) == true)
                {
                    winnerOutputLabel.Text = "O Wins!";
                    return;
                }
                // call check_row to determine if the row contains 1,1,1 for player 2
                if (check_row(letters, i, 2) == true)
                {
                    winnerOutputLabel.Text = "X Wins!";
                    return;
                }
            }
            // iterate through columns and check if there are wins
            for (int i = 0; i < COLS; i++)
            {
                // call check_column to determine if the column contains 0,0,0 for player 1
                if (check_column(letters, i, 1) == true)
                {
                    winnerOutputLabel.Text = "O Wins!";
                    return;
                }
                // call check_column to determine if the column contains 1,1,1 for player 2
                if (check_column(letters, i, 2) == true)
                {
                    winnerOutputLabel.Text = "X Wins!";
                    return;
                }
            }

            // Diagonal 1 \- Top left to bottom right, check if it contains 0,0,0
            if (letters[0, 0] == letters[1, 1] && letters[1, 1] == letters[2, 2] && letters[0, 0] == 0)
            {
                winnerOutputLabel.Text = "O Wins!";
                return;
            }
            // Diagonal 1 \- Top left to bottom right, check if it contains 1,1,1 
            if (letters[0, 0] == letters[1, 1] && letters[1, 1] == letters[2, 2] && letters[0, 0] == 1)
            {
                winnerOutputLabel.Text = "X Wins!";
                return;
            }

            // Diagonal 2 /- Top right to bottom left, check to see if it contains 0,0,0
            if (letters[0, 2] == letters[1, 1] && letters[1, 1] == letters[2, 0] && letters[0, 2] == 0)
            {
                winnerOutputLabel.Text = "O Wins!";
                return;
            }
            // Diagonal 2 /- Top right to bottom left, check to see if it contains 1,1,1
            if (letters[0, 2] == letters[1, 1] && letters[1, 1] == letters[2, 0] && letters[0, 2] == 1)
            {
                winnerOutputLabel.Text = "X Wins!";
                return;
            }

            // display match draw
            winnerOutputLabel.Text = "Match Draw";
        }

        //**************************************************************************************************************
        // method Form1_Load - This code is ran when the program first starts up.                                      *
        //                     Disables the minimize and maximize resize boxes, and disables individual form resizing. *
        //**************************************************************************************************************
        private void Form1_Load(object sender, EventArgs e)
        {
            // Disables Max/Min window boxes, and individual resizing of the form window 
            MinimizeBox = false;
            MaximizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;
        }
    }
}
