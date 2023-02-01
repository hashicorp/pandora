using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RedhatOpenShift.v2022_09_04;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-09-04";
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
