using BatchRecordDAL.Models;

namespace BatchRecordApi.ResponseModels.Users
{
    /// <summary>
    /// Clase para salida de usuarios
    /// </summary>
    public class UserOuput(User user)
    {
        /// <summary>
        /// ID del usuario
        /// </summary>
        public long IdUser { get; set; } = user.IdUser;

        /// <summary>
        /// Nombre Usuario
        /// </summary>
        public string Name { get; set; } = user.Name;

        /// <summary>
        /// Apellido usuario
        /// </summary>
        public string SurName { get; set; } = user.SurName;

        /// <summary>
        /// Correo Electronico
        /// </summary>
        public string Email { get; set; } = user.Email;

        /// <summary>
        /// Id del Rol del Usuario
        /// </summary>
        public long RoleId { get; set; } = user.RoleId;

        /// <summary>
        /// Rol del Usuario
        /// </summary>
        public Role? Role { get; set; } = user.Role;

        /// <summary>
        /// Enums para tipos de Usuarios
        /// </summary>
        public UserType UserType { get; set; } = UserType.Standar;
    }

}
