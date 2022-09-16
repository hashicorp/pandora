using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsDataMaskingRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DataMaskingFunctionConstant
{
    [Description("CCN")]
    CCN,

    [Description("Default")]
    Default,

    [Description("Email")]
    Email,

    [Description("Number")]
    Number,

    [Description("SSN")]
    SSN,

    [Description("Text")]
    Text,
}
