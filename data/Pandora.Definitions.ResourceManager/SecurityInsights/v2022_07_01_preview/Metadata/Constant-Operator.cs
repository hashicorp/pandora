using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.Metadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatorConstant
{
    [Description("AND")]
    AND,

    [Description("OR")]
    OR,
}
