using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2023_07_01.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SmbAccessBasedEnumerationConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
