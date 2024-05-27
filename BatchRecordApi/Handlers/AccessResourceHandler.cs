using BatchRecordApi.Bases;
using BatchRecordApi.InputModels.AccessResource;
using BatchRecordApi.ResponseModels.AccessResources;
using BatchRecordCore.Services.AccessResources;
using BatchRecordDAL;
using BatchRecordDAL.Models;

namespace BatchRecordApi.Handlers;

/// <summary>
/// Manejador de los Recursos
/// </summary>
/// <param name="db"></param>
/// <param name="httpContextAccessor"></param>
public class AccessResourceHandler(BatchRecordContext db, IHttpContextAccessor httpContextAccessor)
                                   : BaseHandler(db, httpContextAccessor)
{
    /// <summary>
    /// Obtener Lista de Recursos
    /// </summary>
    /// <param name="resourceId"></param>
    /// <param name="page"></param>
    /// <param name="itemPerPage"></param>
    public async Task<CreateAccessResourcesResponse> GetAccessResourceList(long? resourceId, int page, int itemPerPage)
    {
        using var accessResourcesService = new AccessResourcesService(Db);
        var accessResources = await accessResourcesService.GetAccessResourcesPaginate(resourceId, page, itemPerPage);
        var totalItems = await accessResourcesService.GetCountAccessResourcePaginate(resourceId);

        if (accessResources == null || accessResources.Count() <= 0)
        {
            throw new Exception("No se encontraron registros");
        }

        return new CreateAccessResourcesResponse(accessResources, itemPerPage, page, totalItems);
    }

    /// <summary>
    /// Crear o Edita un Recurso
    /// </summary>
    /// <param name="input"></param>
    public async Task<CreateAccessResourceResponse> CreateOrUpdateAccessResource(AccessResourceInput input)
    {
        using var accessResourcesService = new AccessResourcesService(Db);
        var newResource = new AccessResource
        {
            ResourceId = input.ResourceId,
            ResourceName = input.ResourceName,
            Description = input.Description,
            RoleId = input.RoleId,
            CreatedAt = DateTime.UtcNow,
            ModifiedAt = DateTime.UtcNow,
            Deleted = false
        };
        newResource = await accessResourcesService.CreateOrUpdateAccessResource(newResource);

        if (newResource == null)
        {
            throw new Exception("No se pudo crear");
        }

        return new CreateAccessResourceResponse(newResource);
    }

    /// <summary>
    /// Elimina un Recurso
    /// </summary>
    /// <param name="resourceId"></param>
    public async Task<OkResponse> DeleteAccessResource(int resourceId)
    {
        using var accessResourcesService = new AccessResourcesService(Db);
        var resource = await accessResourcesService.GetAccessResourceById(resourceId);
        if (resource != null)
        {
            accessResourcesService.DeleteAccessResource(resource);
        }
        return new OkResponse("Eliminado con exito");
    }
}
