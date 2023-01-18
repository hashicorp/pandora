using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2019-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new IntegrationAccountAgreements.Definition(),
        new IntegrationAccountAssemblies.Definition(),
        new IntegrationAccountBatchConfigurations.Definition(),
        new IntegrationAccountCertificates.Definition(),
        new IntegrationAccountMaps.Definition(),
        new IntegrationAccountPartners.Definition(),
        new IntegrationAccountSchemas.Definition(),
        new IntegrationAccountSessions.Definition(),
        new IntegrationAccounts.Definition(),
        new IntegrationServiceEnvironmentManagedApi.Definition(),
        new IntegrationServiceEnvironmentManagedApis.Definition(),
        new IntegrationServiceEnvironmentNetworkHealth.Definition(),
        new IntegrationServiceEnvironmentRestart.Definition(),
        new IntegrationServiceEnvironmentSkus.Definition(),
        new IntegrationServiceEnvironments.Definition(),
        new WorkflowRunActions.Definition(),
        new WorkflowRuns.Definition(),
        new WorkflowTriggerHistories.Definition(),
        new WorkflowTriggers.Definition(),
        new WorkflowVersions.Definition(),
        new Workflows.Definition(),
    };
}
