using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.Metadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatorConstant
{
    [Description("AND")]
    AND,

    [Description("OR")]
    OR,
}
