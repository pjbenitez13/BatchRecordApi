using BatchRecordDAL.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchRecordDAL.Models
{
    public enum UserType { Standar, Administrative }
    public class User : BaseModel
    {
        /// <summary>
        /// ID del usuario
        /// </summary>
        [Key]
        public long IdUser { get; set; }

        /// <summary>
        /// Nombre Usuario
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Apellido usuario
        /// </summary>
        [Required]
        public string SurName { get; set; } = string.Empty;

        /// <summary>
        /// Correo Electronico
        /// </summary>
        [Required]
        public string Email { get;set; } = string.Empty;

        /// <summary>
        /// Id del Rol del Usuario
        /// </summary>
        [Required]
        public long RoleId { get; set; }

        /// <summary>
        /// Rol del Usuario
        /// </summary>
        public Role? Role { get; set; }

        /// <summary>
        /// Enums para tipos de Usuarios
        /// </summary>
        public UserType UserType { get; set; } = UserType.Standar;
    }
}
