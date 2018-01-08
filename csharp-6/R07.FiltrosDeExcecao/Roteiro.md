# Filtros de exceção

Outro recurso novo no C# 6 são os filtros de exceção. Os filtros de exceção são 
cláusulas que determinam quando uma determinada cláusula catch deve ser aplicada. 
Se a expressão usada para um filtro de exceção é avaliada como **true**, a cláusula 
`catch` realiza seu processamento normal em uma exceção. Se a expressão for avaliada 
como **false**, a cláusula `catch` será ignorada.
Um uso é examinar informações sobre uma exceção para determinar se uma cláusula 
`catch` pode processar a exceção:

```
public static async Task<string> FazerRequisicao()
{ 
    var cliente = new System.Net.Http.HttpClient();
    var streamTask = cliente.GetStringAsync("https://localHost:10000");
    try {
        var responseText = await streamTask;
        return responseText;
    } catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
    {
        return "Site Mudou de Endereço";
    }
}
```

O código gerado pelos filtros de exceção fornece melhores informações sobre uma 
exceção que é lançada e não é processada. Antes que os filtros de exceção fossem 
adicionados à linguagem, era preciso criar código semelhante ao seguinte:

```
public static async Task<string> FazerRequisicao()
{ 
    var cliente = new System.Net.Http.HttpClient();
    var streamTask = cliente.GetStringAsync("https://localHost:10000");
    try {
        var responseText = await streamTask;
        return responseText;
    } catch (System.Net.Http.HttpRequestException e)
    {
        if (e.Message.Contains("301"))
            return "Site Mudou de Endereço";
        else
            throw;
    }
}
```

O ponto em que a exceção é lançada muda nestes dois exemplos. No código anterior, 
em que uma cláusula `throw` é usada, qualquer análise do rastreamento de pilha ou 
exame de despejos de memória mostrará que a exceção foi lançada da instrução `throw` 
na cláusula `catch`. O objeto de exceção real conterá a pilha de chamadas original, 
mas todas as outras informações sobre as variáveis na pilha de chamadas, entre este 
ponto de lançamento e o local do ponto de lançamento original, foram perdidas.

Compare isso com a maneira como o código que usa um filtro de exceção é processado: 
a expressão do filtro de exceção avalia como false. Portanto, execução nunca insere
 a cláusula `catch`. Como a cláusula `catch` não é executada, o desenrolamento de pilha
 não ocorre. Isso significa que o local de lançamento original é preservado para 
qualquer atividade de depuração que aconteceria mais tarde.
Sempre que você precisar avaliar campos ou propriedades de uma exceção, em vez de 
depender exclusivamente do tipo de exceção, use um filtro de exceção para preservar
 mais informações de depuração.
Outro padrão recomendado com filtros de exceção é usá-los para rotinas de registro 
em log. Esse uso também aproveita a maneira pela qual o ponto de lançamento de 
exceção é preservado quando um filtro de exceção é avaliado como false.
Um método de registro em log seria um método cujo argumento é a exceção que retorna
 incondicionalmente false:

```
public static bool LogException(this Exception e)
{
    Console.Error.WriteLine($"Houve exceções: {e}");
    return false;
} 
```

Sempre que você desejar registrar uma exceção, você pode adicionar uma cláusula 
`catch` e usar esse método como o filtro de exceção:

```
public void MetodoQueFalhaAsVezes()
{
    try {
        ExecutarOperacaoFalha();
    } catch (Exception e) when (e.LogException())
    {
        // This is never reached!
    }
} 
```
As exceções nunca são capturadas, porque o método `LogException` sempre retorna 
false. Esse filtro de exceção sempre falso significa que você pode colocar esse 
manipulador de log antes de qualquer outro manipulador de exceção:

```
public void MetodoQueFalhaMasTemCaminhoDeRecuperacao()
{
    try {
        ExecutarOperacaoFalha();
    } catch (Exception e) when (e.LogException())
    {
        // This is never reached!
    }
    catch (RecoverableException ex)
    {
        Console.WriteLine(ex.ToString());
        // This can still catch the more specific
        // exception because the exception filter
        // above always returns false.
        // Perform recovery here 
    }
}
```

O exemplo anterior destaca uma faceta muito importante dos filtros de exceção. 
Os filtros de exceção permitem cenários em que uma cláusula de captura de exceção 
mais geral pode aparecer antes de uma mais específica. Também é possível ter o 
mesmo tipo de exceção aparecendo em várias cláusulas `catch`:

```
public static async Task<string> FazerRequisicaoWithNotModifiedSupport()
{ 
    var cliente = new System.Net.Http.HttpClient();
    var streamTask = cliente.GetStringAsync("https://localHost:10000");
    try {
        var responseText = await streamTask;
        return responseText;
    } catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
    {
        return "Site Mudou de Endereço";
    } catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("304"))
    {
        return "Usar o Cache";
    }
}
```

Outro padrão recomendado ajuda a evitar que cláusulas `catch` processem exceções 
quando um depurador é anexado. Essa técnica permite que você execute um aplicativo 
com o depurador e interrompa a execução quando uma exceção é lançada.
No seu código, adicione um filtro de exceção para que qualquer código de 
recuperação seja executado somente quando um depurador não estiver anexado:

```
public void MethodThatFailsWhenDebuggerIsNotAttached()
{
    try {
        ExecutarOperacaoFalha();
    } catch (Exception e) when (e.LogException())
    {
        // This is never reached!
    }
    catch (RecoverableException ex) when (!System.Diagnostics.Debugger.IsAttached)
    {
        Console.WriteLine(ex.ToString());
        // Only catch exceptions when a debugger is not attached.
        // Otherwise, this should stop in the debugger. 
    }
}
```

Depois de adicionar isso no código, você deve definir o depurador para interromper 
em todas as exceções sem tratamento. Execute o programa no depurador e o depurador 
interromperá sempre que `ExecutarOperacaoFalha()` lançar uma `RecoverableException`. 
O depurador interrompe o programa, porque a cláusula catch não será executada 
devido ao filtro de exceção que retorna false.
