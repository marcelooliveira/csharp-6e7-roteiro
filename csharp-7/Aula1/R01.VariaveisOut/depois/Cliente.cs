using System;
using System.IO;
using static System.Console;

namespace csharp7.R01.depois
{
    public class MenuItem : csharp7.MenuItem
    {
        public override void Main()
        {
            using (var streamReader = File.OpenText("clientes.csv"))
            {
                string linha = string.Empty;
                while ((linha = streamReader.ReadLine()) != null)
                {
                    string[] campos = linha.Split(',');

                    //1) Primeiro exemplo de out int

                    //int.TryParse(campos[0], out int id);
                    //if (id > 0)
                    //{
                    //    Cliente cliente = new Cliente(id, campos[1], campos[2], campos[3]);

                    //    WriteLine("Dados do Cliente");
                    //    WriteLine("================");
                    //    WriteLine("ID: " + cliente.Id);
                    //    WriteLine("Nome: " + cliente.Nome);
                    //    WriteLine("Telefone: " + cliente.Telefone);
                    //    WriteLine("Website: " + cliente.Website);
                    //    WriteLine("================");
                    //}

                    //2) Também podemos usar out var id:

                    //int.TryParse(campos[0], out var id);
                    //if (id > 0)
                    //{
                    //    Cliente cliente = new Cliente(id, campos[1], campos[2], campos[3]);

                    //    WriteLine("Dados do Cliente");
                    //    WriteLine("================");
                    //    WriteLine("ID: " + cliente.Id);
                    //    WriteLine("Nome: " + cliente.Nome);
                    //    WriteLine("Telefone: " + cliente.Telefone);
                    //    WriteLine("Website: " + cliente.Website);
                    //    WriteLine("================");
                    //}

                    //3) neste outro exemplo, int "vaza" para fora da instrução int

                    if (int.TryParse(campos[0], out int id))
                    {
                        Cliente cliente = new Cliente(id, campos[1], campos[2], campos[3]);

                        WriteLine("Dados do Cliente");
                        WriteLine("================");
                        WriteLine("ID: " + cliente.Id);
                        WriteLine("Nome: " + cliente.Nome);
                        WriteLine("Telefone: " + cliente.Telefone);
                        WriteLine("Website: " + cliente.Website);
                        WriteLine("================");
                    }

                    if (id > 0)
                    {
                        Console.WriteLine($"Valor de ID vaza para fora do if: {id}");
                    }
                }
            }
        }
    }

    class Cliente
    {
        readonly int id;
        readonly string nome;
        readonly string telefone;
        readonly string website;

        public int Id => id;

        public string Nome => nome;

        public string Telefone => telefone;

        public string Website => website;

        public Cliente(int id, string nome, string telefone, string website)
        {
            this.id = id;
            this.nome = nome;
            this.telefone = telefone;
            this.website = website;
        }

    }
}
