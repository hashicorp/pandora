using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-09-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Deployments.Definition(),
        new Providers.Definition(),
        new ResourceGroups.Definition(),
        new Resources.Definition(),
    };
}
