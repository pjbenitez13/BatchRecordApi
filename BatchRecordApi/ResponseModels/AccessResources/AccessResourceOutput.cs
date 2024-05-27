using BatchRecordDAL.Models;

namespace BatchRecordApi.ResponseModels.AccessResources;

/// <summary>
/// Clase para salida de recursos
/// </summary>
public class AccessResourceOutput(AccessResource accessResource)
{
    /// <summary>
    /// ID del recurso de acceso
    /// </summary>
    public long ResourceId { get; set; } = accessResource.ResourceId;

    /// <summary>
    /// Nombre del recurso de acceso
    /// </summary>
    public string ResourceName { get; set; } = accessResource.ResourceName;

    /// <summary>
    /// Descripción del recurso de acceso
    /// </summary>
    public string Description { get; set; } = accessResource.Description;

    /// <summary>
    /// Id del Rol asociado a este recurso
    /// </summary>
    public long RoleId { get; set; } = accessResource.RoleId;

}
