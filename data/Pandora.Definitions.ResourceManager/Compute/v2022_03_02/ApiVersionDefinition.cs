using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_02;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-03-02";
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
