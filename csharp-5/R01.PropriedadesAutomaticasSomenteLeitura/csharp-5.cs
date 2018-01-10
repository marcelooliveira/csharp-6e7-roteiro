using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp5.R01
{
    class Programa
    {
        public void Main()
        {

            try
            {
                var aluno = new Aluno("Ferris", "Bueller");
                Console.WriteLine(aluno.Prenome);
                Console.WriteLine(aluno.Sobrenome);

                Console.WriteLine();

                var cameron = new Aluno("Cameron", "");
                Console.WriteLine(cameron.Prenome);
                Console.WriteLine(cameron.Sobrenome);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }
    }

    public class Aluno
    {
        public string Prenome { get; private set;  }
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
            // A próxima linha permite mudar valor da propriedade
            //logo a propriedade não é imutável!
            Sobrenome = novoSobrenome;
        }
    }

}
