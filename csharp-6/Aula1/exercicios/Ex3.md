## Método com sintaxe de expressão

O trecho abaixo exibe o código para o método `GetIdade()`, utilizando a sintaxe tradicional do C#:

```
public int GetIdade()
{
    return (int)(((DateTime.Now - DataNascimento).TotalDays) / 365.242199);
}
```

Como ficaria o mesmo código, reescrito com a sintaxe de expressão?

a-
```
public int GetIdade()
    => (int)(((DateTime.Now - DataNascimento).TotalDays) / 365.242199);
```
Isso mesmo!

Para reescrevermos um método com sintaxe de expressão, precisamos de algumas alterações
no método original:
* remover as chaves de abertura e fechamento
* remover a instrução `return` do corpo do método.

b-
```
public int GetIdade()
    => return (int)(((DateTime.Now - DataNascimento).TotalDays) / 365.242199);
```

Ops! Na sintaxe de expressão, não devemos utilizar a instrução `return`.

c-
```
public int GetIdade
    => (int)(((DateTime.Now - DataNascimento).TotalDays) / 365.242199);
```
Ops! Na sintaxe de expressão, ainda precisamos dos parênteses da assinatura do método.

d-
```
public int GetIdade
    => return (int)(((DateTime.Now - DataNascimento).TotalDays) / 365.242199);
```

Ops! Na sintaxe de expressão, não devemos utilizar a instrução `return`. Além disso
ainda precisamos dos parênteses da assinatura do método.