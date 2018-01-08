# Inicializadores de propriedade automática

Os Inicializadores de propriedade automática permitem 
que você declare o valor inicial de uma propriedade 
automática como parte da declaração de propriedade. 
Em versões anteriores, essas propriedades precisariam 
de setters e você teria que usar esse setter para 
inicializar o armazenamento de dados usado pelo campo 
de suporte. Considere essa classe para um aluno que contém o 
nome e uma lista das notas do aluno:

```
public Aluno(string prenome, string sobrenome)
{
    Prenome = prenome;
    Sobrenome = sobrenome;
}
```

Conforme essa classe cresce, você pode incluir outros construtores. 
Cada construtor precisa inicializar este campo ou você introduzirá 
erros.
O C# 6 permite que você atribua um valor inicial para o armazenamento 
usado por uma propriedade automática na declaração da propriedade 
automática:

```
public ICollection<double> Notas { get; } = new List<double>();
```

A propriedade `Notas` é inicializada no local em que é declarado. Isso 
facilita realizar a inicialização exatamente uma vez. A inicialização
 faz parte da declaração de propriedade, tornando mais fácil igualar
 a alocação de armazenamento com a interface pública para objetos 
`Aluno`.
Inicializadores de propriedade podem ser usados com propriedades 
de leitura/gravação, bem como propriedades somente leitura, conforme 
mostrado aqui.

```
public Ano AnoNaEscola { get; set; } = Ano.Primeiro;
```
