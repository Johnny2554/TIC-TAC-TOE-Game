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
    public partial class Form1 : Form
    {
        bool turn = true;//true = X turn; false = O turn
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Jonatan Zietsman " + Environment.NewLine + "Resource:https://www.youtube.com/watch?v=p3gYVcggQOU" + Environment.NewLine + "Version 1.0", "Tic Tac Toe About"); ;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";

            turn = !turn;
            b.Enabled = false;
            checkForWinner();
            turn_count++;
        }
        private void checkForWinner()
        {
            bool there_is_a_winner = false;
            //Horizontal Checks
            if ((A1.Text == A2.Text && A2.Text == A3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((B1.Text == B2.Text && B2.Text == B3.Text) && (!B1.Enabled))
                there_is_a_winner = true;
            else if ((C1.Text == C2.Text && C2.Text == C3.Text) && (!C1.Enabled))
                there_is_a_winner = true;

            //Vertical Checks
            else if ((A1.Text == B1.Text && B1.Text == C1.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A2.Text == B2.Text && B2.Text == C2.Text) && (!A2.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B3.Text && B3.Text == C3.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            //Daigonal Checks
            else if ((A1.Text == B2.Text && B2.Text == C3.Text) && (!A1.Enabled))
                there_is_a_winner = true;
            else if ((A3.Text == B2.Text && B2.Text == C1.Text) && (!A3.Enabled))
                there_is_a_winner = true;

            if (there_is_a_winner)
            {
                DisableButton();

                string winner = "";
                if (turn)
                {
                    winner = p2.Text;
                    o_win_count.Text = (Int32.Parse(o_win_count.Text) + 1).ToString();
                }
                else
                {
                    winner = p1.Text;
                    x_win_count.Text = (Int32.Parse(x_win_count.Text) + 1).ToString();
                    
                }
                MessageBox.Show(winner + " Wins!", "Yay!");
            }
            else
            {
                if (turn_count == 8)
                {
                    draw_count.Text = (Int32.Parse(draw_count.Text) + 1).ToString();
                    MessageBox.Show("Draw!", "Bummer!");
                }
            }

        }//End checkForWinner
        private void DisableButton()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;

                }// End foreach
            }//End of try
            catch { }
        }

        private void resetBoardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true; // true = X turn; false = O trun
            turn_count = 0;
            MessageBox.Show("Do you want to reset the board?", "Boeard reset.");

            foreach (Control c in Controls)
            {
                try
                {

                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }// End foreach
        }

        private void button_enter(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                if (turn)
                    b.Text = "X";
                else
                    b.Text = "O";
            }
        }

        private void button_leave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (b.Enabled)
            {
                b.Text = "";
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true; // true = X turn; false = O trun
            turn_count = 0;
            foreach (Control c in Controls)
            {
                try
                {
                    x_win_count.Text = "0";
                    o_win_count.Text = "0";
                    draw_count.Text = "0";
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
                catch { }
            }// End foreach
        }

        

        
    }
}
