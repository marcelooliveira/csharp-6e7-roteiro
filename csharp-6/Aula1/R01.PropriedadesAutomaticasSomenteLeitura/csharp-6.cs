using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R01
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("1. Propriedades Automáticas Somente-Leitura");

            Aluno marty = new Aluno("Marty", "McFly", new DateTime(1968, 06, 12))
                { Nome = "Biff", Sobrenome = "Tannen" };

            Console.WriteLine(marty.Nome);
            Console.WriteLine(marty.Sobrenome);
        }
    }

    //1. SOMENTE CAMPOS, SEM PROPRIEDADES
    //class Aluno
    //{
    //    private string nome;
    //    private string sobrenome;
    //    private DateTime dataNascimento;

    //    public Aluno(string nome, string sobrenome, DateTime dataNascimento)
    //    {
    //        this.nome = nome;
    //        this.sobrenome = sobrenome;
    //        this.dataNascimento = dataNascimento;
    //    }
    //}

    //2. DE CAMPOS PARA PROPRIEDADES AUTOMÁTICAS

    class Aluno
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }

        public Aluno(string nome, string sobrenome, DateTime dataNascimento)
        {
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.DataNascimento = dataNascimento;
        }
    }

    //Mas isso permitiria modificar o nome após a criação, o que não é nada bom,
    //pois a propriedade não é imutável!
    //Aluno marty = new Aluno("Marty", "McFly", new DateTime(1968, 06, 12))
    //        { Nome = "Biff", Sobrenome = "Tannen" };
}
