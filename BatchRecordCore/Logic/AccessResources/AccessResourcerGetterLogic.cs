using BatchRecordDAL;
using BatchRecordDAL.Models;
using Microsoft.EntityFrameworkCore;


namespace BatchRecordCore.Logic.AccessResources;

public class AccessResourcerGetterLogic(BatchRecordContext db)
{
    private readonly BatchRecordContext dbContext = db;

    public async Task<IList<AccessResource>> GetAccessResourcePaginate(long? resourceId, int page, int itemPerPage, int skip)
    {
        return await dbContext.AccessResources.Where(r => !r.Deleted && (resourceId == null || r.ResourceId == resourceId))
                                    .OrderBy(o => o.CreatedAt)
                                    .Skip(skip)
                                    .Take(itemPerPage)
                                    .ToListAsync();
    }

    public async Task<int> GetCountAccessResourcePaginate(long? resourceId)
    {
        return await dbContext.AccessResources.Where(r => !r.Deleted && (resourceId == null || r.ResourceId == resourceId))
                                    .CountAsync();
    }

    public async Task<AccessResource> GetAccessResourceById(long resourceId)
    {
        var accessResources = await dbContext.AccessResources.Where(r => !r.Deleted && r.ResourceId == resourceId)
                                        .FirstOrDefaultAsync();

        if (accessResources == null)
            throw new InvalidOperationException("Recurso no encontrado");

        return accessResources;
    }
}
