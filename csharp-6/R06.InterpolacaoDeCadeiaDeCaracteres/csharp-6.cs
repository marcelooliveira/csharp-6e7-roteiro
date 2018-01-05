using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace CSharp6.R06
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

        public string FullName => $"{FirstName} {LastName}";


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

        public override string ToString() => $"{LastName}, {FirstName}";

        public string GetFormattedGradePoint() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Average()}";

        public string GetGradePointPercentage() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Average():F2}";

        public string GetGradePointPercentages() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {(Grades.Any() ? Grades.Average() : double.NaN):F2}";

        public string GetAllGrades() =>
            $@"All Grades: {Grades.OrderByDescending(g => g)
            .Select(s => s.ToString("F2")).Aggregate((partial, element) => $"{partial}, {element}")}";

        public bool MakesDeansList()
        {
            return Grades.All(g => g > 3.5) && Grades.Any();
            // Code below generates CS0103: 
            // The name 'All' does not exist in the current context.
            //All(Grades, g => g > 3.5) && Grades.Any();
        }
    }
}
