using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.Volumes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperationalStatusConstant
{
    [Description("Healthy")]
    Healthy,

    [Description("Invalid")]
    Invalid,

    [Description("Running")]
    Running,

    [Description("Stopped")]
    Stopped,

    [Description("Stopped (deallocated)")]
    StoppedDeallocated,

    [Description("Unhealthy")]
    Unhealthy,

    [Description("Unknown")]
    Unknown,

    [Description("Updating")]
    Updating,
}
