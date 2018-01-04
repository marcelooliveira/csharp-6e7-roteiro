# Expressões nameof

A expressão nameof é avaliada para o nome de um símbolo. É uma ótima maneira de fazer com que as ferramentas funcionem sempre que você precisar do nome de uma variável, de uma propriedade ou de um campo de membro.
Um dos usos mais comuns para nameof é fornecer o nome de um símbolo que causou uma exceção:



```
if (IsNullOrWhiteSpace(lastName))
    throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));
```
Outro uso é com aplicativos baseados em XAML que implementam a interface INotifyPropertyChanged:



```
public string LastName
{
    get { return lastName; }
    set
    {
        if (value != lastName)
        {
            lastName = value;
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(nameof(LastName)));
        }
    }
}
private string lastName;
```
A vantagem de usar o operador nameof em uma cadeia de caracteres constante é que as ferramentas podem entender o símbolo. Se você usar ferramentas de refatoração para renomear o símbolo, elas vão renomeá-lo na expressão nameof. As cadeias de caracteres constantes não têm essa vantagem. Experimente você mesmo em seu editor favorito: renomeie uma variável e qualquer expressão nameof também atualizará.
A expressão nameof produz o nome não qualificado de seu argumento (LastName nos exemplos anteriores), mesmo que você use o nome totalmente qualificado para o argumento:



```
public string FirstName
{
    get { return firstName; }
    set
    {
        if (value != firstName)
        {
            firstName = value;
            PropertyChanged?.Invoke(this, 
                new PropertyChangedEventArgs(nameof(UXComponents.ViewModel.FirstName)));
        }
    }
}
private string firstName;
```
Essa expressão nameof produz FirstName e não UXComponents.ViewModel.FirstName.