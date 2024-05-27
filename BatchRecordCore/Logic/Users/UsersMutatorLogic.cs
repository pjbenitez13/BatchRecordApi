using BatchRecordDAL;
using BatchRecordDAL.Models;
using Microsoft.EntityFrameworkCore;


namespace BatchRecordCore.Logic.Users;

public class UsersMutatorLogic(BatchRecordContext db)
{
    private readonly BatchRecordContext dbContext = db;

    public async Task<User> CreateOrUpdateUser(User user)
    {

        if (user.IdUser.Equals(0)) 
        {
            await dbContext.Users.AddAsync(user);
            return user;
        }
        else
        {
            dbContext.Entry(user).State = EntityState.Modified;
            return user;
        }
    }

    public void DeleteUser(User user)
    {
            user.Deleted = true; 
            dbContext.Entry(user).State = EntityState.Modified;        
    }
}
