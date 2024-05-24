namespace BatchRecordApi.Bases;

/// <summary>
/// Interfaz de respuestas paginadas
/// </summary>
public interface IPaginatedResponse
{
    /// <summary>
    /// Cantidad de elementos por pagina
    /// </summary>
    public int ItemsPerPage { get; set; }
    /// <summary>
    /// Numero de pagina actual
    /// </summary>
    public int PageNumber { get; set; }
    /// <summary>
    /// Total de elementos
    /// </summary>
    public long TotalItems { get; set; }
}
