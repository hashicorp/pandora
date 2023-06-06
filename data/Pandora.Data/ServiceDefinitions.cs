using System.Collections.Generic;
using System.Linq;
using Pandora.Data.Models;
using Pandora.Definitions.DataPlane;
using Pandora.Definitions.HandDefined;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta;
using Pandora.Definitions.MicrosoftGraph.Stable;
using Pandora.Definitions.ResourceManager;
using ServiceDefinition = Pandora.Definitions.Interfaces.ServiceDefinition;

namespace Pandora.Data;

public static class SupportedServices
{
    public static Dictionary<ServiceDefinitionType, IEnumerable<ServiceDefinition>> Get()
    {
        var data = new Dictionary<ServiceDefinitionType, List<ServicesDefinition>>
        {
            {
                ServiceDefinitionType.DataPlane,
                new List<ServicesDefinition>
                {
                    new DataPlaneServices(),
                }
            },
            {
                ServiceDefinitionType.MicrosoftGraphBeta,
                new List<ServicesDefinition>
                {
                    new MicrosoftGraphBetaServices(),
                }
            },
            {
                ServiceDefinitionType.MicrosoftGraphStableV1,
                new List<ServicesDefinition>
                {
                    new MicrosoftGraphStableV1Services(),
                }
            },
            {
                ServiceDefinitionType.ResourceManager,
                new List<ServicesDefinition>
                {
                    new HandDefinedServices(),
                    new ResourceManagerServices(),
                }
            },
        };
        var output = new Dictionary<ServiceDefinitionType, IEnumerable<ServiceDefinition>>();
        foreach (var item in data)
        {
            var definitions =item.Value.SelectMany(Definitions.Discovery.Services.WithinServicesDefinition).ToList();
            output.Add(item.Key, definitions);
        }

        return output;
    }
}