using BatchRecordApi.Bases;
using BatchRecordDAL.Models;

namespace BatchRecordApi.ResponseModels.AccessResources;

public class CreateAccessResourceResponse(AccessResource accessResource) : IBaseResponse
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
    /// Recurso de Respuesta
    /// </summary>
    public AccessResourceOutput AccessResource { get; set; } = new AccessResourceOutput(accessResource);
}
