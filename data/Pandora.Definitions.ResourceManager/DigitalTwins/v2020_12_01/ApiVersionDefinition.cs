using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2020_12_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-12-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CheckNameAvailability.Definition(),
        new DigitalTwinsInstance.Definition(),
        new Endpoints.Definition(),
        new PrivateEndpoints.Definition(),
    };
}
