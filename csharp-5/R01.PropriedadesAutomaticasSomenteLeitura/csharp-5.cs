using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp5.R01
{
    public class Aluno
    {
        public string Prenome { get; private set; }
        public string Sobrenome { get; private set; }

        public Aluno(string prenome, string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException(message: "Não pode ser vazio", paramName: "sobrenome");

            Prenome = prenome;
            Sobrenome = sobrenome;
        }

        public void MudarNome(string novoSobrenome)
        {
            // Podemos modificar a propriedade dentro de um método, logo ela não é imutável!
            Sobrenome = novoSobrenome;
        }
    }
}
