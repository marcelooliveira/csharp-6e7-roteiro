Observe o código abaixo:

```
string valor1 = "Virgulino";
string valor2 = "Ferreira";
Console.WriteLine($"resultado: {valor1} {nameof(valor2)}");
```

O que acontece quando esse código é executado? Escolha a melhor resposta: 

a-
É impresso no console:
```
resultado: Virgulino valor2
```
Isso mesmo! O símbolo **$** (dólar) permite a **interpolação da string**.
Já o operador **nameof** obtém o nome do símbolo **valor2** ("valor2").

b-
É impresso no console:
```
resultado: Virgulino Ferreira
```
Ops! O operador **nameof** obtém o nome do símbolo **valor2** ("valor2"),
e não o seu valor.

c-
É impresso no console:
```
resultado: valor1 valor2
```
Ops! O símbolo **$** (dólar) permite a **interpolação da string**.
A expressão `{valor1}` é resolvida como "Virgulino", e não como "valor1".

d-
É lançada uma exceção: ***`erro CS0103: O nome 'nameof' não existe no contexto atual`***,
pois a expressão `nameof` não é um nome de variável. 
Ops! Não só variáveis, mas qualquer expressão C# é permitida dentro das chaves numa interpolação
de strings. O operador **nameof** irá obter o nome do símbolo **valor2** ("valor2").