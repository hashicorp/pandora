using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Cognitive.v2021_04_30
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2021-04-30";
        public bool Preview => false;

        public IEnumerable<ResourceDefinition> Apis => new List<ResourceDefinition>
        {
            new CognitiveServicesAccounts.Definition(),
            new PrivateEndpointConnections.Definition(),
            new PrivateLinkResources.Definition(),
            new Skus.Definition(),
        };
    }
}
