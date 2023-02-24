using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.FileImports;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FileImportContentTypeConstant
{
    [Description("BasicIndicator")]
    BasicIndicator,

    [Description("StixIndicator")]
    StixIndicator,

    [Description("Unspecified")]
    Unspecified,
}
