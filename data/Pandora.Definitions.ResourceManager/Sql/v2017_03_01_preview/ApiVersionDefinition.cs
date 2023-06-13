using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2017-03-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new BackupLongTermRetentionPolicies.Definition(),
        new BlobAuditing.Definition(),
        new DataWarehouseUserActivities.Definition(),
        new DatabaseVulnerabilityAssesmentRuleBaselines.Definition(),
        new DatabaseVulnerabilityAssessments.Definition(),
        new Databases.Definition(),
        new JobAgents.Definition(),
        new JobCredentials.Definition(),
        new JobExecutions.Definition(),
        new JobStepExecutions.Definition(),
        new JobSteps.Definition(),
        new JobTargetExecutions.Definition(),
        new JobTargetGroups.Definition(),
        new JobVersions.Definition(),
        new Jobs.Definition(),
        new LongTermRetentionBackups.Definition(),
        new ManagedBackupShortTermRetentionPolicies.Definition(),
        new ManagedDatabaseSecurityAlertPolicies.Definition(),
        new ManagedDatabases.Definition(),
        new ManagedInstanceAdministrators.Definition(),
        new ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies.Definition(),
        new ManagedServerSecurityAlertPolicies.Definition(),
        new RestorableDroppedManagedDatabases.Definition(),
        new RestorePoints.Definition(),
        new SensitivityLabels.Definition(),
        new ServerAutomaticTuning.Definition(),
        new ServerDnsAliases.Definition(),
        new ServerSecurityAlertPolicies.Definition(),
    };
}
