Expressões throw
No C#, throw sempre foi uma instrução. Como throw é uma instrução, não uma expressão, havia constructos C# em que não era possível usá-la. Eles incluíam expressões condicionais, expressões de união nulas e algumas expressões lambda. A adição de membros aptos para expressão inclui mais locais em que as expressões throw seriam úteis. Para que você possa escrever qualquer um desses constructos, o C# 7 introduz expressões throw.
A sintaxe é a mesma que você sempre usou para instruções throw. A única diferença é que agora você pode colocá-los em novas localidades, como em uma expressão condicional:



public string Name
{
    get => name;
    set => name = value ?? 
        throw new ArgumentNullException(paramName: nameof(value), message: "New name must not be null");
}
Esse recurso permite usar expressões throw em expressões de inicialização:



private ConfigResource loadedConfig = LoadConfigResourceOrDefault() ?? 
    throw new InvalidOperationException("Could not load config");
Anteriormente, essas inicializações precisavam estar em um construtor, com as instruções throw no corpo do construtor:



public ApplicationOptions()
{
    loadedConfig = LoadConfigResourceOrDefault();
    if (loadedConfig == null)
        throw new InvalidOperationException("Could not load config");

}
Observação

Ambos os construtores acima farão com que exceções sejam geradas durante a construção de um objeto. Muitas vezes é difícil realizar a recuperação deles. Por esse motivo, os designs que lançam exceções durante a construção são desencorajados.