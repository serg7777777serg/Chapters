using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapters.Common;
using Chapters.Entity;
using System.Threading;

namespace Chapters.Factories
{
    class Chapter92Factory
    {

        public static object[] PerformTask(TaskNumber number)
        {
            var A1_2 = new Lazy<Structures<Illness>>(() =>
                {
                    using (var illnessStream = @"Chapters.Embedded_resources.dataIllness.bin".ReadData().BaseStream)
                        return Structures<Illness>.Create(Chapter9_2TaskType.FromList, illnessStream.Deserialize<Illness>());
                });
            var A3_4 = new Lazy<Structures<Population>>(() =>
                {
                    using (var populationStream = @"Chapters.Embedded_resources.Populations.bin".ReadData().BaseStream)
                        return Structures<Population>.Create(Chapter9_2TaskType.FromList, populationStream.Deserialize<Population>());
                });
            var A5_6 = new Lazy<Structures<Graduation>>(() =>
                {
                    using (var graduationStream = @"Chapters.Embedded_resources.Graduations.bin".ReadData().BaseStream)
                        return Structures<Graduation>.Create(Chapter9_2TaskType.FromList, graduationStream.Deserialize<Graduation>());
                });
            var A7_8 = new Lazy<Structures<Credit>>(() =>
                    {
                        using (var creditStream = @"Chapters.Embedded_resources.Credits.bin".ReadData().BaseStream)
                            return Structures<Credit>.Create(Chapter9_2TaskType.FromList, creditStream.Deserialize<Credit>());
                    });
            var A9_10 = new Lazy<Structures<Journey>>(() =>
                    {
                        using (var journeyStream = @"Chapters.Embedded_resources.Journey.bin".ReadData().BaseStream)
                            return Structures<Journey>.Create(Chapter9_2TaskType.FromList, journeyStream.Deserialize<Journey>());
                    });
            var A11 = new Lazy<Structures<Client>>(() =>
                    {
                        using (var clientStream = @"Chapters.Embedded_resources.Client.bin".ReadData().BaseStream)
                            return Structures<Client>.Create(Chapter9_2TaskType.FromList, clientStream.Deserialize<Client>());
                    });
            var A12_13 = new Lazy<Structures<Coal>>(() =>
                {
                    using (var coalStream = @"Chapters.Embedded_resources.CoalMining.bin".ReadData().BaseStream)
                        return Structures<Coal>.Create(Chapter9_2TaskType.FromList, coalStream.Deserialize<Coal>());
                });
            var employeeListLazy = new Lazy<IEnumerable<Employee>>(() =>
                {
                    using (var employeeStream = @"Chapters.Embedded_resources.Employee.bin".ReadData().BaseStream)
                        return employeeStream.Deserialize<Employee>();
                });

            var A14_20 = new Lazy<Structures<Employee>>(() => Structures<Employee>.Create(Chapter9_2TaskType.FromList, employeeListLazy.Value));
            var A21_25 = new Lazy<Structures<Tea>>(
                () =>
                    {
                        using (var teaStream = @"Chapters.Embedded_resources.Tea.bin".ReadData().BaseStream)
                            return Structures<Tea>.Create(Chapter9_2TaskType.FromList, teaStream.Deserialize<Tea>());
                    });

            switch (number)
            {
                case TaskNumber.Task1:
                    //var illnessList1 = illnessStream.Deserialize<Illness>();
                    //var A1 = Structures<Illness>.Create(Chapter9_2TaskType.FromList,
                    //    illnessList1);
                    var res1 = A1_2.Value.AvegareIllnesses<Illness>()
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Average: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res1 };

                case TaskNumber.Task2:
                    //var illnessList2 = illnessStream.Deserialize<Illness>();
                    //var A2 = Structures<Illness>.Create(Chapter9_2TaskType.FromList,
                    //    illnessList2);
                    var res2 =
                        A1_2.Value.MinIllnesses<Illness>()
                            .OrderBy(y => y.Value)
                            .Aggregate(string.Empty, (x, y) =>
                            {
                                x += string.Format("Name: {0}, Average: {1}\n", y.Key, y.Value);
                                return x;
                            });
                    return new object[] { res2 };

                case TaskNumber.Task3:
                    //var populationList1 = populationStream.Deserialize<Population>();
                    //var A3 = Structures<Population>.Create(Chapter9_2TaskType.FromList, populationList1);
                    var res3 = A3_4.Value.AvegarePopulations<Population>().OrderBy(x => x.Key)
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Average: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res3 };

