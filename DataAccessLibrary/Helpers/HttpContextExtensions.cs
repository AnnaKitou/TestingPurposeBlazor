using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Helpers
{
    public static class HttpContextExtensions
    {
        public static async Task InsertPaginationParameterInResponse<T>(this HttpContext httpContext,IQueryable<T> queryable, int recordsPerPage)
        {
         double count =  queryable.Count();
            double pagesQuantity=Math.Ceiling(count/recordsPerPage);
            httpContext.Response.Headers.Add("pagesQuantity",pagesQuantity.ToString());
        }
    }
}
