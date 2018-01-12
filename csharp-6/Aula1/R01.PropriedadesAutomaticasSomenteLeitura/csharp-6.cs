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

            Aluno marty = new Aluno("Marty", "McFly", new DateTime(1968, 06, 12));
            //{ Nome = "Biff", Sobrenome = "Tannen" };

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





    //2. MUDANDO DE CAMPOS PARA PROPRIEDADES AUTOMÁTICAS
    //class Aluno
    //{
    //    public string Nome { get; set; }
    //    public string Sobrenome { get; set; }
    //    public DateTime DataNascimento { get; set; }

    //    public Aluno(string nome, string sobrenome, DateTime dataNascimento)
    //    {
    //        this.Nome = nome;
    //        this.Sobrenome = sobrenome;
    //        this.DataNascimento = dataNascimento;
    //    }
    //}

    //Mas isso permitiria modificar o nome após a criação, o que não é nada bom,
    //pois a propriedade não é imutável!
    //Aluno marty = new Aluno("Marty", "McFly", new DateTime(1968, 06, 12))
    //        { Nome = "Biff", Sobrenome = "Tannen" };






    //3. podemos criar membros imutáveis com campos auxiliares,
    //com getters mas sem setters:

    //private readonly string nome;
    //private readonly string sobrenome;
    //private readonly DateTime dataNascimento;

    //public string Nome { get { return nome; } }
    //public string Sobrenome { get { return sobrenome; } }
    //public DateTime DataNascimento { get { return dataNascimento; } }

    //public Aluno(string nome, string sobrenome, DateTime dataNascimento)
    //{
    //    this.nome = nome;
    //    this.sobrenome = sobrenome;
    //    this.dataNascimento = dataNascimento;
    //}







    //4. talvez campos auxiliares seja muito código. 
    //vamos tentar propriedades automáticas com private set
    //class Aluno
    //{

    //    public string Nome { get; private set; }
    //    public string Sobrenome { get; private set; }
    //    public DateTime DataNascimento { get; private set; }

    //    public Aluno(string nome, string sobrenome, DateTime dataNascimento)
    //    {
    //        this.Nome = nome;
    //        this.Sobrenome = sobrenome;
    //        this.DataNascimento = dataNascimento;
    //    }
    //}
    //Legal, agora não podemos mais modificar o nome uma vez criado o objeto.

    //Aluno marty = new Aluno("Marty", "McFly", new DateTime(1968, 06, 12));
    //marty.Nome = "Biff";
    //marty.Sobrenome = "Tannen";
    //Error CS0272  The property or indexer 'Aluno.Nome' cannot be used in 
    //this context because the set accessor is inaccessible   





    //5. agora não podemos mudar o nome de fora da classe,
    //porém podemos mudar de DENTRO da classe, em um outro
    //método, por exemplo:
    //class Aluno
    //{
    //    public string Nome { get; private set; }
    //    public string Sobrenome { get; private set; }
    //    public DateTime DataNascimento { get; private set; }

    //    public Aluno(string nome, string sobrenome, DateTime dataNascimento)
    //    {
    //        this.Nome = nome;
    //        this.Sobrenome = sobrenome;
    //        this.DataNascimento = dataNascimento;
    //    }

    //    public override string ToString()
    //    {
    //        Nome = "Biff";
    //        Sobrenome = "Tannen";
    //        return Nome;
    //    }
    //}







    //6. Ainda não atingimos a verdadeira imutabilidade! Por quê?
    //Vamos mostrar o que o compilador está fazendo por trás dos panos
    //ilustrando com campos privados:
    //class Aluno
    //{
    //    private string nome;
    //    public string Nome
    //    {
    //        get { return nome; }
    //        private set { nome = value; }
    //    }

    //    private string sobrenome;
    //    public string Sobrenome
    //    {
    //        get { return sobrenome; }
    //        private set { sobrenome = value; }
    //    }

    //    public DateTime DataNascimento { get; private set; }

    //    public Aluno(string nome, string sobrenome, DateTime dataNascimento)
    //    {
    //        this.Nome = nome;
    //        this.Sobrenome = sobrenome;
    //        this.DataNascimento = dataNascimento;
    //    }
    //}






    //7. Com C# 6, podemos deixar as propriedades somente com getter e sem setter!
    //class Aluno
    //{
    //    public string Nome { get;  }
    //    public string Sobrenome { get;  }
    //    public DateTime DataNascimento { get; }

    //    public Aluno(string nome, string sobrenome, DateTime dataNascimento)
    //    {
    //        this.Nome = nome;
    //        this.Sobrenome = sobrenome;
    //        this.DataNascimento = dataNascimento;
    //    }

    //    public override string ToString()
    //    {
    //        //Nome = "Tannen";
    //        //Sobrenome = "Biff";
    //        //a linha acima gera um ERRO:
    //        //error CS0200: Property or indexer 'Aluno.Nome' cannot be assigned to --it is read only
    //        return Nome;
    //    }
    //}





    //8. por que tomamos o erro CS0200 acima no método ToString() mas não no construtor?
    //porque no Construtor, não estamos atribuindo o valor à propriedade, mas sim 
    //ao campo privado que é gerado por trás dos panos!
    //Esse campo readonly só pode ser definido no construtor!
    //O código acima é equivalente ao abaixo:
    class Aluno
    {
        private readonly string nome;
        public string Nome { get { return nome; } }
        public string Sobrenome { get; }
        public DateTime DataNascimento { get; }

        public Aluno(string nome, string sobrenome, DateTime dataNascimento)
        {
            this.nome = nome;
            this.Sobrenome = sobrenome;
            this.DataNascimento = dataNascimento;
        }

        public override string ToString()
        {
            //Nome = "Biff";
            //Sobrenome = "Tannen";
            //a linha acima gera um ERRO:
            //error CS0200: Property or indexer 'Aluno.Nome' cannot be assigned to --it is read only
            return Nome;
        }
    }
}
