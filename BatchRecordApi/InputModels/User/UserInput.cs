using BatchRecordDAL.Models;
using System.ComponentModel.DataAnnotations;

namespace BatchRecordApi.InputModels.User;

public class UserInput
{
    /// <summary>
    /// ID del usuario
    /// </summary>
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
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Id del Rol del Usuario
    /// </summary>
    [Required]
    public long RoleId { get; set; }

    /// <summary>
    /// Enums para tipos de Usuarios
    /// </summary>
    //[JsonConverter(typeof(EnumToStringJsonConverter<PaymentStatus>))]
    public UserType UserType { get; set; } = UserType.Standar;
}
