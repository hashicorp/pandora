using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EnableSubvolumesConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
