namespace SsttekAcademyHomeWork.Models.Enhencers;

public class ServiceResult<T>
{
    public bool Success { get; private set; }
    public string Message { get; private set; }
    public T Data { get; private set; }

    // Başarılı sonuç için
    public static ServiceResult<T> CreateSuccess(T data, string message = null)
    {
        return new ServiceResult<T>
        {
            Success = true,
            Data = data,
            Message = message
        };
    }

    // Hatalı sonuç için
    public static ServiceResult<T> CreateFailure(string message)
    {
        return new ServiceResult<T>
        {
            Success = false,
            Message = message
        };
    }
}