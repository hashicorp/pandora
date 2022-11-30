using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VideoSyncModeConstant
{
    [Description("Auto")]
    Auto,

    [Description("Cfr")]
    Cfr,

    [Description("Passthrough")]
    Passthrough,

    [Description("Vfr")]
    Vfr,
}
