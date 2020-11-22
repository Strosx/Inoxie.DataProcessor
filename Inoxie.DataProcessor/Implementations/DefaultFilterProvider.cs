using Inoxie.DataProcessor.Abstractions.Interfaces;
using Inoxie.DataProcessor.Abstractions.Models;
using System;
using System.Linq;

namespace Inoxie.DataProcessor.Implementations
{
    internal class DefaultFilterProvider<TModel> : IDataProcessorFilterProvider<TModel, DefaultFilterModel>
        where TModel : class
    {
        public Func<DefaultFilterModel, IQueryable<TModel>> GetFunc(IQueryable<TModel> queryable)
        {
            return (filterModel) =>
            {
                return queryable
                    .Skip((filterModel.Page - 1) * filterModel.Limit)
                    .Take(filterModel.Limit);
            };
        }
    }
}
