using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SignalR.v2021_10_01.SignalR;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyTypeConstant
{
    [Description("Primary")]
    Primary,

    [Description("Salt")]
    Salt,

    [Description("Secondary")]
    Secondary,
}
