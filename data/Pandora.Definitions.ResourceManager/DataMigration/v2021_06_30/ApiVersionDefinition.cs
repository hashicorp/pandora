using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2021-06-30";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new CustomOperation.Definition(),
        new DELETE.Definition(),
        new FieResource.Definition(),
        new FileResource.Definition(),
        new GET.Definition(),
        new PATCH.Definition(),
        new POST.Definition(),
        new PUT.Definition(),
        new ProjectResource.Definition(),
        new ServiceResource.Definition(),
        new ServiceTaskResource.Definition(),
        new StandardOperation.Definition(),
        new TaskResource.Definition(),
    };
}
