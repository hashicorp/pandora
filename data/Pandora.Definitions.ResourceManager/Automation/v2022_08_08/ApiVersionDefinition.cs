using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Automation.v2022_08_08;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-08-08";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Activity.Definition(),
        new AutomationAccount.Definition(),
        new Certificate.Definition(),
        new Connection.Definition(),
        new ConnectionType.Definition(),
        new Credential.Definition(),
        new DscConfiguration.Definition(),
        new DscNodeConfiguration.Definition(),
        new HybridRunbookWorker.Definition(),
        new HybridRunbookWorkerGroup.Definition(),
        new Job.Definition(),
        new JobSchedule.Definition(),
        new JobStream.Definition(),
        new LinkedWorkspace.Definition(),
        new ListAllHybridRunbookWorkerGroupInAutomationAccount.Definition(),
        new ListKeys.Definition(),
        new Module.Definition(),
        new ObjectDataTypes.Definition(),
        new Python2Package.Definition(),
        new Python3Package.Definition(),
        new Runbook.Definition(),
        new RunbookDraft.Definition(),
        new Schedule.Definition(),
        new SoftwareUpdateConfigurationMachineRun.Definition(),
        new SoftwareUpdateConfigurationRun.Definition(),
        new SourceControl.Definition(),
        new SourceControlSyncJob.Definition(),
        new SourceControlSyncJobStreams.Definition(),
        new Statistics.Definition(),
        new TestJob.Definition(),
        new TestJobStream.Definition(),
        new TypeFields.Definition(),
        new Usages.Definition(),
        new Variable.Definition(),
    };
}
