# Resolução de sobrecarga aprimorada

Esse último recurso provavelmente não será notado. 
Havia construções nas quais a versão anterior do compilador do C# pode ter 
encontrado algumas chamadas de método que envolviam expressões lambda ambíguas. 
Considere este método:

```
static Task DoThings() 
{
     return Task.FromResult(0); 
}
```

Em versões anteriores do C#, haveria uma falha ao chamar esse método usando a 
sintaxe de grupo de método:

```
Task.Run(DoThings); 
```

O compilador anterior não podia distinguir corretamente entre `Task.Run(Action)` e 
`Task.Run(Func<Task>())`. Nas versões anteriores, você precisava usar uma expressão 
lambda como um argumento:



```
Task.Run(() => DoThings());
```

O compilador do C# 6 determina corretamente que `Task.Run(Func<Task>())` é uma 
opção melhor.