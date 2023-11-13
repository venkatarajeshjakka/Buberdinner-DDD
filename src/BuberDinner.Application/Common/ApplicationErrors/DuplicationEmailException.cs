using System.Net;

namespace BuberDinner.Application.Common.ApplicationErrors;

public class DuplicationEmailException : Exception, IServiceException
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

    public string ErrorMessage => "Email already Exists";
}