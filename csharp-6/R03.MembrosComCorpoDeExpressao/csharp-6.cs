﻿using System;
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
            Console.WriteLine("Programa 3");
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

        public string NomeCompleto => string.Format("{0} {1}", Prenome, Sobrenome);

        public Aluno(string prenome, string sobrenome)
        {
            if (string.IsNullOrWhiteSpace(sobrenome))
                throw new ArgumentException(message: "Não pode ser vazio", paramName: "sobrenome");

            Prenome = prenome;
            Sobrenome = sobrenome;
        }

        public void MudarNome(string novoSobrenome)
        {
            // Produz erro: CS0200: Property or indexer cannot be assigned to -- it is read only
            //Sobrenome = novoSobrenome;
        }

        public override string ToString() => string.Format("{0}, {1}", Sobrenome, Prenome);
    }
}
