using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public interface ApiDefinition
    {
        string Name { get; }

        IEnumerable<ApiOperation> Operations { get; }
    }
}