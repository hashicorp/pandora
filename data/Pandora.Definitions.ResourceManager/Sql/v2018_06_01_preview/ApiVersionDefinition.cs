using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-06-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DatabaseColumns.Definition(),
        new DatabaseSchemas.Definition(),
        new DatabaseSecurityAlertPolicies.Definition(),
        new DatabaseTables.Definition(),
        new FailoverDatabases.Definition(),
        new FailoverElasticPools.Definition(),
        new InstancePools.Definition(),
        new LocationCapabilities.Definition(),
        new LongTermRetentionManagedInstanceBackups.Definition(),
        new ManagedDatabaseColumns.Definition(),
        new ManagedDatabaseRestoreDetails.Definition(),
        new ManagedDatabaseSchemas.Definition(),
        new ManagedDatabaseSensitivityLabels.Definition(),
        new ManagedDatabaseTables.Definition(),
        new ManagedDatabases.Definition(),
        new ManagedInstanceLongTermRetentionPolicies.Definition(),
        new ManagedInstanceOperations.Definition(),
        new ManagedInstanceVulnerabilityAssessments.Definition(),
        new ManagedInstances.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new ServerAzureADAdministrators.Definition(),
        new ServerVulnerabilityAssessments.Definition(),
        new Usages.Definition(),
    };
}
