using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Web.UI;
namespace LandMines
{
    public partial class Form2 : Form
    {
        int[,] map = new int[Class1.MapSize, Class1.MapSize];
        int indeterminedArea = Class1.MapSize * Class1.MapSize;
        Image redFlag = Image.FromFile(Application.StartupPath + @"\Red-Flag.png");
        Image mine = Image.FromFile(Application.StartupPath + @"\mine.jpg");
        bool gameOver = false;
        Font f = new Font("Monotype Corsiva", 12);
        Label unclearedArea = new Label();
        Label numberOfFlag = new Label();
        int FlagsCount = 0;
        public Form2()
        {
            InitializeComponent();
            this.Height = (Class1.MapSize * 30) + 150;
            this.Width = (Class1.MapSize * 30) + 75;
            Button buttonQuit = new Button();
            buttonQuit.Location = new Point(this.Width - 95, 30);
            buttonQuit.Text = "Quit";
            buttonQuit.Font = f;
            buttonQuit.Size = new Size(50, 30);
            this.Controls.Add(buttonQuit);
            buttonQuit.Click += ButtonQuit_Click;
            Label numberOfMines = new Label();
            numberOfMines.Location = new Point(10, 10);
            numberOfMines.Text = "Number of mines : " + Class1.NumOfMines.ToString();
            numberOfMines.Font = f;
            numberOfMines.AutoSize = true;
            this.Controls.Add(numberOfMines);
            unclearedArea.Location = new Point(10, 30);
            unclearedArea.Text = "Uncleared Area : " + indeterminedArea.ToString();
            unclearedArea.Font = f;
            unclearedArea.AutoSize = true;
            this.Controls.Add(unclearedArea);
            numberOfFlag.Location = new Point(10, 50);
            numberOfFlag.Text = "Number of Flags : " + FlagsCount.ToString();
            numberOfFlag.Font = f;
            numberOfFlag.AutoSize = Enabled;
            this.Controls.Add(numberOfFlag);
            for (int i = 0; i < Class1.MapSize; i++)
            {
                for (int j = 0; j < Class1.MapSize; j++)
                {
                    string name = (i).ToString() + "-" + (j).ToString();
                    Button b = new Button();
                    b.Name = name;
                    b.Size = new Size(30, 30);
                    b.Text = "";
                    b.Location = new Point(30+(i * 30), 90 + (j * 30));
                    b.Show();
                    this.Controls.Add(b);
                    b.MouseDown += Button_Click;
                }
            }
            mapReset();
            plantMines();
        }
        private void plantMines() 
        {
            int count = 0;
            Random r = new Random();
            while (count != Class1.NumOfMines)
            {
                int i = r.Next(0, Class1.MapSize);
                int j = r.Next(0, Class1.MapSize);
                if (map[i,j] == 0)
                {
                    map[i, j] = 1;
                    count++;
                }
            }
        }
        private void mapReset()
        {
            for (int i = 0; i < Class1.MapSize; i++)
            {
                for (int j = 0; j < Class1.MapSize; j++)
                {
                    map[i, j] = 0;
                }
            }
        }
        private void Button_Click(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    ButtonLeft_Click(sender, e);
                    break;
                case MouseButtons.Right:
                    ButtonRight_Click(sender, e);
                    break;
                default:
                    break;
            }
        }
        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int i = Convert.ToInt32(b.Name.Split('-')[0]);
            int j = Convert.ToInt32(b.Name.Split('-')[1]);
            if (b.Text == "")
            {
                b.Image = null;
                if (map[i, j] == 1)
                {
                    b.Image = mine;
                    MessageBox.Show("Gameover!", "GameOver!");
                    this.Close();
                    Form3 form3 = new Form3();
                    form3.Show();
                }
                else
                {
                    int count = 0;
                    count = CountMinesAround(count, i, j, Class1.MapSize);
                    b.Text = count.ToString();
                    indeterminedArea--;
                    unclearedArea.Text = "Uncleared Area : " + indeterminedArea.ToString();
                    if (count == 0)
                    {
                        ClickZeros(i, j, Class1.MapSize, e);
                    }
                    CheckWin(indeterminedArea, Class1.NumOfMines);
                }
            }
            
        }
        private void ButtonRight_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int i = Convert.ToInt32(b.Name.Split('-')[0]);
            int j = Convert.ToInt32(b.Name.Split('-')[1]);
            if (b.Text == "")
            {
                if (b.Image != redFlag)
                {
                    b.Image = redFlag;
                    FlagsCount++;
                }
                else
                {
                    b.Image = null;
                    FlagsCount--;
                }
                numberOfFlag.Text = "Number of Flags : " + FlagsCount.ToString();
            }
        }
        private void ButtonQuit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to quit the game?","Quit the game",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
                Form3 form3 = new Form3();
                form3.Show();
            }
        }
        private void CheckWin(int indeterminedArea, int numOfMines)
        {
            if (gameOver == false)
            {
                if (indeterminedArea == numOfMines)
                {
                    foreach (Button but in this.Controls.OfType<Button>())
                    {
                        if (but.Image == redFlag || but.Text == "")
                        {
                            but.Image = mine;
                            but.Enabled = false;
                        }
                    }
                    gameOver = true;
                    MessageBox.Show("You have won!!! Click Ok to get back to Menu.", "Congratulation!!");
                    this.Close();
                    Form3 form3 = new Form3();
                    form3.Show();
                }
            }
            
        }
        private int CountMinesAround(int count, int i, int j, int mapSize)
        {
            for (int p = i - 1; p <= i + 1; p++)
            {
                for (int q = j - 1; q <= j + 1; q++)
                {
                    if (p >= 0 && p < mapSize && q >= 0 && q < mapSize)
                    {
                        if (map[p, q] == 1)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
        private void ClickZeros(int i, int j, int mapSize, EventArgs e)
        {
            for (int p = i - 1; p <= i + 1; p++)
            {
                for (int q = j - 1; q <= j + 1; q++)
                {
                    if (p >= 0 && p < mapSize && q >= 0 && q < mapSize)
                    {
                        string name = (p).ToString() + "-" + (q).ToString();
                        Button b = Controls.Find(name, true).OfType<Button>().FirstOrDefault();
                        if (b.Text == "")
                        {
                            Object bu = Controls.Find(name, true).OfType<Button>().FirstOrDefault();
                            ButtonLeft_Click(bu, e);
                        }
                    }
                }
            }
        }
    }
}
