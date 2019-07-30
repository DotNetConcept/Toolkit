namespace DotNetConcept.Toolkit.AspNetCore.Mvc
{
    using System;
    using System.Linq;
    using System.Net;

    using DotNetConcept.Toolkit.Extensions;
    using DotNetConcept.Toolkit.Messaging;

    using IdentityModel;

    using JetBrains.Annotations;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using X.PagedList;

    public abstract class ExtendedControllerBase : ControllerBase
    {
        /// <summary>
        /// Gets the user identifier from JWT token.
        /// </summary>
        /// <param name="claimType">Type of the claim.</param>
        /// <returns></returns>
        public virtual Guid? GetUserIdFromJwtToken(string claimType = JwtClaimTypes.Subject)
        {
            return Guid.TryParse(this.User.FindFirst(claimType)?.Value, out var result)
                       ? (Guid?)result
                       : null;
        }

        /// <summary>
        /// Gets the user identifier from headers.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public virtual Guid? GetUserIdFromHeaders(string key = "UserId")
        {
            return Guid.TryParse(this.Request.Headers[key].FirstOrDefault(), out var result)
                       ? (Guid?)result
                       : null;
        }

        /// <summary>
        /// Partials the content.
        /// </summary>
        /// <param name="pagedList">The paged list.</param>
        /// <returns></returns>
        public virtual IActionResult PartialContent([NotNull]IPagedList pagedList)
        {
            var paginationHeader = new
                                       {
                                           pagedList.PageNumber,
                                           pagedList.PageSize,
                                           pagedList.TotalItemCount,
                                           pagedList.PageCount,
                                       };

            this.Request.HttpContext.Response.Headers.Add(
                "X-Pagination",
                JsonConvert.SerializeObject(paginationHeader));
            return pagedList.PageCount > 1
                       ? this.StatusCode((int)HttpStatusCode.PartialContent, pagedList)
                       : this.Ok(pagedList);
        }

        /// <summary>
        /// Converts the specified response.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <returns></returns>
        public virtual IActionResult Result([NotNull] IResponse response)
        {
            switch (response.Status)
            {
                case ResponseStatus.Success:
                    if (response.Data is IPagedList pagedList)
                    {
                        return this.PartialContent(pagedList);
                    }

                    return response.Data != null ? (IActionResult)this.Ok(response.Data) : this.NotFound();

                case ResponseStatus.Conflict:
                    return response.Message.IsNullOrWhiteSpace()
                               ? (IActionResult)this.Conflict()
                               : this.Conflict(response.Message);


                case ResponseStatus.NotFound:
                    return this.NotFound();

                case ResponseStatus.BadRequest:
                    return response.Message.IsNullOrWhiteSpace()
                               ? (IActionResult)this.BadRequest()
                               : this.BadRequest(response.Message);

                default:
                    return response.Message.IsNullOrWhiteSpace()
                               ? (IActionResult)this.StatusCode(500)
                               : this.StatusCode(500, response.Message);
            }
        }
    }
}
