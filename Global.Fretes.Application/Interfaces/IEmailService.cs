using Global.Fretes.Application.Dtos.Emails;

namespace Global.Fretes.Application.Interfaces;

public interface IEmailService
{
    Task<bool> EnviarAsync(EnvioEmailDto envioEmailDto);
}
