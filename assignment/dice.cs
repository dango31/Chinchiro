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

       
        public string GetDiceHand(int x, int y, int z)
        {
            if (x == y && y == z) // ゾロ目
            {
                return x + "のゾロ目です";
            }
            else if (x == y || y == z || x == z) // ニフ
            {
                if (x == y)
                {
                    return z + "の目";
                }
                if (y == z)
                {
                    return x + "の目";
                }
                if (x == z)
                {
                    return y + "の目";
                }
            }
            else if (x == 1 && y == 1 && z == 1) // ピンゾロ
            {
                return "ピンゾロ";
            }
            else if (x + y + z == 15) // シゴロ
            {
                return "シゴロ";
            }
            else if (x + y + z == 6) // ヒフミ
            {
                return "ヒフミ";
            }

            return "目無し";
        }

        public string GetRandomCPUHand()
        {
           
            List<int> diceValues = new List<int>
    
            {        
                rand.Next(1, 7),        
                rand.Next(1, 7),        
                rand.Next(1, 7)    
            };

         
            return GetDiceHand(diceValues[0], diceValues[1], diceValues[2]);
        }

        public Result GetResult(string playerHand, string cpuHand)
        {
           
            List<string> handsOrder = new List<string>
    
            {        
                "ヒフミ", "目無し", "1の目", "2の目", "3の目", "4の目", "5の目", "6の目",        
                "2のゾロ目", "3のゾロ目", "4のゾロ目", "5のゾロ目", "6のゾロ目", "ピンゾロ"    
            };

            
            string generatedCPUHand = GetRandomCPUHand();

            int playerIndex = handsOrder.IndexOf(playerHand);
            int cpuIndex = handsOrder.IndexOf(generatedCPUHand);

            if (playerIndex < cpuIndex)
            {
                return Result.PlayerWins;
            }
            else if (playerIndex > cpuIndex)
            {
                return Result.CpuWins;
            }

            return Result.Draw;
        }
    }
}

