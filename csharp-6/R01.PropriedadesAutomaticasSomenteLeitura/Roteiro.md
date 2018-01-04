# Propriedades automáticas somente-leitura

As Propriedades automáticas somente leitura fornecem uma sintaxe mais concisa para criar tipos imutáveis. O mais próximo você chegava em relação a tipos imutáveis nas versões anteriores do C# era para declarar setters particulares:

```
public string FirstName { get; private set; }
public string LastName { get; private set; }
```

Ao usar esta sintaxe, o compilador não garante que o tipo é realmente imutável. Ele somente impõe que as propriedades FirstName e LastName não são modificadas de qualquer código fora da classe.
As propriedades automáticas somente leitura habilitam o verdadeiro comportamento somente leitura. Você declara a propriedade automática apenas com um acessador get:

```
public string FirstName { get; }
public string LastName { get;  }
```

As propriedades FirstName e LastName só podem ser definidas no corpo de um construtor:

```
public Student(string firstName, string lastName)
{
    if (IsNullOrWhiteSpace(lastName))
        throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));
    FirstName = firstName;
    LastName = lastName;
}

```

A tentativa de definir LastName em outro método gera um erro de compilação CS0200:

```
public class Student
{
    public string LastName { get;  }

    public void ChangeName(string newLastName)
    {
        // Generates CS0200: Property or indexer cannot be assigned to -- it is read only
        LastName = newLastName;
    }
}
```

Esse recurso habilita o suporte real à linguagem para criar tipos imutáveis e usar a sintaxe de propriedade automática mais concisa e conveniente.