using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.RedhatOpenShift.v2022_04_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-04-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new OpenShiftClusters.Definition(),
    };
}
