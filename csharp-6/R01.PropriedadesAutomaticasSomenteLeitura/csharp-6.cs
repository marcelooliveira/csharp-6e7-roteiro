using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R01
{
    public class Student
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Student(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));

            FirstName = firstName;
            LastName = lastName;
        }

        public void ChangeName(string newLastName)
        {
            // Generates CS0200: Property or indexer cannot be assigned to -- it is read only
            //LastName = newLastName;
        }
    }

}
