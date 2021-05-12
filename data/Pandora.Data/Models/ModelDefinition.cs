using System.Collections.Generic;

namespace Pandora.Data.Models
{
    public class ModelDefinition
    {
        public string Name { get; set; }
        public List<PropertyDefinition> Properties { get; set; }
    }
}