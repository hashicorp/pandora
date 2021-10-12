using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview
{
    public partial class Definition : ApiVersionDefinition
    {
        public string ApiVersion => "2020-12-01-preview";
        public bool Preview => true;

        public IEnumerable<ApiDefinition> Apis => new List<ApiDefinition>
        {
            new Account.Definition(),
            new DefaultAccount.Definition(),
            new PrivateEndpointConnection.Definition(),
            new PrivateLinkResource.Definition(),
            new Provider.Definition(),
        };
    }
}
