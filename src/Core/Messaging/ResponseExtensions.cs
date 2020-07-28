namespace DotNetConcept.Toolkit.Messaging
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// IResponse extension methods
    /// </summary>
    public static class ResponseExtensions
    {
        /// <summary>
        /// Add a message into the response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="response">The response.</param>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static TResponse WithMessage<TResponse>(this TResponse response, string message) where TResponse : IResponse
        {
            response.Message = message;
            return response;
        }

        /// <summary>
        /// Add a code into the response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="response">The response.</param>
        /// <param name="code">The code.</param>
        /// <returns></returns>
        public static TResponse WithCode<TResponse>(this TResponse response, string code) where TResponse : IResponse
        {
            response.Code = code;
            return response;
        }

        /// <summary>
        /// Add an exception into the response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="response">The response.</param>
        /// <param name="exception">The exception.</param>
        /// <returns></returns>
        public static TResponse WithException<TResponse>(this TResponse response, Exception exception) where TResponse : IResponse
        {
            response.Exception = exception;
            return response;
        }

        /// <summary>
        /// Add headers into the response.
        /// </summary>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="response">The response.</param>
        /// <param name="headers">The headers.</param>
        /// <returns></returns>
        public static TResponse WithHeaders<TResponse>(this TResponse response, IDictionary<string, object> headers) where TResponse : IResponse
        {
            response.SetHeaders(headers);
            return response;
        }
    }
}
