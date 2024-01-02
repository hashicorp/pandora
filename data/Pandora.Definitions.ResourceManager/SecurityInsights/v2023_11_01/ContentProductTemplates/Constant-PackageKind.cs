using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.ContentProductTemplates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PackageKindConstant
{
    [Description("Solution")]
    Solution,

    [Description("Standalone")]
    Standalone,
}
