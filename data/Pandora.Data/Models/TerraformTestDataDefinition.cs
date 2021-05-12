using System.Collections.Generic;

namespace Pandora.Data.Models
{
    public class TerraformTestDataDefinition
    {
        public bool ImportAfterApply { get; set; }
        public List<string>? FieldsUnavailableAtImport { get; set; }
        public string TestConfigurationHcl { get; set; }
    }
}