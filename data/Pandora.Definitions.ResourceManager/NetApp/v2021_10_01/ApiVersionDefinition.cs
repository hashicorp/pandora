using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.NetApp.v2021_10_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-10-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new BackupPolicy.Definition(),
        new Backups.Definition(),
        new CapacityPools.Definition(),
        new NetAppAccounts.Definition(),
        new NetAppResource.Definition(),
        new PoolChange.Definition(),
        new Restore.Definition(),
        new SnapshotPolicy.Definition(),
        new SnapshotPolicyListVolumes.Definition(),
        new Snapshots.Definition(),
        new SubVolumes.Definition(),
        new Vaults.Definition(),
        new VolumeGroups.Definition(),
        new Volumes.Definition(),
        new VolumesReplication.Definition(),
        new VolumesRevert.Definition(),
    };

    public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
    {
    };
}
