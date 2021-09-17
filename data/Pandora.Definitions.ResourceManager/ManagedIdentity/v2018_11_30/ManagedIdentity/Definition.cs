using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "e07d7900e7e02c9bb6caba0ee15f0e280e97b8f5" 

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
