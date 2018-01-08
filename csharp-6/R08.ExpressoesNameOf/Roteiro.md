# Expressões nameof

A expressão `nameof` retorna uma string com o nome de um símbolo. É uma ótima maneira de 
fazer com que as ferramentas funcionem sempre que você precisar do nome de uma 
variável, de uma propriedade ou de um campo de classe ou struct.
Um dos usos mais comuns para nameof é fornecer o nome de um símbolo que causou 
uma exceção:

```
if (IsNullOrWhiteSpace(sobrenome))
    throw new ArgumentException(message: "Não pode ser vazio", paramName: nameof(sobrenome));
```

Outro uso é com aplicativos baseados em **XAML** que implementam a interface 
`INotifyPropertyChanged`:


```
public string Sobrenome
{
    get { return sobrenome; }
    set
    {
        if (value != sobrenome)
        {
            sobrenome = value;
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(nameof(Sobrenome)));
        }
    }
}
private string sobrenome;
```

A vantagem de usar o operador `nameof` em uma cadeia de caracteres constante é que as 
ferramentas podem entender o símbolo. Se você usar ferramentas de refatoração para 
renomear o símbolo, elas vão renomeá-lo na expressão `nameof`. As cadeias de 
caracteres constantes não têm essa vantagem. Experimente você mesmo em seu editor 
favorito: renomeie uma variável e qualquer expressão nameof também atualizará.
A expressão nameof produz o nome não qualificado de seu argumento (Sobrenome nos 
exemplos anteriores), mesmo que você use o nome totalmente qualificado para o 
argumento:

```
public string Prenome
{
    get { return prenome; }
    set
    {
        if (value != prenome)
        {
            prenome = value;
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(nameof(UXComponents.ViewModel.Prenome)));
        }
    }
}
private string prenome;
```

Essa expressão `nameof` produz Prenome e não UXComponents.ViewModel.Prenome.
