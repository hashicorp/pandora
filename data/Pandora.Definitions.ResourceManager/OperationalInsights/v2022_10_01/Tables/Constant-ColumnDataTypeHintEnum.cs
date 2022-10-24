using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Tables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ColumnDataTypeHintEnumConstant
{
    [Description("armPath")]
    ArmPath,

    [Description("guid")]
    Guid,

    [Description("ip")]
    IP,

    [Description("uri")]
    Uri,
}
