using BatchRecordCore.Base;
using BatchRecordCore.Logic.Users;
using BatchRecordDAL;
using Microsoft.EntityFrameworkCore;
using BatchRecordDAL.Models;


namespace BatchRecordCore.Services.Users;

public class UsersService(BatchRecordContext db) : BaseService(db)
{
    private readonly UsersGetterLogic usersGetterLogic = new(db);

    public async Task<IList<User>> GetUsersPaginate(long? roleId, int page, int itemPerPage)
    {
        var skip = (page - 1) * itemPerPage;
        return await usersGetterLogic.GetUsersPaginate(roleId, 
                                                       page, 
                                                       itemPerPage, 
                                                       skip);

    }

    public async Task<int> GetCountUsersPaginate(long? roleId)
    {
        return await usersGetterLogic.GetCountUsersPaginate(roleId);

    }
}
