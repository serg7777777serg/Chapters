using System;

namespace Chapters.Entity
{
    [Serializable]
    public class Client
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public int YearBirth { get; set; }
        public int SavingSum { get; set; }
        public int Income { get; set; }
        public int Consumption { get; set; }
    }
}