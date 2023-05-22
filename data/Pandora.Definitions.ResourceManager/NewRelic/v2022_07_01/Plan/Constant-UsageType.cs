using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NewRelic.v2022_07_01.Plan;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UsageTypeConstant
{
    [Description("COMMITTED")]
    COMMITTED,

    [Description("PAYG")]
    PAYG,
}
