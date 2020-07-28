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
