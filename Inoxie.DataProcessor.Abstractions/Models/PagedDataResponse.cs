using System;
using System.Collections.Generic;

namespace Inoxie.DataProcessor.Abstractions.Models
{
    public class PagedDataResponse<T> where T : class
    {
        public IEnumerable<T> Collection { get; set; }
        public string NextPage { get; set; }
        public string PreviousPage { get; set; }
    }
}
