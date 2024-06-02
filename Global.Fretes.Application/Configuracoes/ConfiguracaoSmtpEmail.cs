namespace Global.Fretes.Application.Configuracoes;

public static class ConfiguracaoSmtpEmail
{
    public static string From { get; private set; } = string.Empty;
    public static string Senha { get; private set; } = string.Empty;
    public static string Servidor { get; private set; } = string.Empty;
    public static string Porta { get; private set; } = string.Empty;

    public static void Configure(
        string from,
        string senha,
        string servidor,
        string porta)
    {
        From = from;
        Senha = senha;
        Servidor = servidor;
        Porta = porta;
    }
}
