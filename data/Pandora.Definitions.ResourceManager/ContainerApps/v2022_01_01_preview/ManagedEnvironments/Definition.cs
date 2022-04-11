using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ManagedEnvironments;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedEnvironments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CertificatesCreateOrUpdateOperation(),
        new CertificatesDeleteOperation(),
        new CertificatesGetOperation(),
        new CertificatesListOperation(),
        new CertificatesUpdateOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
}
