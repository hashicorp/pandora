using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2021_06_01.Cluster;

[ConstantType(ConstantTypeAttribute.ConstantType.Integer)]
internal enum CapacityConstant
{
    [Description("500")]
    FiveHundred,

    [Description("5000")]
    FiveThousand,

    [Description("1000")]
    OneThousand,

    [Description("2000")]
    TwoThousand,
}
