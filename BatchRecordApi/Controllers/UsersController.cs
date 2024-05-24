using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BatchRecordDAL;
using System.Reflection.Metadata;
using BatchRecordApi.Handlers;
using Microsoft.AspNetCore.Http;
using BatchRecordApi.ResponseModels.Users;

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
    /// Obtiene una lista de cobros
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="itemsPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<CreateUsersReponse> GetUsers(long? roleId, int itemsPerPage = 10,int pageNumber = 1)
    {
        return await _usersHandler.GetUserList(roleId,
                                       pageNumber,
                                       itemsPerPage
                                       );
    }

}
