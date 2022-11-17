using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_05_01.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SmbNonBrowsableConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
