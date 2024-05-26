using Global.Fretes.Application.Dtos.TransportadorDto;
using Global.Fretes.Application.Interfaces;
using Global.Fretes.Application.ViewModels;
using Global.Fretes.Domain.Exceptions;
using Global.Fretes.Domain.Interfaces;
using Global.Fretes.Infrastructure.Azure.Interfaces;

namespace Global.Fretes.Application.Services;

public sealed class TransportadorService : ITransportadorService
{
    private readonly ITransportadorRepository _transportadorRepository;
    private readonly IUploadImageBlobClient _uploadImageBlobClient;
    private readonly IConfiguracaoContaTransportadorService _configuracaoContaTransportadorService;

    public TransportadorService(
        ITransportadorRepository transportadorRepository,
        IUploadImageBlobClient uploadImageBlobClient,
        IConfiguracaoContaTransportadorService configuracaoContaTransportadorService)
    {
        _transportadorRepository = transportadorRepository;
        _uploadImageBlobClient = uploadImageBlobClient;
        _configuracaoContaTransportadorService = configuracaoContaTransportadorService;
    }

    public async Task<TransportadorViewModel> CreateAsync(
        CreateTransportadorDto createTransportadorDto)
    {
        var transportadorValidacao = await _transportadorRepository
            .GetValidarAsync(createTransportadorDto.Email, createTransportadorDto.Telefone, createTransportadorDto.Cpf);

        if(transportadorValidacao != null)
        {
            if (transportadorValidacao.Email.Equals(createTransportadorDto.Email))
            {
                throw new ExceptionApi($"O e-mail: {createTransportadorDto.Email}, já se encontra cadastrado em nosso site!");
            }

            if (transportadorValidacao.Telefone.Equals(createTransportadorDto.Telefone))
            {
                throw new ExceptionApi($"O telefone: {createTransportadorDto.Telefone}, já se encontra cadastrado em nosso site!");
            }

            if (transportadorValidacao.Cpf.Equals(createTransportadorDto.Cpf))
            {
                throw new ExceptionApi($"O CPF: {createTransportadorDto.Cpf}, já se encontra cadastrado em nosso site!");
            }
        }

        string? foto = null;

        if (!string.IsNullOrWhiteSpace(createTransportadorDto.Foto))
        {
            foto = await _uploadImageBlobClient.UploadImageAsync(
                createTransportadorDto.Foto, 
                Guid.NewGuid().ToString());
        }

        var transportador = createTransportadorDto.ToEntity(foto);
        await _transportadorRepository.AddAsync(transportador);
        await _configuracaoContaTransportadorService.CreateAsync(transportador.Id);
        await _transportadorRepository.SaveChangesAsync();
        return new TransportadorViewModel().FromEntity(transportador);
    }
}
