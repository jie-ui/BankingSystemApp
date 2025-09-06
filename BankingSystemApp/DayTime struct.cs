using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_Application
{
    public struct DayTime
    {
        private long minutes;

        //constructor
        public DayTime(long minutes)
        {
            this.minutes = minutes;
        }
        public static DayTime operator +(DayTime lhs, int minutes)
        {
            return new DayTime(lhs.minutes + minutes);
        }

        public override string ToString()
        {
            long m = minutes;
            int year = 2023 + (int)(m / 518400);
            m %= 518400;
            int month = 1 + (int)(m / 43200); m %= 43200;
            int day = 1 + (int)(m / 1440); m %= 1440;
            int hour = (int)(m / 60);
            int minute = (int)(m % 60);

            return $"{year:0000}-{month:00}-{day:00} {hour:00}:{minute:00}";

        }
    }
  }
