using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp5.R01
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Student(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(message: "Cannot be blank", paramName: "lastName");

            FirstName = firstName;
            LastName = lastName;
        }

        public void ChangeName(string newLastName)
        {
            // Podemos modificar a propriedade dentro de um método, logo ela não é imutável!
            LastName = newLastName;
        }
    }
}
