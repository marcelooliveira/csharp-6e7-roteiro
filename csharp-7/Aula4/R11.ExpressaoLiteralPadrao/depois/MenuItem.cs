using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using static System.Console;

namespace csharp7.R11.depois
{
    //Tipo de valor | Valor padrão
    //============================
    //string: null
    //List<int>: null
    //struct: O valor produzido pela configuração de todos os campos tipo-valor para seus valores padrão e todos os campos tipo-referência para null.
    //enum: O valor produzido pela expressão(E)0, em que E é o identificador de enumeração.
    //bool: false
    //byte: 0
    //char: '\0'
    //decimal: M 0
    //double: 0,0D
    //float: 0,0F
    //int: 0
    //long, sbyte, short, uint, ulong, ushort: 0

    class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            IList<Cidade> cidades = default;
            cidades = LerArquivo();
            IEnumerable<Cidade> capitais = default;
            capitais = cidades.Where(c => c.Capital);
            foreach (var capital in capitais)
            {
                WriteLine(capital.Nome);
            }
        }

        private static IList<Cidade> LerArquivo()
        {
            IList<Cidade> cidades = default;
            cidades = new List<Cidade>();
            Encoding encoding = Encoding.GetEncoding(new CultureInfo("pt-BR").TextInfo.ANSICodePage);
            using (var streamReader = new StreamReader("cidades.csv", encoding))
            {
                streamReader.ReadLine();

                string linha = default;
                while ((linha = streamReader.ReadLine()) != null)
                {
                    var (estado, nome, latitude, longitude, capital) = LerLinha(linha);
                    cidades.Add(new Cidade(estado, nome, capital));
                }
            }

            return cidades;
        }

        private static (string estado, string nome, double latitude, double longitude, bool capital)
            LerLinha(string linha)
        {
            string[] campos = default;

            string estado = default;
            string nome = default;
            double latitude = default;
            double longitude = default;
            bool capital = default;

            campos = linha.Split(',');

            estado = campos[0];
            nome = campos[1];
            latitude = double.Parse(campos[2]);
            longitude = double.Parse(campos[3]);
            capital = campos[4] == "true";

            //return (estado: estado, nome: nome, latitude: latitude, longitude: longitude, capital: capital);
            //a linha acima pode ser reescrita como: 

            return (estado, nome, latitude, longitude, capital);
        }

        class Cidade
        {
            public string Estado { get; }
            public string Nome { get; }
            public bool Capital { get; }

            public Cidade(string estado, string nome, bool capital = default)
            {
                Estado = estado;
                Nome = nome;
                Capital = capital;
            }
        }
    }
}
