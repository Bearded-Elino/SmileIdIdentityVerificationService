namespace IdentityVerificationService.Application.Shared;

/// <summary>
/// A generic response class to standardize API responses.
/// </summary>
/// <typeparam name="T">The type of the response data.</typeparam>
public class OResponse<T>
{
    /// <summary>
    /// Status code indicating the result of the operation.
    /// Example: 0 = Success, 1 = Validation Error, etc.
    /// </summary>
    public int ResultCode { get; set; }

    /// <summary>
    /// A detailed message or description of the result.
    /// </summary>
    public string ResultDescription { get; set; }

    /// <summary>
    /// The data payload of the response.
    /// </summary>
    public T Data { get; set; }
}
