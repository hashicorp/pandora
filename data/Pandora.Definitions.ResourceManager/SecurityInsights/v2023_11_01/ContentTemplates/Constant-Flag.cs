using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.ContentTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FlagConstant
{
    [Description("false")]
    False,

    [Description("true")]
    True,
}
