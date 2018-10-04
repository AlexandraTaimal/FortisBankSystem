using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FortisBankSystem_AlexandraTaimal.bus
{
    public class Date
    {
        private int day;
        private int month;
        private int year;

        public int Day { get => day; set => day = value; }
        public int Month { get => month; set => month = value; }
        public int Year { get => year; set => year = value; }


        public Date()
        {
            this.Day = 00;
            this.Month = 00;
            this.Year = 0000;
        }

        public Date(int day, int month, int year)
        {
            this.Day = day;
            this.Month = month;
            this.Year = year;
        }

        public override string ToString()
        {
            String state;
            state = this.Day + " - " + this.Month + " - " + this.Year;
            return state;
        }

    }
}
