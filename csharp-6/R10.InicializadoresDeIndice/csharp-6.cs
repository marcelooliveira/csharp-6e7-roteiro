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

    public class ListaDeMatricula : IEnumerable<Aluno>
    {
        private List<Aluno> todosAlunos = new List<Aluno>();

        public void Matricular(Aluno s)
        {
            todosAlunos.Add(s);
        }

        public IEnumerator<Aluno> GetEnumerator()
        {
            return ((IEnumerable<Aluno>)todosAlunos).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Aluno>)todosAlunos).GetEnumerator();
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

        public string NomeCompleto => $"{Prenome} {Sobrenome}";


        public Aluno(string prenome, string sobrenome)
        {
            if (IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException(message: "Não pode ser vazio", paramName: nameof(sobrenome));

            Prenome = prenome;
            Sobrenome = sobrenome;
        }

        public void MudarNome(string novoSobrenome)
        {
            // Produz erro: CS0200: Property or indexer cannot be assigned to -- it is read only
            //Sobrenome = novoSobrenome;
        }

        public override string ToString() => $"{Sobrenome}, {Prenome}";

        public string GetNotaMedia() =>
            $"Name: {Sobrenome}, {Prenome}. G.P.A: {Notas.Average()}";

        public string GetPorcentagemNotaMedia() =>
            $"Name: {Sobrenome}, {Prenome}. G.P.A: {Notas.Average():F2}";

        public string GetPorcentagemNotaMedias() =>
            $"Name: {Sobrenome}, {Prenome}. G.P.A: {(Notas.Any() ? Notas.Average() : double.NaN):F2}";

        public string GetTodasNotas() =>
            $@"All Notas: {Notas.OrderByDescending(g => g)
            .Select(s => s.ToString("F2")).Aggregate((parcial, elemento) => $"{parcial}, {elemento}")}";

        public bool EntrouNaListaDeHonra()
        {
            return Notas.All(g => g > 3.5) && Notas.Any();
            // Code below generates CS0103: 
            // The name 'All' does not exist in the current context.
            //All(Notas, g => g > 3.5) && Notas.Any();
        }
    }
}
