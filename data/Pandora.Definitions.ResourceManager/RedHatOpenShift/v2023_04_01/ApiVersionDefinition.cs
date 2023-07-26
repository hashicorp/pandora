using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RedHatOpenShift.v2023_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new MachinePools.Definition(),
        new OpenShiftClusters.Definition(),
        new OpenShiftVersions.Definition(),
        new Secrets.Definition(),
        new SyncIdentityProviders.Definition(),
        new SyncSets.Definition(),
    };
}
