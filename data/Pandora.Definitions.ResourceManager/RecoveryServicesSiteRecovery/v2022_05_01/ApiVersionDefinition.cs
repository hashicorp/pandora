using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new MigrationRecoveryPoints.Definition(),
        new RecoveryPoints.Definition(),
        new ReplicationAlertSettings.Definition(),
        new ReplicationAppliances.Definition(),
        new ReplicationEligibilityResults.Definition(),
        new ReplicationEvents.Definition(),
        new ReplicationFabrics.Definition(),
        new ReplicationJobs.Definition(),
        new ReplicationLogicalNetworks.Definition(),
        new ReplicationMigrationItems.Definition(),
        new ReplicationNetworkMappings.Definition(),
        new ReplicationNetworks.Definition(),
        new ReplicationPolicies.Definition(),
        new ReplicationProtectableItems.Definition(),
        new ReplicationProtectedItems.Definition(),
        new ReplicationProtectionContainerMappings.Definition(),
        new ReplicationProtectionContainers.Definition(),
        new ReplicationProtectionIntents.Definition(),
        new ReplicationRecoveryPlans.Definition(),
        new ReplicationRecoveryServicesProviders.Definition(),
        new ReplicationStorageClassificationMappings.Definition(),
        new ReplicationStorageClassifications.Definition(),
        new ReplicationVaultHealth.Definition(),
        new ReplicationVaultSetting.Definition(),
        new ReplicationvCenters.Definition(),
        new SupportedOperatingSystems.Definition(),
        new TargetComputeSizes.Definition(),
    };
}
