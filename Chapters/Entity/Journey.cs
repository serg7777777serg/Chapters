using System;

namespace Chapters.Entity
{
    [Serializable]
    public class Journey
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Month { get; set; }
    }
}