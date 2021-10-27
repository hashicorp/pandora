using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_04_01.WebApplicationFirewallPolicies
{
    internal class Definition : ApiDefinition
    {
        public string ApiVersion => "2020-04-01";
        public string Name => "WebApplicationFirewallPolicies";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new PoliciesCreateOrUpdateOperation(),
            new PoliciesDeleteOperation(),
            new PoliciesGetOperation(),
            new PoliciesListOperation(),
        };
    }
}
