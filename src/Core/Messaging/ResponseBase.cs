namespace DotNetConcept.Toolkit.Messaging
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public abstract class ResponseBase : IResponse
    {
        protected ResponseBase()
        {
            this.Headers = new Dictionary<string, object>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBase"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        protected ResponseBase(object data, IDictionary<string, object> headers = null)
        {
            this.Data = data;
            this.Status = ResponseStatus.Success;
            this.Headers = headers ?? new Dictionary<string, object>();
        }

        protected ResponseBase(ResponseStatus status, string message = null, Exception exception = null, IDictionary<string, object> headers = null)
        {
            this.Status = status;
            this.Message = message;
            this.Exception = exception;
            this.Headers = headers ?? new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets or sets the response identifier.
        /// </summary>
        /// <value>
        /// The response identifier.
        /// </value>
        public Guid ResponseId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public ResponseStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets the headers.
        /// </summary>
        /// <value>
        /// The headers.
        /// </value>
        public IDictionary<string, object> Headers { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public object Data { get; set; }

        /// <summary>
        /// Gets or sets the exception.
        /// </summary>
        /// <value>
        /// The exception.
        /// </value>
        public Exception Exception { get; set; }
    }

    /// <summary>
    /// The response base.
    /// </summary>
    /// <typeparam name="T">
    /// </typeparam>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    public abstract class ResponseBase<T> : ResponseBase, IResponse<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBase{T}"/> class.
        /// </summary>
        protected ResponseBase()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseBase{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        protected ResponseBase(T data) : base(data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public new T Data { get; set; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        object IResponse.Data
        {
            get => this.Data;
            set => this.Data = (T)value;
        }
    }
}
