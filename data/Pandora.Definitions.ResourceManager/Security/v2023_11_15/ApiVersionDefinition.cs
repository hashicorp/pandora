using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Security.v2023_11_15;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-11-15";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new APIMConfig.Definition(),
        new D4APICollection.Definition(),
        new D4APICollectionList.Definition(),
        new OffboardFromD4API.Definition(),
        new OnboardToD4API.Definition(),
    };
}
