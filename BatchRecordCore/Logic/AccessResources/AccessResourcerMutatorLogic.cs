using BatchRecordDAL;
using BatchRecordDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BatchRecordCore.Logic.AccessResources;

public class AccessResourcerMutatorLogic(BatchRecordContext db)
{
    private readonly BatchRecordContext dbContext = db;

    public async Task<AccessResource> CreateOrUpdateAccessResourcer(AccessResource accessResource)
    {

        if (accessResource.ResourceId.Equals(0))
        {
            await dbContext.AccessResources.AddAsync(accessResource);
            return accessResource;
        }
        else
        {
            dbContext.Entry(accessResource).State = EntityState.Modified;
            return accessResource;
        }
    }

    public void DeleteAccessResource(AccessResource accessResource)
    {
        accessResource.Deleted = true;
        dbContext.Entry(accessResource).State = EntityState.Modified;
    }
}
