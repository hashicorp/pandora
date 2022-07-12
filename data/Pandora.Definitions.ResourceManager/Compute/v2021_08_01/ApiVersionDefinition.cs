using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Compute.v2021_08_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-08-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DiskAccesses.Definition(),
        new DiskEncryptionSets.Definition(),
        new Disks.Definition(),
        new IncrementalRestorePoints.Definition(),
        new Snapshots.Definition(),
    };
}
