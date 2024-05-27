using BatchRecordDAL.Models;
using System.ComponentModel.DataAnnotations;

namespace BatchRecordApi.InputModels.AccessResource;

public class AccessResourceInput
{
    /// <summary>
    /// ID del recurso de acceso
    /// </summary>
    public long ResourceId { get; set; }

    /// <summary>
    /// Nombre del recurso de acceso
    /// </summary>
    [Required]
    public string ResourceName { get; set; } = string.Empty;

    /// <summary>
    /// Descripción del recurso de acceso
    /// </summary>
    [Required]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Id del Rol asociado a este recurso
    /// </summary>
    [Required]
    public long RoleId { get; set; }

}
