using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-01-15";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AadProperties.Definition(),
        new BackupCrrJobs.Definition(),
        new BackupProtectedItemsCrr.Definition(),
        new BackupResourceStorageConfigs.Definition(),
        new BackupUsageSummariesCRR.Definition(),
        new CrossRegionRestore.Definition(),
        new CrrJobDetails.Definition(),
        new CrrOperationResults.Definition(),
        new RecoveryPointsCrr.Definition(),
        new RecoveryPointsGetAccessToken.Definition(),
    };
}
