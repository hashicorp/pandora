using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public interface TerraformFunctionDefinition
    {
        public int DefaultTimeoutInMinutes { get; }
        // an ordered list of api operations
        public FunctionType Type { get; }
        public List<ApiReference> Operations { get; }
        public TerraformSchemaMapper? SchemaMapper { get; }
    }

    public class ApiReference
    {
        public ApiOperation Operation { get; set; }
        public ApiDefinition ApiDefinition { get; set; }
    }

    public enum FunctionType
    {
        // only kicking around to catch where this field isn't assigned
        Unknown,
        
        DataSourceRead,
        ResourceCreate,
        ResourceDelete,
        ResourceRead,
        ResourceUpdate,
    }
}