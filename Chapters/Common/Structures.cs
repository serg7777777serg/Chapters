using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography.X509Certificates;
using Chapters.Entity;
using Chapters.Common;

namespace Chapters.Common
{
    class Structures<T> where T: class, new()
    {
        public Structures(IEnumerable<T> data)
        {
            Data = data;
            //100000.RandomizeSavings().ToList().Serialize(@"D:\Client.bin");
            //100000.RandomizeCoalMining().ToList().Serialize(@"D:\CoalMining.bin");
        }

        private IEnumerable<T> Data { get; }

        private Dictionary<string, Dictionary<int, int>> GroupKeyValuePairIllness<T>() where T : Illness
        {
            var temp = Data
                .Cast<T>()
                .GroupBy(x => new { x.Name, x.Date.Month });
            var res = new Dictionary<string, Dictionary<int, int>>();
            foreach (var t in temp)
            {
                Dictionary<int, int> illnessStat;
                res.TryGetValue(t.Key.Name, out illnessStat);
                if (illnessStat == null)
                {
                    illnessStat = new Dictionary<int, int>();
                    res.Add(t.Key.Name, illnessStat);
                }

                var nRecords = t.Count();

                var count = 0;
                illnessStat.TryGetValue(t.Key.Month, out count);

                if (count == 0)
                {
                    illnessStat.Add(t.Key.Month, nRecords);
                    continue;
                }
                illnessStat[t.Key.Month] = illnessStat[t.Key.Month] + nRecords;
            }
            return res;
        }

        private Dictionary<string, Dictionary<int, int>> GroupKeyValuePairPopulation<T>() where T : Population
        {
            var temp = Data
                .Cast<T>()
                .GroupBy(x => new { x.Name, x.Year });
            var res = new Dictionary<string, Dictionary<int, int>>();
            foreach (var t in temp)
            {
                Dictionary<int, int> populationStat;
                res.TryGetValue(t.Key.Name, out populationStat);
                if (populationStat == null)
                {
                    populationStat = new Dictionary<int, int>();
                    res.Add(t.Key.Name, populationStat);
                }

                var nRecords = t.Count();

                var count = 0;
                populationStat.TryGetValue(t.Key.Year, out count);

                if (count == 0)
                {
                    populationStat.Add(t.Key.Year, nRecords);
                    continue;
                }
                populationStat[t.Key.Year] = populationStat[t.Key.Year] + nRecords;
            }
            return res;
        }

        private Dictionary<string, Dictionary<int, int>> GroupKeyValuePairGraduation<T>() where T : Graduation
        {
            var temp = Data
                .Cast<T>()
                .GroupBy(x => new { x.LastName, x.SemestrNumber });
            var res = new Dictionary<string, Dictionary<int, int>>();
            foreach (var t in temp)
            {
                Dictionary<int, int> graduationStat;
                res.TryGetValue(t.Key.LastName, out graduationStat);
                if (graduationStat == null)
                {
                    graduationStat = new Dictionary<int, int>();
                    res.Add(t.Key.LastName, graduationStat);
                }

                var nRecords = t.Count();

                var count = 0;
                graduationStat.TryGetValue(t.Key.SemestrNumber, out count);

                if (count == 0)
                {
                    graduationStat.Add(t.Key.SemestrNumber, nRecords);
                    continue;
                }
                graduationStat[t.Key.SemestrNumber] = graduationStat[t.Key.SemestrNumber] + nRecords;
            }
            return res;
        }

        private Dictionary<string, Dictionary<int, int>> GroupKeyValuePairCredit<T>() where T : Credit
        {
            var temp = Data
                .Cast<T>()
                .GroupBy(x => new { x.Name, x.Year });
            var res = new Dictionary<string, Dictionary<int, int>>();
            foreach (var t in temp)
            {
                Dictionary<int, int> creditStat;
                res.TryGetValue(t.Key.Name, out creditStat);
                if (creditStat == null)
                {
                    creditStat = new Dictionary<int, int>();
                    res.Add(t.Key.Name, creditStat);
                }

                var nRecords = t.Count();

                var count = 0;
                creditStat.TryGetValue(t.Key.Year, out count);

                if (count == 0)
                {
                    creditStat.Add(t.Key.Year, nRecords);
                    continue;
                }
                creditStat[t.Key.Year] = creditStat[t.Key.Year] + nRecords;
            }
            return res;
        }

