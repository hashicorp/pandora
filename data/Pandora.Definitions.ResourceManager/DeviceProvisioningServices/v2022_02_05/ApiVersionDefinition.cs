using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-02-05";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DELETE.Definition(),
        new GET.Definition(),
        new PATCH.Definition(),
        new POST.Definition(),
        new PUT.Definition(),
    };
}
