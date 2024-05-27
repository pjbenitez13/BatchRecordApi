using BatchRecordApi.Bases;
using BatchRecordApi.Handlers;
using BatchRecordApi.InputModels.RoleInput;
using BatchRecordApi.ResponseModels.Roles;
using BatchRecordDAL;
using Microsoft.AspNetCore.Mvc;

namespace BatchRecordApi.Controllers;

/// <summary>
/// Controlador de Roles
/// </summary>
/// <param name="db"></param>
/// <param name="httpContextAccessor"></param>
public class RoleController(BatchRecordContext db, IHttpContextAccessor httpContextAccessor) : BatchRecordBaseController
{
    private readonly RoleHandler _roleHandler = new(db, httpContextAccessor);

    /// <summary>
    /// Obtiene una lista de Roles
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="itemsPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    [HttpGet("GetRoleList")]
    public async Task<CreateRolesResponse> GetRoles(long? roleId, int itemsPerPage = 10, int pageNumber = 1)
    {
        return await _roleHandler.GetRolesList(roleId,
                                       pageNumber,
                                       itemsPerPage
                                       );
    }

    /// <summary>
    /// Crea o Edita un Rol
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("CreateOrUpdateRole")]
    public async Task<CreateRoleResponse> CreateOrUpdateRole(RoleInput input)
    {
        return await _roleHandler.CreateOrUpdateRole(input);
    }

    /// <summary>
    /// Elimina Rol
    /// </summary>
    /// <param name="idRole"></param>
    /// <returns></returns>
    [HttpDelete("DeleteRole")]
    public async Task<OkResponse> DeleteRole(int idRole)
    {
        return await _roleHandler.DeleteRole(idRole);
    }
}
