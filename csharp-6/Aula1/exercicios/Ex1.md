# private set VS Propriedade Automática Somente-Leitura 

Você está desenvolvendo um sistema de gestão escolar. Na classe `Aluno`,
você está montando as propriedades do aluno e, entre elas, a propriedade **Nome**.
Ao implementar a propriedade, você fica em dúvida entre duas implementações possíveis
para a mesma propriedade `Nome`:

### 1) Propriedade automática com `private set`

```
public string Nome { get; private set; }

```

### 2) Propriedade automática somente-leitura

```
public string Nome { get; }
```

Em que situação você utilizaria uma **propriedade automática somente-leitura**
em vez de uma **propriedade automática com `private set`**? Escolha a melhor alternativa.

a- para que a propriedade `Nome` seja realmente imutável.
Isso mesmo! Uma **propriedade automática somente-leitura** só pode receber um valor na declaração
da propriedade ou no construtor da classe, mas nunca em propriedades ou métodos da classe.

b- para que a propriedade `Nome` seja alterável apenas nos métodos da classe `Aluno`.
Ops! O propósito da propriedade automática somente-leitura é justamente impedir que
seu valor seja definido em métodos (e propriedades) da classe.

c- para que a propriedade `Nome` seja alterável somente fora da classe `Aluno`.
Ops! A propriedade `Nome` não tem acessador `set`, logo não pode ser modificada fora da classe.

d- para que a propriedade `Nome` não possa ser lida fora da classe `Aluno`.
Ops! A propriedade `Nome` pode ser lida sim, pois tem visibilidade `public` e acessador `get` público.
