# Aprimoramentos da sintaxe de literais numéricos

A leitura incorreta das constantes numéricas pode fazer com que seja difícil entender o código ao lê-lo pela primeira vez. Isso ocorre geralmente quando esses números são usados como máscaras de bits ou outros simbólicos em vez de valores numéricos. O C# 7 inclui dois novos recursos para facilitar a gravação de números da maneira mais legível para o uso pretendido: literais binários e separadores de dígito.
Para ocasiões em que você estiver criando máscaras de bits ou sempre que uma representação binária de um número torna o código mais legível, escreva esse número em binário:



```
public const int One =  0b0001;
public const int Two =  0b0010;
public const int Four = 0b0100;
public const int Eight = 0b1000;
```
O 0b no início da constante indica que o número é escrito como um número binário.
Números binários podem ficar muito longos, portanto, é mais fácil ver os padrões de bit introduzindo o _ como um separador de dígitos:



```
public const int Sixteen =   0b0001_0000;
public const int ThirtyTwo = 0b0010_0000;
public const int SixtyFour = 0b0100_0000;
public const int OneHundredTwentyEight = 0b1000_0000;
```
O separador de dígitos pode aparecer em qualquer lugar na constante. Para números de base 10, seria comum para usá-lo como um separador de milhar:



```
public const long BillionsAndBillions = 100_000_000_000;
```
O separador de dígitos pode ser usado com os tipos decimal, float e double:



```
public const double AvogadroConstant = 6.022_140_857_747_474e23;
public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;
```
Juntos, você pode declarar constantes numéricas com muito mais facilidade de leitura.