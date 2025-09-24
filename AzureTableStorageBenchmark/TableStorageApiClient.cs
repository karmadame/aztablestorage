using System.Net.Http.Json;
using Abstractions;

namespace AzureTableStorageBenchmark;

public class TableStorageApiClient
{
    private readonly HttpClient _client;
    
    public TableStorageApiClient()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://localhost:7069");
    }
    
    public async Task<Incidente?> ObtenerIncidente(ConsultaIncidenteRequest request)
    {
        var response = await _client.PostAsJsonAsync("api/incidentes",
            request);
        response.EnsureSuccessStatusCode();
        var incidente = await response.Content.ReadFromJsonAsync<Incidente>();
        return incidente;
    }
}