using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp5.R02
{
    public enum Ano
    {
        Primeiro,
        Segundo,
        Terceiro,
        Quarto
    }

    public class Aluno
    {
        public string Prenome { get; private set; }
        public string Sobrenome { get; private set; }
        public ICollection<double> Notas { get; private set; }
        public Ano AnoNaEscola { get; set; }


        public Aluno(string prenome, string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException(message: "Não pode ser vazio", paramName: "sobrenome");

            Prenome = prenome;
            Sobrenome = sobrenome;
            Notas = new List<double>();
            AnoNaEscola = Ano.Primeiro;
        }

        public void MudarNome(string novoSobrenome)
        {
            // Produz erro: CS0200: Property or indexer cannot be assigned to -- it is read only
            //Sobrenome = novoSobrenome;
        }
    }
}
