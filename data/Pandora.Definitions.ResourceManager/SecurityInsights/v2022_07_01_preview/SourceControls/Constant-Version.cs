using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.SourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VersionConstant
{
    [Description("V1")]
    VOne,

    [Description("V2")]
    VTwo,
}
