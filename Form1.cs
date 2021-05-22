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
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (movingPlayer.Text == "Player 1" && btn.Text == "") { btn.Text = "X"; }
            if (movingPlayer.Text == "Player 2" && btn.Text == "") { btn.Text = "O"; }
            nextTurn();
        }
        private void nextTurn()
        {
            int turnmodulus = turns % 2;
            if (turnmodulus != 0) { movingPlayer.Text = "Player 2"; }
            else { movingPlayer.Text = "Player 1"; }
            turns = turns + 1;
            if (turns < 10) { turnNumber.Text = Convert.ToString(turns); }
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
    }
}
