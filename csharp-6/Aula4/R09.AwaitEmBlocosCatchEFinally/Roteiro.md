# Await em blocos catch e finally

O C# 5 tinha várias limitações quanto ao local em que você poderia colocar 
expressões await. Uma delas foi removida no C# 6. Agora você pode usar `await` em 
expressões `catch` ou `finally`.

A adição de expressões await em blocos `catch` e `finally` pode parecer complicar a
 maneira como eles são processados. Vamos adicionar um exemplo para discutir como 
isso é exibido. Em qualquer método assíncrono, você pode usar uma expressão `await` 
em uma cláusula `finally`.
Com o C# 6, você também pode aguardar em expressões catch. Isso geralmente é usado 
com cenários de registro em log:

```
public static async Task<string> FazerRequisicaoELogarFalhas()
{ 
    await logarEntradaNoMetodo();
    var cliente = new System.Net.Http.HttpClient();
    var streamTask = cliente.GetStringAsync("https://localHost:10000");
    try {
        var responseText = await streamTask;
        return responseText;
    } catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
    {
        await logarErro("Recuperado da redireção", e);
        return "Site Mudou de Endereço";
    }
    finally
    {
        await logarSaidaDoMetodo();
        cliente.Dispose();
    }
}
```

Os detalhes de implementação para adicionar suporte ao await dentro de cláusulas 
`catch` e `finally` garante que o comportamento é consistente com o comportamento de 
código síncrono. Quando o código que é executado em uma cláusula `catch` ou `finally` 
realiza o lançamento, a execução procura por uma cláusula `catch` adequada no próximo 
bloco. Se houver uma exceção atual, essa exceção será perdida. O mesmo acontece 
com expressões aguardadas em cláusulas catch e finally: um `catch` adequado é 
pesquisado e a exceção atual, se houver, será perdida.

Observação

Esse comportamento é a razão pela qual recomenda-se escrever cláusulas `catch` e 
`finally` com cuidado, a fim de evitar introduzir novas exceções.