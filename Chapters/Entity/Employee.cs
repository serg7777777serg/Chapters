using System;

namespace Chapters.Entity
{
    [Serializable]
    public class Employee
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public string AcademicDegree { get; set; }
        public int YearBirth { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
        public double DirtyMoney { get; set; }

        public override string ToString()
        {
            return string.Format("Name:{0}, Gender:{1}, Position:{2}, AcademicDegree:{3}, YearBirth:{4}, Experience:{5}, Salary:{6}, DirtyMoney:{7}",Name,Gender,Position,AcademicDegree,YearBirth,Experience,Salary,DirtyMoney);
        }
    }
}