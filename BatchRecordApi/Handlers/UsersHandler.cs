using BatchRecordApi.ResponseModels.Users;
using BatchRecordDAL;
using BatchRecordCore.Services.Users;


namespace BatchRecordApi.Handlers;

/// <summary>
/// Manejador de los Usuarios
/// </summary>
/// <param name="db"></param>
/// <param name="httpContextAccessor"></param>
public class UsersHandler(BatchRecordContext db, IHttpContextAccessor httpContextAccessor) 
                          : BaseHandler(db, httpContextAccessor)
{
    /// <summary>
    /// Obtener Lista de usuarios
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="page"></param>
    /// <param name="itemPerPage"></param>
    public async Task<CreateUsersReponse> GetUserList(long? roleId, int page, int itemPerPage)
    {
        using var userService = new UsersService(Db);
        var users = await userService.GetUsersPaginate(roleId, page, itemPerPage);
        var totalItems = await userService.GetCountUsersPaginate(roleId);

        if (users == null || users.Count() <= 0)
        {
            throw new Exception("No se encontraron registros");
        }

        return new CreateUsersReponse(users, itemPerPage, page, totalItems);
    }
}
