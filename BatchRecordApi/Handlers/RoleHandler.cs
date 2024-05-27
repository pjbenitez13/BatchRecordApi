using BatchRecordApi.Bases;
using BatchRecordApi.InputModels.RoleInput;
using BatchRecordApi.ResponseModels.Roles;
using BatchRecordApi.ResponseModels.Users;
using BatchRecordCore.Services.Roles;
using BatchRecordCore.Services.Users;
using BatchRecordDAL;
using BatchRecordDAL.Models;


namespace BatchRecordApi.Handlers;

/// <summary>
/// Manejador de los Usuarios
/// </summary>
/// <param name="db"></param>
/// <param name="httpContextAccessor"></param>
public class RoleHandler(BatchRecordContext db, IHttpContextAccessor httpContextAccessor)
                         : BaseHandler(db, httpContextAccessor)
{
    /// <summary>
    /// Obtener Lista de roles
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="page"></param>
    /// <param name="itemPerPage"></param>
    public async Task<CreateRolesResponse> GetRolesList(long? roleId, int page, int itemPerPage)
    {
        using var rolesService = new RolesService(Db);
        var roles = await rolesService.GetRolesPaginate(roleId, page, itemPerPage);
        var totalItems = await rolesService.GetCountRolesPaginate(roleId);

        if (roles == null || roles.Count() <= 0)
        {
            throw new Exception("No se encontraron registros");
        }

        return new CreateRolesResponse(roles, itemPerPage, page, totalItems);
    }

    /// <summary>
    /// Crear o Edita un Rol
    /// </summary>
    /// <param name="input"></param>
    public async Task<CreateRoleResponse> CreateOrUpdateRole(RoleInput input)
    {
        using var rolesService = new RolesService(Db);
        var newRole = new Role
        {
            RoleId = input.RoleId,
            RoleName = input.RoleName,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow,
            Deleted = false
        };
        newRole = await rolesService.CreateOrUpdateRole(newRole);

        if (newRole == null)
        {
            throw new Exception("No se pudo crear");
        }

        return new CreateRoleResponse(newRole);
    }

    /// <summary>
    /// Elimina un Rol
    /// </summary>
    /// <param name="idUser"></param>
    public async Task<OkResponse> DeleteRole(int idRole)
    {
        using var rolesService = new RolesService(Db);
        var role = await rolesService.GetRoleById(idRole);
        if (role != null)
        {
            rolesService.DeleteRole(role);
        }
        return new OkResponse("Eliminado con exito");
    }
}
