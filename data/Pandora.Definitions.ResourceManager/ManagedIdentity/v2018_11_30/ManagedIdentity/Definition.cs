using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagedIdentity.v2018_11_30.ManagedIdentity
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "fd7603f9a8acb1decf94f7770a0bfe7b78df9b20" 

        public string ApiVersion => "2018-11-30";
        public string Name => "ManagedIdentity";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new UserAssignedIdentitiesCreateOrUpdateOperation(),
            new UserAssignedIdentitiesDeleteOperation(),
            new UserAssignedIdentitiesGetOperation(),
            new UserAssignedIdentitiesListByResourceGroupOperation(),
            new UserAssignedIdentitiesListBySubscriptionOperation(),
            new UserAssignedIdentitiesUpdateOperation(),
        };
    }
}
