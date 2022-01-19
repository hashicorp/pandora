using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public interface ResourceDefinition
    {
        string Name { get; }

        IEnumerable<ApiOperation> Operations { get; }
    }
}