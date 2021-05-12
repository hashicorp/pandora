using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.DataPlane
{
    public class DataPlaneServices : ServicesDefinition
    {
        public IEnumerable<ServiceDefinition> Services => new List<ServiceDefinition>
        {
            // new AppConfiguration.Service(),
        };
    }
}