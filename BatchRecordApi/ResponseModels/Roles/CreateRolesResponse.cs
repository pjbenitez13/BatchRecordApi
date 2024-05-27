using BatchRecordApi.Bases;
using BatchRecordApi.ResponseModels.Users;
using BatchRecordDAL.Models;

namespace BatchRecordApi.ResponseModels.Roles;

/// <summary>
/// Respuesta para Roles Devs
/// </summary>
public class CreateRolesResponse : IBaseResponse, IPaginatedResponse
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
    /// Salida de Usuarios de la clase
    /// </summary>
    public IEnumerable<RoleOutput>? Roles { get; set; }

    /// <summary>
    /// Constructor de Usuarios
    /// </summary>
    public CreateRolesResponse(IList<Role> roles, int itemsPerPage, int pageNumber, int totalItems)
    {
        Roles = roles.Select(u => new RoleOutput(u));
        Message = "Roles obtenidos con exito";
        Success = true;
        ItemsPerPage = itemsPerPage;
        PageNumber = pageNumber;
        TotalItems = totalItems;
    }
}
