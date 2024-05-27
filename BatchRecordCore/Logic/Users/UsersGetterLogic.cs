using BatchRecordDAL;
using BatchRecordDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BatchRecordCore.Logic.Users;

public class UsersGetterLogic(BatchRecordContext db)
{
    private readonly BatchRecordContext dbContext = db;

    public async Task<IList<User>> GetUsersPaginate(long? roleId, int page, int itemPerPage, int skip)
    {
        return await dbContext.Users.Where(r => !r.Deleted && (roleId == null || r.RoleId == roleId))
                                    .OrderBy(o => o.CreatedAt)
                                    .Skip(skip)
                                    .Take(itemPerPage)
                                    .ToListAsync();
    }

    public async Task<int> GetCountUsersPaginate(long? roleId)
    {
        return await dbContext.Users.Where(r => !r.Deleted && (roleId == null || r.RoleId == roleId))
                                    .CountAsync();
    }

    public async Task<User> GetUserById(long userId)
    {
        var user = await dbContext.Users.Where(r => !r.Deleted && r.IdUser == userId)
                                        .FirstOrDefaultAsync();

        if (user == null)
           throw new InvalidOperationException("Usuario no encontrado");

        return user;
    }
}
