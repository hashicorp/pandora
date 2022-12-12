using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.AttachedDataNetworks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NaptEnabledConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
