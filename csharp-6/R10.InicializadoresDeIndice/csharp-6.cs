using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace CSharp6.R10
{
    class CSharp6
    {
        private List<string> messages = new List<string>
        {
            "Page not Found",
            "Page moved, but left a forwarding address.",
            "The web server can't come out to play today."
        };

        private Dictionary<int, string> webErrors = new Dictionary<int, string>
        {
            [404] = "Page not Found",
            [302] = "Page moved, but left a forwarding address.",
            [500] = "The web server can't come out to play today."
        };

    }

    public class Enrollment : IEnumerable<Student>
    {
        private List<Student> allStudents = new List<Student>();

        public void Enroll(Student s)
        {
            allStudents.Add(s);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return ((IEnumerable<Student>)allStudents).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Student>)allStudents).GetEnumerator();
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
