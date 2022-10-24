using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Tables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RetentionInDaysAsDefaultConstant
{
    [Description("False")]
    False,

    [Description("True")]
    True,
}
