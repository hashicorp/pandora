using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Dynatrace.v2021_09_01.Monitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SendingMetricsStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
