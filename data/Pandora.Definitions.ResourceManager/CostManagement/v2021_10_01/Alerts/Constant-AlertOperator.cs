using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2021_10_01.Alerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertOperatorConstant
{
    [Description("EqualTo")]
    EqualTo,

    [Description("GreaterThan")]
    GreaterThan,

    [Description("GreaterThanOrEqualTo")]
    GreaterThanOrEqualTo,

    [Description("LessThan")]
    LessThan,

    [Description("LessThanOrEqualTo")]
    LessThanOrEqualTo,

    [Description("None")]
    None,
}
