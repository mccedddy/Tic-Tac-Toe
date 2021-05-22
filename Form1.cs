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
            if (movingPlayer.Text == "Player 1" && btn1.Text == "")
            {
                btn1.Text = "X";
                nextTurn();
            }
            if (movingPlayer.Text == "Player 2" && btn1.Text == "")
            {
                btn1.Text = "O";
                nextTurn();
            }
        }
        private void nextTurn()
        {
            if (movingPlayer.Text == "Player 1") 
            { 
                movingPlayer.Text = "Player 2"; 
            }
            if (movingPlayer.Text == "Player 2") 
            { 
                movingPlayer.Text = "Player 1"; 
            }
            turns = turns + 1;
            turnNumber.Text = Convert.ToString(turns);
        }
    }
}
