using System.Text.Json;

namespace Inoxie.DataProcessor.Abstractions.Models
{
    public class DefaultFilterModel : BaseFilterModel
    {
        public override object Clone()
        {
            var jsonString = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize(jsonString, this.GetType());
        }
    }
}
