using BatchRecordDAL.Models;

namespace BatchRecordApi.ResponseModels.Roles;

public class RoleOutput(Role role)
{
    /// <summary>
    /// Id del Rol
    /// </summary>
    public long RoleId { get; set; } = role.RoleId;

    /// <summary>
    /// Nombre del Rol
    /// </summary>
    public string RoleName { get; set; } = role.RoleName;

}
