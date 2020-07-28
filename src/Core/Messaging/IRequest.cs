namespace DotNetConcept.Toolkit.Messaging
{
    using System;

    public interface IRequest
    {
        Guid RequestId { get; }
    }
}
