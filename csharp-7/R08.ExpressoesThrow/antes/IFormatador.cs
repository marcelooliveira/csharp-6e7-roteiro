namespace csharp7.R08.antes
{
    public interface IFormatador
    {
        bool PodeSerFormatado(string value);
        string Formatar(string value);
        string Desformatar(string value);
        bool EstaFormatado(string value);
    }
}