using BatchRecordDAL.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRecordDAL.Models
{
    public class Role : BaseModel
    {
        /// <summary>
        /// Id del Rol
        /// </summary>
        [Key]
        public long RoleId { get; set; }

        /// <summary>
        /// Nombre del Rol
        /// </summary>
        [Required]
        public string RoleName { get; set; } = string.Empty;

        public ICollection<User>? Users { get; set; }
        public ICollection<AccessResource>? AccessResources { get; set; }
    }
}
