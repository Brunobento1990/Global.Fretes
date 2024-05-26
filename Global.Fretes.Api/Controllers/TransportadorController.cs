using Global.Fretes.Application.Dtos.TransportadorDto;
using Global.Fretes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Global.Fretes.Api.Controllers;

[ApiController]
[Route("transportador")]
public class TransportadorController : ControllerBase
{
    private readonly ITransportadorService _transportadorService;

    public TransportadorController(ITransportadorService transportadorService)
    {
        _transportadorService = transportadorService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateTransportadorDto createTransportadorDto)
    {
        var transportadorViewModel = await _transportadorService.CreateAsync(createTransportadorDto);
        return Ok(transportadorViewModel);
    }
}
