using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DigitalTwins.v2023_01_31;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-01-31";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CheckNameAvailability.Definition(),
        new DigitalTwinsInstance.Definition(),
        new Endpoints.Definition(),
        new PrivateEndpoints.Definition(),
        new TimeSeriesDatabaseConnections.Definition(),
    };
}
