using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Authorization.v2018_01_01_preview;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-01-01-preview";
    public bool Preview => true;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new Permissions.Definition(),
        new ProviderOperationsMetadata.Definition(),
        new RoleAssignments.Definition(),
        new RoleDefinitions.Definition(),
    };
}
