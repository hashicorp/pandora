using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2023_09_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WorkspaceSkuNameEnumConstant
{
    [Description("CapacityReservation")]
    CapacityReservation,

    [Description("Free")]
    Free,

    [Description("LACluster")]
    LACluster,

    [Description("PerGB2018")]
    PerGBTwoZeroOneEight,

    [Description("PerNode")]
    PerNode,

    [Description("Premium")]
    Premium,

    [Description("Standalone")]
    Standalone,

    [Description("Standard")]
    Standard,
}
