using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConcept.Toolkit.Messaging
{
    public abstract class RequestBase : IRequest
    {
        public Guid RequestId { get; set; }
    }
}
