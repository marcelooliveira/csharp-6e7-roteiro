using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace CSharp6.R11
{
    class CSharp6
    {
        public CSharp6()
        {
            var classList = new Enrollment()
            {
                new Student("Lessie", "Crosby"),
                new Student("Vicki", "Petty"),
                new Student("Ofelia", "Hobbs"),
                new Student("Leah", "Kinney"),
                new Student("Alton", "Stoker"),
                new Student("Luella", "Ferrell"),
                new Student("Marcy", "Riggs"),
                new Student("Ida", "Bean"),
                new Student("Ollie", "Cottle"),
                new Student("Tommy", "Broadnax"),
                new Student("Jody", "Yates"),
                new Student("Marguerite", "Dawson"),
                new Student("Francisca", "Barnett"),
                new Student("Arlene", "Velasquez"),
                new Student("Jodi", "Green"),
                new Student("Fran", "Mosley"),
                new Student("Taylor", "Nesmith"),
                new Student("Ernesto", "Greathouse"),
                new Student("Margret", "Albert"),
                new Student("Pansy", "House"),
                new Student("Sharon", "Byrd"),
                new Student("Keith", "Roldan"),
                new Student("Martha", "Miranda"),
                new Student("Kari", "Campos"),
                new Student("Muriel", "Middleton"),
                new Student("Georgette", "Jarvis"),
                new Student("Pam", "Boyle"),
                new Student("Deena", "Travis"),
                new Student("Cary", "Totten"),
                new Student("Althea", "Goodwin")
            };
        }
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

    public static class StudentExtensions
    {
        public static void Add(this Enrollment e, Student s) => e.Enroll(s);
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
