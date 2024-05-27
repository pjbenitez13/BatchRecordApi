using BatchRecordDAL.Bases;
using System.ComponentModel.DataAnnotations;

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
        /// Usuario para Login
        /// </summary>
        [Required]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña
        /// </summary>
        [Required]
        public string Password { get; set; } = string.Empty;

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
