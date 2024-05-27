using BatchRecordDAL;
using BatchRecordDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BatchRecordCore.Logic.Roles;

public class RolesGetterLogic(BatchRecordContext db)
{
    private readonly BatchRecordContext dbContext = db;

    public async Task<IList<Role>> GetRolesPaginate(long? roleId, int page, int itemPerPage, int skip)
    {
        return await dbContext.Roles.Where(r => !r.Deleted && (roleId == null || r.RoleId == roleId))
                                    .OrderBy(o => o.CreatedAt)
                                    .Skip(skip)
                                    .Take(itemPerPage)
                                    .ToListAsync();
    }

    public async Task<int> GetCountRolesPaginate(long? roleId)
    {
        return await dbContext.Roles.Where(r => !r.Deleted && (roleId == null || r.RoleId == roleId))
                                    .CountAsync();
    }

    public async Task<Role> GetRoleById(long roleId)
    {
        var role = await dbContext.Roles.Where(r => !r.Deleted && r.RoleId == roleId)
                                        .FirstOrDefaultAsync();

        if (role == null)
            throw new InvalidOperationException("Rol no encontrado");

        return role;
    }
}
