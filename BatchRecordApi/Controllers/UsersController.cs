using Microsoft.AspNetCore.Mvc;
using BatchRecordDAL;
using BatchRecordApi.Handlers;
using BatchRecordApi.ResponseModels.Users;
using BatchRecordApi.InputModels.User;
using BatchRecordApi.Bases;

namespace BatchRecordApi.Controllers;

/// <summary>
/// Controlador de Usuarios
/// </summary>
/// <param name="db"></param>
/// <param name="httpContextAccessor"></param>
public class UsersController(BatchRecordContext db, IHttpContextAccessor httpContextAccessor) : BatchRecordBaseController()
{
    private readonly UsersHandler _usersHandler = new(db,httpContextAccessor);

    /// <summary>
    /// Obtiene una lista de Usuarios
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="itemsPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    [HttpGet("GetUsersList")]
    public async Task<CreateUsersResponse> GetUsers(long? roleId, int itemsPerPage = 10,int pageNumber = 1)
    {
        return await _usersHandler.GetUserList(roleId,
                                       pageNumber,
                                       itemsPerPage
                                       );
    }

    /// <summary>
    /// Crea o Edita un Usuario
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("CreateOrUpdateUser")]
    public async Task<CreateUserResponse> CreateOrUpdateUser(UserInput input)
    {
        return await _usersHandler.CreateOrUpdateUser(input);
    }

    /// <summary>
    /// Elimina Usuario
    /// </summary>
    /// <param name="idUser"></param>
    /// <returns></returns>
    [HttpDelete("DeleteUser")]
    public async Task<OkResponse> DeleteUser(int idUser)
    {
       return await _usersHandler.DeleteUser(idUser);
    }

}
