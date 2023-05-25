using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.DataMaskingRules;

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
