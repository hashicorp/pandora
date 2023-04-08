using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.DeviceSecurityGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ValueTypeConstant
{
    [Description("IpCidr")]
    IPCidr,

    [Description("String")]
    String,
}
