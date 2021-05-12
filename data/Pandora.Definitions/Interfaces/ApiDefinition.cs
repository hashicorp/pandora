using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public interface ApiDefinition
    {
        string ApiVersion { get; }
        
        string Name { get; }
        
        IEnumerable<ApiOperation> Operations { get; }
    }
}