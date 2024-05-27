using BatchRecordApi.Bases;
using BatchRecordApi.Handlers;
using BatchRecordApi.InputModels.AccessResource;
using BatchRecordApi.ResponseModels.AccessResources;
using BatchRecordDAL;
using Microsoft.AspNetCore.Mvc;

namespace BatchRecordApi.Controllers;

/// <summary>
/// Controlador de Recursos
/// </summary>
/// <param name="db"></param>
/// <param name="httpContextAccessor"></param>
public class AccessResourceController(BatchRecordContext db, IHttpContextAccessor httpContextAccessor) : BatchRecordBaseController()
{
    private readonly AccessResourceHandler _accessResourceHandler = new(db, httpContextAccessor);
    /// <summary>
    /// Obtiene una lista de Recursos
    /// </summary>
    /// <param name="resourceId"></param>
    /// <param name="itemsPerPage"></param>
    /// <param name="pageNumber"></param>
    /// <returns></returns>
    [HttpGet("GetAccessResourceList")]
    public async Task<CreateAccessResourcesResponse> GetAccessResource(long? resourceId, int itemsPerPage = 10, int pageNumber = 1)
    {
        return await _accessResourceHandler.GetAccessResourceList(resourceId,
                                       pageNumber,
                                       itemsPerPage
                                       );
    }

    /// <summary>
    /// Crea o Edita un Recurso
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [HttpPost("CreateOrUpdateAccessResource")]
    public async Task<CreateAccessResourceResponse> CreateOrUpdateAccessResource(AccessResourceInput input)
    {
        return await _accessResourceHandler.CreateOrUpdateAccessResource(input);
    }

    /// <summary>
    /// Elimina Recurso
    /// </summary>
    /// <param name="resourceId"></param>
    /// <returns></returns>
    [HttpDelete("DeleteAccessResource")]
    public async Task<OkResponse> DeleteAccessResource(int resourceId)
    {
        return await _accessResourceHandler.DeleteAccessResource(resourceId);
    }
}
