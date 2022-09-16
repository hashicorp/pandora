using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new BigDataPools.Definition(),
        new DatabaseVulnerabilityAssesmentRuleBaselines.Definition(),
        new IPFirewallRules.Definition(),
        new IntegrationRuntime.Definition(),
        new IntegrationRuntimes.Definition(),
        new Keys.Definition(),
        new Libraries.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkHubPrivateLinkResources.Definition(),
        new PrivateLinkHubs.Definition(),
        new PrivateLinkResources.Definition(),
        new RecoverableSqlPools.Definition(),
        new RestorableDroppedSqlPools.Definition(),
        new SensitivityLabels.Definition(),
        new SqlPools.Definition(),
        new SqlPoolsBackup.Definition(),
        new SqlPoolsBlobAuditing.Definition(),
        new SqlPoolsConnectionPolicies.Definition(),
        new SqlPoolsDataMaskingPolicies.Definition(),
        new SqlPoolsDataMaskingRules.Definition(),
        new SqlPoolsDatabaseVulnerabilityAssesmentRuleBaselines.Definition(),
        new SqlPoolsGeoBackupPolicies.Definition(),
        new SqlPoolsMaintenanceWindowOptions.Definition(),
        new SqlPoolsMaintenanceWindows.Definition(),
        new SqlPoolsReplicationLinks.Definition(),
        new SqlPoolsRestorePoints.Definition(),
        new SqlPoolsSchemas.Definition(),
        new SqlPoolsSecurityAlertPolicies.Definition(),
        new SqlPoolsSensitivityLabels.Definition(),
        new SqlPoolsSqlPoolColumns.Definition(),
        new SqlPoolsSqlPoolSchemas.Definition(),
        new SqlPoolsSqlPoolTables.Definition(),
        new SqlPoolsSqlPoolUserActivities.Definition(),
        new SqlPoolsSqlPoolVulnerabilityAssesmentRuleBaselines.Definition(),
        new SqlPoolsSqlPoolVulnerabilityAssessmentScans.Definition(),
        new SqlPoolsTables.Definition(),
        new SqlPoolsTransparentDataEncryption.Definition(),
        new SqlPoolsUsages.Definition(),
        new SqlPoolsVulnerabilityAssessmentScansExecute.Definition(),
        new SqlPoolsVulnerabilityAssessmentScansExport.Definition(),
        new SqlPoolsVulnerabilityAssessments.Definition(),
        new SqlPoolsWorkloadClassifiers.Definition(),
        new SqlPoolsWorkloadGroups.Definition(),
        new WorkspaceAzureADOnlyAuthentications.Definition(),
        new WorkspaceManagedSqlServer.Definition(),
        new WorkspaceManagedSqlServerBlobAuditing.Definition(),
        new WorkspaceManagedSqlServerDedicatedSQLminimalTlsSettings.Definition(),
        new WorkspaceManagedSqlServerSecurityAlertPolicies.Definition(),
        new WorkspaceManagedSqlServerServerEncryptionProtector.Definition(),
        new WorkspaceManagedSqlServerServerVulnerabilityAssessments.Definition(),
        new WorkspaceManagedSqlServerSqlUsages.Definition(),
        new Workspaces.Definition(),
    };
}