                case TaskNumber.Task4:
                    //var populationList2 = populationStream.Deserialize<Population>();
                    //var A4 = Structures<Population>.Create(Chapter9_2TaskType.FromList, populationList2);
                    var res4 = A3_4.Value.AvegarePopulations<Population>()
                        .OrderByDescending(x => x.Value)
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Average: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res4 };

                case TaskNumber.Task5:
                    //var graduationList1 = graduationStream.Deserialize<Graduation>();
                    //var A5 = Structures<Graduation>.Create(Chapter9_2TaskType.FromList, graduationList1);
                    var res5 = A5_6.Value.AvegareGraduations<Graduation>()
                        .Where(x => x.Value > 3.5)
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Average: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res5 };

                case TaskNumber.Task6:
                    //var graduationList2 = graduationStream.Deserialize<Graduation>();
                    //var A6 = Structures<Graduation>.Create(Chapter9_2TaskType.FromList, graduationList2);
                    var res6 = A5_6.Value.AvegareGraduations<Graduation>()
                        .OrderBy(x => x.Key)
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Average: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res6 };

                case TaskNumber.Task7:
                    //var creditList1 = creditStream.Deserialize<Credit>();
                    //var A7 = Structures<Credit>.Create(Chapter9_2TaskType.FromList, creditList1);
                    var res7 = A7_8.Value.CountCredits<Credit>()
                        .OrderBy(x => x.Key)
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Count: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res7 };

                case TaskNumber.Task8:
                    //var creditList2 = creditStream.Deserialize<Credit>();
                    //var A8 = Structures<Credit>.Create(Chapter9_2TaskType.FromList, creditList2);
                    var t = A7_8.Value.CountCredits<Credit>();
                    var res8 = t
                        .Where(x => x.Value > 1000).OrderBy(x => x.Key)
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Count: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res8 };

                case TaskNumber.Task9:
                    //var journeyList1 = journeyStream.Deserialize<Journey>();
                    //var A9 = Structures<Journey>.Create(Chapter9_2TaskType.FromList, journeyList1);
                    var res9 = A9_10.Value.CountJourneys<Journey>()
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Count: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res9 };

                case TaskNumber.Task10:
                    //var journeyList2 = journeyStream.Deserialize<Journey>();
                    //var A10 = Structures<Journey>.Create(Chapter9_2TaskType.FromList, journeyList2);
                    var res10 = A9_10.Value.AverageJourneys<Journey>()
                        .OrderByDescending(x => x.Value)
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Average: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res10 };

                case TaskNumber.Task11:
                    //var clientList1 = clientStream.Deserialize<Client>();
                    //var A11 = Structures<Client>.Create(Chapter9_2TaskType.FromList, clientList1);
                    return new object[] { A11.Value.Clients<Client>() };

                case TaskNumber.Task12:
                    //var coalList1 = coalStream.Deserialize<Coal>();
                    //var A12 = Structures<Coal>.Create(Chapter9_2TaskType.FromList, coalList1);
                    var res12 = A12_13.Value.CountCoals<Coal>()
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Count: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res12 };

                case TaskNumber.Task13:
                    //var coalList2 = coalStream.Deserialize<Coal>();
                    //var A13 = Structures<Coal>.Create(Chapter9_2TaskType.FromList, coalList2);
                    var res13 = A12_13.Value.SumCoals<Coal>()
                        .Aggregate(string.Empty, (x, y) =>
                        {
                            x += string.Format("Name: {0}, Sum: {1}\n", y.Key, y.Value);
                            return x;
                        });
                    return new object[] { res13 };

                case TaskNumber.Task14:
                    var res14 = A14_20.Value.Enumerate<Employee>().Aggregate(new StringBuilder(), (x, y) => x.AppendLine(y.DirtyMoney.ToString()));
                    return new object[] { res14 };

                case TaskNumber.Task15:
                    //var employeeList1 = employeeStream.Deserialize<Employee>();
                    //var A15 = Structures<Employee>.Create(Chapter9_2TaskType.FromList, employeeList1);
                                                
                    var orderedByName15 = A14_20.Value.OrderByName<Employee>().Aggregate(new StringBuilder(), (x, y) => x.AppendLine(y.ToString()));
                    var pensionersCount = A14_20.Value.CountPensionersAndYoung<Employee>();
                    return new object[] { orderedByName15, pensionersCount };

                case TaskNumber.Task16:
                    //var employeeList2 = employeeStream.Deserialize<Employee>();
                    //var A16 = Structures<Employee>.Create(Chapter9_2TaskType.FromList, employeeList2);
                    var res16 = A14_20.Value.Pensioners<Employee>().Count();
                    return new object[] { res16 };

                case TaskNumber.Task17:
                    //var employeeList3 = employeeStream.Deserialize<Employee>();
                    //var A17 = Structures<Employee>.Create(Chapter9_2TaskType.FromList, employeeList3);
                    var res17 = A14_20.Value.WithoutPensioners<Employee>();
                    return new object[] { res17 };

                case TaskNumber.Task18:
                    //var employeeList4 = employeeStream.Deserialize<Employee>();
                    //var A18 = Structures<Employee>.Create(Chapter9_2TaskType.FromList, employeeList4);
                    var count = A14_20.Value.YoungPhD<Employee>().Count();
                    var loosers = A14_20.Value.DeleteOlder40NotPhD<Employee>().Aggregate(new StringBuilder(), (x, y) => x.AppendLine(y.ToString()));
                    return new object[] { count, loosers };

                case TaskNumber.Task19:
                    //var employeeList5 = employeeStream.Deserialize<Employee>();
                    //var A19 = Structures<Employee>.Create(Chapter9_2TaskType.FromList, employeeList5);
                    var incomeTaxToPayOff = employeeListLazy.Value.Aggregate(new StringBuilder(), (x, y) => x.AppendFormat(y.Name.ToString() + " - Income tax: {0}, To payoff: {1}\n", y.Salary * 0.13, y.Salary * 0.87));
                    var sortedByPosition = A14_20.Value.OrderByPosition<Employee>().Aggregate(new StringBuilder(), (x, y) => x.AppendLine(y.ToString()));
                    return new object[] { incomeTaxToPayOff, A14_20.Value.FoundMinSalary<Employee>(), sortedByPosition };

                case TaskNumber.Task20:
                    //var employeeList6 = employeeStream.Deserialize<Employee>();
                    //var A20 = Structures<Employee>.Create(Chapter9_2TaskType.FromList, employeeList6);
                    var toPayOff = employeeListLazy.Value.Aggregate(new StringBuilder(), (x, y) => x.AppendFormat(y.Name.ToString() + "- {0}\n", y.Salary * 0.87));
                    var orderedByName = A14_20.Value.OrderByName<Employee>().Aggregate(new StringBuilder(), (x, y) => x.AppendLine(y.ToString()));
                    return new object[] { toPayOff, A14_20.Value.FoundMaxSalary<Employee>(), orderedByName };

                case TaskNumber.Task21:
                    //var teaList = teaStream.Deserialize<Tea>();
                    //var A21 = Structures<Tea>.Create(Chapter9_2TaskType.FromList, teaList);
                    var orderedBySum = A21_25.Value.OrderBySales<Tea>().Aggregate(new StringBuilder(), (x, y) => x.AppendLine(y.ToString()));
                    return new object[] { A21_25.Value.TotalCount<Tea>(), A21_25.Value.TotalSum<Tea>(), orderedBySum };

                case TaskNumber.Task22:
                    //var teaList1 = teaStream.Deserialize<Tea>();
                    //var A22 = Structures<Tea>.Create(Chapter9_2TaskType.FromList, teaList1);
                    var orderedByColor = A21_25.Value.OrderByColor<Tea>().Aggregate(new StringBuilder(), (x, y) => x.AppendLine(y.ToString()));
                    return new object[] { orderedByColor };

                case TaskNumber.Task23:
                    //var teaList2 = teaStream.Deserialize<Tea>();
                    //var A23 = Structures<Tea>.Create(Chapter9_2TaskType.FromList, teaList2);
                    var orderedByName23 = A21_25.Value.OrderByTeaName<Tea>().Aggregate(new StringBuilder(), (x, y) => x.AppendLine(y.ToString()));
                    return new object[] { orderedByName23, A21_25.Value.MaxSales<Tea>() };

                case TaskNumber.Task24:
                    //var teaList3 = teaStream.Deserialize<Tea>();
                    //var A24 = Structures<Tea>.Create(Chapter9_2TaskType.FromList, teaList3);
                    var orderedTypeForm = A21_25.Value.OrderByTypeForm<Tea>().Aggregate(new StringBuilder(), (x, y) => x.AppendLine(y.ToString()));
                    return new object[] { orderedTypeForm, A21_25.Value.maxSalesForm<Tea>() };

                case TaskNumber.Task25:
                    //var teaList4 = teaStream.Deserialize<Tea>();
                    //var A25 = Structures<Tea>.Create(Chapter9_2TaskType.FromList, teaList4);
                    var orderedByCount = A21_25.Value.OrderByCount<Tea>().Aggregate(new StringBuilder(), (x, y) => x.AppendLine(y.ToString()));
                    return new object[] { orderedByCount, A21_25.Value.TotalSum<Tea>() };

                default:
                    throw new ArgumentOutOfRangeException(number.GetType().Name, number, null);
            }
        }
    }
}