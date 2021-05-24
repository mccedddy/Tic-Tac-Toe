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
            if (movingPlayer.Text == "Player 1" && btn.Text == "") { btn.Text = "X"; }
            if (movingPlayer.Text == "Player 2" && btn.Text == "") { btn.Text = "O"; }
            winConditions();
            nextTurn();
            if (winner != "") { nextRound(); }
        }
        
        private void btnClear_Click(object sender, EventArgs e)
        {
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
            win1.Text = "0";
            win2.Text = "0";
        }
        private void nextTurn()
        {
            int turnmodulus = turns % 2;
            if (turnmodulus != 0) { movingPlayer.Text = "Player 2"; }
            else { movingPlayer.Text = "Player 1"; }
            turns = turns + 1;
            if (turns < 10) { turnNumber.Text = Convert.ToString(turns); }
        }

        private void winConditions()
        {
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
            {
                winner = "Player 1";
            }
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
            {
                winner = "Player 2";
            }
            if (winner != "") 
            { 
                if (winner == "Player 1")
                {
                    win1.Text = Convert.ToString(int.Parse(win1.Text) + 1);
                }
                if (winner == "Player 2")
                {
                    win2.Text = Convert.ToString(int.Parse(win2.Text) + 1);
                }
                MessageBox.Show(winner + " Win");
            }
        }
        private void nextRound()
        {
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
        }
    }
}
