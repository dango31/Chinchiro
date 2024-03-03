using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment
{
    public partial class Form1 : Form
    {
        private Random rnd;
       
      
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dice dice = new Dice();
            List<int> dices = dice.GetDiceList();
            string hands = dice.GetDiceHand(dices[0], dices[1], dices[2]);
            label1.Text = hands;
            label6.Text = dices[0].ToString();
            label7.Text = dices[1].ToString();
            label8.Text = dices[2].ToString();
            timer1.Enabled = false;
            timer2.Enabled=false;
            timer3.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int p = rnd.Next(1, 7);
            if (p == 5)
            {
                dice1.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d1-150x150.png");

            }
            if (p == 1)
            {
                dice1.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d2-150x150.png");
            }
            if (p == 4)
            {
                dice1.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d3-150x150.png");
            }
            if (p == 2)
            {
                dice1.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d4-150x150.png");
            }
            if (p == 6)
            {
                dice1.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d5-150x150.png");
            }
            if (p == 3)
            {
                dice1.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d6-150x150.png");
            }
          
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int x = rnd.Next(1, 7);
            if (x == 2)
            {
                dice2.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d1-150x150.png");
            }
            if (x == 5)
            {
                dice2.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d2-150x150.png");
            }
            if (x == 6)
            {
                dice2.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d3-150x150.png");
            }
            if (x == 1)
            {
                dice2.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d4-150x150.png");
            }
            if (x == 3)
            {
                dice2.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d5-150x150.png");
            }
            if (x == 4)
            {
                dice2.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d6-150x150.png");
            }
            
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int y = rnd.Next(1,7 );
            if (y == 1)
            {
                dice3.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d1-150x150.png");
            }
            if (y == 2)
            {
                dice3.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d2-150x150.png");
            }
            if (y == 3)
            {
                dice3.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d3-150x150.png");
            }
            if(y== 4)
            {
                dice3.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d4-150x150.png");
            }
            if(y == 5)
            {
                dice3.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d5-150x150.png");
            }
            if(y==6)
            {
                dice3.Image = System.Drawing.Image.FromFile(@"C:\\temp\image\dice2d6-150x150.png");
            }
           
        }
    }
}
