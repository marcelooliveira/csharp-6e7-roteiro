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
            var classList = new ListaDeMatricula()
            {
                new Aluno("Lessie", "Crosby"),
                new Aluno("Vicki", "Petty"),
                new Aluno("Ofelia", "Hobbs"),
                new Aluno("Leah", "Kinney"),
                new Aluno("Alton", "Stoker"),
                new Aluno("Luella", "Ferrell"),
                new Aluno("Marcy", "Riggs"),
                new Aluno("Ida", "Bean"),
                new Aluno("Ollie", "Cottle"),
                new Aluno("Tommy", "Broadnax"),
                new Aluno("Jody", "Yates"),
                new Aluno("Marguerite", "Dawson"),
                new Aluno("Francisca", "Barnett"),
                new Aluno("Arlene", "Velasquez"),
                new Aluno("Jodi", "Green"),
                new Aluno("Fran", "Mosley"),
                new Aluno("Taylor", "Nesmith"),
                new Aluno("Ernesto", "Greathouse"),
                new Aluno("Margret", "Albert"),
                new Aluno("Pansy", "House"),
                new Aluno("Sharon", "Byrd"),
                new Aluno("Keith", "Roldan"),
                new Aluno("Martha", "Miranda"),
                new Aluno("Kari", "Campos"),
                new Aluno("Muriel", "Middleton"),
                new Aluno("Georgette", "Jarvis"),
                new Aluno("Pam", "Boyle"),
                new Aluno("Deena", "Travis"),
                new Aluno("Cary", "Totten"),
                new Aluno("Althea", "Goodwin")
            };
        }
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

    public static class AlunoExtensions
    {
        public static void Add(this ListaDeMatricula e, Aluno s) => e.Matricular(s);
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
