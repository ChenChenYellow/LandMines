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
    
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            if (Class1.MapSize != 0)
            {
                numericUpDown2.Value = Class1.MapSize;
            }
            if (Class1.NumOfMines != 0)
            {
                numericUpDown1.Value = Class1.NumOfMines;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Class1.NumOfMines = Convert.ToInt32(numericUpDown1.Value);
            Class1.MapSize = Convert.ToInt32(numericUpDown2.Value);
            Form2 form2 = new Form2();
            form2.Show();
            this.Close();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = Math.Round((numericUpDown2.Value * numericUpDown2.Value)/4,0);
            if (numericUpDown2.Value > numericUpDown2.Maximum)
            {
                numericUpDown2.Value = numericUpDown2.Maximum;
            }
            else if (numericUpDown2.Value < numericUpDown2.Minimum)
            {
                numericUpDown2.Value = numericUpDown2.Minimum;
            }
            if (numericUpDown1.Maximum < numericUpDown1.Value)
            {
                numericUpDown1.Value = numericUpDown1.Maximum;
            }
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > numericUpDown1.Maximum)
            {
                numericUpDown1.Value = numericUpDown1.Maximum;
            }
            else if (numericUpDown1.Value < numericUpDown1.Minimum)
            {
                numericUpDown1.Value = numericUpDown1.Minimum;
            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit?","Exit the program",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        
    }
}
