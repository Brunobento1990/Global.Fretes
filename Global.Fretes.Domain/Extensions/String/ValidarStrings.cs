using Global.Fretes.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Global.Fretes.Domain.Extensions.String;

public static partial class ValidarStrings
{
    private static IList<string> _cpfsInvalidos = new List<string>()
    {
        "00000000000",
        "11111111111",
        "22222222222",
        "33333333333",
        "44444444444",
        "55555555555",
        "66666666666",
        "77777777777",
        "88888888888",
        "99999999999",
    };
    public static void ValidarEmail(this string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)) ||
                    email.Length > 255)
        {
            throw new ExceptionApi("E-mail inválido!");
        }
    }

    public static void ValidarTelefone(this string value)
    {
        const int length = 11;

        if (string.IsNullOrWhiteSpace(value) || 
            value.Length != length || 
            !ValidarSomenteNumero(value))
        {
            throw new ExceptionApi("Telefone inválido");
        }
    }

    public static void ValidarCpf(this string cpf)
    {
        const int length = 11;

        if (string.IsNullOrWhiteSpace(cpf) ||
            cpf.Length != length ||
            !ValidarSomenteNumero(cpf) ||
            _cpfsInvalidos.Any(x => x.Equals(cpf)))
        {
            throw new ExceptionApi("Telefone inválido");
        }
    }

    public static bool ValidarSomenteNumero(string value)
    {
        return SomenteNumeros().IsMatch(value);
    }

    [GeneratedRegex("^[0-9]+$")]
    private static partial Regex SomenteNumeros();
}
