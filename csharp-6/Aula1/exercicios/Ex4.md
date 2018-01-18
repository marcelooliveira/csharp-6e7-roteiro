## Membros com sintaxe de expressão

No trecho abaixo temos o código para o a propriedade `NomeCompleto` de uma classe
`Aluno`, utilizando a sintaxe padrão do C#:

```
public string NomeCompleto
{
    get { return Nome + " " + Sobrenome; }
}
```

Como ficaria a mesma propriedade reescrita com sintaxe de expressão? Desenvolva
abaixo os passos necessários para essa alteração.

## RESPOSTA

1. Primeiro vamos remover as chaves da propriedade: 

```
public string NomeCompleto
    get { return Nome + " " + Sobrenome; }
```

2. Em seguida, vamos substituir o acessor `get` pelo operador "flecha" (`=>`):

```
public string NomeCompleto
    => { return Nome + " " + Sobrenome; }
```

3. Agora vamos remover as chaves internas do **getter**:

```
public string NomeCompleto
    => return Nome + " " + Sobrenome;
```


4. Agora sim, removemos a instrução `return` e temos a propriedade com a sintaxe de expressão:

```
public string NomeCompleto
    => Nome + " " + Sobrenome;
```


