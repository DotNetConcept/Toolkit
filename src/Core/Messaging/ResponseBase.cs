namespace DotNetConcept.Toolkit.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using JetBrains.Annotations;

    public abstract class ResponseBase<TResponse, TData> : ResponseBase<TResponse>
        where TResponse : IResponse<TData>, new()
    {
        public TData Data { get; set; }

        public static TResponse Success(TData data)
        {
            return new TResponse { Data = data, Status = ResponseStatus.Success };
        }
    }

    public abstract class ResponseBase<TResponse>
        where TResponse : IResponse, new()
    {
        /// <summary>
        ///     Gets or sets the exception.
        /// </summary>
        /// <value>
        ///     The exception.
        /// </value>
        public Exception Exception { get; set; }

        /// <summary>
        ///     Gets the headers.
        /// </summary>
        /// <value>
        ///     The headers.
        /// </value>
        public IReadOnlyDictionary<string, object> Headers { get; protected set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the response identifier.
        /// </summary>
        /// <value>
        ///     The response identifier.
        /// </value>
        public Guid ResponseId { get; } = Guid.NewGuid();

        /// <summary>
        ///     Gets or sets the status.
        /// </summary>
        /// <value>
        ///     The status.
        /// </value>
        public ResponseStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string Code { get; set; }

        public static TResponse BadRequest()
        {
            return new TResponse { Status = ResponseStatus.BadRequest };
        }

        public static TResponse Error()
        {
            return new TResponse { Status = ResponseStatus.Error };
        }

        public static TResponse NotFound()
        {
            return new TResponse { Status = ResponseStatus.NotFound };
        }

        public static TResponse Success()
        {
            return new TResponse { Status = ResponseStatus.Success };
        }

        public virtual void SetHeaders([NotNull] IDictionary<string, object> headers)
        {
            this.Headers = new ReadOnlyDictionary<string, object>(headers);
        }
    }
}