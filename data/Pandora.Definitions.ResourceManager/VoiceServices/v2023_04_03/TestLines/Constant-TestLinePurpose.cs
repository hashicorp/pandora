using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VoiceServices.v2023_04_03.TestLines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TestLinePurposeConstant
{
    [Description("Automated")]
    Automated,

    [Description("Manual")]
    Manual,
}
