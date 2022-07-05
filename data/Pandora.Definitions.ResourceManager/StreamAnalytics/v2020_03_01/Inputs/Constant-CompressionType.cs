using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.Inputs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CompressionTypeConstant
{
    [Description("Deflate")]
    Deflate,

    [Description("GZip")]
    GZip,

    [Description("None")]
    None,
}
