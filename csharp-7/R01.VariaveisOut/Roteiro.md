Variáveis out
A sintaxe existente que dá suporte a parâmetros out foi aperfeiçoada nesta versão.

Anteriormente, você precisaria separar a declaração da variável out e sua inicialização em duas instruções diferentes:



int numericResult;
if (int.TryParse(input, out numericResult))
    WriteLine(numericResult);
else
    WriteLine("Could not parse input");

Agora você pode declarar variáveis out na lista de argumentos de uma chamada de método, em vez de escrever uma instrução de declaração separada:



if (int.TryParse(input, out int result))
    WriteLine(result);
else
    WriteLine("Could not parse input");
Você talvez queira especificar o tipo da variável out para maior clareza, conforme mostrado acima. No entanto, a linguagem dá suporte ao uso de variável local de tipo implícito:



if (int.TryParse(input, out var answer))
    WriteLine(answer);
else
    WriteLine("Could not parse input");
O código é mais fácil de ler.
Você declara a variável out onde a usa, não em outra linha acima.
Não é necessário atribuir um valor inicial.
Ao declarar a variável out onde ela é usada em uma chamada de método, você não pode usá-la acidentalmente antes de ela ser atribuída.
O uso mais comum para esse recurso será o padrão Try. Nesse padrão, um método retorna um bool indicando êxito ou falha e uma variável out que fornece o resultado se o método tiver êxito.
Ao usar a declaração de variável out, a variável declarada "vaza" no escopo externo da instrução if. Isso permite que você use a variável posteriormente:



if (!int.TryParse(input, out int result))
{    
    return null;
}

return result;