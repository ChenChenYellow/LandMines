using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LandMines
{
    public partial class Form1 : Form
    {
        private const int Zize = 8;
        private int[,] landMines = new int[Zize, Zize];
        private bool gameOver = false;
        public Form1()
        {
            InitializeComponent();
            disableAllButtons();
        }
        private void disableAllButtons()
        {
            foreach (Button button in this.Controls.OfType<Button>())
            {
                if (button != buttonReset && button != buttonExit)
                {
                    button.Enabled = false;
                }
            }
        }
        private void enableAllButtons()
        {
            foreach (Button button in this.Controls.OfType<Button>())
            {
                if (button != buttonReset && button != buttonExit)
                {
                    button.Enabled = true;
                    button.Text = "+";
                }
            }
        }
        private void buttonClick (int row, int col, Button b)
        {
            if (gameOver == false)
            {
                b.Enabled = false;
                if (landMines[row, col] == 1)
                {
                    b.Text = "*";
                    gameOver = true;
                    foreach (Button button in this.Controls.OfType<Button>())
                    {
                        if (button != buttonReset && button != buttonExit)
                        {
                            button.PerformClick();
                        }
                    }
                    disableAllButtons();
                    MessageBox.Show("HAHA! GOT YOU!!", "You are dead");
                    textBox1.Enabled = true;
                }
                else if (landMines[row, col] == 0)
                {
                    int count = 0;
                    for (int i = row - 1; i <= row + 1; i++)
                    {
                        for (int j = col - 1; j <= col + 1; j++)
                        {
                            if (i >= 0 && i < Zize && j >= 0 && j < Zize)
                            {
                                if (landMines[i, j] == 1)
                                {
                                    count++;
                                }
                            }
                        }
                    }
                    b.Text = count.ToString();
                    int bCount = 0;
                    foreach (Button button in this.Controls.OfType<Button>())
                    {
                        if (button != buttonReset && button != buttonExit)
                        {
                            if (button.Enabled == false)
                            {
                                bCount++;
                            }
                        }
                    }
                    if (64 - bCount == Convert.ToInt32(textBox1.Text))
                    {
                        MessageBox.Show("Congratulation, You Won!!", "Lucky and Smart");
                        disableAllButtons();
                        textBox1.Enabled = true;
                    }                    
                }
            }
            else if (gameOver == true)
            {
                if (landMines[row, col] == 1)
                {
                    b.Text = "*";
                }
            }            
        }
        private void buttonReset_Click(object sender, EventArgs e)
        {
            int a;
            int mines = 0;
            gameOver = false;
            if (int.TryParse(textBox1.Text,out a))
            {
                mines = Convert.ToInt32(textBox1.Text);
            }
            if (mines >= 5 && mines <=16)
            {
                int count = 0;
                Random randomNum = new Random();
                for (int i = 0; i < Zize; i++)
                {
                    for (int j = 0; j < Zize; j++)
                    {
                        landMines[i, j] = 0;
                    }
                }
                while (count < mines)
                {
                    int row = randomNum.Next(0, Zize);
                    int col = randomNum.Next(0, Zize);
                    if (landMines[row, col] != 1)
                    {
                        landMines[row, col] = 1;
                        count++;
                    }
                }
                enableAllButtons();
                textBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Number of mines must be between 5 and 16, Please Enter another one", "Invalid Number of Mines");
                textBox1.Clear();
                textBox1.Focus();
            }
        }
        private void button00_Click(object sender, EventArgs e)
        {
            buttonClick(0, 0, button00);
        }
        private void button01_Click(object sender, EventArgs e)
        {
            buttonClick(0, 1, button01);
        }
        private void button02_Click(object sender, EventArgs e)
        {
            buttonClick(0, 2, button02);
        }
        private void button03_Click(object sender, EventArgs e)
        {
            buttonClick(0, 3, button03);
        }
        private void button04_Click(object sender, EventArgs e)
        {
            buttonClick(0, 4, button04);
        }
        private void button05_Click(object sender, EventArgs e)
        {
            buttonClick(0, 5, button05);
        }
        private void button06_Click(object sender, EventArgs e)
        {
            buttonClick(0, 6, button06);
        }
        private void button07_Click(object sender, EventArgs e)
        {
            buttonClick(0, 7, button07);
        }
        private void button10_Click(object sender, EventArgs e)
        {
            buttonClick(1, 0, button10);
        }
        private void button11_Click(object sender, EventArgs e)
        {
            buttonClick(1, 1, button11);
        }
        private void button12_Click(object sender, EventArgs e)
        {
            buttonClick(1, 2, button12);
        }
        private void button13_Click(object sender, EventArgs e)
        {
            buttonClick(1, 3, button13);
        }
        private void button14_Click(object sender, EventArgs e)
        {
            buttonClick(1, 4, button14);
        }
        private void button15_Click(object sender, EventArgs e)
        {
            buttonClick(1, 5, button15);
        }
        private void button16_Click(object sender, EventArgs e)
        {
            buttonClick(1, 6, button16);
        }
        private void button17_Click(object sender, EventArgs e)
        {
            buttonClick(1, 7, button17);
        }
        private void button20_Click(object sender, EventArgs e)
        {
            buttonClick(2, 0, button20);
        }
        private void button21_Click(object sender, EventArgs e)
        {
            buttonClick(2, 1, button21);
        }
        private void button22_Click(object sender, EventArgs e)
        {
            buttonClick(2, 2, button22);
        }
        private void button23_Click(object sender, EventArgs e)
        {
            buttonClick(2, 3, button23);
        }
        private void button24_Click(object sender, EventArgs e)
        {
            buttonClick(2, 4, button24);
        }
        private void button25_Click(object sender, EventArgs e)
        {
            buttonClick(2, 5, button25);
        }
        private void button26_Click(object sender, EventArgs e)
        {
            buttonClick(2, 6, button26);
        }
        private void button27_Click(object sender, EventArgs e)
        {
            buttonClick(2, 7, button27);
        }
        private void button30_Click(object sender, EventArgs e)
        {
            buttonClick(3, 0, button30);
        }
        private void button31_Click(object sender, EventArgs e)
        {
            buttonClick(3, 1, button31);
        }
        private void button32_Click(object sender, EventArgs e)
        {
            buttonClick(3, 2, button32);
        }
        private void button33_Click(object sender, EventArgs e)
        {
            buttonClick(3, 3, button33);
        }
        private void button34_Click(object sender, EventArgs e)
        {
            buttonClick(3, 4, button34);
        }
        private void button35_Click(object sender, EventArgs e)
        {
            buttonClick(3, 5, button35);
        }
        private void button36_Click(object sender, EventArgs e)
        {
            buttonClick(3, 6, button36);
        }
        private void button37_Click(object sender, EventArgs e)
        {
            buttonClick(3, 7, button37);
        }
        private void button40_Click(object sender, EventArgs e)
        {
            buttonClick(4, 0, button40);
        }
        private void button41_Click(object sender, EventArgs e)
        {
            buttonClick(4, 1, button41);
        }
        private void button42_Click(object sender, EventArgs e)
        {
            buttonClick(4, 2, button42);
        }
        private void button43_Click(object sender, EventArgs e)
        {
            buttonClick(4, 3, button43);
        }
        private void button44_Click(object sender, EventArgs e)
        {
            buttonClick(4, 4, button44);
        }
        private void button45_Click(object sender, EventArgs e)
        {
            buttonClick(4, 5, button45);
        }
        private void button46_Click(object sender, EventArgs e)
        {
            buttonClick(4, 6, button46);
        }
        private void button47_Click(object sender, EventArgs e)
        {
            buttonClick(4, 7, button47);
        }
        private void button50_Click(object sender, EventArgs e)
        {
            buttonClick(5, 0, button50);
        }
        private void button51_Click(object sender, EventArgs e)
        {
            buttonClick(5, 1, button51);
        }
        private void button52_Click(object sender, EventArgs e)
        {
            buttonClick(5, 2, button52);
        }
        private void button53_Click(object sender, EventArgs e)
        {
            buttonClick(5, 3, button53);
        }
        private void button54_Click(object sender, EventArgs e)
        {
            buttonClick(5, 4, button54);
        }
        private void button55_Click(object sender, EventArgs e)
        {
            buttonClick(5, 5, button55);
        }
        private void button56_Click(object sender, EventArgs e)
        {
            buttonClick(5, 6, button56);
        }
        private void button57_Click(object sender, EventArgs e)
        {
            buttonClick(5, 7, button57);
        }
        private void button60_Click(object sender, EventArgs e)
        {
            buttonClick(6, 0, button60);
        }
        private void button61_Click(object sender, EventArgs e)
        {
            buttonClick(6, 1, button61);
        }
        private void button62_Click(object sender, EventArgs e)
        {
            buttonClick(6, 2, button62);
        }
        private void button63_Click(object sender, EventArgs e)
        {
            buttonClick(6, 3, button63);
        }
        private void button64_Click(object sender, EventArgs e)
        {
            buttonClick(6, 4, button64);
        }
        private void button65_Click(object sender, EventArgs e)
        {
            buttonClick(6, 5, button65);
        }
        private void button66_Click(object sender, EventArgs e)
        {
            buttonClick(6, 6, button66);
        }
        private void button67_Click(object sender, EventArgs e)
        {
            buttonClick(6, 7, button67);
        }
        private void button70_Click(object sender, EventArgs e)
        {
            buttonClick(7, 0, button70);
        }
        private void button71_Click(object sender, EventArgs e)
        {
            buttonClick(7, 1, button71);
        }
        private void button72_Click(object sender, EventArgs e)
        {
            buttonClick(7, 2, button72);
        }
        private void button73_Click(object sender, EventArgs e)
        {
            buttonClick(7, 3, button73);
        }
        private void button74_Click(object sender, EventArgs e)
        {
            buttonClick(7, 4, button74);
        }
        private void button75_Click(object sender, EventArgs e)
        {
            buttonClick(7, 5, button75);
        }
        private void button76_Click(object sender, EventArgs e)
        {
            buttonClick(7, 6, button76);
        }
        private void button77_Click(object sender, EventArgs e)
        {
            buttonClick(7, 7, button77);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Quit Application?","Quit",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
