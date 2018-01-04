# Using Static

O aprimoramento using static permite que você importe os métodos estáticos de uma única classe. Anteriormente, a instrução using importava todos os tipos de um namespace.

Com frequência usamos métodos estáticos de uma classe em todo o nosso código. Digitar o nome de classe repetidamente pode obscurecer o significado do seu código. Um exemplo comum é quando você escreve classes que realizam muitos cálculos numéricos. Seu código ficará repleto Sin, Sqrt e outras chamadas a métodos diferentes na classe Math. A nova sintaxe using static pode deixar essas classes muito mais limpas para serem lidas. Você especifica a classe que está usando:
C#

Copiar
using static System.Math;
E agora, você pode usar qualquer método estático na classe Math sem qualificar a classe Math. A classe Math é um ótimo caso de uso desse recurso, porque ela não contém nenhum método de instância. Você também pode usar using static para importar os métodos estáticos de uma classe para uma classe que tem os métodos estáticos e de instância. Um dos exemplos mais úteis é String:
C#

Copiar
using static System.String;
Observação

Você deve usar o nome de classe totalmente qualificado System.String em uma instrução static using. Não é possível usar a palavra-chave string em vez disso.

Agora você pode chamar métodos estáticos definidos na classe String sem qualificar esses métodos como membros dessa classe:
C#

Copiar
if (IsNullOrWhiteSpace(lastName))
    throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));
O recurso static using e os métodos de extensão interagem de maneiras interessantes e o design de linguagem incluiu algumas regras que tratam especificamente dessas interações. A meta é minimizar qualquer possibilidade de alterações significativas nas bases de código existentes, incluindo a sua.
Os métodos de extensão só estão no escopo quando chamados usando a sintaxe de invocação do método de extensão e não quando chamados como um método estático. Você verá isso com frequência em consultas LINQ. Você pode importar o padrão LINQ importando Enumerable.
C#

Copiar
using static System.Linq.Enumerable;
Isso importa todos os métodos na classe Enumerable. No entanto, os métodos de extensão somente estão no escopo quando chamados como métodos de extensão. Eles não estão no escopo se chamados usando a sintaxe de método estático:
C#

Copiar
public bool MakesDeansList()
{
    return Grades.All(g => g > 3.5) && Grades.Any();
    // Code below generates CS0103: 
    // The name 'All' does not exist in the current context.
    //return All(Grades, g => g > 3.5) && Grades.Any();
}
Essa decisão foi tomada porque os métodos de extensão são geralmente chamados usando expressões de invocação de método de extensão. No caso raro em que eles são chamados usando a sintaxe de chamada ao método estático, é para resolver a ambiguidade. Parece prudente exigir o nome de classe como parte da invocação.
Há um último recurso de static using. A diretiva static using também importa todos tipos aninhados. Isso habilita você a referenciar qualquer tipo aninhado sem qualificação.