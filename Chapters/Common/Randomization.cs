using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Chapters.Entity;

namespace Chapters.Common
{
    static class Randomization
    {
        public static IEnumerable<Illness> RandomizeIllnesses(this int numberOfRecords)
        {
            var r = new Random((int)DateTime.UtcNow.Ticks);
            var illnessNames = new[] { "Грипп", "Астма", "Гайморит", "Геморрой", "Сколиоз" };
            var dateFrom = new DateTime(2015, 1, 1);
            var dateTo = new DateTime(2015, 12, 31);

            for (var i = 0; i < numberOfRecords; i++)
            {
                yield return new Illness
                {
                    Date = r.GetRandomDate(dateFrom, dateTo),
                    Name = r.GetRandomElement(illnessNames)
                };
            }
        }

        public static IEnumerable<Population> RandomizePopulations(this int numberOfRecords)
        {
            var r = new Random((int)DateTime.UtcNow.Ticks);
            var PopulationsNames = new[] { "Kiev", "Donetsk", "Lvov", "Chernigov", "Kherson" };
            var dateFrom = new DateTime(1996, 1, 1);
            var dateTo = new DateTime(2015, 12, 31);

            for (var i = 0; i < numberOfRecords; i++)
            {
                yield return new Population
                {
                    Year = r.GetRandomDate(dateFrom, dateTo).Year,
                    Name = r.GetRandomElement(PopulationsNames)
                };
            }
        }

        public static IEnumerable<Graduation> RandomizeGraduations(this int numberOfRecords)
        {
            var r = new Random((int)DateTime.UtcNow.Ticks);
            var GraduationsNames = new[] { "Ivanov1", "Petrov1", "Sidorov1", "Testov1", "Ivanov2", "Petrov2", "Sidorov2", "Testov2" };

            for (var i = 0; i < numberOfRecords; i++)
            {
                yield return new Graduation
                {
                    SemestrNumber = r.Next(1, 10),
                    LastName = r.GetRandomElement(GraduationsNames)
                };
            }
        }

        public static IEnumerable<Credit> RandomizeCredits(this int numberOfRecords)
        {
            var r = new Random((int)DateTime.UtcNow.Ticks);
            var CreditsNames = new[] { "Alfa", "Unicredit", "Privat", "Stolichniy", "Platinum", "Aval" };
            var dateFrom = new DateTime(1999, 1, 1);
            var dateTo = new DateTime(2015, 12, 31);

            for (var i = 0; i < numberOfRecords; i++)
            {
                yield return new Credit
                {
                    Year = r.GetRandomDate(dateFrom, dateTo).Year,
                    Name = r.GetRandomElement(CreditsNames)
                };
            }
        }

        public static IEnumerable<Journey> RandomizeJourneys(this int numberOfRecords)
        {
            var r = new Random((int)DateTime.UtcNow.Ticks);
            var JourneysNames = new[] { "Greece", "Italy", "Tunis", "Chernigoria", "France", "Turkey", "Arabian Emirates" };
            var monthFrom = new DateTime(2015, 4, 1).Month;
            var monthTo = new DateTime(2015, 9, 1).Month;

            for (var i = 0; i < numberOfRecords; i++)
            {
                yield return new Journey
                {
                    Month = r.Next(monthFrom, monthTo),
                    Name = r.GetRandomElement(JourneysNames),
                    Price = r.Next(100, 800)
                };
            }
        }

        public static IEnumerable<Coal> RandomizeCoalMining(this int numberOfRecords)
        {
            var r = new Random((int)DateTime.UtcNow.Ticks);
            var dateFrom = new DateTime(2016, 3, 7);
            var dateTo = new DateTime(2016, 3, 11);

            for (var i = 0; i < numberOfRecords; i++)
            {
                yield return new Coal
                {
                    WeekDay = r.GetRandomDate(dateFrom, dateTo).DayOfWeek,
                    Number = r.Next(1, numberOfRecords),
                    Price = r.Next(100, 3000)
                };
            }
        }

        public static IEnumerable<Client> RandomizeSavings(this int numberOfRecords)
        {
            var r = new Random((int)DateTime.UtcNow.Ticks);
            var SavingsNames = new[] { "Ivanov I.I.", "Petrov P.P", "Sidorov A.A.", "Krasnov K.K.", "Belov B.B.", "Valuev N.N", "Kukuev K.K." };
           
            for (var i = 0; i < numberOfRecords; i++)
            {
                int amount = r.Next(0, 5000);
                bool isIncome = Convert.ToBoolean(r.Next(0, 2));
                yield return new Client
                {
                    Number = r.Next(1, 1000000000).ToString(),
                    Name = r.GetRandomElement(SavingsNames),
                    YearBirth = r.Next(1945, 1998),
                    SavingSum = r.Next(1000, 5000),
                    Income = isIncome ? amount : 0,
                    Consumption = !isIncome ? amount : 0
                };
            }
        }

        public static IEnumerable<Employee> RandomizeEmployees(this int numberOfRecords)
        {
            var r = new Random((int)DateTime.UtcNow.Ticks);
            var EmployeesNames = new[] { "Ivanov I.I.", "Petrov P.P", "Sidorov A.A.", "Krasnov K.K.", "Belov B.B.", "Valuev N.N", "Kukuev K.K." };
            var AcademicDegrees = new[] { "Bachelor", "Specialist", "Master", "Ph.D" };
            var Positions = new[] { "Intern", "Junior", "Middle", "Team lead", "Senior", "Project manager" };
            
            for (var i = 0; i < numberOfRecords; i++)
            {
                int amount = r.Next(1500, 10000);
                bool isMen = Convert.ToBoolean(r.Next(0, 2));
                var experience = r.Next(2, 45);
                yield return new Employee
                {
                    Name = r.GetRandomElement(EmployeesNames),
                    Gender = isMen ? "Men" : "Woman",
                    Position = r.GetRandomElement(Positions),
                    AcademicDegree = r.GetRandomElement(AcademicDegrees),
                    YearBirth = r.Next(1945, 1990),
                    Salary = amount,
                    Experience = experience,
                    DirtyMoney = amount + (experience<10 ? 0 : (experience>=10 && experience<=20 ? amount*0.1 : amount*0.15))
                };
            }
        }

        public static IEnumerable<Tea> RandomizeTeas(this int numberOfRecords)
        {
            var r = new Random((int)DateTime.UtcNow.Ticks);
            var TeasNames = new[] { "Askold", "Lipton", "Ahmad", "Golden dragon", "Greenfiled", "Riston", "Tes", "Batik" };
            var Types = new[] { "green", "black", "red", "yellow" };
            var Forms = new[] { "package", "farfor", "tin", "pyramid", "bag" };

            for (var i = 0; i < numberOfRecords; i++)
            {
                int price = r.Next(50, 400);
                int count = r.Next(10, 30);
                var sum = price*count;
                yield return new Tea
                {
                    Name = r.GetRandomElement(TeasNames),
                    Type = r.GetRandomElement(Types),
                    Form = r.GetRandomElement(Forms),
                    Price = price,
                    Count = count,
                    Sum = sum
                };
            }
        }
    }
}
