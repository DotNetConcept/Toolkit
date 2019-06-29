namespace DotNetConcept.Toolkit.AspNetCore.Mvc
{
    using System;
    using System.Net;

    using IdentityModel;

    using JetBrains.Annotations;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using X.PagedList;

    public abstract class ExtendedControllerBase : ControllerBase
    {
        public virtual Guid? GetUserIdFromJwtToken()
        {
            return Guid.TryParse(this.User.FindFirst(JwtClaimTypes.Subject)?.Value, out var result)
                       ? (Guid?)result
                       : null;
        }

        public virtual IActionResult PartialContent<T>([NotNull]IPagedList<T> pagedList)
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
    }
}
