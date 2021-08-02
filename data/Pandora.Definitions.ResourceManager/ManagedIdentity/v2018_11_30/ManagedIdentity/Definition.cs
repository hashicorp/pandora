using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "d2183715d380084ff04313a73c8803d042fe91b9" 

        public string ApiVersion => "2018-11-30";
        public string Name => "ManagedIdentity";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new SystemAssignedIdentitiesGetByScopeOperation(),
            new UserAssignedIdentitiesCreateOrUpdateOperation(),
            new UserAssignedIdentitiesDeleteOperation(),
            new UserAssignedIdentitiesGetOperation(),
            new UserAssignedIdentitiesListByResourceGroupOperation(),
            new UserAssignedIdentitiesListBySubscriptionOperation(),
            new UserAssignedIdentitiesUpdateOperation(),
        };
    }
}
