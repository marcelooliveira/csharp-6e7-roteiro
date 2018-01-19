Você está desenvolvendo uma aplicação e utilizando o método
`Console.WriteLine` diversas vezes para imprimir informações no console:

```
Console.WriteLine(aluno.Nome);
Console.WriteLine(aluno.Sobrenome);
Console.WriteLine(aluno.NomeCompleto);
Console.WriteLine("Idade: {0}", aluno.GetIdade());
Console.WriteLine(aluno.DadosPessoais);
```

Você então decide fazer uma modificação na aplicação, para poder
chamar o método `WriteLine` sem precisar mencionar o nome da classe `Console`:

```
WriteLine(aluno.Nome);
WriteLine(aluno.Sobrenome);
WriteLine(aluno.NomeCompleto);
WriteLine("Idade: {0}", aluno.GetIdade());
WriteLine(aluno.DadosPessoais);
```

Que alteração você faria na aplicação para permitir essa nova sintaxe?

a- Adicionaria uma declaração no início do código: `using static System.Console;`
Isso mesmo! A declaração `using static System.Console;`, permite que você importe os métodos estáticos de uma 
única classe (`System.Console`). Anteriormente, a instrução `using` importava todos os tipos de um 
`namespace`.

b- Adicionaria uma declaração no início do código: `using System.Console;`
Ops! A diretiva `using` (sem `static`) deve ser usada somente com namespaces. Nunca com tipos (como `System.Console`).

c- Adicionaria uma declaração no início do código: `using static System.Console.WriteLine;`
Ops! A diretiva `using static` deve ser usada somente com tipos, nunca com membros desses tipos. 

d- Adicionaria uma declaração no início do código: `using System.Console.WriteLine;`
Ops! A diretiva `using` (sem `static`) deve ser usada somente com namespaces, nunca com membros desses tipos.

