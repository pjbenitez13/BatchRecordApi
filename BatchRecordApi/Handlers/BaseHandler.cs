using System.Security.Claims;
using BatchRecordDAL;

namespace BatchRecordApi.Handlers;

public class BaseHandler
{
    /// <summary>
    /// Instanciar el contexto de la base de datos
    /// </summary>
    protected BatchRecordContext Db { get; }


    /// <summary>
    /// Constructor base handler
    /// </summary>
    /// <param name="db"></param>
    /// <param name="httpContextAccessor"></param>
    public BaseHandler(BatchRecordContext db, IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor?.HttpContext?.User;
        this.Db = db;
    }
}
