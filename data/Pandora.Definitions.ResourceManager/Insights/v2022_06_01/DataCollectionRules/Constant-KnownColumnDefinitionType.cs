using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2022_06_01.DataCollectionRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KnownColumnDefinitionTypeConstant
{
    [Description("boolean")]
    Boolean,

    [Description("datetime")]
    Datetime,

    [Description("dynamic")]
    Dynamic,

    [Description("int")]
    Int,

    [Description("long")]
    Long,

    [Description("real")]
    Real,

    [Description("string")]
    String,
}
