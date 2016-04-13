using System;

namespace Chapters.Entity
{
    [Serializable]
    public class Tea
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Form { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public int Sum { get; set; }

        public override string ToString()
        {
            return string.Format("Name:{0}, Type:{1}, Form:{2}, Price:{3}, Count:{4}, Sum:{5}", Name, Type, Form, Price, Count, Sum);
        }
    }
}