using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R03
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("3. Membros Com Corpo De Expressão");

            Aluno marty = new Aluno("Marty", "McFly", new DateTime(1968, 06, 12));
            //{ Nome = "Biff", Sobrenome = "Tannen" };

            Console.WriteLine(marty.Nome);
            Console.WriteLine(marty.Sobrenome);
        }
    }

    //1. vamos adicionar uma propriedade para obter o nome completo:
    //class Aluno
    //{
    //    public string Nome { get; }
    //    public string Sobrenome { get; }
    //    public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

    //    public Aluno(string nome, string sobrenome)
    //    {
    //        this.Nome = nome;
    //        this.Sobrenome = sobrenome;
    //    }

    //    public Aluno(string nome, string sobrenome, DateTime dataNascimento) : this(nome, sobrenome)
    //    {
    //        this.DataNascimento = dataNascimento;
    //    }

    //    public string NomeCompleto
    //    {
    //        get { return string.Format("{0} {1}", Nome, Sobrenome); }
    //    }
    //}

    //2. Agora vamos criar um método para obter a idade do aluno:
    //class Aluno
    //{
    //    public string Nome { get; }
    //    public string Sobrenome { get; }
    //    public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

    //    public Aluno(string nome, string sobrenome)
    //    {
    //        this.Nome = nome;
    //        this.Sobrenome = sobrenome;
    //    }

    //    public Aluno(string nome, string sobrenome, DateTime dataNascimento) : this(nome, sobrenome)
    //    {
    //        this.DataNascimento = dataNascimento;
    //    }

    //    public string NomeCompleto
    //    {
    //        get { return string.Format("{0} {1}", Nome, Sobrenome); }
    //    }

    //    public int GetIdade()
    //    {
    //        return (int)((DateTime.Now - DataNascimento).TotalDays / 365.242199);
    //    }
    //}

    //3. C# 6 permite escrever propriedades e métodos com sintaxe de expressão: 
    class Aluno
    {
        public string Nome { get; }
        public string Sobrenome { get; }
        public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);

        public Aluno(string nome, string sobrenome)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
        }

        public Aluno(string nome, string sobrenome, DateTime dataNascimento) : this(nome, sobrenome)
        {
            this.DataNascimento = dataNascimento;
        }

        public string NomeCompleto => string.Format("{0} {1}", Nome, Sobrenome);

        public int GetIdade()
            => (int)((DateTime.Now - DataNascimento).TotalDays / 365.242199);
    }
}
