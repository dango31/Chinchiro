using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal class Dice
    {
        //、三つのランダムの値を生成し、返却をする
        public List<int> GetDiceList()
        {
            List<int> diceList = new List<int>(); //返却用
            //三つのランダムの数値を生成　サイコロなので1-6の範囲
            Random rand = new Random();
            int dice1 = rand.Next(1, 7);
            int dice2 = rand.Next(1, 7);
            int dice3 = rand.Next(1, 7);

            //Listに格納
            diceList.Add(dice1);
            diceList.Add(dice2);
            diceList.Add(dice3);
            
            return diceList;
        }

        //３つのintを受け取り、役を返す
        public string GetDiceHand(int x, int y, int z)
        {
            
            if (x == y && y == z)   //ゾロ目
            {
                return x +"のゾロ目です";
            }
            else if (x == y || y == z || x == z)    //ニフ
            {
                if (x == y)
                {
                    return z + "ニフ";
                }
                if (y == z)
                {
                    return x + "ニフ";
                }
                if(x == z)
                {
                    return y + "ニフ";
                }
            }else
            {
                return "目無し";
            }
            return "";
        }
    }
}
