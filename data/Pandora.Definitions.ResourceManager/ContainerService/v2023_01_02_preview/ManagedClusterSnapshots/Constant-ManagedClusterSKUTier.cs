using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_02_preview.ManagedClusterSnapshots;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedClusterSKUTierConstant
{
    [Description("Free")]
    Free,

    [Description("Paid")]
    Paid,

    [Description("Standard")]
    Standard,
}
