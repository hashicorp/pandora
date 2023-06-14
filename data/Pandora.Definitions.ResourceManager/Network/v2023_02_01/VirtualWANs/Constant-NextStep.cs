using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_02_01.VirtualWANs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NextStepConstant
{
    [Description("Continue")]
    Continue,

    [Description("Terminate")]
    Terminate,

    [Description("Unknown")]
    Unknown,
}
