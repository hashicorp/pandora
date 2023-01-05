using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-12-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AzureBackupJob.Definition(),
        new AzureBackupJobs.Definition(),
        new BackupInstances.Definition(),
        new BackupPolicies.Definition(),
        new BackupVaults.Definition(),
        new DeletedBackupInstances.Definition(),
        new DppFeatureSupport.Definition(),
        new FindRestorableTimeRanges.Definition(),
        new RecoveryPoint.Definition(),
        new ResourceGuards.Definition(),
    };
}
