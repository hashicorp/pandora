using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsDataMaskingRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataMaskingRuleStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
