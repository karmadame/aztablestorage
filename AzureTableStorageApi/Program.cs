using Abstractions;
using AzureTableStorageApi;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IncidentesTableClient>();
    
var app = builder.Build();

app.MapPost("/api/incidentes", async ([FromServices] IncidentesTableClient incidentesTableClient,
    [FromBody] ConsultaIncidenteRequest request, CancellationToken cancellationToken) =>
{
    var incidente = await incidentesTableClient.ObtenerIncidente(request, cancellationToken);
    return incidente;
});

app.Run();