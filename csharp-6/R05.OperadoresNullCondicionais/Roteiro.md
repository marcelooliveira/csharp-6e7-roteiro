Operadores condicionais null
Os valores null complicam o código. É necessário verificar cada acesso de variáveis para garantir que você não está desreferenciando null. O operador condicional null torna essas verificações muito mais fáceis e fluidas.
Basta substituir o acesso de membro . por ?.:

```
var first = person?.FirstName; 
```
No exemplo anterior, a variável first é atribuída como null se o objeto person é null. Caso contrário, ela é atribuída com o valor da propriedade FirstName. Mais importante, o ?. significa que essa linha de código não gerará um NullReferenceException quando a variável person for null. Em vez disso, ela encurta o caminho e produz null.
Além disso, observe que essa expressão retorna uma string, independentemente do valor de person. No caso de encurtar o caminho, o valor null retornado é tipado para corresponder à expressão completa.
Você também pode usar esse constructo com o operador null coalescing para atribuir valores padrão quando uma das propriedades é null:

```
first = person?.FirstName ?? "Unspecified";
```
O operando do lado direito do operador ?. não está limitado a campos ou propriedades. Você também pode usá-lo para invocar métodos de maneira condicional. O uso mais comum de funções membro com o operador condicional null é para invocar delegados com segurança (ou manipuladores de eventos) que podem ser null. Você fará isso chamando o método Invoke do delegado, usando o operador ?. para acessar o membro. Você pode ver um exemplo no
tópico padrões delegados.
As regras do operador ?. garantem que o lado esquerdo do operador é avaliado apenas uma vez. Isso é importante e habilita muitas expressões, incluindo o exemplo com o uso de manipuladores de eventos. Vamos começar com o uso do manipulador de eventos. Nas versões anteriores do C#, você era incentivado a escrever código assim:

```
var handler = this.SomethingHappened;
if (handler != null)
    handler(this, eventArgs);
Isso era preferível em relação a uma sintaxe mais simples:
```

```
// Not recommended
if (this.SomethingHappened != null)
    this.SomethingHappened(this, eventArgs);
```
Importante

O exemplo anterior introduz uma condição de corrida. O evento SomethingHappened pode ter assinantes quando verificado em relação a null e esses assinantes podem ter sido removidos antes de o evento ser acionado. Isso poderia causar o lançamento de uma NullReferenceException.
Nesta segunda versão, o manipulador de eventos SomethingHappened pode ser não nulo quando testado, mas se outro código remover um manipulador, ele ainda poderia ser null quando o manipulador de eventos foi chamado.
O compilador gera um código para o operador ?., que garante que o lado esquerdo (this.SomethingHappened) da expressão ?. é avaliado uma vez e o resultado é armazenado em cache:

```
// preferred in C# 6:
this.SomethingHappened?.Invoke(this, eventArgs);
Garantir que o lado esquerdo seja avaliado apenas uma vez também habilita você a usar qualquer expressão, inclusive chamadas de método, no lado esquerdo do ?.. Mesmo que elas tenham efeitos colaterais, elas serão avaliadas uma vez e os efeitos colaterais ocorrerão apenas uma vez. Você pode ver um exemplo em nosso conteúdo em eventos.
```