using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Automation.v2015_10_31;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2015-10-31";
    public bool Preview => false;
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
        new DscConfiguration.Definition(),
        new DscNode.Definition(),
        new DscNodeConfiguration.Definition(),
        new HybridRunbookWorkerGroup.Definition(),
        new Job.Definition(),
        new JobSchedule.Definition(),
        new JobStream.Definition(),
        new LinkedWorkspace.Definition(),
        new ListKeys.Definition(),
        new Module.Definition(),
        new NodeReports.Definition(),
        new ObjectDataTypes.Definition(),
        new Runbook.Definition(),
        new RunbookDraft.Definition(),
        new Schedule.Definition(),
        new Statistics.Definition(),
        new TestJob.Definition(),
        new TestJobStream.Definition(),
        new TypeFields.Definition(),
        new Usages.Definition(),
        new Variable.Definition(),
        new Watcher.Definition(),
        new Webhook.Definition(),
    };
}
