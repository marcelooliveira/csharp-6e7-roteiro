using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace CSharp6.R05
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("5. Operadores Null-Condicionais");

            try
            {
                var aluno = new Aluno("Ferris", "Bueller");
                Console.WriteLine(aluno.Prenome);
                Console.WriteLine(aluno.Sobrenome);

                aluno.Notas.Add(3.5);
                aluno.Notas.Add(4.5);
                aluno.Notas.Add(3);
                aluno.Notas.Add(5);

                Console.WriteLine();
                Console.WriteLine("NOTAS");
                Console.WriteLine("=====");

                foreach (var nota in aluno.Notas)
                {
                    Console.WriteLine(nota);
                }

                Console.WriteLine();
                Console.WriteLine(Format("Entrou na lista de honra? {0}", aluno.EntrouNaListaDeHonra()));

                List<Aluno> alunos = new List<Aluno>();
                var student = alunos.FirstOrDefault();

                var primeiro = student?.Prenome;
                Console.WriteLine();
                Console.WriteLine(Format("Primeiro aluno: {0}", primeiro));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }
    }

    public enum Ano
    {
        Primeiro,
        Segundo,
        Terceiro,
        Quarto
    }

    public class Aluno
    {
        public string Prenome { get; }
        public string Sobrenome { get; }

        public ICollection<double> Notas { get; } = new List<double>();
        public Ano AnoNaEscola { get; set; } = Ano.Primeiro;

        public string NomeCompleto => Format("{0} {1}", Prenome, Sobrenome);

        public Aluno(string prenome, string sobrenome)
        {
            if (IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException(message: "Não pode ser vazio", paramName: "sobrenome");

            Prenome = prenome;
            Sobrenome = sobrenome;
        }

        public void MudarNome(string novoSobrenome)
        {
            // Produz erro: CS0200: Property or indexer cannot be assigned to -- it is read only
            //Sobrenome = novoSobrenome;
        }

        public override string ToString() => Format("{0}, {1}", Sobrenome, Prenome);

        public bool EntrouNaListaDeHonra()
        {
            return Notas.All(g => g > 3.5) && Notas.Any();
            // Code below generates CS0103: 
            // The name 'All' does not exist in the current context.
            //All(Notas, g => g > 3.5) && Notas.Any();
        }
    }
}
