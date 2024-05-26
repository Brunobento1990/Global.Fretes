using Global.Fretes.Api.Configurations;
using Global.Fretes.Application.Dtos.AppLogs;
using Global.Fretes.Application.Interfaces;
using Global.Fretes.Domain.Exceptions;
using Global.Fretes.Domain.Enuns;
using System.Text.Json;

namespace Global.Fretes.Api.Middlewares;

public class MainMiddleware
{
    private readonly RequestDelegate _next;
    private CreateAppLog _createAppLog;
    private const string _erroGenerico =
        "Ocorreu um erro interno, tente novamente mais tarde, ou entre em contato com o suporte!";
    
    public MainMiddleware(RequestDelegate next)
    {
        _createAppLog = new();
        _next = next;
    }

    public async Task Invoke(
        HttpContext httpContext, 
        IAppLogService appLogService)
    {
        try
        {
            _createAppLog.Host = httpContext.Request.Headers.Host;
            _createAppLog.Path = httpContext.Request.Path;
            _createAppLog.Ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty;
            _createAppLog.LogLevel = AppLogLevel.Info;
            _createAppLog.StatusCode = 200;

            await _next(httpContext);
        }
        catch (ExceptionUnauthorize ex)
        {
            await HandleError(httpContext, ex.Message, 401);
            _createAppLog ??= new();
            _createAppLog.StatusCode = 401;
            _createAppLog.LogLevel = AppLogLevel.Unauthorize;
            _createAppLog.Erro = ex.Message;
        }
        catch (ExceptionApi ex)
        {
            await HandleError(httpContext, ex.Message, 404);
            _createAppLog ??= new();
            _createAppLog.StatusCode = 404;
            _createAppLog.Erro = ex.Message;
            _createAppLog.LogLevel = AppLogLevel.Warn;
        }
        catch (Exception ex)
        {
            if (VariaveisDeAmbiente.IsDevelopment())
            {
                await HandleError(httpContext, ex.Message, 404);
            }
            else
            {
                await HandleError(
                    httpContext,
                    _erroGenerico,
                    404);
            }
            _createAppLog ??= new();
            _createAppLog.StatusCode = 404;
            _createAppLog.Erro = ex.Message;
            _createAppLog.LogLevel = AppLogLevel.Error;
        }
        finally
        {
            await appLogService.CreateAppLogAsync(_createAppLog);
        }
    }

    public async Task HandleError(HttpContext httpContext, string mensagem, int statusCode)
    {
        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = statusCode;
        var errorResponse = new
        {
            Mensagem = mensagem
        };
        await httpContext.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}
