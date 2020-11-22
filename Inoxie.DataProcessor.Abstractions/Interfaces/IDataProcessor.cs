using Inoxie.DataProcessor.Abstractions.Models;
using System.Linq;

namespace Inoxie.DataProcessor.Abstractions.Interfaces
{
    public interface IDataProcessor<TModel, TFilter>
        where TModel : class
        where TFilter : BaseFilterModel
    {
        PagedDataResponse<TModel> Process(TFilter filter, IQueryable<TModel> queryable);
    }
}
