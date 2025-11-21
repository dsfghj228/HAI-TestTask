using System.Net;

namespace Back.Exceptions;

public abstract class CustomExceptions(
    HttpStatusCode statusCode,
    string type,
    string title,
    string message)
    : Exception(message)
{
    public readonly HttpStatusCode StatusCode = statusCode;
    public readonly string Type = type;
    public readonly string Title = title;

    public class DoctorNotFoundException(int id) : CustomExceptions(HttpStatusCode.NotFound,
        "https://tools.ietf.org/html/rfc7231#section-6.5.4",
        "Врач не найден",
        $"Врач с таким id: {id} не найден");
    
    public class PatientNotFoundException(int id) : CustomExceptions(HttpStatusCode.NotFound,
        "https://tools.ietf.org/html/rfc7231#section-6.5.4",
        "Пациент не найден",
        $"Пациент с таким id: {id} не найден");
   
}