        private Dictionary<string, Dictionary<int, int>> GroupKeyValuePairJourney<T>() where T : Journey
        {
            var temp = Data
                .Cast<T>()
                .GroupBy(x => new { x.Name, x.Price });
            var res = new Dictionary<string, Dictionary<int, int>>();
            foreach (var t in temp)
            {
                Dictionary<int, int> journeyStat;
                res.TryGetValue(t.Key.Name, out journeyStat);
                if (journeyStat == null)
                {
                    journeyStat = new Dictionary<int, int>();
                    res.Add(t.Key.Name, journeyStat);
                }

                var nRecords = t.Count();

                var count = 0;
                journeyStat.TryGetValue(t.Key.Price, out count);

                if (count == 0)
                {
                    journeyStat.Add(t.Key.Price, nRecords);
                    continue;
                }
                journeyStat[t.Key.Price] = journeyStat[t.Key.Price] + nRecords;
            }
            return res;
        }

        private Dictionary<string, Dictionary<DayOfWeek, int>> GroupKeyValuePairCoal<T>() where T : Coal
        {
            var temp = Data
                .Cast<T>()
                .GroupBy(x => new { x.WeekDay, x.Price });
            var res = new Dictionary<string, Dictionary<DayOfWeek, int>>();
            foreach (var t in temp)
            {
                Dictionary<DayOfWeek, int> coalStat;
                res.TryGetValue(t.Key.WeekDay.ToString(), out coalStat);
                if (coalStat == null)
                {
                    coalStat = new Dictionary<DayOfWeek, int>();
                    res.Add(t.Key.WeekDay.ToString(), coalStat);
                }

                var nRecords = t.Count();

                var count = 0;
                coalStat.TryGetValue(t.Key.WeekDay, out count);

                if (count == 0)
                {
                    coalStat.Add(t.Key.WeekDay, nRecords);
                    continue;
                }
                coalStat[t.Key.WeekDay] = coalStat[t.Key.WeekDay] + nRecords;
            }
            return res;
        }

        private Tuple<List<T>, double, int, int> ClientsPerformStatistics<T>() where T : Client
        {
            var _data = Data.Cast<T>();
            return Tuple.Create(_data.OrderBy(x => x.Name).ToList(),
                Convert.ToDouble(_data.Sum(x => x.Income) - _data.Sum(x => x.Consumption)),
                _data.Count(x => x.Income > 0), _data.Count(x => x.Consumption > 0));
        }

        //1
        public Dictionary<string, double> AvegareIllnesses<T>() where T: Illness
        {
            return GroupKeyValuePairIllness<T>().ToDictionary(x => x.Key, y => y.Value.Values.Average());
        }

        //2
        public Dictionary<string, int> MinIllnesses<T>() where T : Illness
        {
            return GroupKeyValuePairIllness<T>().ToDictionary(x => x.Key, y => y.Value.Values.Min());
        }

        //3, 4
        public Dictionary<string, double> AvegarePopulations<T>() where T : Population
        {
            return GroupKeyValuePairPopulation<T>().ToDictionary(x => x.Key, y => y.Value.Values.Average());
        }

        //5,6
        public Dictionary<string, double> AvegareGraduations<T>() where T : Graduation
        {
            return GroupKeyValuePairGraduation<T>().ToDictionary(x => x.Key, y => y.Value.Values.Average());
        }

        //7,8
        public Dictionary<string, int> CountCredits<T>() where T : Credit
        {
            var t = GroupKeyValuePairCredit<T>();
            return t.ToDictionary(x => x.Key, y => y.Value.Values.Max());
        }

        //9
        public Dictionary<string, int> CountJourneys<T>() where T : Journey
        {
            return GroupKeyValuePairJourney<T>().ToDictionary(x => x.Key, y => y.Value.Values.Max());
        }

        //10
        public Dictionary<string, double> AverageJourneys<T>() where T : Journey
        {
            return GroupKeyValuePairJourney<T>().ToDictionary(x => x.Key, y => y.Value.Values.Average());
        }

        //11
        public Tuple<List<T>, double, int, int> Clients<T>() where T : Client
        {
            return ClientsPerformStatistics<T>();
        }

        //12
        public Dictionary<string, int> CountCoals<T>() where T : Coal
        {
            return GroupKeyValuePairCoal<T>().ToDictionary(x => x.Key, y => y.Value.Values.Count);
        }

        //13
        public Dictionary<string, int> SumCoals<T>() where T : Coal
        {
            return GroupKeyValuePairCoal<T>().ToDictionary(x => x.Key, y => y.Value.Values.Sum());
        }

        //14
        public IEnumerable<T> Enumerate<T>() where T : Employee
        { return Data.Cast<T>(); }

