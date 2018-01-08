# Membros de função aptos para expressão

O corpo de muitos membros que escrevemos consiste em apenas uma instrução, que pode ser representada como uma expressão. Você pode reduzir essa sintaxe, escrevendo um membro apto para expressão. Ele funciona para métodos e propriedades somente leitura. Por exemplo, uma substituição de ToString() é, geralmente, uma ótima candidata:

```
public override string ToString() => $"{Sobrenome}, {Prenome}";
```

Você também pode usar membros bodied expressão nas propriedades somente leitura também:

```
public string NomeCompleto => $"{Prenome} {Sobrenome}";
```