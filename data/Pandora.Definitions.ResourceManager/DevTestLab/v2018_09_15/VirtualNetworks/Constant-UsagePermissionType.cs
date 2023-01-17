using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.VirtualNetworks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UsagePermissionTypeConstant
{
    [Description("Allow")]
    Allow,

    [Description("Default")]
    Default,

    [Description("Deny")]
    Deny,
}
