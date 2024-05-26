namespace Global.Fretes.Domain.Exceptions;

public class ExceptionApi : Exception
{
    private const string _mensagemGererica = "Ocorreu um erro interno, tente novamente mais tarde, ou entre em contato com o suporte!";
    public ExceptionApi(string? message = _mensagemGererica) : base(message)
    {
    }
}
