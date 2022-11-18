using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.MariaDB.v2020_01_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-01-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ServerStart.Definition(),
        new ServerStop.Definition(),
    };
}
