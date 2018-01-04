# Inicializadores de índice
Os inicializadores de índice são um dos dois recursos que tornam os inicializadores de coleção mais consistentes. Em versões anteriores do C#, você podia usar inicializadores de coleção apenas com coleções de estilo de sequência:

```
private List<string> messages = new List<string> 
{
    "Page not Found",
    "Page moved, but left a forwarding address.",
    "The web server can't come out to play today."
};
```
Agora, você também pode usá-los com coleções Dictionary<TKey,TValue> e tipos semelhantes:

```
private Dictionary<int, string> webErrors = new Dictionary<int, string>
{
    [404] = "Page not Found",
    [302] = "Page moved, but left a forwarding address.",
    [500] = "The web server can't come out to play today."
};
```
Esse recurso significa que os contêineres associativos podem ser inicializados usando uma sintaxe semelhante à que está em vigor para contêineres de sequência de várias versões.
