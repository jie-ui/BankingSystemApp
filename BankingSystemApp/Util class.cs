using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public static class Util
    {
        private static Random random = new Random();
        private static DayTime currentTime = new DayTime(1_111_715);

        public static DayTime Now
        {
            get
            {
                int increment = random.Next(100);
                currentTime = currentTime + increment;
                return currentTime;
            }
        }
    }
}
