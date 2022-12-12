using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Resources.v2020_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new ManagementLocks.Definition(),
        new PrivateLinkAssociation.Definition(),
        new ResourceManagementPrivateLink.Definition(),
    };
}
