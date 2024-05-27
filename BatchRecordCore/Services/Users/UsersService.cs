using BatchRecordCore.Base;
using BatchRecordCore.Logic.Users;
using BatchRecordDAL;
using BatchRecordDAL.Models;


namespace BatchRecordCore.Services.Users;

public class UsersService(BatchRecordContext db) : BaseService(db)
{
    private readonly UsersGetterLogic usersGetterLogic = new(db);
    private readonly UsersMutatorLogic usersMutatorLogic = new(db);


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

    public async Task<User> GetUserById(long userId)
    {
        return await usersGetterLogic.GetUserById(userId);
    }

    public async Task<User> CreateOrUpdateUser(User user)
    {
        return await usersMutatorLogic.CreateOrUpdateUser(user);
    }

    public void DeleteUser(User? user) 
    {
        if(user != null)
        usersMutatorLogic.DeleteUser(user);
    }
}
