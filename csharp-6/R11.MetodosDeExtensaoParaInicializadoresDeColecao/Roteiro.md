# Métodos Add de extensão em inicializadores de coleção
Outro recurso que facilita a inicialização de coleção é a capacidade de usar um método de extensão para o método Add. Esse recurso foi adicionado para a paridade com o Visual Basic.

O recurso é mais útil quando você tem uma classe de coleção personalizada que tem um método com um nome diferente para adicionar novos itens semanticamente.
Por exemplo, considere uma coleção de alunos como esta:
C#

Copiar
public class Enrollment : IEnumerable<Student>
{
    private List<Student> allStudents = new List<Student>();

    public void Enroll(Student s)
    {
        allStudents.Add(s);
    }

    public IEnumerator<Student> GetEnumerator()
    {
        return ((IEnumerable<Student>)allStudents).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Student>)allStudents).GetEnumerator();
    }
}
O método Enroll adiciona um aluno. Mas não segue o padrão Add. Nas versões anteriores do C#, você não podia usar os inicializadores de coleção com um objeto Enrollment:
C#

Copiar
var classList = new Enrollment()
{
    new Student("Lessie", "Crosby"),
    new Student("Vicki", "Petty"),
    new Student("Ofelia", "Hobbs"),
    new Student("Leah", "Kinney"),
    new Student("Alton", "Stoker"),
    new Student("Luella", "Ferrell"),
    new Student("Marcy", "Riggs"),
    new Student("Ida", "Bean"),
    new Student("Ollie", "Cottle"),
    new Student("Tommy", "Broadnax"),
    new Student("Jody", "Yates"),
    new Student("Marguerite", "Dawson"),
    new Student("Francisca", "Barnett"),
    new Student("Arlene", "Velasquez"),
    new Student("Jodi", "Green"),
    new Student("Fran", "Mosley"),
    new Student("Taylor", "Nesmith"),
    new Student("Ernesto", "Greathouse"),
    new Student("Margret", "Albert"),
    new Student("Pansy", "House"),
    new Student("Sharon", "Byrd"),
    new Student("Keith", "Roldan"),
    new Student("Martha", "Miranda"),
    new Student("Kari", "Campos"),
    new Student("Muriel", "Middleton"),
    new Student("Georgette", "Jarvis"),
    new Student("Pam", "Boyle"),
    new Student("Deena", "Travis"),
    new Student("Cary", "Totten"),
    new Student("Althea", "Goodwin")
};
Agora você pode, mas apenas se você criar um método de extensão que mapeia Add para Enroll:
C#

Copiar
public static class StudentExtensions
{
    public static void Add(this Enrollment e, Student s) => e.Enroll(s);
}
O que você está fazendo com esse recurso é mapear qualquer método que adiciona itens a uma coleção, em um método chamado Add, criando um método de extensão:

C#

Copiar
public class Enrollment : IEnumerable<Student>
{
    private List<Student> allStudents = new List<Student>();

    public void Enroll(Student s)
    {
        allStudents.Add(s);
    }

    public IEnumerator<Student> GetEnumerator()
    {
        return ((IEnumerable<Student>)allStudents).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<Student>)allStudents).GetEnumerator();
    }
}
C#

Copiar
public class ClassList
{
    public Enrollment CreateEnrollment()
    {
        var classList = new Enrollment()
        {
            new Student("Lessie", "Crosby"),
            new Student("Vicki", "Petty"),
            new Student("Ofelia", "Hobbs"),
            new Student("Leah", "Kinney"),
            new Student("Alton", "Stoker"),
            new Student("Luella", "Ferrell"),
            new Student("Marcy", "Riggs"),
            new Student("Ida", "Bean"),
            new Student("Ollie", "Cottle"),
            new Student("Tommy", "Broadnax"),
            new Student("Jody", "Yates"),
            new Student("Marguerite", "Dawson"),
            new Student("Francisca", "Barnett"),
            new Student("Arlene", "Velasquez"),
            new Student("Jodi", "Green"),
            new Student("Fran", "Mosley"),
            new Student("Taylor", "Nesmith"),
            new Student("Ernesto", "Greathouse"),
            new Student("Margret", "Albert"),
            new Student("Pansy", "House"),
            new Student("Sharon", "Byrd"),
            new Student("Keith", "Roldan"),
            new Student("Martha", "Miranda"),
            new Student("Kari", "Campos"),
            new Student("Muriel", "Middleton"),
            new Student("Georgette", "Jarvis"),
            new Student("Pam", "Boyle"),
            new Student("Deena", "Travis"),
            new Student("Cary", "Totten"),
            new Student("Althea", "Goodwin")
        };
        return classList;
    }           
}

public static class StudentExtensions
{
    public static void Add(this Enrollment e, Student s) => e.Enroll(s);
}