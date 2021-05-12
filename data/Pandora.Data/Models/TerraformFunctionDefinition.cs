using System.Collections.Generic;

namespace Pandora.Data.Models
{
    public class TerraformFunctionDefinition
    {
        public int DefaultTimeoutInMinutes { get; set; }
        public TerraformFunctionType FunctionType { get; set; }
        public TerraformSchemaMapperDefinition? Mapper { get; set; }
        public List<OperationDefinition> Operations { get; set; }
    }
}