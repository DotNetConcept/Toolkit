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

        /// <summary>
        /// Returns a success response with specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static TResponse Success(TData data)
        {
            return new TResponse { Data = data, Status = ResponseStatus.Success };
        }
    }

    public abstract class ResponseBase<TResponse>
        where TResponse : IResponse, new()
    {
        /// <summary>
        ///     Gets or sets the code.
        /// </summary>
        /// <value>
        ///     The code.
        /// </value>
        public string Code { get; set; }

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
        /// Returns a "BadRequest" response
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static TResponse BadRequest(string message = null)
        {
            return new TResponse { Status = ResponseStatus.BadRequest, Message = message };
        }

        /// <summary>
        /// Errors the specified exception.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static TResponse Error(Exception exception = null, string message = null)
        {
            return new TResponse { Status = ResponseStatus.Error, Exception = exception, Message = message  ?? exception?.Message };
        }

        /// <summary>
        /// Returns an "NotFound" response
        /// </summary>
        /// <returns></returns>
        public static TResponse NotFound()
        {
            return new TResponse { Status = ResponseStatus.NotFound };
        }

        /// <summary>
        ///     Returns a success response
        /// </summary>
        /// <returns></returns>
        public static TResponse Success(string message = null)
        {
            return new TResponse { Status = ResponseStatus.Success, Message = message };
        }

        /// <summary>
        /// Sets the headers.
        /// </summary>
        /// <param name="headers">The headers.</param>
        public virtual void SetHeaders([NotNull] IDictionary<string, object> headers)
        {
            this.Headers = new ReadOnlyDictionary<string, object>(headers);
        }
    }
}