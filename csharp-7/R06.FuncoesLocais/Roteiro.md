Funções locais
Muitos designs para classes incluem métodos que são chamados de apenas um local. Esses métodos privados adicionais mantêm cada método pequeno e focado. No entanto, eles podem tornar mais difícil de entender uma classe ao lê-lo pela primeira vez. Esses métodos devem ser compreendidos fora do contexto do local de chamada único.
Para esses designs, as funções locais permitem que você declare métodos dentro do contexto de outro método. Isso faz com que seja mais fácil para os leitores da classe verem que o método local é chamado apenas do contexto em que ele está declarado.
Há dois casos de uso muito comuns para funções locais: métodos iteradores públicos e métodos assíncronos públicos. Ambos os tipos de métodos de geram código que relata os erros mais tarde do que os programadores podem esperar. No caso de métodos iteradores, todas as exceções são observadas apenas ao chamar o código que enumera a sequência retornada. No caso de métodos assíncronos, todas as exceções são observadas apenas quando a Task retornada é aguardada.
Vamos começar com um método iterador:
C#

Copiar
public static IEnumerable<char> AlphabetSubset(char start, char end)
{
    if (start < 'a' || start > 'z')
        throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
    if (end < 'a' || end > 'z')
        throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

    if (end <= start)
        throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
    for (var c = start; c < end; c++)
        yield return c;
}
Examine o código abaixo que chama o método iterador incorretamente:
C#

Copiar
var resultSet = Iterator.AlphabetSubset('f', 'a');
Console.WriteLine("iterator created");
foreach (var thing in resultSet)
    Console.Write($"{thing}, ");
A exceção é lançada quando resultSet é iterado, não quando resultSet é criado. Neste exemplo independente, a maioria dos desenvolvedores pode diagnosticar o problema rapidamente. No entanto, em bases de código maiores, o código que cria um iterador geralmente não é tão próximo do código que enumera o resultado. Você pode refatorar o código para que o método público valide todos os argumentos e um método particular gere a enumeração:
C#

Copiar
public static IEnumerable<char> AlphabetSubset2(char start, char end)
{
    if (start < 'a' || start > 'z')
        throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
    if (end < 'a' || end > 'z')
        throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

    if (end <= start)
        throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");
    return alphabetSubsetImplementation(start, end);
}

private static IEnumerable<char> alphabetSubsetImplementation(char start, char end)
{ 
    for (var c = start; c < end; c++)
        yield return c;
}
Esta versão refatorada lançará exceções imediatamente porque o método público não é um método iterador, apenas o método privado usa a sintaxe yield return. No entanto, existem problemas potenciais com a refatoração. O método privado deve ser chamado apenas do método de interface pública, pois, caso contrário, todas as validações de argumento são ignoradas. Os leitores da classe devem descobrir esse fato lendo a classe inteira e pesquisando por todas as outras referências ao método alphabetSubsetImplementation.
Você pode tornar essa intenção de design mais clara declarando o alphabetSubsetImplementation como uma função local dentro do método de API pública:
C#

Copiar
public static IEnumerable<char> AlphabetSubset3(char start, char end)
{
    if (start < 'a' || start > 'z')
        throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
    if (end < 'a' || end > 'z')
        throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

    if (end <= start)
        throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

    return alphabetSubsetImplementation();

    IEnumerable<char> alphabetSubsetImplementation()
    {
        for (var c = start; c < end; c++)
            yield return c;
    }
}
A versão acima deixa claro que o método local é referenciado somente no contexto do método externo. As regras para funções locais também garantem que um desenvolvedor não possa acidentalmente chamar a função local de outro local na classe e ignorar a validação de argumento.
A mesma técnica pode ser empregada com métodos async para garantir que as exceções decorrentes da validação de argumento sejam lançadas antes de o trabalho assíncrono começar:
C#

Copiar
public Task<string> PerformLongRunningWork(string address, int index, string name)
{
    if (string.IsNullOrWhiteSpace(address))
        throw new ArgumentException(message: "An address is required", paramName: nameof(address));
    if (index < 0)
        throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
    if (string.IsNullOrWhiteSpace(name))
        throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

    return longRunningWorkImplementation();

    async Task<string> longRunningWorkImplementation()
    {
        var interimResult = await FirstWork(address);
        var secondResult = await SecondStep(index, name);
        return $"The results are {interimResult} and {secondResult}. Enjoy.";
    }
}
Observação

Alguns dos designs com suporte pelas funções locais também podem ser feitos usando expressões lambda. Os interessados podem ler mais sobre as diferenças