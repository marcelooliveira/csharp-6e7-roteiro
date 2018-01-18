#Inicializando Propriedades Automáticas

No curso vimos como implementar a inicialização de uma propriedade automática:

```
public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);
```

Como o compilador do C# gera internamente o código para inicialização de uma propriedade
automática?

a- Criando e inicializando um campo auxiliar interno para a propriedade
Isso mesmo! Um campo auxiliar é criado internamente para cada propriedade automática.
A inicialização de cada propriedade automática é feita inicializando internamente o
campo auxiliar dessa propriedade.

b- Adicionando código no construtor da classe para inicializar a propriedade
Ops! Nenhum código extra é adicionado ao construtor só para inicializar
a propriedade.

c- Criando um método na classe para inicializar a propriedade
Ops! Nenhum método adicional é criado apenas para inicializar a propriedade.

d- Criando um *setter* interno, onde a propriedade é inicializada
Ops! Nenhum *setter* é criado apenas para inicializar pa propriedade. Essa
propriedade é inicializada através do campo auxiliar que é criado internamente.