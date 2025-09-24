namespace Abstractions;

public record Incidente(
    string Fecha,
    string CodigoIncidente,
    string Descripcion,
    string TipoIncidente,
    string Lugar,
    string FechaHora);