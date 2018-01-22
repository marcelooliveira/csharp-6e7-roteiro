A partir do C# 6, qual(is) a(s) forma(s) aceitável(is) para concatenar uma string
com expressões C#?

a-
```
public string DadosPessoais
{
    return $"Nome: {NomeCompleto}, Endereço: {Endereco}, Telefone: {Telefone}, Data de Nascimento: {DataNascimento:dd/MM/yyyy}";
}
```
Isso mesmo! Essa é a forma conhecida como **interpolação de strings**, que
foi introduzida a partir do C# 6

b-
```
public string DadosPessoais
{
    return string.Format("Nome: {0}, Endereço: {1}, Telefone: {2}, Data de Nascimento: {3:dd/MM/yyyy}",
        NomeCompleto, Endereco, Telefone, DataNascimento);
}
```
Isso mesmo! Método `public static string Format(string format, params object[] args)`
já existia e continua sendo válido para interpolar strings com uma lista de parâmetros em forma de expressões C#.

c-
```
public string DadosPessoais
{
    return "Nome: " + NomeCompleto + ", Endereço: " + Endereco + ", Telefone: " + Telefone + ", Data de Nascimento: " + DataNascimento.ToString("dd/MM/yyyy");
}
```
Isso mesmo! O operador **mais** (+)
já existia e continua sendo válido para concatenar strings com outras expressões C# (incluindo outras strings).

d-
```
public string DadosPessoais
{
    return "Nome: {NomeCompleto}, Endereço: {Endereco}, Telefone: {Telefone}, Data de Nascimento: {DataNascimento:dd/MM/yyyy}";
}
```
Ops! Para esse código funcionar, a **interpolação de strings**, é necessário
preceder a cadeia de caracteres com o caractere ***dólar ($)***.

e-
```
public string DadosPessoais
{
    return string.Format("Nome: {NomeCompleto}, Endereço: {Endereco}, Telefone: {Telefone}, Data de Nascimento: {DataNascimento:dd/MM/yyyy}");
}
```
Ops! Esse código confundiu o uso do método **string.Format()** (que exige uma string com marcadores índices 0, 1, 2, etc.)
com a **interpolação de strings**.

f-
```
public string DadosPessoais
{
    return @"Nome: {NomeCompleto}, Endereço: {Endereco}, Telefone: {Telefone}, Data de Nascimento: {DataNascimento:dd/MM/yyyy}";
}
```
Ops! O símbolo ***arroba*** (@) é usado para criar cadeias de caracteres "verbatim" (isto é, literais),
que fazem o compilador ignorar o caractere de escape ("\").
