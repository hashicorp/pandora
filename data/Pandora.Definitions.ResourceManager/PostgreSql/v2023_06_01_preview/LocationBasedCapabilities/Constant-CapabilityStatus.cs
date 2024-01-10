using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.LocationBasedCapabilities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CapabilityStatusConstant
{
    [Description("Available")]
    Available,

    [Description("Default")]
    Default,

    [Description("Disabled")]
    Disabled,

    [Description("Visible")]
    Visible,
}
