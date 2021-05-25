using System.Collections.Generic;
using System.Linq;
using Pandora.Definitions.DataPlane;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.ResourceManager;

namespace Pandora.Data
{
    public static class SupportedServices
    {
        public static IEnumerable<ServiceDefinition> Get()
        {
            var servicesDefinitions = new List<ServicesDefinition>{
                new DataPlaneServices(),
                new ResourceManagerServices(),
            };
            return servicesDefinitions.SelectMany(Definitions.Discovery.Services.WithinServicesDefinition).ToList();
        }
    }
}