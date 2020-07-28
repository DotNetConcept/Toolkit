namespace DotNetConcept.Toolkit.Messaging
{
    public class Response : ResponseBase<Response>, IResponse
    {
    }

    public class Response<T> : ResponseBase<Response<T>, T>, IResponse<T>
    {
    }
}