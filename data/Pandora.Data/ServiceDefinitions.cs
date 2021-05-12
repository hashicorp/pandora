using System.Collections.Generic;
using Pandora.Definitions.DataPlane;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.ResourceManager;

namespace Pandora.Definitions
{
    public static class SupportedServices
    {
        public static IEnumerable<ServicesDefinition> Get() => new List<ServicesDefinition>
        {
            new DataPlaneServices(),
            new ResourceManagerServices(),
        };
    }
}