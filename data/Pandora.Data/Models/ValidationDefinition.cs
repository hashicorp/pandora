using System.Collections.Generic;

namespace Pandora.Data.Models
{
    public class ValidationDefinition
    {
        public ValidationType ValidationType { get; set; }

        public List<object>? Values { get; set; }
    }
}