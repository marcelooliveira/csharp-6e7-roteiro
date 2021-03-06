﻿# Interpolação de cadeia de caracteres

O C# 6 contém uma nova sintaxe para compor cadeias de caracteres de uma cadeia 
de caracteres de formato e de expressões que podem ser avaliadas para produzir 
outros valores de cadeia de caracteres.
Tradicionalmente, você precisava usar parâmetros posicionais em um método como 
`string.Format`:

```
public string NomeCompleto
{
    get
    {
        return string.Format("{0} {1}", Prenome, Sobrenome);
    }
}
```

Com o C# 6, o novo recurso de interpolação de cadeia de caracteres permite que 
você insira as expressões na cadeia de caracteres de formato. Basta preceder a 
cadeia de caracteres com o caractere ***dólar ($)***:

```
public string NomeCompleto => $"{Prenome} {Sobrenome}";
```

Este exemplo inicial usou expressões variáveis para as expressões substituídas. 
Você pode expandir esta sintaxe para usar qualquer expressão. Por exemplo, você 
pode calcular a média do aluno como parte da interpolação:



```
public string GetNotaMedia() =>
    $"Name: {Sobrenome}, {Prenome}. G.P.A: {Notas.Average()}";
```

Ao executar o exemplo anterior, você veria que a saída de `Notas.Average()` pode 
ter mais casas decimais do que o desejado. A sintaxe de interpolação de cadeia 
de caracteres dá suporte a todas as cadeias de caracteres de formato disponíveis 
que usam métodos de formatação anteriores. Você adiciona as cadeias de caracteres 
de formato dentro de chaves. Adicione um **: (dois pontos)** seguido da expressão a ser formatada:

```
public string GetPorcentagemNotaMedia() =>
    $"Name: {Sobrenome}, {Prenome}. G.P.A: {Notas.Average():F2}";
```

A linha de código anterior formatará o valor de `Notas.Average()` como um número de 
ponto flutuante com duas casas decimais.
O **: (dois pontos)** é sempre interpretado como o separador entre a expressão que está sendo 
formatada e a cadeia de caracteres de formato. Isso pode causar problemas quando 
a expressão usa um **: (dois pontos)** de outra forma, como um operador condicional:

```
public string GetPorcentagemNotaMedias() =>
    $"Name: {Sobrenome}, {Prenome}. G.P.A: {Notas.Any() ? Notas.Average() : double.NaN:F2}";
```

No exemplo anterior, o **: (dois pontos)** é analisado como o início da cadeia de caracteres de 
formato e não como parte do operador condicional. Em todos os casos em que isso 
ocorre, você pode colocar a expressão entre parênteses para forçar o compilador a 
interpretar a expressão como você deseja:

```
public string GetPorcentagemNotaMedias() =>
    $"Name: {Sobrenome}, {Prenome}. G.P.A: {(Notas.Any() ? Notas.Average() : double.NaN):F2}";
```

Não há limitações em expressões que você pode colocar entre as chaves. Você pode
 executar uma consulta **LINQ** complexa dentro de uma cadeia de caracteres interpolada
 para realizar cálculos e exibir o resultado:

```
public string GetTodasNotas() =>
    $@"All Notas: {Notas.OrderByDescending(g => g)
    .Select(s => s.ToString("F2")).Aggregate((parcial, elemento) => $"{parcial}, {elemento}")}";
```

Neste exemplo você pode ver que é até mesmo possível aninhar uma expressão de 
interpolação de cadeia de caracteres dentro de outra expressão de interpolação 
de cadeia de caracteres. É muito provável que este exemplo seja mais complexo 
do que você desejaria no código de produção. No entanto, ele serve para ilustrar 
abrangência do recurso. Qualquer expressão de C# pode ser colocada entre as 
chaves de uma cadeia de caracteres interpolada.
Interpolação de cadeia de caracteres e culturas específicas
Todos os exemplos mostrados na seção anterior formatarão as cadeias de caracteres 
usando a cultura e o idioma atuais do computador em que o código é executado. 
Com frequência, talvez seja necessário formatar a cadeia de caracteres gerada, 
usando uma cultura específica. O objeto produzido de uma interpolação de cadeia 
de caracteres é um tipo que tem uma conversão implícita para `String` ou 
`FormattableString`.
O tipo `FormattableString` contém a cadeia de caracteres de formato e os 
resultados da avaliação de argumentos antes de convertê-los em cadeias de 
caracteres. Você pode usar métodos públicos de `FormattableString` para especificar 
a cultura ao formatar uma cadeia de caracteres. O exemplo a seguir produzirá uma 
cadeia de caracteres usando o alemão como o idioma e a cultura. (Ele usará o 
caractere ',' para o separador decimal e o caractere '.' como separador de 
milhares).

```
FormattableString str = $"A nota média é {s.Notas.Average()}";
var notaStr = string.Format(null, 
    System.Globalization.CultureInfo.CreateSpecificCulture("de-de"),
    str.GetFormat(), str.GetArguments());
```
