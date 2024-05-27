using BatchRecordDAL;
using BatchRecordDAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRecordCore.Logic.Roles;

public class RolesMutatorLogic(BatchRecordContext db)
{
    private readonly BatchRecordContext dbContext = db;

    public async Task<Role> CreateOrUpdateRole(Role role)
    {

        if (role.RoleId.Equals(0))
        {
            await dbContext.Roles.AddAsync(role);
            return role;
        }
        else
        {
            dbContext.Entry(role).State = EntityState.Modified;
            return role;
        }
    }

    public void DeleteRole(Role role)
    {
        role.Deleted = true;
        dbContext.Entry(role).State = EntityState.Modified;
    }
}
