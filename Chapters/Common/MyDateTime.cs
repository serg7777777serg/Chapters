using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapters.Common
{
    public class MyDateTime
    {
        private uint Hour { get; }
        private uint Minute { get; }
        private uint Second { get; }

        private uint Day { get; }
        private uint Month { get; }
        private uint Year { get; }

        public MyDateTime(uint year = 0, uint month = 0, uint day = 0, uint hour = 0, uint minute = 0, uint second = 0   )
        {
            Year = year;
            Month = month;
            Day = day;

            Hour = hour;
            Minute = minute;
            Second = second;             
        }
        private UInt64 ToSeconds()
        {
            return Second + Minute * 60 + Hour * 3600 + Day*86400 + MonthToSecond() + YearToSecond();
        }
        
        private uint MonthToSecond()
        {
            switch (Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31 * 86400;
                case 2:
                    return isLeapYear() ? (uint)29 * 86400 : (uint)28 * 86400 ;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30 * 86400;
                default:
                    return 0;
            }
        }
       
        private uint YearToSecond()
        {
            return isLeapYear() ? (uint)366 * 86400 : (uint)365 * 86400;
        }

        public bool isLeapYear()
        {
            return (Year % 4 == 0 && Year % 100 != 0) || Year % 400 == 0;
        }

        public static MyDateTime operator +(MyDateTime D1, MyDateTime D2)
        {
            var sum = new TimeSpan((int)D1.Hour, (int)D1.Minute, (int)D1.Second) + new TimeSpan((int)D2.Hour, (int)D2.Minute, (int)D2.Second);
            return new MyDateTime(0,0,(uint)sum.Days,(uint)sum.Hours,(uint)sum.Minutes,(uint)sum.Seconds);
        }

        public static MyDateTime operator +(MyDateTime D1, int d)
        {
            var t = new DateTime((int)D1.Year, (int)D1.Month, (int)D1.Day).AddDays(d);
            return new MyDateTime((uint)t.Year,(uint)t.Month,(uint)t.Day, D1.Hour, D1.Minute, D1.Second);
        }
       
        public static TimeSpan operator -(MyDateTime D1, MyDateTime D2)
        {
            return new DateTime((int)D1.Year, (int)D1.Month, (int)D1.Day, (int)D1.Hour, (int)D1.Minute, (int)D1.Second) - 
                   new DateTime((int)D2.Year, (int)D2.Month, (int)D2.Day, (int)D2.Hour, (int)D2.Minute, (int)D2.Second);
        }

        public static bool operator >(MyDateTime DT1, MyDateTime DT2)
        {
            if(DT1.Year > DT2.Year) return true;
            if(DT1.Year < DT2.Year) return false;
            if(DT1.Year == DT2.Year)
            {
                if(DT1.Month > DT2.Month) return true;
                if(DT1.Month < DT2.Month) return false;
                if (DT1.Month == DT2.Month)
                {
                    if (DT1.Day > DT2.Day) return true;
                    if (DT1.Day < DT2.Day) return false;
                    if (DT1.Day == DT2.Day)
                    {
                        if (DT1.Hour > DT2.Hour) return true;
                        if (DT1.Hour < DT2.Hour) return false;
                        if (DT1.Hour == DT2.Hour)
                        {
                            if (DT1.Minute > DT2.Minute) return true;
                            if (DT1.Minute < DT2.Minute) return false;
                            if (DT1.Minute == DT2.Minute)
                            {
                                if (DT1.Second > DT2.Second) return true;
                                if (DT1.Second < DT2.Second) return false;
                                if (DT1.Second == DT2.Second) return false;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static bool operator <(MyDateTime DT1, MyDateTime DT2)
        {
            return !(DT1>DT2);
        }

        public string DayPart()
        {
            if (Hour>=0 && Hour < 6)
                return "Night";
            if (Hour >= 6 && Hour < 12)
                return "Morning";
            if (Hour >= 12 && Hour < 18)
                return "Day";
            if (Hour >= 18 && Hour < 24)
                return "Evening";
            return "";
        }

        public string Season()
        {
            switch (Month)
            {
                case 12:
                case 1:
                case 2:
                    return "Winter";
                case 3:
                case 4:
                case 5:
                    return "Spring";
                case 6:
                case 7:
                case 8:
                    return "Summer";
                case 9:
                case 10:
                case 11:
                    return "Autumn";
                default: return "";
            }
        }

        public override string ToString()
        {
            return string.Format("Date: {0}.{1}.{2}, Time: {3}:{4}:{5}", Year, Month, Day, Hour, Minute, Second);
        }

        public static MyDateTime Create(Chapter10TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter10TaskType.FromString:
                    return new MyDateTime(uint.Parse((param as string[])[0]), uint.Parse((param as string[])[1]), uint.Parse((param as string[])[2]),
                        uint.Parse((param as string[])[3]), uint.Parse((param as string[])[4]), uint.Parse((param as string[])[5]));

                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }
    }
}
