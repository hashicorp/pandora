using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AnalysisResolutionConstant
{
    [Description("SourceResolution")]
    SourceResolution,

    [Description("StandardDefinition")]
    StandardDefinition,
}
