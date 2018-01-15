using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.DateTime;
using static CSharp6.R11.Ano;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;

//1. Vamos criar uma classe para armazenar a lista de matrícula
//2. C# 6 permite criar uma extensão para inicialização de coleções

namespace CSharp6.R11
{
    class Programa
    {
        public async void Main()
        {
            Console.WriteLine("11. Metodos De Extensão Para Inicializadores De Coleção");

            StreamWriter logger = new StreamWriter("LogDoCurso.txt");
            try
            {
                Aluno marty = new Aluno("Marty", "McFly", new DateTime(1968, 06, 12))
                {
                    Endereco = "9303 Lyon Drive Hill Valley CA",
                    Telefone = "555-4385"
                };

                await logger.WriteLineAsync("Aluno Marty McFly criado");

                Console.WriteLine(marty.Nome);
                Console.WriteLine(marty.Sobrenome);
                Console.WriteLine(marty.DadosPessoais);
                Avaliacao melhorAvaliacao = GetMelhorNota(marty);

                Console.WriteLine("Melhor Nota: {0}", melhorAvaliacao?.Nota);

                marty.AdicionarAvaliacao(new Avaliacao(1, "GEO", 8));
                marty.AdicionarAvaliacao(new Avaliacao(1, "MAT", 6));
                marty.AdicionarAvaliacao(new Avaliacao(1, "HIS", 7));

                melhorAvaliacao = GetMelhorNota(marty);

                Console.WriteLine("Melhor Nota: {0}", melhorAvaliacao?.Nota);

                foreach (var avaliacao in marty.Avaliacoes)
                {
                    Console.WriteLine(avaliacao);
                }

                marty.PropertyChanged += (sender, eventArgs) =>
                {
                    Console.WriteLine($"Propriedade {eventArgs.PropertyName} mudou!");
                };
                marty.Endereco = "novo endereço";
                marty.Telefone = "7777777";

                //Aluno biff = new Aluno("Biff", "");


                ListaDeMatricula alunos = new ListaDeMatricula
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
                //alunos.Matricular(new Aluno("Lessie", "Crosby"));
                //alunos.Matricular(new Aluno("Vicki", "Petty"));
                //alunos.Matricular(new Aluno("Ofelia", "Hobbs"));
                //alunos.Matricular(new Aluno("Leah", "Kinney"));
                //alunos.Matricular(new Aluno("Alton", "Stoker"));
                //alunos.Matricular(new Aluno("Luella", "Ferrell"));
                //alunos.Matricular(new Aluno("Marcy", "Riggs"));
                //alunos.Matricular(new Aluno("Ida", "Bean"));
                //alunos.Matricular(new Aluno("Ollie", "Cottle"));
                //alunos.Matricular(new Aluno("Tommy", "Broadnax"));
                //alunos.Matricular(new Aluno("Jody", "Yates"));
                //alunos.Matricular(new Aluno("Marguerite", "Dawson"));
                //alunos.Matricular(new Aluno("Francisca", "Barnett"));
                //alunos.Matricular(new Aluno("Arlene", "Velasquez"));
                //alunos.Matricular(new Aluno("Jodi", "Green"));
                //alunos.Matricular(new Aluno("Fran", "Mosley"));
                //alunos.Matricular(new Aluno("Taylor", "Nesmith"));
                //alunos.Matricular(new Aluno("Ernesto", "Greathouse"));
                //alunos.Matricular(new Aluno("Margret", "Albert"));
                //alunos.Matricular(new Aluno("Pansy", "House"));
                //alunos.Matricular(new Aluno("Sharon", "Byrd"));
                //alunos.Matricular(new Aluno("Keith", "Roldan"));
                //alunos.Matricular(new Aluno("Martha", "Miranda"));
                //alunos.Matricular(new Aluno("Kari", "Campos"));
                //alunos.Matricular(new Aluno("Muriel", "Middleton"));
                //alunos.Matricular(new Aluno("Georgette", "Jarvis"));
                //alunos.Matricular(new Aluno("Pam", "Boyle"));
                //alunos.Matricular(new Aluno("Deena", "Travis"));
                //alunos.Matricular(new Aluno("Cary", "Totten"));
                //alunos.Matricular(new Aluno("Althea", "Goodwin"));

                Console.WriteLine();
                Console.WriteLine("ALUNOS DA TURMA");
                Console.WriteLine("===============");
                foreach (var aluno in alunos)
                {
                    Console.WriteLine(aluno.DadosPessoais);
                }
            }
            catch (ArgumentException exc) when (exc.Message.Contains("não informado"))
            {
                Console.WriteLine($"ERRO: O parâmetro '{exc.ParamName}' não foi informado!");
                await logger.WriteLineAsync("Erro: " + exc.ToString());
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
                await logger.WriteLineAsync(exc.ToString());
            }
            finally
            {
                await logger.WriteLineAsync("O programa terminou.");
                logger.Dispose();
            }
        }

