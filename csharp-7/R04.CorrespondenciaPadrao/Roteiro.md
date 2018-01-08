# Correspondência de padrões

Correspondência de padrões é um recurso que permite que você implemente a expedição do método em propriedades diferentes do tipo de um objeto. Você provavelmente já está familiarizado com a expedição de método com base no tipo de um objeto. Em programação orientada a objetos, os métodos de substituição e virtual fornecem a sintaxe da linguagem para implementar a expedição de método com base em um tipo de objeto. As classes base e derivada fornecem implementações diferentes. Expressões de correspondência de padrões estendem esse conceito para que você possa implementar facilmente padrões de expedição semelhantes para elementoos de dados e tipos que não são relacionados por meio de uma hierarquia de herança.

A correspondência de padrões tem suporte a expressões is e switch. Cada uma delas permite inspecionar um objeto e suas propriedades para determinar se esse objeto satisfaz o padrão procurado. Você usa a palavra-chave when para especificar regras adicionais para o padrão.
Expressão is
A expressão de padrão is estende o operador familiar is para consultar um objeto além de seu tipo.
Vamos começar com um cenário simples. Vamos adicionar recursos a este cenário que demonstram como expressões de correspondência de padrões tornam algoritmos que funcionam com tipos não relacionados fáceis. Começaremos com um método que calcula a soma de uma série de rolagens de dado:



```
public static int DiceSum(IEnumerable<int> values)
{
    return values.Sum();
}
```
Você pode pensar rapidamente que precisa localizar a soma dos lançamentos de dado em que alguns dos lançamentos são feitos com vários dados (dados é plural de dado). Parte da sequência de entrada pode ser vários resultados, em vez de um único número:



```
public static int DiceSum2(IEnumerable<object> values)
{
    var sum = 0;
    foreach(var item in values)
    {
        if (item is int val)
            sum += val;
        else if (item is IEnumerable<object> subList)
            sum += DiceSum2(subList);
    }
    return sum;
}
```
A expressão padrão is funciona muito bem nesse cenário. Como parte da verificação de tipo, você escreve uma inicialização de variável. Isso cria uma nova variável do tipo de tempo de execução validado.
Conforme você continua a expandir esses cenários, pode descobrir que cria mais instruções if e else if. Assim que isso se tornar complicado, provavelmente você desejará mudar para expressões padrão switch.

Atualizações da instrução switch
A expressão de correspondência tem uma sintaxe familiar, com base na instrução switch que já faz parte da linguagem C#. Vamos converter o código existente para usar uma expressão de correspondência antes de adicionar novas expressões case:




```
public static int DiceSum3(IEnumerable<object> values)
{
    var sum = 0;
    foreach (var item in values)
    {
        switch (item)
        {
            case int val:
                sum += val;
                break;
            case IEnumerable<object> subList:
                sum += DiceSum3(subList);
                break;
        }
    }
    return sum;
}
```
As expressões de correspondência têm uma sintaxe ligeiramente diferente das expressões is, em que você declara o tipo e a variável no início da expressão case.
As expressões de correspondência também dão suporte a constantes. Isso pode poupar tempo ao fatorar expressões case simples:



```
public static int DiceSum4(IEnumerable<object> values)
{
    var sum = 0;
    foreach (var item in values)
    {
        switch (item)
        {
            case 0:
                break;
            case int val:
                sum += val;
                break;
            case IEnumerable<object> subList when subList.Any():
                sum += DiceSum4(subList);
                break;
            case IEnumerable<object> subList:
                break;
            case null:
                break;
            default:
                throw new InvalidOperationException("unknown item type");
        }
    }
    return sum;
}
```
O código acima adiciona expressões case de 0 como um case especial de int e null como um case especial quando não há nenhuma entrada. Isso demonstra um novo recurso importante em expressões de padrão switch: a ordem das expressões case agora importa. O case 0 deve aparecer antes do case int geral. Caso contrário, o primeiro padrão a ser correspondido seria o case int, mesmo quando o valor fosse 0. Se você acidentalmente ordenar expressões de correspondência de forma que uma expressão posterior já tenha sido tratada, o compilador sinalizará isso e gerará um erro.
Esse mesmo comportamento habilita o case especial para uma sequência de entrada vazia. Você pode ver que o case de um item IEnumerable que tem elementoos deve aparecer antes do case IEnumerable geral.
Esta versão também adicionou um case default. O case default sempre é avaliado por último, independentemente da ordem em que ele aparece na origem. Por esse motivo, a convenção é colocar o case default por último.
Por fim, vamos adicionar um último case para um novo estilo de dado. Alguns jogos usam dados de percentil para representar intervalos maiores de números.

Observação

Dois dados de percentil de 10 faces podem representar todos os números de 0 a 99. Um dado tem os lados rotulados como 00, 10, 20,... 90. O outro dado tem os lados rotulados como 0, 1, 2,... 9. Some os valores dos dois dados e você pode obter todos os números de 0 a 99.
Para adicionar esse tipo de dado à sua coleção, primeiro defina um tipo para representar os dados do percentil. A propriedade TensDigit armazena valores 0, 10, 20, até 90:



```
public struct PercentileDice
{
    public int OnesDigit { get; }
    public int TensDigit { get; }

    public PercentileDice(int tensDigit, int onesDigit)
    {
        this.OnesDigit = onesDigit;
        this.TensDigit = tensDigit;
    }
}
```
Em seguida, adicione uma expressão de correspondência case para o novo tipo:



```
public static int DiceSum5(IEnumerable<object> values)
{
    var sum = 0;
    foreach (var item in values)
    {
        switch (item)
        {
            case 0:
                break;
            case int val:
                sum += val;
                break;
            case PercentileDice dice:
                sum += dice.TensDigit + dice.OnesDigit;
                break;
            case IEnumerable<object> subList when subList.Any():
                sum += DiceSum5(subList);
                break;
            case IEnumerable<object> subList:
                break;
            case null:
                break;
            default:
                throw new InvalidOperationException("unknown item type");
        }
    }
    return sum;
}
```
A nova sintaxe para expressões de correspondência de padrões torna mais fácil criar algoritmos de expedição com base no tipo de um objeto ou outras propriedades, usando uma sintaxe clara e concisa. Expressões de correspondência de padrões permitem esses constructos em tipos de dados que não são relacionados por herança.
Você pode aprender mais sobre a correspondência de padrões no tópico dedicado à correspondência de padrões no C#.