using Abstractions;
using Azure.Data.Tables;

namespace AzureTableStorageApi;

public class IncidentesTableClient
{
    private readonly TableClient _tableClient;

    public IncidentesTableClient(IConfiguration config)
    {
        _tableClient = new TableClient(config["ConnectionString:TableStorageConn"], "Incidentes");
    }

    public async Task<Incidente?> ObtenerIncidente(ConsultaIncidenteRequest request, CancellationToken cancellationToken)
    {
        var response = await _tableClient.GetEntityAsync<TableEntity>(request.Fecha, 
            request.CodigoIncidente, cancellationToken: cancellationToken);

        if (!response.HasValue) return null;
        
        var incidente = new Incidente(
            Fecha: response.Value.PartitionKey,
            CodigoIncidente: response.Value.RowKey,
            TipoIncidente: response.Value.GetString("TipoIncidente"),
            Descripcion: response.Value.GetString("Descripcion"),
            Lugar: response.Value.GetString("Lugar"),
            FechaHora: response.Value.GetString("FechaHora")
        );
            
        return incidente;
    }
}