using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2020_06_01
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2020-06-01";
        public bool Preview => false;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new ConfigurationStores.Definition(),
            new PrivateEndpointConnections.Definition(),
            new PrivateLinkResources.Definition(),
        };
    }
}
