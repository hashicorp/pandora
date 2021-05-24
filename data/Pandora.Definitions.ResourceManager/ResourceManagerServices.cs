using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager
{
    public class ResourceManagerServices : ServicesDefinition
    {
        public IEnumerable<ServiceDefinition> Services => new List<ServiceDefinition>
        {
            new AppConfiguration.Service(),
            new EventHub.Service(),
            new Pandamonium.Service(),
            new Resources.Service(),
        };
    }
}