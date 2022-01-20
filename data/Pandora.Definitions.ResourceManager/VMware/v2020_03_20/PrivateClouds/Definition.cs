using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds;

internal class Definition : ResourceDefinition
{
    public string Name => "PrivateClouds";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListAdminCredentialsOperation(),
        new ListInSubscriptionOperation(),
        new UpdateOperation(),
    };
}
