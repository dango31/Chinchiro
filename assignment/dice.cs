using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal class dice
    {
        //クラスを生成した際、三つのランダムの値を生成する
        public List<int> Dice()
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
    }
}
