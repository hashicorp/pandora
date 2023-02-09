using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.Environments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IngressStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Paused")]
    Paused,

    [Description("Ready")]
    Ready,

    [Description("Running")]
    Running,

    [Description("Unknown")]
    Unknown,
}
