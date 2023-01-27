using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Agreements.Definition(),
        new ApiKey.Definition(),
        new Hosts.Definition(),
        new LinkedResources.Definition(),
        new MonitoredResources.Definition(),
        new MonitorsResource.Definition(),
        new RefreshSetPasswordLink.Definition(),
        new Rules.Definition(),
        new SingleSignOn.Definition(),
    };
}
