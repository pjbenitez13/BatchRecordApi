using BatchRecordDAL;


namespace BatchRecordApi.Handlers;

/// <summary>
/// Manejador de los Usuarios
/// </summary>
/// <param name="db"></param>
/// <param name="httpContextAccessor"></param>
public class RoleHandler(BatchRecordContext db, IHttpContextAccessor httpContextAccessor)
                         : BaseHandler(db, httpContextAccessor)
{

}
