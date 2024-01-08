using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-08-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new BackupEngines.Definition(),
        new BackupJobs.Definition(),
        new BackupPolicies.Definition(),
        new BackupProtectableItems.Definition(),
        new BackupProtectedItems.Definition(),
        new BackupProtectionContainers.Definition(),
        new BackupProtectionIntent.Definition(),
        new BackupResourceEncryptionConfigs.Definition(),
        new BackupResourceStorageConfigsNonCRR.Definition(),
        new BackupResourceVaultConfigs.Definition(),
        new BackupStatus.Definition(),
        new BackupUsageSummaries.Definition(),
        new BackupWorkloadItems.Definition(),
        new Backups.Definition(),
        new DataMove.Definition(),
        new FeatureSupport.Definition(),
        new FetchTieringCost.Definition(),
        new ItemLevelRecoveryConnections.Definition(),
        new JobCancellations.Definition(),
        new JobDetails.Definition(),
        new Jobs.Definition(),
        new Operation.Definition(),
        new PrivateEndpointConnection.Definition(),
        new ProtectableContainers.Definition(),
        new ProtectedItems.Definition(),
        new ProtectionContainers.Definition(),
        new ProtectionIntent.Definition(),
        new ProtectionPolicies.Definition(),
        new RecoveryPoint.Definition(),
        new RecoveryPoints.Definition(),
        new RecoveryPointsRecommendedForMove.Definition(),
        new ResourceGuardProxies.Definition(),
        new ResourceGuardProxy.Definition(),
        new Restores.Definition(),
        new SecurityPINs.Definition(),
        new SoftDeletedContainers.Definition(),
        new ValidateOperation.Definition(),
    };
}
