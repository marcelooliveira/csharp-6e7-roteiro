using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_5.R02
{
    public enum Standing
    {
        Freshman,
        Sophomore,
        Junior,
        Senior
    }

    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ICollection<double> Grades { get; private set; }
        public Standing YearInSchool { get; set; }


        public Student(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(message: "Cannot be blank", paramName: "lastName");

            FirstName = firstName;
            LastName = lastName;
            Grades = new List<double>();
            YearInSchool = Standing.Freshman;
        }
        public void ChangeName(string newLastName)
        {
            // Generates CS0200: Property or indexer cannot be assigned to -- it is read only
            //LastName = newLastName;
        }
    }
}
