using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.v2023_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new PolicyAssignments.Definition(),
        new PolicyDefinitionVersions.Definition(),
        new PolicyDefinitions.Definition(),
        new PolicySetDefinitionVersions.Definition(),
        new PolicySetDefinitions.Definition(),
    };
}
