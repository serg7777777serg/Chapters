using System;

namespace Chapters.Entity
{
    [Serializable]
    public class Coal
    {
        public int Number { get; set; }
        public int Price { get; set; }
        public DayOfWeek WeekDay { get; set; }
    }
}