﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R02
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("2. Inicializadores De Propriedade Automática");

            try
            {
                var aluno = new Aluno("Ferris", "Bueller");
                Console.WriteLine(aluno.Prenome);
                Console.WriteLine(aluno.Sobrenome);

                aluno.Notas.Add(3.5);
                aluno.Notas.Add(4.5);
                aluno.Notas.Add(3);
                aluno.Notas.Add(5);


                Console.WriteLine();
                Console.WriteLine("NOTAS");
                Console.WriteLine("=====");

                foreach (var nota in aluno.Notas)
                {
                    Console.WriteLine(nota);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
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
    }
}