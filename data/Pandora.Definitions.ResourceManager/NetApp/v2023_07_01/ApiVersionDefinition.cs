using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-07-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new BackupPolicy.Definition(),
        new CapacityPools.Definition(),
        new FileLocks.Definition(),
        new GroupIdListForLDAPUser.Definition(),
        new NetAppAccounts.Definition(),
        new NetAppResource.Definition(),
        new PoolChange.Definition(),
        new ResetCifsPassword.Definition(),
        new Restore.Definition(),
        new SnapshotPolicy.Definition(),
        new SnapshotPolicyListVolumes.Definition(),
        new Snapshots.Definition(),
        new SubVolumes.Definition(),
        new VolumeGroups.Definition(),
        new VolumeQuotaRules.Definition(),
        new Volumes.Definition(),
        new VolumesRelocation.Definition(),
        new VolumesReplication.Definition(),
        new VolumesRevert.Definition(),
    };
}
