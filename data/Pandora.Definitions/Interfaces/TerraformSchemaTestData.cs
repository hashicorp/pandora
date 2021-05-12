using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public class TerraformSchemaTestData
    {
        public bool ImportAfterApply { get; set; }
        
        public List<string>? FieldUnavailableAtImport { get; }
        
        public string TestConfiguration { get; set; }
    }
}