using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-07-01";
    public bool Preview => false;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DeploymentInfo.Definition(),
        new MonitoredResources.Definition(),
        new MonitorsResource.Definition(),
        new Rules.Definition(),
        new VMCollectionUpdate.Definition(),
        new VMHHostList.Definition(),
        new VMIngestionDetails.Definition(),
    };
}
