namespace DotNetConcept.Toolkit.AspNetCore.Mvc
{
    using System.Net;

    using Ardalis.GuardClauses;

    using Microsoft.AspNetCore.Mvc;

    using Newtonsoft.Json;

    using X.PagedList;

    public abstract class ExtendedControllerBase : ControllerBase
    {
        public IActionResult PartialContent<T>(IPagedList<T> pagedList)
        {
            Guard.Against.Null(pagedList, nameof(pagedList));

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
