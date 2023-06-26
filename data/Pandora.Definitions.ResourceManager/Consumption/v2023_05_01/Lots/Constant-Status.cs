using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Consumption.v2023_05_01.Lots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusConstant
{
    [Description("Active")]
    Active,

    [Description("Canceled")]
    Canceled,

    [Description("Complete")]
    Complete,

    [Description("Expired")]
    Expired,

    [Description("Inactive")]
    Inactive,

    [Description("None")]
    None,
}
