# Tuplas

Observação

Os novos recursos de tuplas exigem os tipos ValueTuple. Você deve adicionar o pacote NuGet System.ValueTuple para usá-lo em plataformas que não incluem os tipos.
Isso é semelhante a outros recursos de linguagem que dependem de tipos entregues no framework. Os exemplos incluem async e await que dependem da interface INotifyCompletion, além do LINQ que depende de IEnumerable<T>. No entanto, o mecanismo de entrega está mudando conforme o .NET se torna mais independente de plataforma. O .NET Framework pode não ser enviados sempre na mesma cadência que o compilador de linguagem. Quando novos recursos de linguagem dependerem de novos tipos, esses tipos estarão disponíveis como pacotes do NuGet quando os recursos de linguagem forem enviados. Conforme esses novos tipos são adicionados à API padrão do .NET e fornecidos como parte do framework, o requisito de pacote do NuGet será removido.
O C# fornece uma sintaxe avançada para classes e structs que são usados para explicar a intenção do design. Mas, às vezes, essa sintaxe avançada requer trabalho adicional com poucas vantagens. Geralmente, você pode escrever métodos que precisam de uma estrutura simples que contém mais de um elemento de dados. Para dar suporte a esses cenários foram adicionadas tuplas ao C#. As tuplas são estruturas de dados leves que contêm vários campos para representar os membros de dados. Os campos não são validados e você não pode definir seus próprios métodos
Observação

As tuplas estavam disponíveis antes do C# 7, mas elas eram ineficientes e não tinham nenhum suporte de linguagem. Isso significava que os elementos de tupla só podiam ser referenciados como Item1, Item2 e assim por diante. O C# 7 introduz o suporte de linguagem para tuplas, que permite nomes semânticos para os campos de uma tupla, usando tipos de tupla novos e mais eficientes.
Você pode criar uma tupla atribuindo cada membro a um valor:



```
var letters = ("a", "b");
```
A atribuição cria uma tupla cujos membros são Item1 e Item2, que podem ser usados da mesma forma que Tuple. Você pode alterar a sintaxe para criar uma tupla que fornece nomes semânticos para cada um dos membros da tupla:



```
(string Alpha, string Beta) namedLetters = ("a", "b");
```
A tupla namedLetters contém campos denominados Alpha e Beta. Esses nomes existem somente em tempo de compilação e não são preservados, por exemplo, ao inspecionar a tupla usando a reflexão em tempo de execução.
Em uma atribuição de tupla, você também pode especificar os nomes dos campos no lado direito da atribuição:



```
var alphabetStart = (Alpha: "a", Beta: "b");
```
Você pode especificar nomes para os campos no lado esquerdo e direito da atribuição:



```
(string First, string Second) firstLetters = (Alpha: "a", Beta: "b");
```
A linha acima gera um aviso, CS8123, informando que os nomes no lado direito da atribuição, Alpha e Beta, são ignorados porque eles estão em conflito com os nomes no lado esquerdo, First e Second.
Os exemplos acima mostram a sintaxe básica para declarar tuplas. As tuplas são mais úteis como tipos de retorno para os métodos private e internal. As tuplas fornecem uma sintaxe simples para esses métodos retornarem vários valores distintos: salve o trabalho de criação de um class ou um struct que define o tipo retornado. Não é necessário criar um novo tipo.
Criar uma tupla é mais eficiente e produtivo. É uma sintaxe mais simples e leve para definir uma estrutura de dados que contém mais de um valor. O método de exemplo a seguir retorna os valores mínimo e máximo encontrados em uma sequência de inteiros:



```
private static (int Max, int Min) Range(IEnumerable<int> numbers)
{
    int min = int.MaxValue;
    int max = int.MinValue;
    foreach(var n in numbers)
    {
        min = (n < min) ? n : min;
        max = (n > max) ? n : max;
    }
    return (max, min);
}
```
Usar tuplas dessa maneira oferece várias vantagens:
Você salva o trabalho de criação de um class ou um struct que define o tipo retornado.
Você não precisa criar um novo tipo.
Os aprimoramentos de linguagem removem a necessidade de chamar os métodos Create<T1>(T1).
A declaração do método fornece os nomes dos campos da tupla que é retornada. Quando você chama o método, o valor retornado é uma tupla cujos campos são Max e Min:



```
var range = Range(numbers);
```
Pode haver ocasiões em que você deseja descompactar os membros de uma tupla que foram retornados de um método. Você pode fazer isso declarando variáveis separadas para cada um dos valores na tupla. Isso é chamado de desconstruir a tupla:



```
(int max, int min) = Range(numbers);
```
Você também pode fornecer uma desconstrução semelhante para qualquer tipo no .NET. Isso é feito escrevendo um método Deconstruct como um membro da classe. esse método Deconstruct fornece um conjunto de argumentos out para cada uma das propriedades que você deseja extrair. Considere essa classe Point que fornece um método desconstrutor que extrai as coordenadas X e Y:



```
public class Point
{
    public Point(double x, double y)
    {
        this.X = x;
        this.Y = y;
    }

    public double X { get; }
    public double Y { get; }

    public void Deconstruct(out double x, out double y)
    {
        x = this.X;
        y = this.Y;
    }
}
```
Você pode extrair os campos individuais atribuindo uma tupla a um Point:



```
var p = new Point(3.14, 2.71);
(double X, double Y) = p;
```
Você não está vinculado aos nomes definidos no método Deconstruct. Você pode renomear as variáveis de extração como parte da atribuição:




```
(double horizontalDistance, double verticalDistance) = p;
```
Você pode aprender sobre tuplas de forma mais aprofundada no tópico sobre tuplas.