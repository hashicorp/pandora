using System.Collections.Generic;
using System.Linq;
using Pandora.Definitions.DataPlane;
using Pandora.Definitions.HandDefined;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.ResourceManager;
using Pandora.Definitions.TestData;

namespace Pandora.Data;

public static class SupportedServices
{
    public static IEnumerable<ServiceDefinition> Get()
    {
        var servicesDefinitions = new List<ServicesDefinition>{
            new DataPlaneServices(),
            new HandDefinedServices(),
            new ResourceManagerServices(),
                
            // NOTE: this can be useful during development for example scenarios so is intentionally commented out here
            // new TestDataServices(),
        };
        return servicesDefinitions.SelectMany(Definitions.Discovery.Services.WithinServicesDefinition).ToList();
    }
}