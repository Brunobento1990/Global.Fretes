using Global.Fretes.Application.Dtos.TransportadorDto;
using Global.Fretes.Application.ViewModels;

namespace Global.Fretes.Application.Interfaces;

public interface ITransportadorService
{
    Task<TransportadorViewModel> CreateAsync(CreateTransportadorDto createTransportadorDto);
}
