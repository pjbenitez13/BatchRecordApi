using BatchRecordCore.Base;
using BatchRecordCore.Logic.Roles;
using BatchRecordDAL;
using BatchRecordDAL.Models;


namespace BatchRecordCore.Services.Roles;

public class RolesService(BatchRecordContext db) : BaseService(db)
{
    private readonly RolesGetterLogic rolesGetterLogic = new(db);
    private readonly RolesMutatorLogic rolesMutatorLogic = new(db);

    public async Task<IList<Role>> GetRolesPaginate(long? roleId, int page, int itemPerPage)
    {
        var skip = (page - 1) * itemPerPage;
        return await rolesGetterLogic.GetRolesPaginate(roleId,
                                                       page,
                                                       itemPerPage,
                                                       skip);

    }

    public async Task<int> GetCountRolesPaginate(long? roleId)
    {
        return await rolesGetterLogic.GetCountRolesPaginate(roleId);

    }

    public async Task<Role> GetRoleById(long roleId)
    {
        return await rolesGetterLogic.GetRoleById(roleId);
    }

    public async Task<Role> CreateOrUpdateRole(Role role)
    {
        return await rolesMutatorLogic.CreateOrUpdateRole(role);
    }

    public void DeleteRole(Role? role)
    {
        if (role != null)
            rolesMutatorLogic.DeleteRole(role);
    }
}
