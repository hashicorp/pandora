using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.SourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VersionConstant
{
    [Description("V1")]
    VOne,

    [Description("V2")]
    VTwo,
}
