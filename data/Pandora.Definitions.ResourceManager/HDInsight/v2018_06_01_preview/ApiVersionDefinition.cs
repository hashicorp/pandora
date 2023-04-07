using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-06-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Applications.Definition(),
        new Clusters.Definition(),
        new Configurations.Definition(),
        new Extensions.Definition(),
        new Promote.Definition(),
        new Regions.Definition(),
        new ScriptActions.Definition(),
        new ScriptExecutionHistory.Definition(),
        new VirtualMachines.Definition(),
    };
}
