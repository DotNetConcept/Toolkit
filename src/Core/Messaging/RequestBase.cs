namespace DotNetConcept.Toolkit.Messaging
{
    using System;

    public abstract class RequestBase : IRequest
    {
        public Guid RequestId { get; } = Guid.NewGuid();
    }
}
