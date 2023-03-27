using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Insights.v2021_07_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-07-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new PrivateLinkScopedResources.Definition(),
        new PrivateLinkScopesAPIs.Definition(),
    };
}
