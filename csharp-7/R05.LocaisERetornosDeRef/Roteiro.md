# Locais e retornos de ref
Esse recurso permite que os algoritmos que usam e retornam referências para as variáveis definidas em outro lugar. Um exemplo é trabalhar com matrizes grandes e localizar um único local com determinadas características. Um método retornaria os dois índices para um único local na matriz:



```
public static (int i, int j) Find(int[,] matrix, Func<int, bool> predicate)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (predicate(matrix[i, j]))
                return (i, j);
    return (-1, -1); // Not found
}
```
Há muitos problemas com esse código. Em primeiro lugar, ele é um método público que está retornando uma tupla. A linguagem dá suporte a isso, mas tipos definidos pelo usuário (classes ou estruturas) são preferenciais para APIs públicas.
Em segundo lugar, esse método está retornando os índices para o item na matriz. Isso leva os chamadores a escreverem um código que usa esses índices para desreferenciar a matriz e modificar um único elemento:



```
var indices = MatrixSearch.Find(matrix, (val) => val == 42);
Console.WriteLine(indices);
matrix[indices.i, indices.j] = 24;
```
Você prefere escrever um método que retorna uma referência para o elemento da matriz que deseja alterar. Você apenas poderia fazer isso usando código não seguro e retornando um ponteiro para um int em versões anteriores.
Vamos examinar uma série de alterações para demonstrar o recurso local de ref e mostrar como criar um método que retorna uma referência ao armazenamento interno. Ao longo do caminho, você aprenderá as regras do recurso de retorno de ref e local de ref que impedem que você acidentalmente o use de maneira indevida.
Comece modificando a declaração do método Find para que ele retorne um ref int em vez de uma tupla. Em seguida, modifique a instrução return para que ela retorne o valor armazenado na matriz em vez de dois índices:



```
// Note that this won't compile. 
// Method declaration indicates ref return,
// but return statement specifies a value return.
public static ref int Find2(int[,] matrix, Func<int, bool> predicate)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (predicate(matrix[i, j]))
                return matrix[i, j];
    throw new InvalidOperationException("Not found");
}
```
Quando você declara que um método retorna uma variável ref, você também deve adicionar a palavra-chave ref a cada instrução return. Isso indica o retorno pela referência e ajuda os desenvolvedores lendo o código posteriormente a lembrarem que o método retorna pela referência:



```
public static ref int Find3(int[,] matrix, Func<int, bool> predicate)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
        for (int j = 0; j < matrix.GetLength(1); j++)
            if (predicate(matrix[i, j]))
                return ref matrix[i, j];
    throw new InvalidOperationException("Not found");
}
```
Agora que o método retorna uma referência para o valor inteiro na matriz, você precisa modificar onde ele é chamado. A declaração var significa que valItem é agora um int em vez de uma tupla:



```
var valItem = MatrixSearch.Find3(matrix, (val) => val == 42);
Console.WriteLine(valItem);
valItem = 24;
Console.WriteLine(matrix[4, 2]);
```
A segunda instrução WriteLine no exemplo acima imprime o valor 42, não 24. A variável valItem é um int, não um ref int. A palavra-chave var permite que o compilador especifique o tipo, mas não adiciona implicitamente o modificador ref. Em vez disso, o valor referenciado pelo ref return é copiado para a variável no lado esquerdo da atribuição. A variável não é um local de ref.
Para obter o resultado desejado, você precisa adicionar o modificador ref à declaração de variável local para tornar a variável em uma referência quando o valor retornado é uma referência:



```
ref var item = ref MatrixSearch.Find3(matrix, (val) => val == 42);
Console.WriteLine(item);
item = 24;
Console.WriteLine(matrix[4, 2]);
```
Agora, a segunda instrução WriteLine no exemplo acima imprimirá o valor 24, indicando que o armazenamento da matriz foi modificado. A variável local foi declarada com um modificador ref e ele levará um retorno de ref. Você deve inicializar uma variável ref quando ela é declarada, não é possível dividir a declaração e a inicialização.
A linguagem C# tem outras três regras que protegem contra o uso indevido de locais e retornos de ref:
Não é possível atribuir um valor retornado do método padrão a uma variável local de ref.
Isso proíbe que instruções como ref int i = sequence.Count();
Você não pode retornar um ref para uma variável cujo tempo de vida não ultrapassa a execução do método.
Isso significa que você não pode retornar uma referência a uma variável local ou uma variável com escopo semelhante.
O locais e retornos de ref não podem ser usados com métodos assíncronos.
O compilador não consegue saber se a variável referenciada foi definida com o valor final quando o método assíncrono retorna.
A adição de locais de ref e retornos de ref habilita algoritmos que são mais eficientes evitando copiar valores ou executar operações de desreferenciamento várias vezes.

