A partir do C# 6, foi introduzido um recurso chamado **filtro de exceção**.

Como você implementaria um **filtro de exceção** num método que obtém
o resultado de uma consulta a um endereço http e trata as exceções de acordo 
com o código do erro HTTP da mensagem?

a-
```
public static async Task<string> FazerRequisicao()
{ 
    var cliente = new System.Net.Http.HttpClient();
    var streamTask = cliente.GetStringAsync("https://localHost:10000");
    try 
    {
        var resposta = await streamTask;
        return resposta;
    } 
    catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("404"))
    {
        return "Página não encontrada";
    } 
    catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("301"))
    {
        return "Site Mudou de Endereço";
    } 
    catch (System.Net.Http.HttpRequestException e) when (e.Message.Contains("304"))
    {
        return "Usar o Cache";
    }
    catch (System.Exception e)
    {
        return "Ocorreu uma exceção";
    }
}
```
Isso mesmo! Os filtros de exceção são 
cláusulas que determinam quando uma determinada cláusula catch deve ser aplicada. 
Se a expressão usada para um filtro de exceção é avaliada como **true**, a cláusula 
`catch` realiza seu processamento normal em uma exceção. Se a expressão for avaliada 
como **false**, a cláusula `catch` será ignorada. A maneira que usamos para criar
filtro de exceções é criando cláusula `catch` com a cláusula `when`, onde é definida
a expresssão do filtro.

b-
```
public static async Task<string> FazerRequisicao()
{ 
    var cliente = new System.Net.Http.HttpClient();
    var streamTask = cliente.GetStringAsync("https://localHost:10000");
    try 
    {
        var resposta = await streamTask;
        return resposta;
    } 
    catch (System.Exception e)
    {
        if (e.Message.Contains("404"))
        {
            return "Página não encontrada";
        } 
        if (e.Message.Contains("301"))
        {
            return "Site Mudou de Endereço";
        } 
        if (e.Message.Contains("304"))
        {
            return "Usar o Cache";
        }

        return "Ocorreu uma exceção";
    }
}
```
Ops! Um **filtro de excepção** é criado com a cláusula `when` ***na mesma linha***
da cláusula `catch`, e não criando condicionais ***dentro*** da cláusula `catch`.

c-
```
public static async Task<string> FazerRequisicao()
{ 
    var cliente = new System.Net.Http.HttpClient();
    var streamTask = cliente.GetStringAsync("https://localHost:10000");
    try 
    {
        var resposta = await streamTask;
        return resposta;
    } 
    catch (System.Exception e)
    {
        switch (e.Message)
        {
            case "404":
                return "Página não encontrada";
            case "301":
                return "Site Mudou de Endereço";
            case "304":
                return "Usar o Cache";
            default:
                return "Ocorreu uma exceção";
        }
    }
}
```
Ops! Um **filtro de excepção** é criado com a cláusula `when` ***na mesma linha***
da cláusula `catch`, e não criando condicionais ***dentro*** da cláusula `catch`.


d-
```
public static async Task<string> FazerRequisicao()
{ 
    var cliente = new System.Net.Http.HttpClient();
    var streamTask = cliente.GetStringAsync("https://localHost:10000");
    try 
    {
        var resposta = await streamTask;
        return resposta;
    } 
    catch (System.Net.Http.HttpRequestException e) if (e.Message.Contains("404"))
    {
        return "Página não encontrada";
    } 
    catch (System.Net.Http.HttpRequestException e) if (e.Message.Contains("301"))
    {
        return "Site Mudou de Endereço";
    } 
    catch (System.Net.Http.HttpRequestException e) if (e.Message.Contains("304"))
    {
        return "Usar o Cache";
    }
    catch (System.Exception e)
    {
        return "Ocorreu uma exceção";
    }
}
```
Ops! A maneira que usamos para criar
filtro de exceções é criando cláusula `catch` com a cláusula `when`, onde é definida
a expresssão do filtro, e **não com a cláusula `if`**.