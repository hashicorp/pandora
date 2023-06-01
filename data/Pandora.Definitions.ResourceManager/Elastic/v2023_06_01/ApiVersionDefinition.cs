using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ApiKey.Definition(),
        new DeploymentInfo.Definition(),
        new DeploymentUpdate.Definition(),
        new ElasticVersions.Definition(),
        new MonitorUpgradableVersions.Definition(),
        new MonitoredResources.Definition(),
        new MonitorsResource.Definition(),
        new Rules.Definition(),
        new TrafficFilter.Definition(),
        new VMCollectionUpdate.Definition(),
        new VMHHostList.Definition(),
        new VMIngestionDetails.Definition(),
    };
}
