using BatchRecordCore.Base;
using BatchRecordCore.Logic.AccessResources;
using BatchRecordDAL;
using BatchRecordDAL.Models;

namespace BatchRecordCore.Services.AccessResources;

public class AccessResourcesService(BatchRecordContext db) : BaseService(db)
{
    private readonly AccessResourcerGetterLogic accessResourcerGetterLogic = new(db);
    private readonly AccessResourcerMutatorLogic accessResourcerMutatorLogic = new(db);

    public async Task<IList<AccessResource>> GetAccessResourcesPaginate(long? resourceId, int page, int itemPerPage)
    {
        var skip = (page - 1) * itemPerPage;
        return await accessResourcerGetterLogic.GetAccessResourcePaginate(resourceId,
                                                       page,
                                                       itemPerPage,
                                                       skip);

    }

    public async Task<int> GetCountAccessResourcePaginate(long? resourceId)
    {
        return await accessResourcerGetterLogic.GetCountAccessResourcePaginate(resourceId);

    }

    public async Task<AccessResource> GetAccessResourceById(long resourceId)
    {
        return await accessResourcerGetterLogic.GetAccessResourceById(resourceId);
    }

    public async Task<AccessResource> CreateOrUpdateAccessResource(AccessResource accessResource)
    {
        return await accessResourcerMutatorLogic.CreateOrUpdateAccessResourcer(accessResource);
    }

    public void DeleteAccessResource(AccessResource? accessResource)
    {
        if (accessResource != null)
            accessResourcerMutatorLogic.DeleteAccessResource(accessResource);
    }


}
