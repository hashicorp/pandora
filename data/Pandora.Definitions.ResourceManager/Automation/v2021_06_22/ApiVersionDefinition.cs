using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Automation.v2021_06_22;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-06-22";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AutomationAccount.Definition(),
        new HybridRunbookWorker.Definition(),
        new HybridRunbookWorkerGroup.Definition(),
        new ListKeys.Definition(),
        new Statistics.Definition(),
        new Usages.Definition(),
    };
}
