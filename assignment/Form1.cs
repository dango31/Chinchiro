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
        private readonly Dice dice;
        private readonly Random random;

        public Form1()
        {
            InitializeComponent();
            dice = new Dice();
            // シード値を指定してRandomクラスを初期化
            random = new Random();
           // string Point = "";
        }

        //数値以外を入力させない
        private void BetBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                return;
            }


            if ((e.KeyChar < '0' || '9' < e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int Point = int.Parse(BetBox.Text);
            List<int> dices = dice.GetDiceList();
             Chinchiroyaku yaku = dice.GetDiceHand(dices[0], dices[1], dices[2],Point);
            ImageDice(dices[0], 1);
            ImageDice(dices[1], 2);
            ImageDice(dices[2], 3);
            label1.Text = yaku.Getint();
            label6.Text = dices[0].ToString();
            label7.Text = dices[1].ToString();
            label8.Text = dices[2].ToString();
            

            // 以下を追加

            int PlayerPoint = Point;
            PlayerPoint += yaku.GetScore();
            PlayerHand.Text = "Player: " + PlayerPoint;

            int CpuPoint = Point;
            CpuPoint += yaku.GetScore();
            CPUHand.Text = "CPU:" + CpuPoint;

            // 勝敗判定
            Chinchiroyaku Cpuchin = dice.GetRandomCPUHand(Point);
            Dice.Result result = dice.GetResult(yaku,Cpuchin);
            UpdatePoints(result);

            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            button2.Enabled = false;
            CPUHand.Text = Cpuchin.Getint();
            PlayerHand.Text=yaku.Getint();
            
        }

        // ポイントを更新するメソッド
        private void UpdatePoints(Dice.Result result)
        {
            try
            {
                int playerPoints;
                int cpuPoints;

                if (int.TryParse(PlayerPoint.Text, out playerPoints) && int.TryParse(CpuPoint.Text, out cpuPoints))
                {
                    switch (result)
                    {
                        case Dice.Result.PlayerWins:
                            playerPoints += int.Parse(BetBox.Text);
                            cpuPoints -= int.Parse(BetBox.Text);
                            LabelResult.Text = "勝利！";
                            break;
                        case Dice.Result.CpuWins:
                            playerPoints -= int.Parse(BetBox.Text);
                            cpuPoints += int.Parse(BetBox.Text);
                            LabelResult.Text = "敗北…";
                            break;
                        case Dice.Result.Draw:
                            LabelResult.Text = "引き分け";
                            break;
                    }

                    PlayerPoint.Text = playerPoints.ToString();
                    CpuPoint.Text = cpuPoints.ToString();
                    BetBox.Text = "0";
                }
                else
                {
                    // エラー処理
                    MessageBox.Show("ポイントの更新に失敗しました。数値を入力してください。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            button2.Enabled = true;
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label1.Text = "";
            LabelResult.Text = "";
        }

        public void timer1_Tick(object sender, EventArgs e)
        {
            int p = random.Next(1, 7);
            ImageDice(p, 1);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int x = random.Next(1, 7);
            ImageDice(x, 2);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int y = random.Next(1, 7);
            ImageDice(y, 3);
        }


        private void ImageDice(int x, int y)
        {
            string Path = @"C:\\temp\image\dice";
            switch (x)
            {
                case 1:
                    Path += "1.png";
                    break;
                case 2:
                    Path += "2.png";
                    break;
                case 3:
                    Path += "3.png";
                    break;
                case 4:
                    Path += "4.png";
                    break;
                case 5:
                    Path += "5.png";
                    break;
                case 6:
                    Path += "6.png";
                    break;
            }
            switch (y)
            {
                case 1:
                    this.dice1.Image = System.Drawing.Image.FromFile(Path);
                    break;
                case 2:
                    this.dice2.Image = System.Drawing.Image.FromFile(Path);
                    break;
                case 3:
                    this.dice3.Image = System.Drawing.Image.FromFile(Path);
                    break;
            }

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            PlayerPoint.Text = "100";
            CpuPoint.Text = "100";  
        }

        private void CpuPoint_Click(object sender, EventArgs e)
        {

        }

        
    }
}