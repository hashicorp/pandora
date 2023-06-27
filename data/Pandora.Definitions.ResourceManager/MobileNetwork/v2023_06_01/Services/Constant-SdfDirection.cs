using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.Services;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SdfDirectionConstant
{
    [Description("Bidirectional")]
    Bidirectional,

    [Description("Downlink")]
    Downlink,

    [Description("Uplink")]
    Uplink,
}
