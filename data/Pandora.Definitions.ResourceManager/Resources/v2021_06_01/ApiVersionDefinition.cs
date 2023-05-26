using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.v2021_06_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-06-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new PolicyAssignments.Definition(),
        new PolicyDefinitions.Definition(),
        new PolicySetDefinitions.Definition(),
    };
}
