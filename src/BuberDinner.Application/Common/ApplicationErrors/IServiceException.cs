using System.Net;

namespace BuberDinner.Application.Common.ApplicationErrors;

public interface IServiceException
{
    public HttpStatusCode StatusCode { get; }

    public string ErrorMessage { get; }
}