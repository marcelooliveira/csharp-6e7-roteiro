using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;
using static System.DateTime;
using static CSharp6.R05.Ano;
using System.Collections.ObjectModel;

namespace CSharp6.R05
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("5. Operadores Null-Condicionais");

            Aluno marty = new Aluno("Marty", "McFly", new DateTime(1968, 06, 12))
            {
                Endereco = "9303 Lyon Drive Hill Valley CA",
                Telefone = "555-4385"
            };

            Console.WriteLine(marty.Nome);
            Console.WriteLine(marty.Sobrenome);
            Console.WriteLine(marty.DadosPessoais);
            Avaliacao melhorAvaliacao = GetMelhorNota(marty);

            Console.WriteLine("Melhor Nota: {0}", melhorAvaliacao?.Nota);

            marty.AdicionarAvaliacao(new Avaliacao(1, "Geografia", 8));
            marty.AdicionarAvaliacao(new Avaliacao(1, "Matemática", 6));
            marty.AdicionarAvaliacao(new Avaliacao(1, "História", 7));

            melhorAvaliacao = GetMelhorNota(marty);

            Console.WriteLine("Melhor Nota: {0}", melhorAvaliacao?.Nota);

        }

        private static Avaliacao GetMelhorNota(Aluno marty)
        {
            return marty.Avaliacoes
                .OrderByDescending(a => a.Nota)
                .FirstOrDefault();
        }
    }

    public enum Ano
    {
        Primeiro,
        Segundo,
        Terceiro,
        Quarto
    }

    class Aluno
    {
        public string Nome { get; }
        public string Sobrenome { get; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

        public Ano AnoNaEscola { get; set; } = Primeiro;

        public int PontosDeExperiencia()
        {
            switch (AnoNaEscola)
            {
                case Primeiro:
                    return 0;
                case Segundo:
                    return 15;
                case Terceiro:
                    return 65;
                case Quarto:
                    return 80;
                default:
                    return 0;
            }
        }

        public Aluno(string nome, string sobrenome)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
        }

        public Aluno(string nome, string sobrenome, DateTime dataNascimento) : this(nome, sobrenome)
        {
            this.DataNascimento = dataNascimento;
        }

        public string NomeCompleto => Format("{0} {1}", Nome, Sobrenome);

        public int GetIdade()
            => (int)((Now - DataNascimento).TotalDays / 365.242199);

        public string DadosPessoais =>
            Format("Nome: {0}, " +
                "Endereço: {1}, " +
                "Telefone: {2}", NomeCompleto, Endereco, Telefone);


        private IList<Avaliacao> avaliacoes = new List<Avaliacao>();
        public IReadOnlyCollection<Avaliacao> Avaliacoes 
            => new ReadOnlyCollection<Avaliacao>(avaliacoes);

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            avaliacoes.Add(avaliacao);
        }
    }

    class Avaliacao
    {
        public Avaliacao(int bimestre, string materia, double nota)
        {
            Bimestre = bimestre;
            Materia = materia;
            Nota = nota;
        }

        public int Bimestre { get; }
        public string Materia { get; }
        public double Nota { get; }
    }
}
