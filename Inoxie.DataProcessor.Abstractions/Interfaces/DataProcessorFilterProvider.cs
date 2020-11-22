using Inoxie.DataProcessor.Abstractions.Models;
using System;
using System.Linq;

namespace Inoxie.DataProcessor.Abstractions.Interfaces
{
    public interface IDataProcessorFilterProvider<TModel, TFilter>
        where TModel : class
        where TFilter : BaseFilterModel
    {
        Func<TFilter, IQueryable<TModel>> GetFunc(IQueryable<TModel> queryable);
    }
}
