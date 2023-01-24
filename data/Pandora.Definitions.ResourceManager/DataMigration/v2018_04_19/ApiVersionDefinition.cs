using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2018-04-19";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CustomOperation.Definition(),
        new DELETE.Definition(),
        new GET.Definition(),
        new PATCH.Definition(),
        new POST.Definition(),
        new PUT.Definition(),
        new ProjectResource.Definition(),
        new ServiceResource.Definition(),
        new StandardOperation.Definition(),
        new TaskResource.Definition(),
    };
}
