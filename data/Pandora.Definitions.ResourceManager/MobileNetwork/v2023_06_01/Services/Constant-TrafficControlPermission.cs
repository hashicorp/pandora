using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TrafficControlPermissionConstant
{
    [Description("Blocked")]
    Blocked,

    [Description("Enabled")]
    Enabled,
}
