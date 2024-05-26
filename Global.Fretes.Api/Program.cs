using dotenv.net;
using Global.Fretes.Api.Configurations;
using Global.Fretes.Api.Middlewares;
using Global.Fretes.Infrastructure.Azure;
using Global.Fretes.IoC.Context;
using Global.Fretes.IoC.Cors;
using Global.Fretes.IoC.Repositories;
using Global.Fretes.IoC.Services;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var conectionDb = VariaveisDeAmbiente.GetVariavel("STRING_CONNECTION");
var key_azure = VariaveisDeAmbiente.GetVariavel("AZURE_KEY_CONTAINER");
var container_azure = VariaveisDeAmbiente.GetVariavel("AZURE_CONTAINER");
var origem = VariaveisDeAmbiente.GetVariavel("ORIGEM");

ConfigKeyAzureContainer.Configure(key_azure, container_azure);

builder.Services
    .InjectCors(origem)
    .InjectContext(conectionDb)
    .InjectRepositories()
    .InjectService();

var app = builder.Build();

if (VariaveisDeAmbiente.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<MainMiddleware>();

app.MapControllers();

app.UseCors("base");

app.Run();
