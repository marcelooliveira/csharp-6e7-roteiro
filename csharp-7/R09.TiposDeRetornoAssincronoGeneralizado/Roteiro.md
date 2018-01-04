Tipos de retorno assíncrono generalizado
Retornar um objeto Task de métodos assíncronos pode introduzir afunilamentos de desempenho em determinados caminhos. Task é um tipo de referência, portanto, usá-lo significa alocar um objeto. Em casos em que um método declarado com o modificador async retorna um resultado armazenado em cache ou é concluído de forma síncrona, as alocações extras podem se tornar um custo de tempo significativo em seções críticas de desempenho de código. Ele poderá se tornar muito caro se essas alocações ocorrerem em loops rígidos.
O novo recurso de linguagem significa que os métodos assíncronos podem retornar outros tipos além de Task, Task<T> e void. O tipo retornado ainda deve satisfazer o padrão assíncrono, o que significa que um método GetAwaiter deve ser acessível. Como um exemplo concreto, o tipo ValueTask foi adicionado ao .NET Framework para usar esse novo recurso de linguagem:




```
public async ValueTask<int> Func()
{
    await Task.Delay(100);
    return 5;
}
```
Observação

Você precisa adicionar o pacote NuGet System.Threading.Tasks.Extensions para usar o tipo ValueTask<TResult>.
Uma otimização simples seria usar ValueTask em locais em que Task seria usado antes. No entanto, se você quiser executar otimizações adicionais manualmente, poderá armazenar em cache os resultados do trabalho assíncrono e reutilizar o resultado em chamadas subsequentes. O struct ValueTask tem um construtor com um parâmetro Task para que você possa construir um ValueTask do valor retornado de qualquer método assíncrono existente:



```
public ValueTask<int> CachedFunc()
{
    return (cache) ? new ValueTask<int>(cacheResult) : new ValueTask<int>(LoadCache());
}
private bool cache = false;
private int cacheResult;
private async Task<int> LoadCache()
{
    // simulate async work:
    await Task.Delay(100);
    cacheResult = 100;
    cache = true;
    return cacheResult;
}
```
Como com todas as recomendações de desempenho, você deve submeter a benchmark as duas versões antes de fazer alterações em grande escala em seu código.