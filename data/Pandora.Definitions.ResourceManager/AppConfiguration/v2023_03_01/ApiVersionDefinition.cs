using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.AppConfiguration.v2023_03_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-03-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ConfigurationStores.Definition(),
        new DeletedConfigurationStores.Definition(),
        new KeyValues.Definition(),
        new Operations.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Replicas.Definition(),
    };
}
