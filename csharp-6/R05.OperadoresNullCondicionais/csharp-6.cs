using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace csharp_6.R05
{
    class Program
    {
        void Main()
        {
            List<Student> students = new List<Student>();
            var student = students.FirstOrDefault();

            var first = student?.FirstName;
        }
    }

    public enum Standing
    {
        Freshman,
        Sophomore,
        Junior,
        Senior
    }

    public class Student
    {
        public string FirstName { get; }
        public string LastName { get; }

        public ICollection<double> Grades { get; } = new List<double>();
        public Standing YearInSchool { get; set; } = Standing.Freshman;

        public string FullName => string.Format("{0} {1}", FirstName, LastName);

        public Student(string firstName, string lastName)
        {
            if (IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
        }

        public void ChangeName(string newLastName)
        {
            // Generates CS0200: Property or indexer cannot be assigned to -- it is read only
            //LastName = newLastName;
        }

        public override string ToString() => string.Format("{0}, {1}", LastName, FirstName);

        public bool MakesDeansList()
        {
            return Grades.All(g => g > 3.5) && Grades.Any();
            // Code below generates CS0103: 
            // The name 'All' does not exist in the current context.
            //All(Grades, g => g > 3.5) && Grades.Any();
        }
    }
}