        //15
        public IEnumerable<T> OrderByName<T>() where T : Employee
        {
            return Data.Cast<T>().OrderBy(x => x.Name);
        }
        //15
        public int CountPensionersAndYoung<T>() where T : Employee
        {
            return Data.Cast<T>().Count(x => DateTime.UtcNow.Year - x.YearBirth > 60 || DateTime.UtcNow.Year - x.YearBirth <= 25);
        }

        //16
        public IEnumerable<T> Pensioners<T>() where T : Employee
        {
            return Data.Cast<T>().Where(x => (x.Gender == "Woman" && DateTime.UtcNow.Year - x.YearBirth > 55) || (x.Gender == "Men" && DateTime.UtcNow.Year - x.YearBirth > 60));
        }

        //17
        public IEnumerable<T> WithoutPensioners<T>() where T : Employee
        {
            return Data.Cast<T>().Where(x => (x.Gender == "Woman" && x.Position != "Specialist" && DateTime.UtcNow.Year - x.YearBirth <= 55) || (x.Gender == "Men" && x.Position != "Specialist" && DateTime.UtcNow.Year - x.YearBirth <= 60));
        }

        //18
        public IEnumerable<T> YoungPhD<T>() where T : Employee
        {
            return Data.Cast<T>().Where(x => x.AcademicDegree == "Ph.D" && (DateTime.UtcNow.Year - x.YearBirth) < 35);
        }

        //18
        public IEnumerable<T> DeleteOlder40NotPhD<T>() where T : Employee
        {
            return Data.Cast<T>().Where(x => x.AcademicDegree != "Ph.D" && DateTime.UtcNow.Year - x.YearBirth <= 40);
        }

        //19
        public int FoundMinSalary<T>() where T : Employee
        {
            var employees = Data.Cast<T>();
            return employees.Count(x => x.Salary == employees.Min(y => y.Salary));
        }
        //19
        public int FoundMaxSalary<T>() where T : Employee
        {
            var employees = Data.Cast<T>();
            return employees.Count(x => x.Salary == employees.Max(y => y.Salary));
        }
        //19
        public IEnumerable<T> OrderByPosition<T>() where T : Employee
        {
            return Data.Cast<T>().OrderBy(x => x.Position);
        }
        
        //21
        public int TotalCount<T>() where T : Tea
        {
            return Data.Cast<Tea>().Sum(x => x.Count);
        }
        //21
        public Int64 TotalSum<T>() where T : Tea
        {
            return Data.Cast<Tea>().Sum(x => x.Sum);
        }
        //21
        public IEnumerable<T> OrderBySales<T>() where T : Tea
        {
            return Data.Cast<T>().OrderBy(x => x.Sum);
        }

        //22
        public IEnumerable<T> OrderByColor<T>() where T : Tea
        { return Data.Cast<T>().OrderBy(x => x.Type); }

        //23
        public IEnumerable<T> OrderByTeaName<T>() where T : Tea
        {
            return Data.Cast<T>().OrderBy(x => x.Name);
        }
        //23
        public string MaxSales<T>() where T : Tea
        {
            var temp = Data.Cast<T>().
                GroupBy(x => x.Name).
                Select(x => new { Name = x.Key, Sum = x.Sum(y => y.Sum) }).
                OrderByDescending(x => x.Sum).
                First();
            return string.Format("Name: {0}, Sum: {1}", temp.Name, temp.Sum);
        }

        //24
        public IEnumerable<T> OrderByTypeForm<T>() where T : Tea
        { return Data.Cast<T>().OrderBy(x => x.Type).OrderBy(x => x.Form); }
        //24
        public string maxSalesForm<T>() where T : Tea
        {
            var temp = Data.Cast<T>().
                GroupBy(x => x.Form).
                Select(x => new { Form = x.Key, Sum = x.Sum(y => y.Sum) }).
                OrderByDescending(x => x.Sum).
                First();
            return string.Format("Name: {0}, Sum: {1}", temp.Form, temp.Sum);
        }

        //25
        public IEnumerable<T> OrderByCount<T>() where T : Tea
        {
            return Data.Cast<T>().OrderBy(x => x.Count);
        }
             

        public static Structures<T> Create(Chapter9_2TaskType type, object param = null)
        {
            switch (type)
            {
                case Chapter9_2TaskType.FromList:
                    return new Structures<T>(param as IEnumerable<T>);
                default:
                    throw new ArgumentOutOfRangeException(type.GetType().Name, type, null);
            }
        }
    }
}
