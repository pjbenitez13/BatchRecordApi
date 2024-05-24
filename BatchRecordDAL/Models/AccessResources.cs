using BatchRecordDAL.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRecordDAL.Models
{
    public class AccessResource : BaseModel
    {
        /// <summary>
        /// ID del recurso de acceso
        /// </summary>
        [Key]
        public long ResourceId { get; set; }

        /// <summary>
        /// Nombre del recurso de acceso
        /// </summary>
        [Required]
        public string ResourceName { get; set; } = string.Empty;

        /// <summary>
        /// Descripción del recurso de acceso
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Id del Rol asociado a este recurso
        /// </summary>
        [Required]
        public long RoleId { get; set; }

        /// <summary>
        /// Rol asociado a este recurso
        /// </summary>
        public Role? Role { get; set; }
    }
}
