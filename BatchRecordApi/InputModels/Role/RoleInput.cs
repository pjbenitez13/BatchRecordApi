using System.ComponentModel.DataAnnotations;

namespace BatchRecordApi.InputModels.RoleInput
{
    public class RoleInput
    {
        /// <summary>
        /// Id del Rol
        /// </summary>
        public long RoleId { get; set; }

        /// <summary>
        /// Nombre del Rol
        /// </summary>
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}
