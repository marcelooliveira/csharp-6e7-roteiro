Observe o programa abaixo, escrito para imprimir a melhor nota de um 
aluno:

```
class Programa
{
    public void Main()
    {
        .
        .
        .
        Aluno aluno2 = new Aluno("Bart", "Simpson");
        ImprimirMelhorNota(aluno2);

    }

    private static void ImprimirMelhorNota(Aluno aluno)
    {
        Console.WriteLine("Melhor nota: {0}",
            aluno?.MelhorAvaliacao.Nota);
    }
}

class Aluno
{
    .
    .
    .
    private IList<Avaliacao> avaliacoes = new List<Avaliacao>();
    public IReadOnlyCollection<Avaliacao> Avaliacoes
        => new ReadOnlyCollection<Avaliacao>(avaliacoes);

    public Avaliacao MelhorAvaliacao =>
        avaliacoes.OrderBy(a => a.Nota).LastOrDefault();
}

```

O que acontece quando o programa executa a linha de código `ImprimirMelhorNota(aluno2);`?

a- O .NET lança uma exceção: `System.NullReferenceException: 'Referência de objeto não definida para uma instância de um objeto.'`
Isso mesmo! A expressão `avaliacoes.OrderBy(a => a.Nota).LastOrDefault();` do método 
`MelhorAvaliacao` retorna um valor nulo. Logo, quando tentamos acessar a propriedade `Nota`
de `aluno?.MelhorAvaliacao`, tomamos uma exceção de referência nula. 

b- O programa imprime no console: `Melhor nota: `
Ops! Como o aluno não tem nenhuma nota ainda, a expressão `aluno?.MelhorAvaliacao.Nota`
provoca uma **exceção de referência nula**, e uma exceção é gerada em:
```
Console.WriteLine("Melhor nota: {0}",
    aluno?.MelhorAvaliacao.Nota);
```
Portanto, nenhuma mensagem é impressa no console.

c- O programa imprime no console: `Melhor nota: 0`
Ops! Como o aluno não tem nenhuma nota ainda, a expressão `aluno?.MelhorAvaliacao.Nota`
provoca uma **exceção de referência nula**, e uma exceção é gerada em:
```
Console.WriteLine("Melhor nota: {0}",
    aluno?.MelhorAvaliacao.Nota);
```
Portanto, nenhuma mensagem é impressa no console.

d- O .NET lança uma exceção: `System.IndexOutOfRangeException: O índice estava fora dos limites da matriz`
Ops! A exceção `IndexOutOfRangeException` só é lançada quando tentamos acessar um 
índice fora do alcance dentro da coleção. Como não estamos acessando a coleção
de avaliações pelo índice, essa exceção não é lançada.