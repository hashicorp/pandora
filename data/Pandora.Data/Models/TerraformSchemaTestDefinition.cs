using System.Collections.Generic;

namespace Pandora.Data.Models
{
    public class TerraformSchemaTestDefinition
    {
        public string Name { get; set; }
        
        public List<TerraformTestDataDefinition> Steps { get; set; }
    }
}