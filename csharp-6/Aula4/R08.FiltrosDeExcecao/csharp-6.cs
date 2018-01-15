using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.DateTime;
using static CSharp6.R08.Ano;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CSharp6.R08
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("8. Filtros De Exceção");

            try
            {
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

                marty.PropertyChanged += (sender, eventArgs) =>
                {
                    Console.WriteLine($"Propriedade {eventArgs.PropertyName} mudou!");
                };
                marty.Endereco = "novo endereço";
                marty.Telefone = "7777777";

                Aluno biff = new Aluno("Biff", "");

            }
            //3. C# 6 permite filtrar as exceções na cláusula catch
            catch (ArgumentException exc) when (exc.Message.Contains("não informado"))
            {
                Console.WriteLine($"ERRO: O parâmetro '{exc.ParamName}' não foi informado!");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
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

    //1. Vamos criar uma regra de validação dos campos nome e sobrenome
    //class Aluno : INotifyPropertyChanged
    //{
    //    public string Nome { get; }
    //    public string Sobrenome { get; }

    //    private string endereco;
    //    public string Endereco
    //    {
    //        get { return endereco; }
    //        set
    //        {
    //            if (endereco != value)
    //            {
    //                endereco = value;
    //                PropertyChanged.Call(this);
    //                PropertyChanged.Call(this, nameof(DadosPessoais));
    //            }
    //        }
    //    }

    //    private string telefone;
    //    public string Telefone
    //    {
    //        get { return telefone; }
    //        set
    //        {
    //            if (endereco != value)
    //            {
    //                telefone = value;
    //                PropertyChanged.Call(this);
    //                PropertyChanged.Call(this, nameof(DadosPessoais));
    //            }
    //        }
    //    }

    //    public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

    //    public Ano AnoNaEscola { get; set; } = Primeiro;

    //    public int PontosDeExperiencia()
    //    {
    //        switch (AnoNaEscola)
    //        {
    //            case Primeiro:
    //                return 0;
    //            case Segundo:
    //                return 15;
    //            case Terceiro:
    //                return 65;
    //            case Quarto:
    //                return 80;
    //            default:
    //                return 0;
    //        }
    //    }

    //    public Aluno(string nome, string sobrenome)
    //    {
    //        if (string.IsNullOrEmpty(nome))
    //        {
    //            throw new ArgumentException("Parâmetro não informado", nameof(nome));
    //        }
    //        if (string.IsNullOrEmpty(sobrenome))
    //        {
    //            throw new ArgumentException("Parâmetro não informado", nameof(sobrenome));
    //        }

    //        this.Nome = nome;
    //        this.Sobrenome = sobrenome;
    //    }

    //    public Aluno(string nome, string sobrenome, DateTime dataNascimento) : this(nome, sobrenome)
    //    {
    //        this.DataNascimento = dataNascimento;
    //    }

    //    public string NomeCompleto => $"{Nome} {Sobrenome}";

    //    public int GetIdade()
    //        => (int)((Now - DataNascimento).TotalDays / 365.242199);

    //    public string DadosPessoais =>
    //        $"Nome: {NomeCompleto}, " +
    //        $"Nascimento: {DataNascimento:dd/MM/yyyy}, " +
    //        $"Endereço: {Endereco}, " +
    //        $"Telefone: {Telefone}";

    //    private IList<Avaliacao> avaliacoes = new List<Avaliacao>();

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    public IReadOnlyCollection<Avaliacao> Avaliacoes
    //        => new ReadOnlyCollection<Avaliacao>(avaliacoes);

    //    public void AdicionarAvaliacao(Avaliacao avaliacao)
    //    {
    //        avaliacoes.Add(avaliacao);
    //    }
    //}





    //2. Podemos facilitar um pouco a verificação dos parâmetros com CallerMemberName:
    //class Aluno : INotifyPropertyChanged
    //{
    //    public string Nome { get; }
    //    public string Sobrenome { get; }

    //    private string endereco;
    //    public string Endereco
    //    {
    //        get { return endereco; }
    //        set
    //        {
    //            if (endereco != value)
    //            {
    //                endereco = value;
    //                PropertyChanged.Call(this);
    //                PropertyChanged.Call(this, nameof(DadosPessoais));
    //            }
    //        }
    //    }

    //    private string telefone;
    //    public string Telefone
    //    {
    //        get { return telefone; }
    //        set
    //        {
    //            if (endereco != value)
    //            {
    //                telefone = value;
    //                PropertyChanged.Call(this);
    //                PropertyChanged.Call(this, nameof(DadosPessoais));
    //            }
    //        }
    //    }

    //    public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

    //    public Ano AnoNaEscola { get; set; } = Primeiro;

    //    public int PontosDeExperiencia()
    //    {
    //        switch (AnoNaEscola)
    //        {
    //            case Primeiro:
    //                return 0;
    //            case Segundo:
    //                return 15;
    //            case Terceiro:
    //                return 65;
    //            case Quarto:
    //                return 80;
    //            default:
    //                return 0;
    //        }
    //    }

    //    public Aluno(string nome, string sobrenome)
    //    {
    //        VerificarParametro(nome, nameof(nome));
    //        VerificarParametro(sobrenome, nameof(sobrenome));

    //        this.Nome = nome;
    //        this.Sobrenome = sobrenome;
    //    }

    //    private static void VerificarParametro(string valorDoParametro, string nomeDoParametro)
    //    {
    //        if (string.IsNullOrEmpty(valorDoParametro))
    //        {
    //            throw new ArgumentException("Parâmetro não informado", nomeDoParametro);
    //        }
    //    }

    //    public Aluno(string nome, string sobrenome, DateTime dataNascimento) : this(nome, sobrenome)
    //    {
    //        this.DataNascimento = dataNascimento;
    //    }

    //    public string NomeCompleto => $"{Nome} {Sobrenome}";

    //    public int GetIdade()
    //        => (int)((Now - DataNascimento).TotalDays / 365.242199);

    //    public string DadosPessoais =>
    //        $"Nome: {NomeCompleto}, " +
    //        $"Nascimento: {DataNascimento:dd/MM/yyyy}, " +
    //        $"Endereço: {Endereco}, " +
    //        $"Telefone: {Telefone}";

    //    private IList<Avaliacao> avaliacoes = new List<Avaliacao>();

    //    public event PropertyChangedEventHandler PropertyChanged;

    //    public IReadOnlyCollection<Avaliacao> Avaliacoes
    //        => new ReadOnlyCollection<Avaliacao>(avaliacoes);

    //    public void AdicionarAvaliacao(Avaliacao avaliacao)
    //    {
    //        avaliacoes.Add(avaliacao);
    //    }

    //}






    //3. C# 6 permite filtrar as exceções na cláusula catch
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
