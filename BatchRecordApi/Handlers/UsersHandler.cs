using BatchRecordApi.ResponseModels.Users;
using BatchRecordDAL;
using BatchRecordCore.Services.Users;
using BatchRecordDAL.Models;
using BatchRecordApi.InputModels.User;
using BatchRecordApi.Bases;


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
    public async Task<CreateUsersResponse> GetUserList(long? roleId, int page, int itemPerPage)
    {
        using var userService = new UsersService(Db);
        var users = await userService.GetUsersPaginate(roleId, page, itemPerPage);
        var totalItems = await userService.GetCountUsersPaginate(roleId);

        if (users == null || users.Count() <= 0)
        {
            throw new Exception("No se encontraron registros");
        }

        return new CreateUsersResponse(users, itemPerPage, page, totalItems);
    }

    /// <summary>
    /// Crear o Edita un usuario
    /// </summary>
    /// <param name="input"></param>
    public async Task<CreateUserResponse> CreateOrUpdateUser(UserInput input)
    {
        using var userService = new UsersService(Db);
        var newUser = new User
        {
            IdUser = input.IdUser,
            Name = input.Name,
            SurName = input.SurName,
            Email = input.Email,
            Password = input.Password,
            UserName = input.UserName,
            RoleId = input.RoleId,
            UserType = UserType.Standar,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow,
            Deleted = false
        };
        newUser = await userService.CreateOrUpdateUser(newUser);

        if (newUser == null)
        {
            throw new Exception("No se pudo crear");
        }

        return new CreateUserResponse(newUser);
    }

    /// <summary>
    /// Elimina un usuario
    /// </summary>
    /// <param name="idUser"></param>
    public async Task<OkResponse> DeleteUser(int idUser) 
    {
        using var userService = new UsersService(Db);
        var user = await userService.GetUserById(idUser);
        if (user != null) 
        { 
            userService.DeleteUser(user);
        }
        return new OkResponse("Eliminado con exito");
    }
}
