using System;

namespace Inoxie.DataProcessor.Abstractions.Models
{
    public abstract class BaseFilterModel : ICloneable
    {
        public int Page { get; set; }
        public int Limit { get; set; }

        public BaseFilterModel()
        {
            this.Page = 1;
            this.Limit = 5;
        }

        public abstract object Clone();

    }
}
