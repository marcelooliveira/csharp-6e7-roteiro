using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace CSharp6.R04
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("4. Using Static");

            Aluno marty = new Aluno("Marty", "McFly", new DateTime(1968, 06, 12));
            //{ Nome = "Biff", Sobrenome = "Tannen" };
            marty.Endereco = "9303 Lyon Drive Hill Valley CA";
            marty.Telefone = "555-4385";

            Console.WriteLine(marty.Nome);
            Console.WriteLine(marty.Sobrenome);
            Console.WriteLine(marty.DadosPessoais);
        }
    }

    class Aluno
    {
        public string Nome { get; }
        public string Sobrenome { get; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

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

        public string DadosPessoais =>
            string.Format("Nome: {0}, " +
                "Endereço: {1}, " +
                "Telefone: {2}", NomeCompleto, Endereco, Telefone);
    }
}
