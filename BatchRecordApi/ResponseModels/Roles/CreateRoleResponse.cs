using BatchRecordApi.Bases;
using BatchRecordApi.InputModels.RoleInput;
using BatchRecordApi.ResponseModels.Users;
using BatchRecordDAL.Models;

namespace BatchRecordApi.ResponseModels.Roles
{
    public class CreateRoleResponse(Role role): IBaseResponse
    {
        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// true -> Respuesta exitosa; false -> Respuesta fallida
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Rol de Respuesta
        /// </summary>
        public RoleOutput Role { get; set; } = new RoleOutput(role);
    }
}
