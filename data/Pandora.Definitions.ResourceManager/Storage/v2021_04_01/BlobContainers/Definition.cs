using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Storage.v2021_04_01.BlobContainers;

internal class Definition : ResourceDefinition
{
    public string Name => "BlobContainers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ClearLegalHoldOperation(),
        new CreateOperation(),
        new CreateOrUpdateImmutabilityPolicyOperation(),
        new DeleteOperation(),
        new DeleteImmutabilityPolicyOperation(),
        new ExtendImmutabilityPolicyOperation(),
        new GetOperation(),
        new GetImmutabilityPolicyOperation(),
        new LeaseOperation(),
        new ListOperation(),
        new LockImmutabilityPolicyOperation(),
        new ObjectLevelWormOperation(),
        new SetLegalHoldOperation(),
        new UpdateOperation(),
    };
}
