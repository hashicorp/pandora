using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-01-13-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Activity.Definition(),
        new AgentRegistrationInformation.Definition(),
        new AutomationAccount.Definition(),
        new Certificate.Definition(),
        new Connection.Definition(),
        new ConnectionType.Definition(),
        new Credential.Definition(),
        new DscCompilationJob.Definition(),
        new DscNode.Definition(),
        new DscNodeConfiguration.Definition(),
        new HybridRunbookWorkerGroup.Definition(),
        new JobSchedule.Definition(),
        new LinkedWorkspace.Definition(),
        new ListKeys.Definition(),
        new Module.Definition(),
        new NodeCountInformation.Definition(),
        new NodeReports.Definition(),
        new ObjectDataTypes.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Python2Package.Definition(),
        new Schedule.Definition(),
        new SourceControl.Definition(),
        new SourceControlSyncJob.Definition(),
        new SourceControlSyncJobStreams.Definition(),
        new Statistics.Definition(),
        new TypeFields.Definition(),
        new Usages.Definition(),
        new Variable.Definition(),
        new Watcher.Definition(),
    };
}
