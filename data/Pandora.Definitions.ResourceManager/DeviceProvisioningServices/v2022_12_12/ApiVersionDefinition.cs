using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_12_12;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2022-12-12";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new DpsCertificate.Definition(),
        new IotDpsResource.Definition(),
    };
}
