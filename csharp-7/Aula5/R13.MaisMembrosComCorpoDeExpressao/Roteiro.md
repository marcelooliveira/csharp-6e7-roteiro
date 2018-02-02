Mais membros aptos para expressão
O C# 6 introduziu membros aptos para expressão para funções de membro e propriedades somente leitura. O C# 7 expande os membros permitidos que podem ser implementados como expressões. No C# 7, você pode implementar construtores, finalizadores e acessadores get e set em propriedades e indexadores. O código a seguir mostra exemplos de cada um:



```
// Expression-bodied constructor
public ExpressionMembersExample(string label) => this.Label = label;

// Expression-bodied finalizer
~ExpressionMembersExample() => Console.Error.WriteLine("Finalized!");

private string label;

// Expression-bodied get / set accessors.
public string Label
{
    get => label;
    set => this.label = value ?? "Default label";
}
```
Observação

Este exemplo não precisa de um finalizador, mas ele é mostrado para demonstrar a sintaxe. Você não deve implementar um finalizador em sua classe a menos que seja necessário para liberar recursos não gerenciados. Você também deve considerar o uso da classe SafeHandle em vez de gerenciar recursos não gerenciados diretamente.
Esses novos locais para membros aptos para expressão representam uma etapa importante para a linguagem C#: esses recursos foram implementados por membros da comunidade trabalhando no projeto Roslyn de software livre.