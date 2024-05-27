using BatchRecordApi.Bases;
using BatchRecordDAL.Models;

namespace BatchRecordApi.ResponseModels.Users;

public class CreateUserResponse(User user) : IBaseResponse
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
    /// Usuario de Respuesta
    /// </summary>
    public UserOuput User { get; set; } = new UserOuput(user);
}
