# Descartes

Geralmente, ao desconstruir uma tupla ou chamar um método com parâmetros out, você é forçado a definir uma variável cujo valor não é importante e você não pretende usar. O C# adiciona suporte para descartes para lidar com esse cenário. Um descarte é uma variável de somente gravação cujo nome é _ (o caractere de sublinhado); você pode atribuir todos os valores que você pretende descartar à variável única. Um descarte é como uma variável não atribuída. Além da instrução de atribuição, o descarte não pode ser usado no código.
Os descartes são compatíveis com os seguintes cenários:
Ao desconstruir tuplas ou tipos definidos pelo usuário.
Ao chamar métodos com parâmetros out.
Em uma operação de correspondência de padrões com as instruções is e switch.
Como um identificador autônomo quando você deseja identificar explicitamente o valor de uma atribuição como um descarte.
O exemplo a seguir define um método QueryCityDataForYears que retorna uma tupla de 6 que contém dados de dois anos diferentes para uma cidade. A chamada do método no exemplo é relacionada somente com os dois valores de população retornados pelo método e, por isso, trata os valores restantes na tupla como descartes ao desconstruir a tupla.



```
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
       var (_, _, _, pop1, _, pop2) = QueryCityDataForYears("New York City", 1960, 2010);

       Console.WriteLine($"Population change, 1960 to 2010: {pop2 - pop1:N0}");
   }
   
   private static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
   {
      int population1 = 0, population2 = 0;
      double area = 0;
      
      if (name == "New York City") {
         area = 468.48; 
         if (year1 == 1960) {
            population1 = 7781984;
         }
         if (year2 == 2010) {
            population2 = 8175133;
         }
      return (name, area, year1, population1, year2, population2);
      }

      return ("", 0, 0, 0, 0, 0);
   }
}
// The example displays the following output:
//      Population change, 1960 to 2010: 393,149
```
Para obter mais informações, consulte Descartes.