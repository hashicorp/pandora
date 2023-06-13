using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ServerAutomaticTuning;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomaticTuningServerReasonConstant
{
    [Description("AutoConfigured")]
    AutoConfigured,

    [Description("Default")]
    Default,

    [Description("Disabled")]
    Disabled,
}
