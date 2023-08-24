using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.VipSwap;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SlotTypeConstant
{
    [Description("Production")]
    Production,

    [Description("Staging")]
    Staging,
}
