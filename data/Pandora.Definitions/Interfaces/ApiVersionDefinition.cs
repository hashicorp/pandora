using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public interface ApiVersionDefinition
    {
        // TODO: we should make "Preview" (and potentially Generate) smarter here
        // e.g. is this API available in this region, or in Preview in that region
        string ApiVersion { get; }
        bool Generate { get; }
        bool Preview { get; }

        IEnumerable<ResourceDefinition> Resources { get; }
    }
}