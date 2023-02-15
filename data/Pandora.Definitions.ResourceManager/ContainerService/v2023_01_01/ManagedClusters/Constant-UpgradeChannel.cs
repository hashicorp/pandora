using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_01.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpgradeChannelConstant
{
    [Description("node-image")]
    NodeNegativeimage,

    [Description("none")]
    None,

    [Description("patch")]
    Patch,

    [Description("rapid")]
    Rapid,

    [Description("stable")]
    Stable,
}
