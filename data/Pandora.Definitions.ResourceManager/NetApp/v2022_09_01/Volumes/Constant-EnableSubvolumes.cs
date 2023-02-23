using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnableSubvolumesConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
