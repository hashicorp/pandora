using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2021-08-01";
        public bool Preview => false;

        public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
        {
            new Databases.Definition(),
            new OperationsStatus.Definition(),
            new PrivateEndpointConnections.Definition(),
            new PrivateLinkResources.Definition(),
            new RedisEnterprise.Definition(),
        };
    }
}
