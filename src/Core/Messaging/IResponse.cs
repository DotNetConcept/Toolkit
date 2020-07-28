namespace DotNetConcept.Toolkit.Messaging
{
    using System;
    using System.Collections.Generic;

    using JetBrains.Annotations;

    public interface IResponse
    {
        /// <summary>
        /// Gets or sets the response identifier.
        /// </summary>
        /// <value>
        /// The response identifier.
        /// </value>
        Guid ResponseId { get; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        ResponseStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }

        /// <summary>
        /// Gets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        IReadOnlyDictionary<string, object> Headers { get; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        Exception Exception { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        string Code { get; set; }

        /// <summary>
        /// Sets the headers.
        /// </summary>
        /// <param name="headers">The headers.</param>
        void SetHeaders([NotNull] IDictionary<string, object> headers);
    }

    public interface IResponse<T> : IResponse
    {
        T Data { get; set; }
    }
}
