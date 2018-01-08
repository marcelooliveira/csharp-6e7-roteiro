# Expressões Lambda em Membros de Classe

Na maioria das vezes, o corpo de membros de classes consiste em apenas uma instrução, que 
pode ser representada como uma expressão. Você pode reduzir essa sintaxe, 
escrevendo-a na forma de **expressão lambda**. Ela funciona para métodos e propriedades 
somente leitura. Por exemplo, uma substituição de `ToString()` é, geralmente, 
uma ótima candidata:

```
public override string ToString() => $"{Sobrenome}, {Prenome}";
```

Você também pode usar expressão lambda nas propriedades somente leitura 
também:

```
public string NomeCompleto => $"{Prenome} {Sobrenome}";
```