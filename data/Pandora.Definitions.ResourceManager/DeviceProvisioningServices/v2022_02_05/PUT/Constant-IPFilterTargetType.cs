using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DeviceProvisioningServices.v2022_02_05.PUT;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IPFilterTargetTypeConstant
{
    [Description("all")]
    All,

    [Description("deviceApi")]
    DeviceApi,

    [Description("serviceApi")]
    ServiceApi,
}
