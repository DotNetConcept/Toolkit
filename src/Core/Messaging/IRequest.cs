using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetConcept.Toolkit.Messaging
{
    public interface IRequest
    {
        Guid RequestId { get; set; }
    }
}
