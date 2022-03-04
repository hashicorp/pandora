using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.HealthCareApis.v2021_06_01_preview;
public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-06-01-preview";
    public bool Preview => true;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Collection.Definition(),
        new DicomServices.Definition(),
        new FhirServices.Definition(),
        new IotConnectors.Definition(),
        new PrivateEndpointConnections.Definition(),
        new PrivateLinkResources.Definition(),
        new Proxy.Definition(),
        new Resource.Definition(),
        new Workspaces.Definition(),
    };
}
