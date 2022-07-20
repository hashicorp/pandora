using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2017_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2017-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Namespaces.Definition(),
        new NotificationHubs.Definition(),
    };
}
