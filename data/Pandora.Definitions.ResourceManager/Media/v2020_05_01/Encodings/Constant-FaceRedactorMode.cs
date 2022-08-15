using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FaceRedactorModeConstant
{
    [Description("Analyze")]
    Analyze,

    [Description("Combined")]
    Combined,

    [Description("Redact")]
    Redact,
}
