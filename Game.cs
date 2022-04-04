using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualEcosystemTwo
{
    public class Game
    {
        private int day = 0;
        private int month = 0;
        public int Day { get => day; }
        public int Month { get => month; }
        public string[] months = { "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC" };
        public Game()
        {

        }

        public void NextDay()
        {
            day++;
            if (day > 10)
            {
                day = 1;
                if (month < months.Length-1)
                {
                    month++;
                }
                else
                {
                    month = 0;
                }
            }
        }

        public void GameOver()
        {
            System.Environment.Exit(0);
        }
       
    }
}
