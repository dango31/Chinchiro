using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment
{
    internal static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {   Dice dice = new Dice();
            List<int> dices = dice.GetDiceList();
            string hands = dice.GetDiceHand(dices[0], dices[1], dices[2]);
            Console.WriteLine(hands)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            ;
        }
    }
}