        private static Avaliacao GetMelhorNota(Aluno marty)
        {
            return marty.Avaliacoes
                .OrderByDescending(a => a.Nota)
                .FirstOrDefault();
        }
    }

    //1. Vamos criar uma classe para armazenar a lista de matrícula
    class ListaDeMatricula : IEnumerable<Aluno>
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

    //2. C# 6 permite criar uma extensão para inicialização de coleções
    static class AlunoExtensions
    {
        public static void Add(this ListaDeMatricula e, Aluno s)
            => e.Matricular(s);
    }

    public enum Ano
    {
        Primeiro,
        Segundo,
        Terceiro,
        Quarto
    }

    class Aluno : INotifyPropertyChanged
    {
        public string Nome { get; }
        public string Sobrenome { get; }

        private string endereco;
        public string Endereco
        {
            get { return endereco; }
            set
            {
                if (endereco != value)
                {
                    endereco = value;
                    PropertyChanged.Call(this);
                    PropertyChanged.Call(this, nameof(DadosPessoais));
                }
            }
        }

        private string telefone;
        public string Telefone
        {
            get { return telefone; }
            set
            {
                if (endereco != value)
                {
                    telefone = value;
                    PropertyChanged.Call(this);
                    PropertyChanged.Call(this, nameof(DadosPessoais));
                }
            }
        }

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
            VerificarParametro(nome, nameof(nome));
            VerificarParametro(sobrenome, nameof(sobrenome));

            this.Nome = nome;
            this.Sobrenome = sobrenome;
        }

        private static void VerificarParametro(string valorDoParametro, string nomeDoParametro)
        {
            if (string.IsNullOrEmpty(valorDoParametro))
            {
                throw new ArgumentException("Parâmetro não informado", nomeDoParametro);
            }
        }

        public Aluno(string nome, string sobrenome, DateTime dataNascimento) : this(nome, sobrenome)
        {
            this.DataNascimento = dataNascimento;
        }

        public string NomeCompleto => $"{Nome} {Sobrenome}";

        public int GetIdade()
            => (int)((Now - DataNascimento).TotalDays / 365.242199);

        public string DadosPessoais =>
            $"Nome: {NomeCompleto}, " +
            $"Nascimento: {DataNascimento:dd/MM/yyyy}, " +
            $"Endereço: {Endereco}, " +
            $"Telefone: {Telefone}";

        private IList<Avaliacao> avaliacoes = new List<Avaliacao>();

        public event PropertyChangedEventHandler PropertyChanged;

        public IReadOnlyCollection<Avaliacao> Avaliacoes
            => new ReadOnlyCollection<Avaliacao>(avaliacoes);

        public void AdicionarAvaliacao(Avaliacao avaliacao)
        {
            avaliacoes.Add(avaliacao);
        }

    }

    static class PropertyChangedExtensions
    {
        public static void Call(this PropertyChangedEventHandler handler,
            object sender, [CallerMemberName] string propertyName = null)
        {
            if (handler != null)
            {
                handler.Invoke(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    //1. Vamos criar um dicionário de matérias e popular esse dicionário
    //class Avaliacao
    //{
    //    Dictionary<string, string> materias = new Dictionary<string, string>();

    //    public Avaliacao(int bimestre, string materia, double nota)
    //    {
    //        Bimestre = bimestre;
    //        Materia = materia;
    //        Nota = nota;
    //        materias.Add("MAT", "Matemática");
    //        materias.Add("LPL", "Língua Portuguesa");
    //        materias.Add("FIS", "Física");
    //        materias.Add("HIS", "História");
    //        materias.Add("GEO", "Geografia");
    //        materias.Add("QUI", "Química");
    //        materias.Add("BIO", "Biologia");
    //    }

    //    public int Bimestre { get; }
    //    public string Materia { get; }
    //    public double Nota { get; }

    //    public override string ToString()
    //    {
    //        return $"Bimestre: {Bimestre} - Matéria: {materias[Materia]} - Nota: {Nota}";
    //    }
    //}


    //2. C# 6 permite inicializar índices, como em dicionários
    class Avaliacao
    {
        Dictionary<string, string> materias = new Dictionary<string, string>
        {
            ["MAT"] = "Matemática",
            ["LPL"] = "Língua Portuguesa",
            ["FIS"] = "Física",
            ["HIS"] = "História",
            ["GEO"] = "Geografia",
            ["QUI"] = "Química",
            ["BIO"] = "Biologia"
        };

        public Avaliacao(int bimestre, string materia, double nota)
        {
            Bimestre = bimestre;
            Materia = materia;
            Nota = nota;
        }

        public int Bimestre { get; }
        public string Materia { get; }
        public double Nota { get; }

        public override string ToString()
        {
            return $"Bimestre: {Bimestre} - Matéria: {materias[Materia]} - Nota: {Nota}";
        }
    }
}
