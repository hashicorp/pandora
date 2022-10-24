using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Tables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ColumnTypeEnumConstant
{
    [Description("boolean")]
    Boolean,

    [Description("dateTime")]
    DateTime,

    [Description("dynamic")]
    Dynamic,

    [Description("guid")]
    Guid,

    [Description("int")]
    Int,

    [Description("long")]
    Long,

    [Description("real")]
    Real,

    [Description("string")]
    String,
}
