using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AzureActiveDirectory.v2020_03_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkForAzureAd.Definition(),
        new PrivateLinkResources.Definition(),
    };
}
