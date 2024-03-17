using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    internal class Chinchiroyaku
    {
       public string Hand { get; set; }
       public int Score {  get; set; }

        public int GetScore()
        {
            return this.Score;
        } 

        public string Getint()
        {
            return this.Hand;
        }


    }
}

