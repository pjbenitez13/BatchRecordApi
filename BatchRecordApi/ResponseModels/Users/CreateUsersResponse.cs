using BatchRecordApi.Bases;
using BatchRecordDAL.Models;

namespace BatchRecordApi.ResponseModels.Users;


/// <summary>
/// Respuesta para Usuarios Devs
/// </summary>
public class CreateUsersResponse : IBaseResponse, IPaginatedResponse
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
    public IEnumerable<UserOuput>? Users { get; set; }

    /// <summary>
    /// Constructor de Usuarios
    /// </summary>
    public CreateUsersResponse(IList<User> users, int itemsPerPage, int pageNumber, int totalItems) 
    {
        Users = users.Select(u => new UserOuput(u));
        Message = "Usuarios obtenidos con exito";
        Success = true;
        ItemsPerPage = itemsPerPage;
        PageNumber = pageNumber;
        TotalItems = totalItems;  
    }
}
