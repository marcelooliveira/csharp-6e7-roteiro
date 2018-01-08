# Propriedades automáticas somente-leitura

As Propriedades automáticas somente leitura fornecem uma sintaxe mais concisa 
para criar tipos imutáveis. O mais próximo você chegava em relação a tipos 
imutáveis nas versões anteriores do C# era para declarar setters particulares:

```
public string Prenome { get; private set; }
public string Sobrenome { get; private set; }
```

Ao usar esta sintaxe, o compilador não garante que o tipo é realmente imutável. 
Ele somente impõe que as propriedades `Prenome` e `Sobrenome` não são modificadas 
de qualquer código fora da classe.
As propriedades automáticas somente leitura habilitam o verdadeiro comportamento 
somente leitura. Você declara a propriedade automática apenas com um acessador
 get:

```
public string Prenome { get; }
public string Sobrenome { get;  }
```

As propriedades `Prenome` e `Sobrenome` só podem ser definidas no corpo de um 
construtor:

```
public Aluno(string prenome, string sobrenome)
{
    if (IsNullOrWhiteSpace(sobrenome))
        throw new ArgumentException(message: "Não pode ser vazio", paramName: nameof(sobrenome));
    Prenome = prenome;
    Sobrenome = sobrenome;
}

```

A tentativa de definir Sobrenome em outro método gera um **erro de compilação 
CS0200**:

```
public class Aluno
{
    public string Sobrenome { get;  }

    public void MudarSobrenome(string novoSobrenome)
    {
        // Produz erro: CS0200: Property or indexer cannot be assigned to -- it is read only
        Sobrenome = novoSobrenome;
    }
}
```

Esse recurso habilita o suporte real à linguagem para criar tipos imutáveis e 
usar a sintaxe de propriedade automática mais concisa e conveniente.