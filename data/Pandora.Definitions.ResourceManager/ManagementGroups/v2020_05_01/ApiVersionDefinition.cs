using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2020_05_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2020-05-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CheckNameAvailability.Definition(),
        new Entities.Definition(),
        new ManagementGroups.Definition(),
        new TenantBackfill.Definition(),
    };
}
