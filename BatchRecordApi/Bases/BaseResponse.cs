namespace BatchRecordApi.Bases;

/// <summary>
/// Interfaz de respuesta base
/// </summary>
public interface IBaseResponse
{
    /// <summary>
    /// Mensaje de respuesta
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// true -> Respuesta exitosa; false -> Respuesta fallida
    /// </summary>
    public bool Success { get; set; }
}

/// <summary>
/// Respuesta exitosa base
/// </summary>
/// <param name="message"></param>
public class OkResponse(string message) : IBaseResponse
{
    /// <summary>
    /// Mensaje de respuesta
    /// </summary>
    public string Message { get; set; } = message;
    /// <summary>
    /// true -> Respuesta exitosa; false -> Respuesta fallida
    /// </summary>
    public bool Success { get; set; } = true;
}
