namespace Global.Fretes.Domain.Exceptions;

public class ExceptionUnauthorize : Exception
{
    private const string _mensagem = "Não autorizado!";
    public ExceptionUnauthorize(string? message = _mensagem) : base(message)
    {
    }
}
