using BatchRecordApi.Bases;
using BatchRecordDAL.Models;

namespace BatchRecordApi.ResponseModels.AccessResources;

/// <summary>
/// Respuesta para Recursos Devs
/// </summary>
public class CreateAccessResourcesResponse : IBaseResponse, IPaginatedResponse
{
    /// <summary>
    /// Mensaje de respuesta
    /// </summary>
    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// true -> Respuesta exitosa; false -> Respuesta fallida
    /// </summary>
    public bool Success { get; set; }

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

    /// <summary>
    /// Salida de Recursos de la clase
    /// </summary>
    public IEnumerable<AccessResourceOutput>? AccessResources { get; set; }

    /// <summary>
    /// Constructor de Recursos
    /// </summary>
    public CreateAccessResourcesResponse(IList<AccessResource> accessResources, int itemsPerPage, int pageNumber, int totalItems)
    {
        AccessResources = accessResources.Select(u => new AccessResourceOutput(u));
        Message = "Recursos obtenidos con exito";
        Success = true;
        ItemsPerPage = itemsPerPage;
        PageNumber = pageNumber;
        TotalItems = totalItems;
    }
}
