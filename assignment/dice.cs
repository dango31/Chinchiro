using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal class Dice
    {
        private readonly Random rand;

        public Dice()
        {
            rand = new Random();
        }
        public enum Result
        {
            PlayerWins,
            CpuWins,
            Draw
        }

        // 三つのランダムの値を生成し、返却するメソッド
        public List<int> GetDiceList()
        {
            List<int> diceList = new List<int>(); // 返却用

            // 三つのランダムの数値を生成 サイコロなので1-6の範囲
            int dice1 = rand.Next(1, 7);
            int dice2 = rand.Next(1, 7);
            int dice3 = rand.Next(1, 7);

            // Listに格納
            diceList.Add(dice1);
            diceList.Add(dice2);
            diceList.Add(dice3);

            return diceList;
        }

       
        public Chinchiroyaku GetDiceHand(int x, int y, int z,int score)
        {
            Chinchiroyaku chin=new Chinchiroyaku();
            if (x == y && y == z) // ゾロ目
            {
                if (x==1)
                {
                    chin.Hand="ピンゾロ";
                    chin.Score = score * 4;
                    return chin;

                }
                else
                {
                    chin.Hand = x + "のゾロ目です";
                    chin.Score = score * 2;
                    return chin;
                }
            }
            else if (x == y || y == z || x == z) // ニフ
            {
                if (x == y)
                {
                    chin.Hand = z+"の目";
                    chin.Score = score+z;
                    return chin;
                }
                if (y == z)
                {
                    chin.Hand = x + "の目";
                    chin.Score = score+x;
                    return chin;
                }
                if (x == z)
                {
                    chin.Hand = y + "の目";
                    chin.Score = score+y;
                    return chin;
                }
            }
           
            else if (x + y + z == 15) // シゴロ
            {
                chin.Hand = "シゴロ";
                chin.Score = score*3;
                return chin;
            }
            else if (x + y + z == 6) // ヒフミ
            {
                chin.Hand = "ヒフミ";
                chin.Score = score/2;
                return chin;
            }

            chin.Hand="目無し";
            chin.Score=score;
            return chin;
        }

        public Chinchiroyaku GetRandomCPUHand(int score)
        {
           
            List<int> diceValues = new List<int>
    
            {        
                rand.Next(1, 7),        
                rand.Next(1, 7),        
                rand.Next(1, 7)    
            };

         
            return GetDiceHand(diceValues[0], diceValues[1], diceValues[2], score);
        }

        public Result GetResult(Chinchiroyaku Playerchin,Chinchiroyaku Cpuchin)
        {
                       
            Chinchiroyaku generatedCPUHand = GetRandomCPUHand(Cpuchin.GetScore());

           
            if (Playerchin.GetScore()>Cpuchin.GetScore())
            {
                return Result.PlayerWins;
            }
            else if (Playerchin.GetScore() < Cpuchin.GetScore())
            {
                return Result.CpuWins;
            }

            return Result.Draw;
        }
    }
}

