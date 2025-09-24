using Abstractions;
using BenchmarkDotNet.Attributes;

namespace AzureTableStorageBenchmark;

public class TableStorageApiBennchmark
{
    private readonly TableStorageApiClient _httpClient = new();
    
    [Params(1000, 10000)]
    public int N;
    
    
    [Benchmark]
    public Incidente? ObtenerIncidente()
    {
        var result = _httpClient.ObtenerIncidente(new ConsultaIncidenteRequest("INC-20250425-000755", "2025-04-25"));
        result.Wait();  
        return result.Result;   
    }
}