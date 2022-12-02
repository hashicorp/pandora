using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new BackupEngines.Definition(),
        new BackupJobs.Definition(),
        new BackupOperationResults.Definition(),
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
        new ItemLevelRecoveryConnections.Definition(),
        new JobCancellations.Definition(),
        new JobDetails.Definition(),
        new Jobs.Definition(),
        new Operation.Definition(),
        new PrivateEndpoint.Definition(),
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
        new ValidateOperation.Definition(),
        new ValidateOperationResults.Definition(),
    };
}
