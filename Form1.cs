using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class TicTacToe : Form
    {
        public TicTacToe()
        {
            InitializeComponent();
        }
        // Fields
        int turns = 1;
        string winner = "";
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            // If the tile is empty, input X or O
            if (btn.Text == "") 
            {
                if (movingPlayer.Text == "Player 1" && btn.Text == "") { btn.Text = "X"; }
                if (movingPlayer.Text == "Player 2" && btn.Text == "") { btn.Text = "O"; }

                // If btn.text is X, color is light red. If btn.text is O, color is light blue
                if (btn.Text == "X") { btn.BackColor = Color.FromArgb(255, 128, 128); }
                if (btn.Text == "O") { btn.BackColor = Color.FromArgb(128, 128, 225); }

                // Check win conditions
                winConditions();

                // If there's still no winner, proceed to next turn
                nextTurn();

                // If there is already a winner, proceed to next round
                if (winner != "") { nextRound(); } 
            }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset everything
            nextRound();
            win1.Text = "0";
            win2.Text = "0";
        }
        private void nextTurn()
        {
            // If Player 1 is finished moving and turn is not divisible by 2, change movingPlayer to Player 2
            if (turns % 2 != 0) { movingPlayer.Text = "Player 2"; }
            else { movingPlayer.Text = "Player 1"; }
            turns = turns + 1;

            // turnNumber.Text will not exceed 9 turns and change number of turns
            if (turns < 10) { turnNumber.Text = Convert.ToString(turns); } 
        }

        private void winConditions()
        {
            // If the tiles have 3 X in a row, player 1 wins
            if (
                (btn1.Text == "X" && btn2.Text == "X" && btn3.Text == "X") |
                (btn4.Text == "X" && btn5.Text == "X" && btn6.Text == "X") |
                (btn7.Text == "X" && btn8.Text == "X" && btn9.Text == "X") |
                (btn1.Text == "X" && btn4.Text == "X" && btn7.Text == "X") |
                (btn2.Text == "X" && btn5.Text == "X" && btn8.Text == "X") |
                (btn3.Text == "X" && btn6.Text == "X" && btn9.Text == "X") |
                (btn1.Text == "X" && btn5.Text == "X" && btn9.Text == "X") |
                (btn3.Text == "X" && btn5.Text == "X" && btn7.Text == "X")
                )
            { winner = "Player 1"; }

            // If the tiles have 3 O in a row, Player 2 wins
            if (
                (btn1.Text == "O" && btn2.Text == "O" && btn3.Text == "O") |
                (btn4.Text == "O" && btn5.Text == "O" && btn6.Text == "O") |
                (btn7.Text == "O" && btn8.Text == "O" && btn9.Text == "O") |
                (btn1.Text == "O" && btn4.Text == "O" && btn7.Text == "O") |
                (btn2.Text == "O" && btn5.Text == "O" && btn8.Text == "O") |
                (btn3.Text == "O" && btn6.Text == "O" && btn9.Text == "O") |
                (btn1.Text == "O" && btn5.Text == "O" && btn9.Text == "O") |
                (btn3.Text == "O" && btn5.Text == "O" && btn7.Text == "O")
                )
            { winner = "Player 2"; }

            // If the tiles are full and there's no winner, the match is a draw
            if (btn1.Text != "" &&
            btn2.Text != "" &&
            btn3.Text != "" &&
            btn4.Text != "" &&
            btn5.Text != "" &&
            btn6.Text != "" &&
            btn7.Text != "" &&
            btn8.Text != "" &&
            btn9.Text != "" &&
            winner == "")
            { winner = "Draw"; }

            // If a winner has been declared, add score to the winner and show on message box
            if (winner != "") 
            { 
                // Add score to the winner
                if (winner == "Player 1")
                { win1.Text = Convert.ToString(int.Parse(win1.Text) + 1); }
                if (winner == "Player 2")
                { win2.Text = Convert.ToString(int.Parse(win2.Text) + 1); }
                
                // Show winner
                if (winner == "Draw")
                { MessageBox.Show(winner); }
                else
                {
                    // Change the color of the winning buttons
                    winnerColor();
                    MessageBox.Show(winner + " Win"); 
                }
            }
        }
        private void nextRound()
        {
            // Reset everything except scores
            winner = "";
            btn1.Text = "";
            btn2.Text = "";
            btn3.Text = "";
            btn4.Text = "";
            btn5.Text = "";
            btn6.Text = "";
            btn7.Text = "";
            btn8.Text = "";
            btn9.Text = "";
            turns = 1;
            turnNumber.Text = "1";
            movingPlayer.Text = "Player 1";
            btn1.BackColor = Color.White;
            btn2.BackColor = Color.White;
            btn3.BackColor = Color.White;
            btn4.BackColor = Color.White;
            btn5.BackColor = Color.White;
            btn6.BackColor = Color.White;
            btn7.BackColor = Color.White;
            btn8.BackColor = Color.White;
            btn9.BackColor = Color.White;
        }
        private void winnerColor()
        {
            // Change the winning tiles color to green
            if (btn1.Text == btn2.Text && btn2.Text == btn3.Text && btn1.Text != "")
            {
                btn1.BackColor = Color.Green;
                btn2.BackColor = Color.Green;
                btn3.BackColor = Color.Green;
            }
            if (btn4.Text == btn5.Text && btn5.Text == btn6.Text && btn4.Text != "")
            {
                btn4.BackColor = Color.Green;
                btn5.BackColor = Color.Green;
                btn6.BackColor = Color.Green;
            }
            if (btn7.Text == btn8.Text && btn8.Text == btn9.Text && btn7.Text != "")
            {
                btn7.BackColor = Color.Green;
                btn8.BackColor = Color.Green;
                btn9.BackColor = Color.Green;
            }
            if (btn1.Text == btn4.Text && btn4.Text == btn7.Text && btn1.Text != "")
            {
                btn1.BackColor = Color.Green;
                btn4.BackColor = Color.Green;
                btn7.BackColor = Color.Green;
            }
            if (btn2.Text == btn5.Text && btn5.Text == btn8.Text && btn2.Text != "")
            {
                btn2.BackColor = Color.Green;
                btn5.BackColor = Color.Green;
                btn8.BackColor = Color.Green;
            }
            if (btn3.Text == btn6.Text && btn6.Text == btn9.Text && btn3.Text != "")
            {
                btn3.BackColor = Color.Green;
                btn6.BackColor = Color.Green;
                btn9.BackColor = Color.Green;
            }
            if (btn1.Text == btn5.Text && btn5.Text == btn9.Text && btn1.Text != "")
            {
                btn1.BackColor = Color.Green;
                btn5.BackColor = Color.Green;
                btn9.BackColor = Color.Green;
            }
            if (btn3.Text == btn5.Text && btn5.Text == btn7.Text && btn3.Text != "")
            {
                btn3.BackColor = Color.Green;
                btn5.BackColor = Color.Green;
                btn7.BackColor = Color.Green;
            }
        }
    }
}
