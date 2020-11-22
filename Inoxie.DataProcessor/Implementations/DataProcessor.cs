using Inoxie.DataProcessor.Abstractions.Interfaces;
using Inoxie.DataProcessor.Abstractions.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Web;

namespace Inoxie.DataProcessor.Implementations
{
    internal class DataProcessorImplementation<TModel, TFilter> : IDataProcessor<TModel, TFilter>
        where TModel : class
        where TFilter : BaseFilterModel
    {
        private readonly IDataProcessorFilterProvider<TModel, TFilter> dataProcessorFilterProvider;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DataProcessorImplementation(
            IDataProcessorFilterProvider<TModel, TFilter> dataProcessorFilterProvider,
            IHttpContextAccessor httpContextAccessor)
        {
            this.dataProcessorFilterProvider = dataProcessorFilterProvider;
            this.httpContextAccessor = httpContextAccessor;
        }

        public PagedDataResponse<TModel> Process(TFilter filter, IQueryable<TModel> queryable)
        {
            Func<TFilter, IQueryable<TModel>> filterData = dataProcessorFilterProvider.GetFunc(queryable);

            var result = new PagedDataResponse<TModel>
            {
                Collection = filterData(filter)
            };

            var nextFilter = filter.Clone() as TFilter;
            nextFilter.Page += 1;
            var nextUrl = filterData(nextFilter).Any() ? ToQueryString(nextFilter) : null;

            var previousFilter = filter.Clone() as TFilter;
            previousFilter.Page -= 1;
            var previousUrl = previousFilter.Page <= 0 ? null : ToQueryString(previousFilter);

            result.NextPage = nextUrl ?? null;
            result.PreviousPage = previousUrl ?? null;

            return result;

        }

        private string ToQueryString(TFilter filter)
        {
            var url=  httpContextAccessor.HttpContext.Request.Path.Value;
        //    var urlWithourQuery = String.Format("{0}{1}{2}{3}", url.Scheme,
         //       Uri.SchemeDelimiter, url.Authority, url.AbsolutePath);

            return $"{url}?{GetQueryString(filter)}";
        }

        private static string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return String.Join("&", properties.ToArray());
        }

    }
}
